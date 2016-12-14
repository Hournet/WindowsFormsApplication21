using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit;
using MailKit.Net.Imap;
namespace WindowsFormsApplication9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ImapClient client = null;
        SortedList<string, KeyValuePair<string,string>> messages = new SortedList<string, KeyValuePair<string, string>>(); 
        private void Form1_Load(object sender, EventArgs e)
        { 

        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            messages.Clear();
            using (client = new ImapClient())
           { 
            client.Connect("imap.gmail.com", 993, true);
            client.Authenticate("maximkerimov88@gmail.com", "ytdpkfvfti88");
            IMailFolder inbox = client.GetFolder(SpecialFolder.All);
            inbox.Open(FolderAccess.ReadOnly);
            inbox.ToList().ForEach(x =>
            {
                messages.Add(x.MessageId, new KeyValuePair<string, string>(x.Subject, x.TextBody));
            });
            listBox1.Items.AddRange(messages.ToList().Select(x => (object)x.Key).ToArray());
            listBox1.DoubleClick += (o, ee) =>
            {
                string key = (string)listBox1.SelectedItem;
                MessageBox.Show(messages[key].Key + ":\n" + messages[key].Value);
            };
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            messages.Clear();
            using (client = new ImapClient())
            {
                client.Connect("imap.gmail.com", 993, true);
                client.Authenticate("maximkerimov88@gmail.com", "ytdpkfvfti88");
                IMailFolder inbox = client.GetFolder(SpecialFolder.Sent);
                inbox.Open(FolderAccess.ReadOnly);
                inbox.ToList().ForEach(x =>
                {
                    messages.Add(x.MessageId, new KeyValuePair<string, string>(x.Subject, x.TextBody));
                });
                listBox2.Items.AddRange(messages.ToList().Select(x => (object)x.Key).ToArray());
                listBox2.DoubleClick += (o, ee) =>
                {
                    string key = (string)listBox2.SelectedItem;
                    MessageBox.Show(messages[key].Key + ":\n" + messages[key].Value);
                };
            }
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            messages.Clear();
            using (client = new ImapClient())
            {
                client.Connect("imap.gmail.com", 993, true);
                client.Authenticate("maximkerimov88@gmail.com", "ytdpkfvfti88");
                IMailFolder inbox = client.GetFolder(SpecialFolder.Trash);
                inbox.Open(FolderAccess.ReadOnly);
                inbox.ToList().ForEach(x =>
                {
                    messages.Add(x.MessageId, new KeyValuePair<string, string>(x.Subject, x.TextBody));
                });
                listBox3.Items.AddRange(messages.ToList().Select(x => (object)x.Key).ToArray());
                listBox3.DoubleClick += (o, ee) =>
                {
                    string key = (string)listBox3.SelectedItem;
                    MessageBox.Show(messages[key].Key + ":\n" + messages[key].Value);
                };
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }
    }
}
