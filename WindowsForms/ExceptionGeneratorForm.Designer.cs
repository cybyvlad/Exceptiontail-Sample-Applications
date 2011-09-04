namespace BuggyApp
{
    partial class ExceptionGeneratorForm
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
            if(disposing && (components != null))
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
            this.btnSendGazzillion = new System.Windows.Forms.Button();
            this.bwSendGazillion = new System.ComponentModel.BackgroundWorker();
            this.lblg = new System.Windows.Forms.Label();
            this.nupMaxPerSecond = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowLocalExceptions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nupMaxPerSecond)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSendGazzillion
            // 
            this.btnSendGazzillion.Location = new System.Drawing.Point(227, 59);
            this.btnSendGazzillion.Name = "btnSendGazzillion";
            this.btnSendGazzillion.Size = new System.Drawing.Size(193, 51);
            this.btnSendGazzillion.TabIndex = 1;
            this.btnSendGazzillion.Text = "Send gazillion";
            this.btnSendGazzillion.UseVisualStyleBackColor = true;
            this.btnSendGazzillion.Click += new System.EventHandler(this.btnSendGazzillion_Click);
            // 
            // bwSendGazillion
            // 
            this.bwSendGazillion.WorkerReportsProgress = true;
            this.bwSendGazillion.WorkerSupportsCancellation = true;
            this.bwSendGazillion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSendGazillion_DoWork);
            this.bwSendGazillion.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwSendGazillion_ProgressChanged);
            this.bwSendGazillion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSendGazillion_RunWorkerCompleted);
            // 
            // lblg
            // 
            this.lblg.AutoSize = true;
            this.lblg.Location = new System.Drawing.Point(270, 127);
            this.lblg.Name = "lblg";
            this.lblg.Size = new System.Drawing.Size(107, 13);
            this.lblg.TabIndex = 3;
            this.lblg.Text = "Sent \'{0}\' exceptions.";
            // 
            // nupMaxPerSecond
            // 
            this.nupMaxPerSecond.Location = new System.Drawing.Point(263, 12);
            this.nupMaxPerSecond.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nupMaxPerSecond.Name = "nupMaxPerSecond";
            this.nupMaxPerSecond.Size = new System.Drawing.Size(120, 20);
            this.nupMaxPerSecond.TabIndex = 2;
            this.nupMaxPerSecond.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nupMaxPerSecond.ValueChanged += new System.EventHandler(this.nupMaxPerSecond_ValueChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Dll files|*.dll|All files|*.*";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(426, 59);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(193, 51);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // btnShowLocalExceptions
            // 
            this.btnShowLocalExceptions.Location = new System.Drawing.Point(28, 59);
            this.btnShowLocalExceptions.Name = "btnShowLocalExceptions";
            this.btnShowLocalExceptions.Size = new System.Drawing.Size(193, 51);
            this.btnShowLocalExceptions.TabIndex = 1;
            this.btnShowLocalExceptions.Text = "Show local exceptions";
            this.btnShowLocalExceptions.UseVisualStyleBackColor = true;
            this.btnShowLocalExceptions.Click += new System.EventHandler(this.btnShowLocalExceptions_Click);
            // 
            // ExceptionGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 232);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nupMaxPerSecond);
            this.Controls.Add(this.lblg);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnShowLocalExceptions);
            this.Controls.Add(this.btnSendGazzillion);
            this.Name = "ExceptionGeneratorForm";
            this.Text = "ExceptionGeneratorForm";
            this.Load += new System.EventHandler(this.ExceptionGeneratorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupMaxPerSecond)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendGazzillion;
        private System.ComponentModel.BackgroundWorker bwSendGazillion;
        private System.Windows.Forms.Label lblg;
        private System.Windows.Forms.NumericUpDown nupMaxPerSecond;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowLocalExceptions;
    }
}

