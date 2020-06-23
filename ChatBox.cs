using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Connection;
using Server;

namespace Client
{
    public partial class ChatBox : Form
    {
        private TCPConnection con;
        private bool closed = false;

        public ChatBox(TCPConnection con)
        {
            InitializeComponent();
            this.con = con;
            con.OnReceiveCompleted += con_OnReceiveCompleted;
            con.OnExceptionRaised += con_OnExceptionRaised;
        }

        void con_OnExceptionRaised(object sender, ExceptionRaiseEventArgs args)
        {
            Application.Exit();
        }

        public ChatBox()
        {
            InitializeComponent();
        }

        private void ChatBox_Load(object sender, EventArgs e)
        {
            con.send(Commands.CreateMessage(Commands.UserList, Commands.Request, null));
        }

        private delegate void ReceiveFunctionCall(string text);
        private string incompleteMessage = null;
        private void ReceieveMessage(string text)
        {

            if (incompleteMessage != null)
            {
                text = incompleteMessage + text;
            }

            chatField.Text += text + "\r\n";

            chatField.SelectionStart = chatField.TextLength;
            chatField.ScrollToCaret();

            string[] messages = text.Split(new string[] { Commands.EndMessageDelim }, StringSplitOptions.RemoveEmptyEntries);

            if (messages.Length > 0)
            {
                //verifies if last message is complete (correction = 0)
                //if not (correction = 1) it will be stored for further use
                int correction = (text.EndsWith(Commands.EndMessageDelim) ? 0 : 1);
                if (correction == 1)
                {
                    incompleteMessage = messages[messages.Length - 1];
                }
                else
                {
                    incompleteMessage = null;
                }

                for (int i = 0; i < messages.Length - correction; i++)
                {
                    Commands.Message message = Commands.DecodeMessage(messages[i]);

                    switch (message.Command)
                    {
                        case Commands.UserList:
                            switch (message.Subcommand)
                            {
                                case Commands.Add:
                                    userlist.Items.Add(message.Data);
                                    break;
                                case Commands.Remove:
                                    userlist.Items.Remove(message.Data);
                                    chatField.Text += message.Data + " has logout.\r\n";
                                    break;
                            }
                            break;

                        case Commands.Disconnect:
                            userlist.Items.Remove(message.Data);
                            chatField.Text += message.Data + " lost connection.\r\n";
                            break;

                        case Commands.PublicMessage:
                            chatField.Text += message.Data + "\r\n";

                            chatField.SelectionStart = chatField.TextLength;
                            chatField.ScrollToCaret();
                            break;
                    }
                }
            }
        }

        void con_OnReceiveCompleted(object sender, ReceiveCompletedEventArgs args)
        {
            string text = Encoding.Unicode.GetString(args.data);
            this.BeginInvoke(new ReceiveFunctionCall(ReceieveMessage), text);
        }

        void sendMessage()
        {
            byte[] data = Commands.CreateMessage(Commands.PublicMessage, Commands.None, txtChat.Text);

            con.send(data);

            txtChat.Text = "";
            sendBtn.Enabled = false;
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void txtChat_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtChat.Text == "" && sendBtn.Enabled)
                sendBtn.Enabled = false;
            else if (txtChat.Text != "" && !sendBtn.Enabled)
                sendBtn.Enabled = true;
        }

        private void ChatBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.send(Commands.CreateMessage(Commands.Logout, Commands.None, null));
            //con.close();
            Application.Exit();
        }

        private void txtChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                sendMessage();
        }

        private void chatField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
