namespace ComApp
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
            this.txtBoxADSIP = new System.Windows.Forms.TextBox();
            this.lblADSIP = new System.Windows.Forms.Label();
            this.btnCorDADS = new System.Windows.Forms.Button();
            this.lblMQTTIP = new System.Windows.Forms.Label();
            this.txtBoxMQTTIP = new System.Windows.Forms.TextBox();
            this.btnCorDMQTT = new System.Windows.Forms.Button();
            this.lblADSPort = new System.Windows.Forms.Label();
            this.txtBoxADSPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBoxADSIP
            // 
            this.txtBoxADSIP.Location = new System.Drawing.Point(12, 25);
            this.txtBoxADSIP.Name = "txtBoxADSIP";
            this.txtBoxADSIP.Size = new System.Drawing.Size(169, 20);
            this.txtBoxADSIP.TabIndex = 0;
            // 
            // lblADSIP
            // 
            this.lblADSIP.AutoSize = true;
            this.lblADSIP.Location = new System.Drawing.Point(9, 9);
            this.lblADSIP.Name = "lblADSIP";
            this.lblADSIP.Size = new System.Drawing.Size(45, 13);
            this.lblADSIP.TabIndex = 1;
            this.lblADSIP.Text = "ADS IP:";
            // 
            // btnCorDADS
            // 
            this.btnCorDADS.Location = new System.Drawing.Point(12, 91);
            this.btnCorDADS.Name = "btnCorDADS";
            this.btnCorDADS.Size = new System.Drawing.Size(169, 23);
            this.btnCorDADS.TabIndex = 2;
            this.btnCorDADS.Text = "Connect To ADS";
            this.btnCorDADS.UseVisualStyleBackColor = true;
            this.btnCorDADS.Click += new System.EventHandler(this.btnCorDADS_Click);
            // 
            // lblMQTTIP
            // 
            this.lblMQTTIP.AutoSize = true;
            this.lblMQTTIP.Location = new System.Drawing.Point(12, 135);
            this.lblMQTTIP.Name = "lblMQTTIP";
            this.lblMQTTIP.Size = new System.Drawing.Size(54, 13);
            this.lblMQTTIP.TabIndex = 3;
            this.lblMQTTIP.Text = "MQTT IP:";
            // 
            // txtBoxMQTTIP
            // 
            this.txtBoxMQTTIP.Location = new System.Drawing.Point(12, 151);
            this.txtBoxMQTTIP.Name = "txtBoxMQTTIP";
            this.txtBoxMQTTIP.Size = new System.Drawing.Size(169, 20);
            this.txtBoxMQTTIP.TabIndex = 4;
            // 
            // btnCorDMQTT
            // 
            this.btnCorDMQTT.Location = new System.Drawing.Point(12, 177);
            this.btnCorDMQTT.Name = "btnCorDMQTT";
            this.btnCorDMQTT.Size = new System.Drawing.Size(169, 23);
            this.btnCorDMQTT.TabIndex = 5;
            this.btnCorDMQTT.Text = "Connect To MQTT";
            this.btnCorDMQTT.UseVisualStyleBackColor = true;
            this.btnCorDMQTT.Click += new System.EventHandler(this.btnCorDMQTT_Click);
            // 
            // lblADSPort
            // 
            this.lblADSPort.AutoSize = true;
            this.lblADSPort.Location = new System.Drawing.Point(9, 49);
            this.lblADSPort.Name = "lblADSPort";
            this.lblADSPort.Size = new System.Drawing.Size(54, 13);
            this.lblADSPort.TabIndex = 7;
            this.lblADSPort.Text = "ADS Port:";
            // 
            // txtBoxADSPort
            // 
            this.txtBoxADSPort.Location = new System.Drawing.Point(12, 65);
            this.txtBoxADSPort.Name = "txtBoxADSPort";
            this.txtBoxADSPort.Size = new System.Drawing.Size(169, 20);
            this.txtBoxADSPort.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblADSPort);
            this.Controls.Add(this.txtBoxADSPort);
            this.Controls.Add(this.btnCorDMQTT);
            this.Controls.Add(this.txtBoxMQTTIP);
            this.Controls.Add(this.lblMQTTIP);
            this.Controls.Add(this.btnCorDADS);
            this.Controls.Add(this.lblADSIP);
            this.Controls.Add(this.txtBoxADSIP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxADSIP;
        private System.Windows.Forms.Label lblADSIP;
        private System.Windows.Forms.Button btnCorDADS;
        private System.Windows.Forms.Label lblMQTTIP;
        private System.Windows.Forms.TextBox txtBoxMQTTIP;
        private System.Windows.Forms.Button btnCorDMQTT;
        private System.Windows.Forms.Label lblADSPort;
        private System.Windows.Forms.TextBox txtBoxADSPort;
    }
}

