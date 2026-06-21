using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace final
{
    public class FileHelper
    {
        private string filePath;

        public FileHelper()
        {
            // 資料檔存在執行檔同一個資料夾，檔名固定為 finance.csv
            filePath = Path.Combine(Application.StartupPath, "finance.csv");

            // 第一次執行時，檔案不存在就自動建立一個只有標題列的空檔案
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "Id,Date,Category,Type,Amount,Note" + Environment.NewLine, Encoding.UTF8);
            }
        }

        // ============ 基本讀寫 ============

        // 讀取全部記錄（依日期新到舊排序）
        public List<Transaction> LoadAll()
        {
            List<Transaction> list = new List<Transaction>();
            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

            for (int i = 1; i < lines.Length; i++) // 第一行是標題，跳過
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;

                string[] parts = lines[i].Split(',');
                if (parts.Length < 6) continue;

                Transaction t = new Transaction
                {
                    Id = int.Parse(parts[0]),
                    Date = parts[1],
                    Category = parts[2],
                    Type = parts[3],
                    Amount = double.Parse(parts[4]),
                    Note = parts[5]
                };
                list.Add(t);
            }

            list.Sort((a, b) => b.Date.CompareTo(a.Date));
            return list;
        }

        // 新增一筆記錄
        public void Add(string date, string category, string type, double amount, string note)
        {
            List<Transaction> all = LoadAll();
            int newId = all.Count == 0 ? 1 : all.Max(t => t.Id) + 1;

            all.Add(new Transaction
            {
                Id = newId,
                Date = date,
                Category = category,
                Type = type,
                Amount = amount,
                Note = note ?? ""
            });

            SaveAll(all);
        }

        // 修改一筆記錄
        public void Update(int id, string date, string category, string type, double amount, string note)
        {
            List<Transaction> all = LoadAll();
            Transaction target = all.Find(t => t.Id == id);

            if (target != null)
            {
                target.Date = date;
                target.Category = category;
                target.Type = type;
                target.Amount = amount;
                target.Note = note ?? "";
                SaveAll(all);
            }
        }

        // 刪除一筆記錄
        public void Delete(int id)
        {
            List<Transaction> all = LoadAll();
            all.RemoveAll(t => t.Id == id);
            SaveAll(all);
        }

        // 清空全部資料（保留標題列）
        public void ClearAll()
        {
            File.WriteAllText(filePath, "Id,Date,Category,Type,Amount,Note" + Environment.NewLine, Encoding.UTF8);
        }

        // 把全部記錄寫回檔案（覆寫整個檔案）
        private void SaveAll(List<Transaction> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Id,Date,Category,Type,Amount,Note");

            foreach (var t in list)
            {
                string safeNote = (t.Note ?? "").Replace(",", "，"); // 避免逗號破壞 CSV 格式
                sb.AppendLine($"{t.Id},{t.Date},{t.Category},{t.Type},{t.Amount},{safeNote}");
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        // ============ 篩選與搜尋 ============

        // 依日期區間、類別、關鍵字篩選（任何條件留空/設為"全部"則不篩選該項）
        public List<Transaction> Filter(DateTime? startDate, DateTime? endDate, string category, string keyword)
        {
            var query = LoadAll().AsEnumerable();

            if (startDate.HasValue)
            {
                query = query.Where(t => DateTime.Parse(t.Date) >= startDate.Value.Date);
            }

            if (endDate.HasValue)
            {
                query = query.Where(t => DateTime.Parse(t.Date) <= endDate.Value.Date);
            }

            if (!string.IsNullOrWhiteSpace(category) && category != "全部")
            {
                query = query.Where(t => t.Category == category);
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(t => t.Note != null && t.Note.Contains(keyword));
            }

            return query.ToList();
        }

        // ============ 轉成 DataTable 給 DataGridView 顯示 ============

        // 把任意一份 Transaction 清單轉成可顯示用的 DataTable（中文化 + 帶正負號金額）
        public DataTable ToDataTable(List<Transaction> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Amount", typeof(double));
            dt.Columns.Add("Note", typeof(string));

            foreach (var t in list)
            {
                dt.Rows.Add(t.Id, t.Date, t.Category, t.TypeDisplay, t.SignedAmount, t.Note);
            }

            return dt;
        }

        public DataTable LoadAllAsDataTable()
        {
            return ToDataTable(LoadAll());
        }

        // ============ 統計 ============

        public double GetTotalIncome()
        {
            return LoadAll().Where(t => t.Type == "Income").Sum(t => t.Amount);
        }

        public double GetTotalExpense()
        {
            return LoadAll().Where(t => t.Type == "Expense").Sum(t => t.Amount);
        }

        public double GetTotalIncome(List<Transaction> source)
        {
            return source.Where(t => t.Type == "Income").Sum(t => t.Amount);
        }

        public double GetTotalExpense(List<Transaction> source)
        {
            return source.Where(t => t.Type == "Expense").Sum(t => t.Amount);
        }

        // 取得有資料的所有月份清單（給「月份統計」下拉選單用），格式 yyyy/MM，新到舊排序
        public List<string> GetAvailableMonths()
        {
            return LoadAll()
                .Select(t => DateTime.Parse(t.Date).ToString("yyyy/MM"))
                .Distinct()
                .OrderByDescending(m => m)
                .ToList();
        }

        // 取得指定月份(yyyy/MM)裡，各支出類別的加總，回傳 (類別, 金額) 清單，由大到小排序
        public List<(string Category, double Amount)> GetExpenseByCategoryForMonth(string yearMonth)
        {
            return LoadAll()
                .Where(t => t.Type == "Expense" && t.Date.StartsWith(yearMonth.Replace("/", "/")))
                .Where(t => DateTime.Parse(t.Date).ToString("yyyy/MM") == yearMonth)
                .GroupBy(t => t.Category)
                .Select(g => (Category: g.Key, Amount: g.Sum(t => t.Amount)))
                .OrderByDescending(x => x.Amount)
                .ToList();
        }

        // 取得指定月份的收入、支出、餘額
        public (double Income, double Expense, double Balance) GetMonthSummary(string yearMonth)
        {
            var monthData = LoadAll().Where(t => DateTime.Parse(t.Date).ToString("yyyy/MM") == yearMonth).ToList();
            double income = monthData.Where(t => t.Type == "Income").Sum(t => t.Amount);
            double expense = monthData.Where(t => t.Type == "Expense").Sum(t => t.Amount);
            return (income, expense, income - expense);
        }

        // ============ 匯出報表 ============

        // 匯出含月份小計的統計報表 CSV
        public void ExportSummaryReport(string filePath)
        {
            var all = LoadAll();
            var months = all.Select(t => DateTime.Parse(t.Date).ToString("yyyy/MM")).Distinct().OrderBy(m => m).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("月份,總收入,總支出,結餘");

            foreach (var month in months)
            {
                var summary = GetMonthSummary(month);
                sb.AppendLine($"{month},{summary.Income},{summary.Expense},{summary.Balance}");
            }

            sb.AppendLine();
            sb.AppendLine("===== 明細 =====");
            sb.AppendLine("日期,類別,收支,金額,備註");
            foreach (var t in all.OrderBy(t => t.Date))
            {
                string safeNote = (t.Note ?? "").Replace(",", "，");
                sb.AppendLine($"{t.Date},{t.Category},{t.TypeDisplay},{t.Amount},{safeNote}");
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        // 取得目前的資料庫檔案完整路徑（給「儲存/備份」按鈕用）
        public string GetFilePath()
        {
            return filePath;
        }
    }
}