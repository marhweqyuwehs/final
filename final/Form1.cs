using final;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace final
{
    public partial class Form1 : Form
    {
        private FileHelper db;
        private int? selectedId = null; // 目前選中要修改/刪除的記錄 Id，沒選就是 null
        private List<Transaction> currentView; // 目前畫面上顯示的資料（套用篩選後的結果）

        public Form1()
        {
            InitializeComponent();
            db = new FileHelper();
        }

        // ============ 表單載入 ============

        private void Form1_Load(object sender, EventArgs e)
        {
            cboCategory.SelectedIndex = 0;
            cboFilterCategory.Items.Clear();
            cboFilterCategory.Items.Add("全部");
            cboFilterCategory.Items.AddRange(new string[] { "餐飲", "交通", "娛樂", "購物", "醫療", "薪水", "獎金", "其他" });
            cboFilterCategory.SelectedIndex = 0;

            SetupChart();
            RefreshMonthList();
            RefreshData();
            UpdateButtonStates();
        }

        // ============ 新增 / 修改 / 刪除 ============

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out double amount)) return;

            string date = dtpDate.Value.ToString("yyyy/MM/dd");
            string category = cboCategory.SelectedItem.ToString();
            string type = rbIncome.Checked ? "Income" : "Expense";
            string note = txtNote.Text.Trim();

            db.Add(date, category, type, amount, note);

            MessageBox.Show("新增成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearInputs();
            RefreshMonthList();
            RefreshData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedId == null)
            {
                MessageBox.Show("請先在下方列表點選要修改的記錄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs(out double amount)) return;

            string date = dtpDate.Value.ToString("yyyy/MM/dd");
            string category = cboCategory.SelectedItem.ToString();
            string type = rbIncome.Checked ? "Income" : "Expense";
            string note = txtNote.Text.Trim();

            db.Update(selectedId.Value, date, category, type, amount, note);

            MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            selectedId = null;
            ClearInputs();
            RefreshMonthList();
            RefreshData();
            UpdateButtonStates();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == null)
            {
                MessageBox.Show("請先在下方列表點選要刪除的記錄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("確定要刪除這筆記錄嗎？", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                db.Delete(selectedId.Value);
                selectedId = null;
                ClearInputs();
                RefreshMonthList();
                RefreshData();
                UpdateButtonStates();
            }
        }

        // 儲存：把目前的資料檔備份到使用者指定位置
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV 檔案 (*.csv)|*.csv";
                sfd.FileName = $"記帳記錄備份_{DateTime.Now:yyyyMMdd}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.Copy(db.GetFilePath(), sfd.FileName, true);
                    MessageBox.Show("儲存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // ============ 篩選 / 搜尋 ============

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime? start = chkUseDateFilter.Checked ? dtpFilterStart.Value : (DateTime?)null;
            DateTime? end = chkUseDateFilter.Checked ? dtpFilterEnd.Value : (DateTime?)null;
            string category = cboFilterCategory.SelectedItem?.ToString() ?? "全部";
            string keyword = txtSearchKeyword.Text.Trim();

            currentView = db.Filter(start, end, category, keyword);
            BindGrid(currentView);
            UpdateSummary(currentView);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cboFilterCategory.SelectedIndex = 0;
            txtSearchKeyword.Text = "";
            chkUseDateFilter.Checked = false;
            RefreshData();
        }

        // ============ 排序（點欄位標頭排序） ============

        private void dgvTransactions_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (currentView == null) return;

            string columnName = dgvTransactions.Columns[e.ColumnIndex].Name;

            switch (columnName)
            {
                case "Date":
                    currentView = currentView.OrderBy(t => t.Date).ToList();
                    break;
                case "Amount":
                    currentView = currentView.OrderBy(t => t.SignedAmount).ToList();
                    break;
                case "Category":
                    currentView = currentView.OrderBy(t => t.Category).ToList();
                    break;
                default:
                    return;
            }

            BindGrid(currentView);
        }

        // ============ 列表選取 ============

        private void dgvTransactions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 0)
            {
                selectedId = null;
                UpdateButtonStates();
                return;
            }

            var row = dgvTransactions.SelectedRows[0];
            selectedId = Convert.ToInt32(row.Cells["Id"].Value);

            dtpDate.Value = DateTime.Parse(row.Cells["Date"].Value.ToString());
            cboCategory.Text = row.Cells["Category"].Value.ToString();

            string type = row.Cells["Type"].Value.ToString();
            rbIncome.Checked = (type == "收入");
            rbExpense.Checked = (type == "支出");

            double amt = Convert.ToDouble(row.Cells["Amount"].Value);
            txtAmount.Text = Math.Abs(amt).ToString();
            txtNote.Text = row.Cells["Note"].Value?.ToString() ?? "";

            UpdateButtonStates();
        }

        // ============ 月份統計 / 圓餅圖 ============

        private void cboMonthSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonthSelect.SelectedItem == null) return;
            UpdateChartForMonth(cboMonthSelect.SelectedItem.ToString());
        }

        private void RefreshMonthList()
        {
            string previous = cboMonthSelect.SelectedItem?.ToString();
            cboMonthSelect.Items.Clear();

            var months = db.GetAvailableMonths();
            if (months.Count == 0)
            {
                cboMonthSelect.Items.Add(DateTime.Now.ToString("yyyy/MM"));
            }
            else
            {
                cboMonthSelect.Items.AddRange(months.ToArray());
            }

            if (previous != null && cboMonthSelect.Items.Contains(previous))
                cboMonthSelect.SelectedItem = previous;
            else
                cboMonthSelect.SelectedIndex = 0;
        }

        private void SetupChart()
        {
            chartCategory.Series.Clear();
            chartCategory.ChartAreas.Clear();
            chartCategory.ChartAreas.Add(new ChartArea("MainArea"));
            chartCategory.Legends.Clear();
            chartCategory.Legends.Add(new Legend("MainLegend") { Docking = Docking.Bottom, Font = new System.Drawing.Font("Microsoft JhengHei", 8) });

            Series series = new Series("支出分類")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Font = new System.Drawing.Font("Microsoft JhengHei", 8)
            };
            series["PieLabelStyle"] = "Outside";
            chartCategory.Series.Add(series);
        }

        private void UpdateChartForMonth(string yearMonth)
        {
            var data = db.GetExpenseByCategoryForMonth(yearMonth);

            Series series = chartCategory.Series["支出分類"];
            series.Points.Clear();

            if (data.Count == 0)
            {
                series.Points.AddXY("無支出記錄", 1);
            }
            else
            {
                foreach (var item in data)
                {
                    int idx = series.Points.AddXY(item.Category, item.Amount);
                    series.Points[idx].Label = $"{item.Category} {item.Amount:N0}";
                }
            }

            var summary = db.GetMonthSummary(yearMonth);
            lblMonthSummary.Text = $"{yearMonth} 收入 {summary.Income:N0} / 支出 {summary.Expense:N0} / 結餘 {summary.Balance:N0}";
        }

        // ============ 資料驗證 ============

        private bool ValidateInputs(out double amount)
        {
            amount = 0;

            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("金額不能空白！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!double.TryParse(txtAmount.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("請輸入有效的金額（必須是大於 0 的數字）！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (amount > 100000000)
            {
                MessageBox.Show("金額過大，請確認輸入是否正確！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboCategory.SelectedItem == null)
            {
                MessageBox.Show("請選擇分類！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpDate.Value.Date > DateTime.Now.Date)
            {
                var confirm = MessageBox.Show("日期是未來日期，確定要這樣記錄嗎？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No) return false;
            }

            return true;
        }

        // ============ 畫面刷新 ============

        private void RefreshData()
        {
            currentView = db.LoadAll();
            BindGrid(currentView);
            UpdateSummary(currentView);
        }

        private void BindGrid(List<Transaction> list)
        {
            dgvTransactions.DataSource = db.ToDataTable(list);

            if (dgvTransactions.Columns.Contains("Id"))
                dgvTransactions.Columns["Id"].Visible = false;

            if (dgvTransactions.Columns.Contains("Date"))
                dgvTransactions.Columns["Date"].HeaderText = "日期";

            if (dgvTransactions.Columns.Contains("Category"))
                dgvTransactions.Columns["Category"].HeaderText = "類別";

            if (dgvTransactions.Columns.Contains("Type"))
                dgvTransactions.Columns["Type"].HeaderText = "收支";

            if (dgvTransactions.Columns.Contains("Amount"))
                dgvTransactions.Columns["Amount"].HeaderText = "金額";

            if (dgvTransactions.Columns.Contains("Note"))
                dgvTransactions.Columns["Note"].HeaderText = "備註";

            ApplyRowColors();
        }

        // 收入顯示綠色文字，支出顯示紅色文字
        private void ApplyRowColors()
        {
            foreach (DataGridViewRow row in dgvTransactions.Rows)
            {
                if (row.Cells["Amount"].Value == null) continue;
                double amt = Convert.ToDouble(row.Cells["Amount"].Value);

                if (amt < 0)
                    row.Cells["Amount"].Style.ForeColor = System.Drawing.Color.FromArgb(193, 18, 31);
                else
                    row.Cells["Amount"].Style.ForeColor = System.Drawing.Color.FromArgb(20, 130, 70);
            }
        }

        private void UpdateSummary(List<Transaction> list)
        {
            double income = db.GetTotalIncome(list);
            double expense = db.GetTotalExpense(list);
            double balance = income - expense;

            lblIncome.Text = $"總收入：{income:N0}";
            lblExpense.Text = $"總支出：{expense:N0}";
            lblBalance.Text = $"目前餘額：{balance:N0}";

            lblIncome.ForeColor = System.Drawing.Color.FromArgb(20, 130, 70);
            lblExpense.ForeColor = System.Drawing.Color.FromArgb(193, 18, 31);
            lblBalance.ForeColor = balance >= 0
                ? System.Drawing.Color.FromArgb(20, 130, 70)
                : System.Drawing.Color.FromArgb(193, 18, 31);
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = selectedId != null;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
        }

        private void ClearInputs()
        {
            txtAmount.Text = "";
            txtNote.Text = "";
            dtpDate.Value = DateTime.Now;
            cboCategory.SelectedIndex = 0;
            rbExpense.Checked = true;
            dgvTransactions.ClearSelection();
            selectedId = null;
        }

        // ============ 匯出統計報表 ============

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV 檔案 (*.csv)|*.csv";
                sfd.FileName = $"記帳統計報表_{DateTime.Now:yyyyMMdd}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    db.ExportSummaryReport(sfd.FileName);
                    MessageBox.Show("報表匯出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}