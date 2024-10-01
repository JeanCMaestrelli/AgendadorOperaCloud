namespace AgendadorOperaCloud.Views
{
    partial class Logger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logger));
            richTextBox1 = new RichTextBox();
            btn_ExportarLog = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(800, 600);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // btn_ExportarLog
            // 
            btn_ExportarLog.Location = new Point(678, 626);
            btn_ExportarLog.Name = "btn_ExportarLog";
            btn_ExportarLog.Size = new Size(133, 34);
            btn_ExportarLog.TabIndex = 1;
            btn_ExportarLog.Text = "Exportar";
            btn_ExportarLog.UseVisualStyleBackColor = true;
            btn_ExportarLog.Click += btn_ExportarLog_Click;
            // 
            // Logger
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 672);
            Controls.Add(btn_ExportarLog);
            Controls.Add(richTextBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Logger";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Logger";
            Load += Logger_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button btn_ExportarLog;
    }
}