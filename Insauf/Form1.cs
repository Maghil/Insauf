using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using Python.Runtime;
using System.Collections.Generic;


namespace Insauf
{
    public partial class Form1 : Form
    {
        //intializing current directory path to python interpreter
        private string path = Environment.CurrentDirectory + "\\packages\\python35";
        private bool mouseDown;
        private Point lastLocation;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
         (
             int nLeftRect,     
             int nTopRect,     
             int nRightRect,    
             int nBottomRect,   
             int nWidthEllipse, 
             int nHeightEllipse 
         );

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 16, 16));
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Hpt_Click(object sender, EventArgs e)
        {

        }

        private void Qbt_Click(object sender, EventArgs e)
        {
            Application.Exit();
          
        }

        private void Nopbt_Click(object sender, EventArgs e)
        {
            hmt.SelectedTab = hpt;
        }

        private void Clsb_Click(object sender, EventArgs e)
        {
            hmt.SelectedTab = qtp;
        }

        private void Head_MouseDown(object sender, MouseEventArgs e)
        {

            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Head_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Head_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Homebt_MouseDown(object sender, MouseEventArgs e)
        {
            Homebt.BackColor = Color.FromArgb(64, 64, 64);
            Homebt.FlatAppearance.BorderColor = Color.FromArgb(64,64,64);
            accbt.BackColor = Color.FromArgb(47,47,47);
            accbt.FlatAppearance.BorderColor = Color.FromArgb(47,47,47);
            nfb.BackColor = Color.FromArgb(47, 47, 47);
            nfb.FlatAppearance.BorderColor = Color.FromArgb(47, 47, 47);
            abtb.BackColor = Color.FromArgb(47, 47, 47);
            abtb.FlatAppearance.BorderColor = Color.FromArgb(47, 47, 47);
               hmt.SelectedTab =hpt;
        
        }

        private void Accbt_MouseDown(object sender, MouseEventArgs e)
        {
            accbt.BackColor = Color.FromArgb(64, 64, 64);
            accbt.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            Homebt.BackColor = Color.FromArgb(47, 47, 47);
            Homebt.FlatAppearance.BorderColor = Color.FromArgb(47, 47, 47);
            nfb.BackColor = Color.FromArgb(47, 47, 47);
            nfb.FlatAppearance.BorderColor = Color.FromArgb(47, 47, 47);
            abtb.BackColor = Color.FromArgb(47, 47, 47);
            abtb.FlatAppearance.BorderColor = Color.FromArgb(47, 47, 47);
            hmt.SelectedTab = acpg;
        }

        private void Nfb_MouseDown(object sender, MouseEventArgs e)
        {
            nfb.BackColor = Color.FromArgb(64, 64, 64);
           nfb.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            Homebt.BackColor = Color.FromArgb(47, 47, 47);
            Homebt.FlatAppearance.BorderColor = Color.FromArgb(47, 47, 47);
            accbt.BackColor = Color.FromArgb(47, 47, 47);
           accbt.FlatAppearance.BorderColor = Color.FromArgb(47, 47, 47);
            abtb.BackColor = Color.FromArgb(47, 47, 47);
            abtb.FlatAppearance.BorderColor = Color.FromArgb(47, 47, 47);
            hmt.SelectedTab = Nonflp;
        }

        private void Abtb_MouseDown(object sender, MouseEventArgs e)
        {
           abtb.BackColor = Color.FromArgb(64, 64, 64);
           abtb.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            Homebt.BackColor = Color.FromArgb(47, 47, 47);
            Homebt.FlatAppearance.BorderColor = Color.FromArgb(47, 47, 47);
            nfb.BackColor = Color.FromArgb(47, 47, 47);
            nfb.FlatAppearance.BorderColor = Color.FromArgb(47, 47, 47);
            accbt.BackColor = Color.FromArgb(47, 47, 47);
          accbt.FlatAppearance.BorderColor = Color.FromArgb(47, 47, 47);
            hmt.SelectedTab = Abt;
        }

        private void Nfb_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            winstart();
            onLoad();
        }

        public void onLoad()
        {
            if (Properties.Settings.Default.check == false) { 
                addrs.settbox("Email", "eg : john@some.com", false);
                psw.settbox("Password", "0000", true);
            }
            else
            {
                addrs.settbox("Email", Properties.Settings.Default.username, false);
                psw.settbox("Password", Properties.Settings.Default.password, true);
                button2.PerformClick();
            }
            List<string> items = new List<string>();
            using (TextReader reader = File.OpenText("non_followers.txt"))
            {
                string line;
                // read until no more lines are present
                while ((line = reader.ReadLine()) != null)
                {
                    items.Add(line);
                }
            }
            // add the ListBox items in a bulk update instead of one at a time.
            listBox1.DataSource = items;
        }
        public void winstart()
        {
           
            timer1.Enabled = true;
            timer1.Start();

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.07;
            Application.DoEvents();
          
        }

        private void PictureBox3_Paint(object sender, PaintEventArgs e)
        {
           
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox3.Width - 3, pictureBox3.Height - 3);
            Region rg = new Region(gp);
            pictureBox3.Region = rg;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {         
            string usr = addrs.getText();
            string pwd = psw.getText();
            if (usr == "eg : john@some.com" || pwd == "0000")
            {
                MessageBox.Show("Please Enter Password and Email ID");
            }
            else
            {
                using (Py.GIL())
                {
                    dynamic insm = Py.Import("instamodule");
                    dynamic data = insm.login(usr, pwd,1);
                    if (data[0].ToString() == "1")
                    {
                        MessageBox.Show("Wrong Credentials");
                    }
                    else
                    {
                        followcount.Text = data[1].ToString();
                        followingcount.Text = data[2].ToString();
                        addrs.Mtx_ReadOnly();
                        nfb.Enabled = true;
                        Properties.Settings.Default.password = pwd;
                        Properties.Settings.Default.username = usr;
                        Properties.Settings.Default.check = true;
                    }

                }
            }
           
        }
        private void addrs_Load(object sender, EventArgs e)
        {
        }

        private void refbt_Click(object sender, EventArgs e)
        {
            string message = "This will rewrite saved file,Do you want to continue?";
            string title = "WARNING";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                using (Py.GIL())
                {
                    dynamic insm = Py.Import("instamodule");
                    /*try
                    {
                        insm.scrape("accounts_following_you", "followers.txt", Properties.Settings.Default.username, Properties.Settings.Default.password);
                        insm.scrape("accounts_you_follow", "following.txt", Properties.Settings.Default.username, Properties.Settings.Default.password);
                    }
                    catch
                    {
                        MessageBox.Show("retry");
                    }*/
                    insm.nonfollowers();
                }
                List<string> items = new List<string>();
                using (TextReader reader = File.OpenText("non_followers.txt"))
                {
                    string line;
                    // read until no more lines are present
                    while ((line = reader.ReadLine()) != null)
                    {
                        items.Add(line);
                    }
                }
                // add the ListBox items in a bulk update instead of one at a time.
                listBox1.DataSource = items;
            }
        }

        private void savbt_Click(object sender, EventArgs e)
        {

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter("non_followers.txt");
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }
        }
    }
}
