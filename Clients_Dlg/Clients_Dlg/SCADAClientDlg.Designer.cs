namespace Clients_Dlg
{
    partial class frmMain
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
            this.btnConnectDisconnect = new System.Windows.Forms.Button();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.portAddress = new System.Windows.Forms.NumericUpDown();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.listMsgHistory = new System.Windows.Forms.ListBox();
            this.textMsgSend = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.portAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnectDisconnect
            // 
            this.btnConnectDisconnect.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnConnectDisconnect.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnConnectDisconnect.Location = new System.Drawing.Point(88, 172);
            this.btnConnectDisconnect.Name = "btnConnectDisconnect";
            this.btnConnectDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnectDisconnect.TabIndex = 0;
            this.btnConnectDisconnect.Text = "Connect";
            this.btnConnectDisconnect.UseVisualStyleBackColor = false;
            this.btnConnectDisconnect.Click += new System.EventHandler(this.btnConnectDisconnect_Click);
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(21, 53);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(17, 13);
            this.lblServerIP.TabIndex = 1;
            this.lblServerIP.Text = "IP";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(24, 87);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(26, 13);
            this.lblServerPort.TabIndex = 2;
            this.lblServerPort.Text = "Port";
            // 
            // portAddress
            // 
            this.portAddress.Location = new System.Drawing.Point(75, 79);
            this.portAddress.Name = "portAddress";
            this.portAddress.Size = new System.Drawing.Size(100, 20);
            this.portAddress.TabIndex = 4;
            this.portAddress.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(75, 53);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(100, 20);
            this.txtServerIP.TabIndex = 3;
            this.txtServerIP.Text = "127.0.0.1";
            
            // 
            // listMsgHistory
            // 
            this.listMsgHistory.FormattingEnabled = true;
            this.listMsgHistory.Location = new System.Drawing.Point(225, 7);
            this.listMsgHistory.Name = "listMsgHistory";
            this.listMsgHistory.Size = new System.Drawing.Size(231, 147);
            this.listMsgHistory.TabIndex = 23;
            // 
            // textMsgSend
            // 
            this.textMsgSend.Location = new System.Drawing.Point(225, 162);
            this.textMsgSend.MinimumSize = new System.Drawing.Size(100, 60);
            this.textMsgSend.Name = "textMsgSend";
            this.textMsgSend.Size = new System.Drawing.Size(231, 60);
            this.textMsgSend.TabIndex = 27;
            this.textMsgSend.Text = "Write text message";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(296, 231);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(74, 23);
            this.sendButton.TabIndex = 26;
            this.sendButton.Text = "Send ";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 262);
            this.Controls.Add(this.textMsgSend);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.listMsgHistory);
            this.Controls.Add(this.portAddress);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.lblServerPort);
            this.Controls.Add(this.lblServerIP);
            this.Controls.Add(this.btnConnectDisconnect);
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "frmMain";
            this.Text = "SCADA Client";
            ((System.ComponentModel.ISupportInitialize)(this.portAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnectDisconnect;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.NumericUpDown portAddress;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.ListBox listMsgHistory;
        private System.Windows.Forms.TextBox textMsgSend;
        private System.Windows.Forms.Button sendButton;
    }
}

