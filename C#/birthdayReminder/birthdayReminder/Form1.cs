using System;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Microsoft.Win32;

namespace birthdayReminder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string GET(string Url)
        {
            string userName = "web";
            string password = "123";
            var authBasic = new NetworkCredential(userName, password);
            WebRequest req = WebRequest.Create(Url);
            req.Credentials = authBasic;
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }
        public void resync()
        {
            birthdays.Scrollable = false;
            if (birthdays.Nodes.Count > 0) { birthdays.Nodes.Clear(); }
            string itemToDeSerialise = GET("http://localhost/test-1c8zup/ru_RU/hs/birthday/"+cut.Value.ToString());
            if (itemToDeSerialise.Length > 0) { 
            itemToDeSerialise = itemToDeSerialise.Remove(itemToDeSerialise.Length - 1);
            string[] bdays = itemToDeSerialise.Split('#');
          
            progressBar1.Minimum = 0;
            progressBar1.Maximum = bdays.Count()+1;
            foreach (var worker in bdays)
            {
                
                TreeNode bdworker = new TreeNode();
                string[] bdinfo = worker.Split('$');
                int whenBd = Convert.ToInt32(bdinfo[6]);               
                if (whenBd == 0) { bdworker = new TreeNode("Сегодня празднует " + bdinfo[1]); }
                if (whenBd == 1) { bdworker = new TreeNode("Завтра у " + bdinfo[1] + " будет день рождение"); }
                if (whenBd == 2) { bdworker = new TreeNode("Послезавтра у " + bdinfo[1] + " будет день рождение"); }
                if (whenBd >= 3 || whenBd < 0) { bdworker = new TreeNode("Позднее у " + bdinfo[1] + " будет день рождение"); }
                bdworker.Nodes.Add(new TreeNode("День рождение: " + bdinfo[2].Remove(bdinfo[2].Length - 8)));
                bdworker.Nodes.Add(new TreeNode("Работает в " + bdinfo[3]));
                bdworker.Nodes.Add(new TreeNode(bdinfo[4]));
                bdworker.Nodes.Add(new TreeNode("Будет праздновать свой " + bdinfo[5] + "-й день рождение"));
                birthdays.Nodes.Add(bdworker);

                progressBar1.Value += 1;
             }
                birthdays.Scrollable = true;
                progressBar1.Value = 0;
            }
        }
        
        private void sync_Click(object sender, EventArgs e)
        {
            resync();
            //birthdays.ExpandAll();
        }

        private void cut_ValueChanged(object sender, EventArgs e)
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey conf = currentUserKey.CreateSubKey("bmBirthdays");
            conf.SetValue("cut", Convert.ToString(cut.Value));
            conf.Close();
            resync();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey conf = currentUserKey.OpenSubKey("bmBirthdays");
            if (conf != null) { decimal recut = Convert.ToDecimal(conf.GetValue("cut").ToString()); cut.Value = recut; conf.Close(); }
          
            RegistryKey cuk = Registry.CurrentUser;
            RegistryKey confx = cuk.OpenSubKey("bmBirthdays");
            if (confx != null) { Boolean reauto = Convert.ToBoolean(confx.GetValue("auto")); autorun.Checked=reauto; confx.Close(); }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                tray.Visible = true;
                TreeNode[] bdays = new TreeNode[birthdays.Nodes.Count];
                birthdays.Nodes.CopyTo(bdays, 0);
                tray.BalloonTipText = "Ничего нет";
                if (birthdays.Nodes.Count > 0)
                {
                    tray.BalloonTipText = "";
                    foreach (TreeNode bday in bdays)
                    {

                        int ind = bday.Text.IndexOf("Сегодня");
                        if (ind == 0)
                        {
                            tray.BalloonTipText = tray.BalloonTipText + bday.Text + '\n';
                        }
                    }
                    if (tray.BalloonTipText == "") { tray.BalloonTipText = "Сегодня нет дней рождений."; }
                    tray.ShowBalloonTip(5000);
                }
                else
                {
                    tray.BalloonTipText = "Дни рождения не получены";
                    tray.ShowBalloonTip(5000);
                }
            }
            
        }

        private void tray_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            tray.Visible = false;
        }

        private void tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tray.ShowBalloonTip(5000);
        }

        public bool SetAutorunValue(string ExePath,string name ,bool autorun)
        {
            
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                    reg.SetValue(name, ExePath);
                else
                    reg.DeleteValue(name);

                reg.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void autorun_CheckedChanged(object sender, EventArgs e)
        {
            if (autorun.Checked==true) {
                RegistryKey currentUserKey = Registry.CurrentUser;
                RegistryKey conf = currentUserKey.CreateSubKey("bmBirthdays");
                conf.SetValue("auto", 1);
                conf.Close();
                SetAutorunValue(Application.ExecutablePath,"bmReminder", true);
            }
            else {
                RegistryKey currentUserKey = Registry.CurrentUser;
                RegistryKey conf = currentUserKey.CreateSubKey("bmBirthdays");
                conf.SetValue("auto", 0);
                conf.Close();
                SetAutorunValue(Application.ExecutablePath, "bmReminder", false);
            }
            
        }

        private void timeToSync_Tick(object sender, EventArgs e)
        {
            resync();
        }

        private void cut_KeyPress(object sender, KeyPressEventArgs e)
        {
            resync();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
