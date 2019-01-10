namespace MK.HtmlAnalyzer.App.Stats
{
    partial class StatsListControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvStats = new System.Windows.Forms.DataGridView();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.keywordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.occurencesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStats
            // 
            this.dgvStats.AutoGenerateColumns = false;
            this.dgvStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keywordDataGridViewTextBoxColumn,
            this.occurencesDataGridViewTextBoxColumn});
            this.dgvStats.DataSource = this.statsBindingSource;
            this.dgvStats.Location = new System.Drawing.Point(10, 29);
            this.dgvStats.Name = "dgvStats";
            this.dgvStats.ReadOnly = true;
            this.dgvStats.RowHeadersVisible = false;
            this.dgvStats.Size = new System.Drawing.Size(369, 187);
            this.dgvStats.TabIndex = 0;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(45, 3);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(273, 20);
            this.txtUrl.TabIndex = 1;
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(324, 3);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(55, 23);
            this.btnAnalyze.TabIndex = 2;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL:";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(7, 219);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(24, 13);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "info";
            // 
            // keywordDataGridViewTextBoxColumn
            // 
            this.keywordDataGridViewTextBoxColumn.DataPropertyName = "Keyword";
            this.keywordDataGridViewTextBoxColumn.HeaderText = "Keyword";
            this.keywordDataGridViewTextBoxColumn.Name = "keywordDataGridViewTextBoxColumn";
            this.keywordDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // occurencesDataGridViewTextBoxColumn
            // 
            this.occurencesDataGridViewTextBoxColumn.DataPropertyName = "Occurences";
            this.occurencesDataGridViewTextBoxColumn.HeaderText = "Occurences";
            this.occurencesDataGridViewTextBoxColumn.Name = "occurencesDataGridViewTextBoxColumn";
            this.occurencesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statsBindingSource
            // 
            this.statsBindingSource.DataSource = typeof(MK.HtmlAnalyzer.Model.KeywordStat);
            // 
            // StatsListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.dgvStats);
            this.Name = "StatsListControl";
            this.Size = new System.Drawing.Size(388, 253);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStats;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.BindingSource statsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn keywordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn occurencesDataGridViewTextBoxColumn;
    }
}
