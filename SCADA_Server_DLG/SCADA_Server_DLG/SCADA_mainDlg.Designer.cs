namespace SCADA_Server_DLG
{
    partial class SCADA_mainDlg
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
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.lblPort = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.newClient = new System.Windows.Forms.NumericUpDown();
            this.newClientConnected = new System.Windows.Forms.Label();
            this.totalClient = new System.Windows.Forms.Label();
            this.dissconnectt = new System.Windows.Forms.Label();
            this.dissconnectClient = new System.Windows.Forms.NumericUpDown();
            this.btnShow = new System.Windows.Forms.Button();
            this.lstCnt = new System.Windows.Forms.ListBox();
            this.lstDiscnt = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalClientConnected = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dissconnectClient)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(152, 74);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPort.TabIndex = 0;
            this.numericUpDownPort.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(15, 79);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(99, 13);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "SCADA Server Port";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(39, 209);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 2;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // newClient
            // 
            this.newClient.Location = new System.Drawing.Point(152, 106);
            this.newClient.Name = "newClient";
            this.newClient.Size = new System.Drawing.Size(120, 20);
            this.newClient.TabIndex = 3;
            this.newClient.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // newClientConnected
            // 
            this.newClientConnected.AutoSize = true;
            this.newClientConnected.Location = new System.Drawing.Point(15, 113);
            this.newClientConnected.Name = "newClientConnected";
            this.newClientConnected.Size = new System.Drawing.Size(130, 13);
            this.newClientConnected.TabIndex = 5;
            this.newClientConnected.Text = "New Connected Client No";
            // 
            // totalClient
            // 
            this.totalClient.AutoSize = true;
            this.totalClient.Location = new System.Drawing.Point(15, 166);
            this.totalClient.Name = "totalClient";
            this.totalClient.Size = new System.Drawing.Size(115, 13);
            this.totalClient.TabIndex = 6;
            this.totalClient.Text = "Total Client Connected";
            // 
            // dissconnectt
            // 
            this.dissconnectt.AutoSize = true;
            this.dissconnectt.Location = new System.Drawing.Point(15, 140);
            this.dissconnectt.Name = "dissconnectt";
            this.dissconnectt.Size = new System.Drawing.Size(107, 13);
            this.dissconnectt.TabIndex = 8;
            this.dissconnectt.Text = "Client Dissconnected";
            // 
            // dissconnectClient
            // 
            this.dissconnectClient.Location = new System.Drawing.Point(151, 133);
            this.dissconnectClient.Name = "dissconnectClient";
            this.dissconnectClient.Size = new System.Drawing.Size(120, 20);
            this.dissconnectClient.TabIndex = 7;
            this.dissconnectClient.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(165, 209);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(107, 23);
            this.btnShow.TabIndex = 9;
            this.btnShow.Text = "Show Values";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lstCnt
            // 
            this.lstCnt.FormattingEnabled = true;
            this.lstCnt.Location = new System.Drawing.Point(4, 12);
            this.lstCnt.Name = "lstCnt";
            this.lstCnt.Size = new System.Drawing.Size(138, 56);
            this.lstCnt.TabIndex = 10;
            // 
            // lstDiscnt
            // 
            this.lstDiscnt.FormattingEnabled = true;
            this.lstDiscnt.Location = new System.Drawing.Point(147, 12);
            this.lstDiscnt.Name = "lstDiscnt";
            this.lstDiscnt.Size = new System.Drawing.Size(137, 56);
            this.lstDiscnt.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Connected Clients";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Disconnected Clients";
            // 
            // totalClientConnected
            // 
            this.totalClientConnected.AutoSize = true;
            this.totalClientConnected.Location = new System.Drawing.Point(162, 166);
            this.totalClientConnected.Name = "totalClientConnected";
            this.totalClientConnected.Size = new System.Drawing.Size(35, 13);
            this.totalClientConnected.TabIndex = 14;
            this.totalClientConnected.Text = "label3";
            // 
            // SCADA_mainDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.totalClientConnected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstDiscnt);
            this.Controls.Add(this.lstCnt);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dissconnectt);
            this.Controls.Add(this.dissconnectClient);
            this.Controls.Add(this.totalClient);
            this.Controls.Add(this.newClientConnected);
            this.Controls.Add(this.newClient);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.numericUpDownPort);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 38);
            this.Name = "SCADA_mainDlg";
            this.Text = "SCADA Server";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dissconnectClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.NumericUpDown newClient;
        private System.Windows.Forms.Label newClientConnected;
        private System.Windows.Forms.Label totalClient;
        private System.Windows.Forms.Label dissconnectt;
        private System.Windows.Forms.NumericUpDown dissconnectClient;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ListBox lstCnt;
        private System.Windows.Forms.ListBox lstDiscnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalClientConnected;
    }
}

