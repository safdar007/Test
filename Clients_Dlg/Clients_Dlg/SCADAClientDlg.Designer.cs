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
            this.clientMessage = new System.Windows.Forms.TextBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
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
            // clientMessage
            // 
            this.clientMessage.Location = new System.Drawing.Point(75, 120);
            this.clientMessage.Name = "clientMessage";
            this.clientMessage.Size = new System.Drawing.Size(100, 20);
            this.clientMessage.TabIndex = 5;
            this.clientMessage.Text = "Write Text Meg<END>";
            this.clientMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(75, 53);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(100, 20);
            this.txtServerIP.TabIndex = 3;
            this.txtServerIP.Text = "127.0.0.1";
            this.txtServerIP.TextChanged += new System.EventHandler(this.txtServerIP_TextChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.clientMessage);
            this.Controls.Add(this.portAddress);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.lblServerPort);
            this.Controls.Add(this.lblServerIP);
            this.Controls.Add(this.btnConnectDisconnect);
            this.MaximumSize = new System.Drawing.Size(300, 300);
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
        private System.Windows.Forms.TextBox clientMessage;
        private System.Windows.Forms.TextBox txtServerIP;
    }
}

