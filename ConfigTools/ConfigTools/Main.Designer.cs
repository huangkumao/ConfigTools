namespace ConfigTools
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCfgPath = new System.Windows.Forms.Button();
            this.btnCodePath = new System.Windows.Forms.Button();
            this.btnExcelPath = new System.Windows.Forms.Button();
            this.mCfgOutPath = new System.Windows.Forms.TextBox();
            this.mCodeOutPath = new System.Windows.Forms.TextBox();
            this.mExcelPath = new System.Windows.Forms.TextBox();
            this.clbCfgFiles = new System.Windows.Forms.CheckedListBox();
            this.textLog = new System.Windows.Forms.TextBox();
            this.cbGenCode = new System.Windows.Forms.CheckBox();
            this.cbGenCfg = new System.Windows.Forms.CheckBox();
            this.rbCSCode = new System.Windows.Forms.RadioButton();
            this.rbTSCode = new System.Windows.Forms.RadioButton();
            this.btnGen = new System.Windows.Forms.Button();
            this.btnAllCheck = new System.Windows.Forms.Button();
            this.btnAllUncheck = new System.Windows.Forms.Button();
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.rbServer = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NeedCom = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.GreenYellow;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excel文件夹路径:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Turquoise;
            this.label2.Location = new System.Drawing.Point(28, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "输出代码路径:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label3.Location = new System.Drawing.Point(16, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "输出配置表路径:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnCfgPath);
            this.panel1.Controls.Add(this.btnCodePath);
            this.panel1.Controls.Add(this.btnExcelPath);
            this.panel1.Controls.Add(this.mCfgOutPath);
            this.panel1.Controls.Add(this.mCodeOutPath);
            this.panel1.Controls.Add(this.mExcelPath);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 86);
            this.panel1.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnRefresh.Location = new System.Drawing.Point(655, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(57, 54);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCfgPath
            // 
            this.btnCfgPath.Location = new System.Drawing.Point(598, 53);
            this.btnCfgPath.Name = "btnCfgPath";
            this.btnCfgPath.Size = new System.Drawing.Size(31, 23);
            this.btnCfgPath.TabIndex = 8;
            this.btnCfgPath.Text = "...";
            this.btnCfgPath.UseVisualStyleBackColor = true;
            this.btnCfgPath.Click += new System.EventHandler(this.btnCfgPath_Click);
            // 
            // btnCodePath
            // 
            this.btnCodePath.Location = new System.Drawing.Point(598, 29);
            this.btnCodePath.Name = "btnCodePath";
            this.btnCodePath.Size = new System.Drawing.Size(31, 23);
            this.btnCodePath.TabIndex = 7;
            this.btnCodePath.Text = "...";
            this.btnCodePath.UseVisualStyleBackColor = true;
            this.btnCodePath.Click += new System.EventHandler(this.btnCodePath_Click);
            // 
            // btnExcelPath
            // 
            this.btnExcelPath.Location = new System.Drawing.Point(598, 5);
            this.btnExcelPath.Name = "btnExcelPath";
            this.btnExcelPath.Size = new System.Drawing.Size(31, 23);
            this.btnExcelPath.TabIndex = 6;
            this.btnExcelPath.Text = "...";
            this.btnExcelPath.UseVisualStyleBackColor = true;
            this.btnExcelPath.Click += new System.EventHandler(this.btnExcelPath_Click);
            // 
            // mCfgOutPath
            // 
            this.mCfgOutPath.Location = new System.Drawing.Point(117, 54);
            this.mCfgOutPath.Name = "mCfgOutPath";
            this.mCfgOutPath.Size = new System.Drawing.Size(474, 21);
            this.mCfgOutPath.TabIndex = 5;
            // 
            // mCodeOutPath
            // 
            this.mCodeOutPath.Location = new System.Drawing.Point(117, 30);
            this.mCodeOutPath.Name = "mCodeOutPath";
            this.mCodeOutPath.Size = new System.Drawing.Size(474, 21);
            this.mCodeOutPath.TabIndex = 4;
            // 
            // mExcelPath
            // 
            this.mExcelPath.Location = new System.Drawing.Point(117, 6);
            this.mExcelPath.Name = "mExcelPath";
            this.mExcelPath.Size = new System.Drawing.Size(474, 21);
            this.mExcelPath.TabIndex = 3;
            // 
            // clbCfgFiles
            // 
            this.clbCfgFiles.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clbCfgFiles.ForeColor = System.Drawing.Color.Blue;
            this.clbCfgFiles.FormattingEnabled = true;
            this.clbCfgFiles.Location = new System.Drawing.Point(11, 176);
            this.clbCfgFiles.Name = "clbCfgFiles";
            this.clbCfgFiles.Size = new System.Drawing.Size(266, 346);
            this.clbCfgFiles.TabIndex = 4;
            // 
            // textLog
            // 
            this.textLog.Location = new System.Drawing.Point(283, 176);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.Size = new System.Drawing.Size(437, 346);
            this.textLog.TabIndex = 5;
            // 
            // cbGenCode
            // 
            this.cbGenCode.AutoSize = true;
            this.cbGenCode.Location = new System.Drawing.Point(29, 98);
            this.cbGenCode.Name = "cbGenCode";
            this.cbGenCode.Size = new System.Drawing.Size(72, 16);
            this.cbGenCode.TabIndex = 6;
            this.cbGenCode.Text = "生成代码";
            this.cbGenCode.UseVisualStyleBackColor = true;
            this.cbGenCode.CheckedChanged += new System.EventHandler(this.cbGenCode_CheckedChanged);
            // 
            // cbGenCfg
            // 
            this.cbGenCfg.AutoSize = true;
            this.cbGenCfg.Location = new System.Drawing.Point(29, 126);
            this.cbGenCfg.Name = "cbGenCfg";
            this.cbGenCfg.Size = new System.Drawing.Size(72, 16);
            this.cbGenCfg.TabIndex = 7;
            this.cbGenCfg.Text = "生成配置";
            this.cbGenCfg.UseVisualStyleBackColor = true;
            this.cbGenCfg.CheckedChanged += new System.EventHandler(this.cbGenCfg_CheckedChanged);
            // 
            // rbCSCode
            // 
            this.rbCSCode.AutoSize = true;
            this.rbCSCode.Enabled = false;
            this.rbCSCode.Location = new System.Drawing.Point(193, 98);
            this.rbCSCode.Name = "rbCSCode";
            this.rbCSCode.Size = new System.Drawing.Size(35, 16);
            this.rbCSCode.TabIndex = 8;
            this.rbCSCode.TabStop = true;
            this.rbCSCode.Text = "CS";
            this.rbCSCode.UseVisualStyleBackColor = true;
            this.rbCSCode.CheckedChanged += new System.EventHandler(this.rbCSCode_CheckedChanged);
            // 
            // rbTSCode
            // 
            this.rbTSCode.AutoSize = true;
            this.rbTSCode.Enabled = false;
            this.rbTSCode.Location = new System.Drawing.Point(127, 98);
            this.rbTSCode.Name = "rbTSCode";
            this.rbTSCode.Size = new System.Drawing.Size(35, 16);
            this.rbTSCode.TabIndex = 9;
            this.rbTSCode.TabStop = true;
            this.rbTSCode.Text = "TS";
            this.rbTSCode.UseVisualStyleBackColor = true;
            this.rbTSCode.CheckedChanged += new System.EventHandler(this.rbTSCode_CheckedChanged);
            // 
            // btnGen
            // 
            this.btnGen.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnGen.Location = new System.Drawing.Point(283, 99);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(428, 46);
            this.btnGen.TabIndex = 10;
            this.btnGen.Text = "生成数据";
            this.btnGen.UseVisualStyleBackColor = false;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // btnAllCheck
            // 
            this.btnAllCheck.Location = new System.Drawing.Point(35, 527);
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Size = new System.Drawing.Size(75, 34);
            this.btnAllCheck.TabIndex = 11;
            this.btnAllCheck.Text = "全部勾选";
            this.btnAllCheck.UseVisualStyleBackColor = true;
            this.btnAllCheck.Click += new System.EventHandler(this.btnAllCheck_Click);
            // 
            // btnAllUncheck
            // 
            this.btnAllUncheck.Location = new System.Drawing.Point(168, 527);
            this.btnAllUncheck.Name = "btnAllUncheck";
            this.btnAllUncheck.Size = new System.Drawing.Size(75, 34);
            this.btnAllUncheck.TabIndex = 12;
            this.btnAllUncheck.Text = "全部取消";
            this.btnAllUncheck.UseVisualStyleBackColor = true;
            this.btnAllUncheck.Click += new System.EventHandler(this.btnAllUncheck_Click);
            // 
            // rbClient
            // 
            this.rbClient.AutoSize = true;
            this.rbClient.Enabled = false;
            this.rbClient.Location = new System.Drawing.Point(1, 3);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(59, 16);
            this.rbClient.TabIndex = 13;
            this.rbClient.TabStop = true;
            this.rbClient.Text = "Client";
            this.rbClient.UseVisualStyleBackColor = true;
            this.rbClient.CheckedChanged += new System.EventHandler(this.rbClient_CheckedChanged);
            // 
            // rbServer
            // 
            this.rbServer.AutoSize = true;
            this.rbServer.Enabled = false;
            this.rbServer.Location = new System.Drawing.Point(67, 3);
            this.rbServer.Name = "rbServer";
            this.rbServer.Size = new System.Drawing.Size(59, 16);
            this.rbServer.TabIndex = 14;
            this.rbServer.TabStop = true;
            this.rbServer.Text = "Server";
            this.rbServer.UseVisualStyleBackColor = true;
            this.rbServer.CheckedChanged += new System.EventHandler(this.rbServer_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbServer);
            this.panel2.Controls.Add(this.rbClient);
            this.panel2.Location = new System.Drawing.Point(126, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(128, 20);
            this.panel2.TabIndex = 15;
            // 
            // NeedCom
            // 
            this.NeedCom.AutoSize = true;
            this.NeedCom.Location = new System.Drawing.Point(127, 153);
            this.NeedCom.Name = "NeedCom";
            this.NeedCom.Size = new System.Drawing.Size(192, 16);
            this.NeedCom.TabIndex = 16;
            this.NeedCom.Text = "压缩生成配置(发布时需要勾选)";
            this.NeedCom.UseVisualStyleBackColor = true;
            this.NeedCom.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(732, 566);
            this.Controls.Add(this.NeedCom);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAllUncheck);
            this.Controls.Add(this.btnAllCheck);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.rbTSCode);
            this.Controls.Add(this.rbCSCode);
            this.Controls.Add(this.cbGenCfg);
            this.Controls.Add(this.cbGenCode);
            this.Controls.Add(this.textLog);
            this.Controls.Add(this.clbCfgFiles);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "ExcelTools";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox mExcelPath;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCfgPath;
        private System.Windows.Forms.Button btnCodePath;
        private System.Windows.Forms.Button btnExcelPath;
        private System.Windows.Forms.TextBox mCfgOutPath;
        private System.Windows.Forms.TextBox mCodeOutPath;
        private System.Windows.Forms.CheckedListBox clbCfgFiles;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.CheckBox cbGenCode;
        private System.Windows.Forms.CheckBox cbGenCfg;
        private System.Windows.Forms.RadioButton rbCSCode;
        private System.Windows.Forms.RadioButton rbTSCode;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Button btnAllCheck;
        private System.Windows.Forms.Button btnAllUncheck;
        private System.Windows.Forms.RadioButton rbClient;
        private System.Windows.Forms.RadioButton rbServer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox NeedCom;
    }
}