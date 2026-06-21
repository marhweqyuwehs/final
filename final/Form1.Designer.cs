namespace final
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblIncome = new System.Windows.Forms.Label();
            this.lblExpense = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.rbIncome = new System.Windows.Forms.RadioButton();
            this.rbExpense = new System.Windows.Forms.RadioButton();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMonthSummary = new System.Windows.Forms.Label();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.cboMonthSelect = new System.Windows.Forms.ComboBox();
            this.chartCategory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.dtpFilterStart = new System.Windows.Forms.DateTimePicker();
            this.dtpFilterEnd = new System.Windows.Forms.DateTimePicker();
            this.chkUseDateFilter = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearchKeyword = new System.Windows.Forms.TextBox();
            this.cboFilterCategory = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(90, 18);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(150, 25);
            this.dtpDate.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDate.Location = new System.Drawing.Point(20, 20);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(61, 22);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "日期：";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[] {
            "餐飲",
            "交通",
            "娛樂",
            "購物",
            "醫療",
            "薪水",
            "獎金",
            "其他"});
            this.cboCategory.Location = new System.Drawing.Point(330, 18);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(121, 23);
            this.cboCategory.TabIndex = 2;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCategory.Location = new System.Drawing.Point(260, 20);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(61, 22);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "類別：";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMoney.Location = new System.Drawing.Point(20, 55);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(61, 22);
            this.lblMoney.TabIndex = 4;
            this.lblMoney.Text = "收支：";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAmount.Location = new System.Drawing.Point(20, 90);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(61, 22);
            this.lblAmount.TabIndex = 5;
            this.lblAmount.Text = "金額：";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblNote.Location = new System.Drawing.Point(260, 90);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(61, 22);
            this.lblNote.TabIndex = 6;
            this.lblNote.Text = "備註：";
            // 
            // lblIncome
            // 
            this.lblIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIncome.AutoSize = true;
            this.lblIncome.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblIncome.Location = new System.Drawing.Point(20, 607);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(93, 23);
            this.lblIncome.TabIndex = 7;
            this.lblIncome.Text = "總收入：0";
            // 
            // lblExpense
            // 
            this.lblExpense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExpense.AutoSize = true;
            this.lblExpense.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblExpense.Location = new System.Drawing.Point(260, 607);
            this.lblExpense.Name = "lblExpense";
            this.lblExpense.Size = new System.Drawing.Size(93, 23);
            this.lblExpense.TabIndex = 8;
            this.lblExpense.Text = "總支出：0";
            // 
            // lblBalance
            // 
            this.lblBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBalance.Location = new System.Drawing.Point(500, 607);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(111, 23);
            this.lblBalance.TabIndex = 9;
            this.lblBalance.Text = "目前餘額：0";
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(20, 235);
            this.dgvTransactions.MultiSelect = false;
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersWidth = 51;
            this.dgvTransactions.RowTemplate.Height = 27;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(476, 326);
            this.dgvTransactions.TabIndex = 10;
            this.dgvTransactions.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTransactions_ColumnHeaderMouseClick);
            this.dgvTransactions.SelectionChanged += new System.EventHandler(this.dgvTransactions_SelectionChanged);
            // 
            // rbIncome
            // 
            this.rbIncome.AutoSize = true;
            this.rbIncome.Location = new System.Drawing.Point(90, 53);
            this.rbIncome.Name = "rbIncome";
            this.rbIncome.Size = new System.Drawing.Size(58, 19);
            this.rbIncome.TabIndex = 11;
            this.rbIncome.Text = "收入";
            this.rbIncome.UseVisualStyleBackColor = true;
            // 
            // rbExpense
            // 
            this.rbExpense.AutoSize = true;
            this.rbExpense.Checked = true;
            this.rbExpense.Location = new System.Drawing.Point(180, 53);
            this.rbExpense.Name = "rbExpense";
            this.rbExpense.Size = new System.Drawing.Size(58, 19);
            this.rbExpense.TabIndex = 12;
            this.rbExpense.TabStop = true;
            this.rbExpense.Text = "支出";
            this.rbExpense.UseVisualStyleBackColor = true;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(90, 87);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(150, 25);
            this.txtAmount.TabIndex = 13;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(330, 87);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(200, 25);
            this.txtNote.TabIndex = 14;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 125);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(120, 125);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 30);
            this.btnEdit.TabIndex = 16;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(220, 125);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(320, 125);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "月份統計：";
            // 
            // lblMonthSummary
            // 
            this.lblMonthSummary.AutoSize = true;
            this.lblMonthSummary.Location = new System.Drawing.Point(520, 490);
            this.lblMonthSummary.Name = "lblMonthSummary";
            this.lblMonthSummary.Size = new System.Drawing.Size(0, 15);
            this.lblMonthSummary.TabIndex = 20;
            // 
            // btnExportReport
            // 
            this.btnExportReport.Location = new System.Drawing.Point(520, 515);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(150, 28);
            this.btnExportReport.TabIndex = 21;
            this.btnExportReport.Text = "匯出統計報表";
            this.btnExportReport.UseVisualStyleBackColor = true;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // cboMonthSelect
            // 
            this.cboMonthSelect.FormattingEnabled = true;
            this.cboMonthSelect.Location = new System.Drawing.Point(600, 232);
            this.cboMonthSelect.Name = "cboMonthSelect";
            this.cboMonthSelect.Size = new System.Drawing.Size(120, 23);
            this.cboMonthSelect.TabIndex = 22;
            this.cboMonthSelect.SelectedIndexChanged += new System.EventHandler(this.cboMonthSelect_SelectedIndexChanged);
            // 
            // chartCategory
            // 
            chartArea6.Name = "ChartArea1";
            this.chartCategory.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartCategory.Legends.Add(legend6);
            this.chartCategory.Location = new System.Drawing.Point(520, 265);
            this.chartCategory.Name = "chartCategory";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartCategory.Series.Add(series6);
            this.chartCategory.Size = new System.Drawing.Size(290, 220);
            this.chartCategory.TabIndex = 23;
            this.chartCategory.Text = "chart1";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(375, 196);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 25);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.Text = "查詢";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Location = new System.Drawing.Point(450, 196);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(80, 25);
            this.btnClearFilter.TabIndex = 25;
            this.btnClearFilter.Text = "清除篩選";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // dtpFilterStart
            // 
            this.dtpFilterStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterStart.Location = new System.Drawing.Point(189, 167);
            this.dtpFilterStart.Name = "dtpFilterStart";
            this.dtpFilterStart.Size = new System.Drawing.Size(110, 25);
            this.dtpFilterStart.TabIndex = 26;
            // 
            // dtpFilterEnd
            // 
            this.dtpFilterEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterEnd.Location = new System.Drawing.Point(350, 167);
            this.dtpFilterEnd.Name = "dtpFilterEnd";
            this.dtpFilterEnd.Size = new System.Drawing.Size(110, 25);
            this.dtpFilterEnd.TabIndex = 27;
            // 
            // chkUseDateFilter
            // 
            this.chkUseDateFilter.AutoSize = true;
            this.chkUseDateFilter.Location = new System.Drawing.Point(20, 170);
            this.chkUseDateFilter.Name = "chkUseDateFilter";
            this.chkUseDateFilter.Size = new System.Drawing.Size(119, 19);
            this.chkUseDateFilter.TabIndex = 28;
            this.chkUseDateFilter.Text = "啟用日期篩選";
            this.chkUseDateFilter.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "起始：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 30;
            this.label3.Text = "結束";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "類別：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 32;
            this.label5.Text = "關鍵字：";
            // 
            // txtSearchKeyword
            // 
            this.txtSearchKeyword.Location = new System.Drawing.Point(255, 197);
            this.txtSearchKeyword.Name = "txtSearchKeyword";
            this.txtSearchKeyword.Size = new System.Drawing.Size(100, 25);
            this.txtSearchKeyword.TabIndex = 34;
            // 
            // cboFilterCategory
            // 
            this.cboFilterCategory.FormattingEnabled = true;
            this.cboFilterCategory.Location = new System.Drawing.Point(70, 197);
            this.cboFilterCategory.Name = "cboFilterCategory";
            this.cboFilterCategory.Size = new System.Drawing.Size(120, 23);
            this.cboFilterCategory.TabIndex = 35;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 649);
            this.Controls.Add(this.cboFilterCategory);
            this.Controls.Add(this.txtSearchKeyword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkUseDateFilter);
            this.Controls.Add(this.dtpFilterEnd);
            this.Controls.Add(this.dtpFilterStart);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.chartCategory);
            this.Controls.Add(this.cboMonthSelect);
            this.Controls.Add(this.btnExportReport);
            this.Controls.Add(this.lblMonthSummary);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.rbExpense);
            this.Controls.Add(this.rbIncome);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblExpense);
            this.Controls.Add(this.lblIncome);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "個人記帳系統";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.Label lblExpense;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.RadioButton rbIncome;
        private System.Windows.Forms.RadioButton rbExpense;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMonthSummary;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.ComboBox cboMonthSelect;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCategory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.DateTimePicker dtpFilterStart;
        private System.Windows.Forms.DateTimePicker dtpFilterEnd;
        private System.Windows.Forms.CheckBox chkUseDateFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearchKeyword;
        private System.Windows.Forms.ComboBox cboFilterCategory;
    }
}

