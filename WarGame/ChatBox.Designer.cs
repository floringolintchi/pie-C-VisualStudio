namespace Client
{
    partial class ChatBox
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
            this.userlist = new System.Windows.Forms.ListBox();
            this.chatField = new System.Windows.Forms.TextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userlist
            // 
            this.userlist.FormattingEnabled = true;
            this.userlist.Location = new System.Drawing.Point(259, 12);
            this.userlist.Name = "userlist";
            this.userlist.Size = new System.Drawing.Size(84, 160);
            this.userlist.TabIndex = 0;
            // 
            // chatField
            // 
            this.chatField.Location = new System.Drawing.Point(12, 12);
            this.chatField.Multiline = true;
            this.chatField.Name = "chatField";
            this.chatField.ReadOnly = true;
            this.chatField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatField.Size = new System.Drawing.Size(241, 134);
            this.chatField.TabIndex = 1;
            this.chatField.TextChanged += new System.EventHandler(this.chatField_TextChanged);
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(12, 152);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(160, 20);
            this.txtChat.TabIndex = 2;
            this.txtChat.TextChanged += new System.EventHandler(this.txtChat_TextChanged);
            this.txtChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChat_KeyDown);
            this.txtChat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtChat_KeyUp);
            // 
            // sendBtn
            // 
            this.sendBtn.Enabled = false;
            this.sendBtn.Location = new System.Drawing.Point(178, 150);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(75, 23);
            this.sendBtn.TabIndex = 3;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 183);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.chatField);
            this.Controls.Add(this.userlist);
            this.Name = "ChatBox";
            this.Text = "ChatBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatBox_FormClosing);
            this.Load += new System.EventHandler(this.ChatBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox userlist;
        private System.Windows.Forms.TextBox chatField;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Button sendBtn;
    }
}