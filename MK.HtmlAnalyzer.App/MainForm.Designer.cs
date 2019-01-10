namespace MK.HtmlAnalyzer.App
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statsListControl1 = new MK.HtmlAnalyzer.App.Stats.StatsListControl();
            this.SuspendLayout();
            // 
            // statsListControl1
            // 
            this.statsListControl1.Location = new System.Drawing.Point(0, 0);
            this.statsListControl1.Name = "statsListControl1";
            this.statsListControl1.Size = new System.Drawing.Size(388, 238);
            this.statsListControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 239);
            this.Controls.Add(this.statsListControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(404, 278);
            this.MinimumSize = new System.Drawing.Size(404, 278);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HtmlAnalyzer";
            this.ResumeLayout(false);

        }

        #endregion

        private Stats.StatsListControl statsListControl1;
    }
}

