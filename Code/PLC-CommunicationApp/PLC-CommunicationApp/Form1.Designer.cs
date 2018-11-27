namespace PLC_CommunicationApp
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
            this.CreateBtn = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.BrokerIpTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connIdTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UsernameTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PublishBtn = new System.Windows.Forms.Button();
            this.PubMsgTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.subscribeLB = new System.Windows.Forms.ListBox();
            this.SubscribeBtn = new System.Windows.Forms.Button();
            this.TopicTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.readBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateBtn
            // 
            this.CreateBtn.Location = new System.Drawing.Point(12, 12);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(75, 23);
            this.CreateBtn.TabIndex = 0;
            this.CreateBtn.Text = "Create";
            this.CreateBtn.UseVisualStyleBackColor = true;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(12, 41);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 0;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // BrokerIpTB
            // 
            this.BrokerIpTB.Location = new System.Drawing.Point(93, 14);
            this.BrokerIpTB.Name = "BrokerIpTB";
            this.BrokerIpTB.Size = new System.Drawing.Size(142, 21);
            this.BrokerIpTB.TabIndex = 1;
            this.BrokerIpTB.Text = "192.168.1.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "BrokerIP";
            // 
            // connIdTB
            // 
            this.connIdTB.Location = new System.Drawing.Point(93, 41);
            this.connIdTB.Name = "connIdTB";
            this.connIdTB.Size = new System.Drawing.Size(142, 21);
            this.connIdTB.TabIndex = 1;
            this.connIdTB.Text = "connect ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "connectID";
            // 
            // UsernameTB
            // 
            this.UsernameTB.Location = new System.Drawing.Point(311, 14);
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.Size = new System.Drawing.Size(142, 21);
            this.UsernameTB.TabIndex = 1;
            this.UsernameTB.Text = "username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "username";
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(518, 14);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(142, 21);
            this.PasswordTB.TabIndex = 1;
            this.PasswordTB.Text = "password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(666, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "password";
            // 
            // PublishBtn
            // 
            this.PublishBtn.Location = new System.Drawing.Point(12, 70);
            this.PublishBtn.Name = "PublishBtn";
            this.PublishBtn.Size = new System.Drawing.Size(75, 23);
            this.PublishBtn.TabIndex = 0;
            this.PublishBtn.Text = "Publish";
            this.PublishBtn.UseVisualStyleBackColor = true;
            this.PublishBtn.Click += new System.EventHandler(this.PublishBtn_Click);
            // 
            // PubMsgTB
            // 
            this.PubMsgTB.Location = new System.Drawing.Point(93, 72);
            this.PubMsgTB.Name = "PubMsgTB";
            this.PubMsgTB.Size = new System.Drawing.Size(142, 21);
            this.PubMsgTB.TabIndex = 1;
            this.PubMsgTB.Text = "message";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "pub msg";
            // 
            // subscribeLB
            // 
            this.subscribeLB.FormattingEnabled = true;
            this.subscribeLB.ItemHeight = 12;
            this.subscribeLB.Location = new System.Drawing.Point(311, 44);
            this.subscribeLB.Name = "subscribeLB";
            this.subscribeLB.Size = new System.Drawing.Size(408, 88);
            this.subscribeLB.TabIndex = 3;
            // 
            // SubscribeBtn
            // 
            this.SubscribeBtn.Location = new System.Drawing.Point(13, 100);
            this.SubscribeBtn.Name = "SubscribeBtn";
            this.SubscribeBtn.Size = new System.Drawing.Size(74, 22);
            this.SubscribeBtn.TabIndex = 4;
            this.SubscribeBtn.Text = "subscribe";
            this.SubscribeBtn.UseVisualStyleBackColor = true;
            this.SubscribeBtn.Click += new System.EventHandler(this.SubscribeBtn_Click);
            // 
            // TopicTB
            // 
            this.TopicTB.Location = new System.Drawing.Point(93, 102);
            this.TopicTB.Name = "TopicTB";
            this.TopicTB.Size = new System.Drawing.Size(142, 21);
            this.TopicTB.TabIndex = 1;
            this.TopicTB.Text = "/test/topic";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "sub topic";
            // 
            // readBtn
            // 
            this.readBtn.Location = new System.Drawing.Point(12, 128);
            this.readBtn.Name = "readBtn";
            this.readBtn.Size = new System.Drawing.Size(74, 22);
            this.readBtn.TabIndex = 4;
            this.readBtn.Text = "read";
            this.readBtn.UseVisualStyleBackColor = true;
            this.readBtn.Click += new System.EventHandler(this.readBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 547);
            this.Controls.Add(this.readBtn);
            this.Controls.Add(this.SubscribeBtn);
            this.Controls.Add(this.subscribeLB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.UsernameTB);
            this.Controls.Add(this.TopicTB);
            this.Controls.Add(this.PubMsgTB);
            this.Controls.Add(this.connIdTB);
            this.Controls.Add(this.BrokerIpTB);
            this.Controls.Add(this.PublishBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.CreateBtn);
            this.Name = "Form1";
            this.Text = "MQTT-Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateBtn;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox BrokerIpTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox connIdTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsernameTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button PublishBtn;
        private System.Windows.Forms.TextBox PubMsgTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox subscribeLB;
        private System.Windows.Forms.Button SubscribeBtn;
        private System.Windows.Forms.TextBox TopicTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button readBtn;
    }
}

