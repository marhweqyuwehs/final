using System;

namespace final
{
    // 一筆記帳記錄的資料結構
    public class Transaction
    {
        public int Id { get; set; }
        public string Date { get; set; }       // 格式: yyyy/MM/dd
        public string Category { get; set; }   // 餐飲、交通、薪水...
        public string Type { get; set; }        // "Income" 或 "Expense"（內部判斷用英文，畫面顯示時轉中文）
        public double Amount { get; set; }      // 一律存正數，正負由 Type 決定
        public string Note { get; set; }

        // 取得收支的中文顯示文字
        public string TypeDisplay => Type == "Income" ? "收入" : "支出";

        // 取得帶正負號的金額（支出顯示負數，方便畫面一眼看出收支方向）
        public double SignedAmount => Type == "Income" ? Amount : -Amount;
    }
}