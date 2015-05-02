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
            this.components = new System.ComponentModel.Container();
            this.lblPort = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.newClientConnected = new System.Windows.Forms.Label();
            this.totalClient = new System.Windows.Forms.Label();
            this.lstConnectedClients = new System.Windows.Forms.ListBox();
            this.lstDisconnectIPs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalClientConnected = new System.Windows.Forms.Label();
            this.newClient = new System.Windows.Forms.Label();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.timerConnectedClients = new System.Windows.Forms.Timer(this.components);
            this.listAllConnected = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.rTxtBoxMessageHistory = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.SuspendLayout();
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
            this.btnStartStop.Location = new System.Drawing.Point(18, 327);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 2;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
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
            this.totalClient.Location = new System.Drawing.Point(15, 142);
            this.totalClient.Name = "totalClient";
            this.totalClient.Size = new System.Drawing.Size(115, 13);
            this.totalClient.TabIndex = 6;
            this.totalClient.Text = "Total Client Connected";
            // 
            // lstConnectedClients
            // 
            this.lstConnectedClients.FormattingEnabled = true;
            this.lstConnectedClients.Location = new System.Drawing.Point(4, 12);
            this.lstConnectedClients.Name = "lstConnectedClients";
            this.lstConnectedClients.Size = new System.Drawing.Size(137, 56);
            this.lstConnectedClients.TabIndex = 10;
            // 
            // lstDisconnectIPs
            // 
            this.lstDisconnectIPs.FormattingEnabled = true;
            this.lstDisconnectIPs.Location = new System.Drawing.Point(136, 12);
            this.lstDisconnectIPs.Name = "lstDisconnectIPs";
            this.lstDisconnectIPs.Size = new System.Drawing.Size(109, 56);
            this.lstDisconnectIPs.TabIndex = 11;
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
            this.label2.Location = new System.Drawing.Point(142, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Disconnected Clients";
            // 
            // totalClientConnected
            // 
            this.totalClientConnected.AutoSize = true;
            this.totalClientConnected.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.totalClientConnected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.totalClientConnected.Location = new System.Drawing.Point(162, 142);
            this.totalClientConnected.Name = "totalClientConnected";
            this.totalClientConnected.Size = new System.Drawing.Size(15, 15);
            this.totalClientConnected.TabIndex = 14;
            this.totalClientConnected.Text = "0";
            // 
            // newClient
            // 
            this.newClient.AutoSize = true;
            this.newClient.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.newClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.newClient.Location = new System.Drawing.Point(162, 113);
            this.newClient.Name = "newClient";
            this.newClient.Size = new System.Drawing.Size(15, 15);
            this.newClient.TabIndex = 16;
            this.newClient.Text = "0";
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(162, 77);
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownPort.TabIndex = 18;
            this.numericUpDownPort.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // timerConnectedClients
            // 
            this.timerConnectedClients.Interval = 1000;
            this.timerConnectedClients.Tick += new System.EventHandler(this.timerConnectedClients_Tick);
            // 
            // listAllConnected
            // 
            this.listAllConnected.FormattingEnabled = true;
            this.listAllConnected.Location = new System.Drawing.Point(248, 14);
            this.listAllConnected.Name = "listAllConnected";
            this.listAllConnected.Size = new System.Drawing.Size(137, 303);
            this.listAllConnected.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "All Connected Clients";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Disconnent Selected IP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(400, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Send ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(400, 234);
            this.textBox1.MinimumSize = new System.Drawing.Size(100, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(172, 60);
            this.textBox1.TabIndex = 24;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(500, 327);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 23);
            this.button3.TabIndex = 25;
            this.button3.Text = "Send To All";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // rTxtBoxMessageHistory
            // 
            this.rTxtBoxMessageHistory.Location = new System.Drawing.Point(400, 14);
            this.rTxtBoxMessageHistory.Name = "rTxtBoxMessageHistory";
            this.rTxtBoxMessageHistory.Size = new System.Drawing.Size(172, 202);
            this.rTxtBoxMessageHistory.TabIndex = 26;
            this.rTxtBoxMessageHistory.Text = "";
            // 
            // SCADA_mainDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.rTxtBoxMessageHistory);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listAllConnected);
            this.Controls.Add(this.numericUpDownPort);
            this.Controls.Add(this.newClient);
            this.Controls.Add(this.totalClientConnected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstDisconnectIPs);
            this.Controls.Add(this.lstConnectedClients);
            this.Controls.Add(this.totalClient);
            this.Controls.Add(this.newClientConnected);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.lblPort);
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(300, 38);
            this.Name = "SCADA_mainDlg";
            this.Text = "SCADA Server";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label newClientConnected;
        private System.Windows.Forms.Label totalClient;
        private System.Windows.Forms.ListBox lstConnectedClients;
        private System.Windows.Forms.ListBox lstDisconnectIPs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalClientConnected;
        private System.Windows.Forms.Label newClient;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.Timer timerConnectedClients;
        private System.Windows.Forms.ListBox listAllConnected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox rTxtBoxMessageHistory;
    }
}

