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
            this.btnDisconnectIP = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.textBoxWriteMsg = new System.Windows.Forms.TextBox();
            this.btnSendAll = new System.Windows.Forms.Button();
            this.rTxtBoxMessageHistory = new System.Windows.Forms.RichTextBox();
            this.msgHistory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPort.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(15, 256);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(226, 27);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "SCADA Server Port";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStop.Location = new System.Drawing.Point(45, 519);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(95, 31);
            this.btnStartStop.TabIndex = 2;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // newClientConnected
            // 
            this.newClientConnected.AutoSize = true;
            this.newClientConnected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.newClientConnected.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newClientConnected.Location = new System.Drawing.Point(15, 299);
            this.newClientConnected.Name = "newClientConnected";
            this.newClientConnected.Size = new System.Drawing.Size(287, 27);
            this.newClientConnected.TabIndex = 5;
            this.newClientConnected.Text = "New Connected Client No";
            // 
            // totalClient
            // 
            this.totalClient.AutoSize = true;
            this.totalClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.totalClient.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalClient.Location = new System.Drawing.Point(15, 341);
            this.totalClient.Name = "totalClient";
            this.totalClient.Size = new System.Drawing.Size(260, 27);
            this.totalClient.TabIndex = 6;
            this.totalClient.Text = "Total Client Connected";
            // 
            // lstConnectedClients
            // 
            this.lstConnectedClients.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstConnectedClients.FormattingEnabled = true;
            this.lstConnectedClients.ItemHeight = 15;
            this.lstConnectedClients.Location = new System.Drawing.Point(0, 39);
            this.lstConnectedClients.Name = "lstConnectedClients";
            this.lstConnectedClients.Size = new System.Drawing.Size(260, 124);
            this.lstConnectedClients.TabIndex = 10;
            // 
            // lstDisconnectIPs
            // 
            this.lstDisconnectIPs.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDisconnectIPs.FormattingEnabled = true;
            this.lstDisconnectIPs.ItemHeight = 15;
            this.lstDisconnectIPs.Location = new System.Drawing.Point(266, 38);
            this.lstDisconnectIPs.Name = "lstDisconnectIPs";
            this.lstDisconnectIPs.Size = new System.Drawing.Size(260, 124);
            this.lstDisconnectIPs.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 27);
            this.label1.TabIndex = 12;
            this.label1.Text = "Connected Clients";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(266, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 27);
            this.label2.TabIndex = 13;
            this.label2.Text = "Disconnected Clients";
            // 
            // totalClientConnected
            // 
            this.totalClientConnected.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.totalClientConnected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.totalClientConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalClientConnected.Location = new System.Drawing.Point(373, 340);
            this.totalClientConnected.Margin = new System.Windows.Forms.Padding(3);
            this.totalClientConnected.Name = "totalClientConnected";
            this.totalClientConnected.Size = new System.Drawing.Size(49, 28);
            this.totalClientConnected.TabIndex = 14;
            this.totalClientConnected.Text = "0";
            // 
            // newClient
            // 
            this.newClient.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.newClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.newClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newClient.Location = new System.Drawing.Point(373, 298);
            this.newClient.Margin = new System.Windows.Forms.Padding(3);
            this.newClient.Name = "newClient";
            this.newClient.Size = new System.Drawing.Size(49, 28);
            this.newClient.TabIndex = 16;
            this.newClient.Text = "0";
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPort.Location = new System.Drawing.Point(373, 256);
            this.numericUpDownPort.MaximumSize = new System.Drawing.Size(50, 0);
            this.numericUpDownPort.MinimumSize = new System.Drawing.Size(10, 0);
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(49, 24);
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
            this.listAllConnected.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listAllConnected.FormattingEnabled = true;
            this.listAllConnected.ItemHeight = 15;
            this.listAllConnected.Location = new System.Drawing.Point(532, 37);
            this.listAllConnected.Name = "listAllConnected";
            this.listAllConnected.Size = new System.Drawing.Size(263, 334);
            this.listAllConnected.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(535, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 27);
            this.label3.TabIndex = 20;
            this.label3.Text = "All Connected Clients";
            // 
            // btnDisconnectIP
            // 
            this.btnDisconnectIP.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnectIP.Location = new System.Drawing.Point(45, 205);
            this.btnDisconnectIP.Name = "btnDisconnectIP";
            this.btnDisconnectIP.Size = new System.Drawing.Size(131, 28);
            this.btnDisconnectIP.TabIndex = 21;
            this.btnDisconnectIP.Text = "Disconnent Selected IP";
            this.btnDisconnectIP.UseVisualStyleBackColor = true;
            this.btnDisconnectIP.Click += new System.EventHandler(this.btnDisconnectIP_Click);
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(821, 521);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(71, 29);
            this.btnSend.TabIndex = 23;
            this.btnSend.Text = "Send ";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // textBoxWriteMsg
            // 
            this.textBoxWriteMsg.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWriteMsg.Location = new System.Drawing.Point(804, 390);
            this.textBoxWriteMsg.MaximumSize = new System.Drawing.Size(400, 300);
            this.textBoxWriteMsg.MinimumSize = new System.Drawing.Size(100, 100);
            this.textBoxWriteMsg.Name = "textBoxWriteMsg";
            this.textBoxWriteMsg.Size = new System.Drawing.Size(232, 100);
            this.textBoxWriteMsg.TabIndex = 24;
            this.textBoxWriteMsg.Text = "Server Message";
            // 
            // btnSendAll
            // 
            this.btnSendAll.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendAll.Location = new System.Drawing.Point(921, 521);
            this.btnSendAll.Name = "btnSendAll";
            this.btnSendAll.Size = new System.Drawing.Size(101, 29);
            this.btnSendAll.TabIndex = 25;
            this.btnSendAll.Text = "Send To All";
            this.btnSendAll.UseVisualStyleBackColor = true;
            this.btnSendAll.Click += new System.EventHandler(this.btnSendAll_Click);
            // 
            // rTxtBoxMessageHistory
            // 
            this.rTxtBoxMessageHistory.Font = new System.Drawing.Font("Modern No. 20", 11.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtBoxMessageHistory.Location = new System.Drawing.Point(801, 36);
            this.rTxtBoxMessageHistory.Name = "rTxtBoxMessageHistory";
            this.rTxtBoxMessageHistory.Size = new System.Drawing.Size(232, 336);
            this.rTxtBoxMessageHistory.TabIndex = 26;
            this.rTxtBoxMessageHistory.Text = "Clients Messages Histort";
            // 
            // msgHistory
            // 
            this.msgHistory.AutoSize = true;
            this.msgHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.msgHistory.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgHistory.Location = new System.Drawing.Point(804, 4);
            this.msgHistory.Name = "msgHistory";
            this.msgHistory.Size = new System.Drawing.Size(188, 27);
            this.msgHistory.TabIndex = 27;
            this.msgHistory.Text = "Message History";
            // 
            // SCADA_mainDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 562);
            this.Controls.Add(this.msgHistory);
            this.Controls.Add(this.rTxtBoxMessageHistory);
            this.Controls.Add(this.btnSendAll);
            this.Controls.Add(this.textBoxWriteMsg);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnDisconnectIP);
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
            this.MaximumSize = new System.Drawing.Size(1100, 600);
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
        private System.Windows.Forms.Button btnDisconnectIP;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox textBoxWriteMsg;
        private System.Windows.Forms.Button btnSendAll;
        private System.Windows.Forms.RichTextBox rTxtBoxMessageHistory;
        private System.Windows.Forms.Label msgHistory;
    }
}

