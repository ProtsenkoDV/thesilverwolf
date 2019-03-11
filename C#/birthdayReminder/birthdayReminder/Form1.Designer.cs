namespace birthdayReminder
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.birthdays = new System.Windows.Forms.TreeView();
            this.cut = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.autorun = new System.Windows.Forms.CheckBox();
            this.timeToSync = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cut)).BeginInit();
            this.SuspendLayout();
            // 
            // birthdays
            // 
            this.birthdays.LineColor = System.Drawing.Color.BlanchedAlmond;
            this.birthdays.Location = new System.Drawing.Point(3, 2);
            this.birthdays.Name = "birthdays";
            this.birthdays.Scrollable = false;
            this.birthdays.Size = new System.Drawing.Size(522, 512);
            this.birthdays.TabIndex = 0;
            // 
            // cut
            // 
            this.cut.Cursor = System.Windows.Forms.Cursors.Default;
            this.cut.Location = new System.Drawing.Point(531, 18);
            this.cut.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.cut.Name = "cut";
            this.cut.Size = new System.Drawing.Size(142, 20);
            this.cut.TabIndex = 2;
            this.cut.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.cut.ValueChanged += new System.EventHandler(this.cut_ValueChanged);
            this.cut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cut_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(528, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Количество дней к выводу";
            // 
            // tray
            // 
            this.tray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tray.BalloonTipTitle = "События на сегодня";
            this.tray.Icon = ((System.Drawing.Icon)(resources.GetObject("tray.Icon")));
            this.tray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tray_MouseClick);
            this.tray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tray_MouseDoubleClick);
            // 
            // autorun
            // 
            this.autorun.AutoSize = true;
            this.autorun.Location = new System.Drawing.Point(531, 44);
            this.autorun.Name = "autorun";
            this.autorun.Size = new System.Drawing.Size(147, 17);
            this.autorun.TabIndex = 4;
            this.autorun.Text = "Автозапуск программы";
            this.autorun.UseVisualStyleBackColor = true;
            this.autorun.CheckedChanged += new System.EventHandler(this.autorun_CheckedChanged);
            // 
            // timeToSync
            // 
            this.timeToSync.Enabled = true;
            this.timeToSync.Interval = 43200000;
            this.timeToSync.Tick += new System.EventHandler(this.timeToSync_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 515);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(522, 16);
            this.progressBar1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 533);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 26);
            this.button1.TabIndex = 7;
            this.button1.Text = "Настройки >>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.autorun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cut);
            this.Controls.Add(this.birthdays);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Дни рождения";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.cut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView birthdays;
        private System.Windows.Forms.NumericUpDown cut;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NotifyIcon tray;
        private System.Windows.Forms.CheckBox autorun;
        private System.Windows.Forms.Timer timeToSync;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
    }
}