using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Insauf
{
    public partial class textbx : UserControl
    {
        string sbtl;
        public textbx()
        {
            InitializeComponent();
            
        }
        public void settbox(String title, String Subtitle,bool ispass)
        {
            ttl.Text = title;
            mtx.Text = Subtitle;
            sbtl = Subtitle;
            if (ispass == true)
            {
                mtx.UseSystemPasswordChar = true;
            }
        }
        public void setText(String value)
        {
            mtx.Text = value;
        }

        private void Mtx_Enter(object sender, EventArgs e)
        {
            if (mtx.Text == sbtl)
            {
                mtx.Clear();
            }
            lit.BackColor = Color.FromArgb(96, 125, 139);
        }
        
        private void Mtx_Leave(object sender, EventArgs e)
        {
            if(mtx.TextLength==0)
            {
                mtx.Text = sbtl;
            }
            lit.BackColor = Color.FromArgb(0, 150, 136);
        }

        private void Textbx_Load(object sender, EventArgs e)
        {

        }
        public void Mtx_ReadOnly()
        {
            mtx.ReadOnly = true;
        }
        public string getText()
        {
            return mtx.Text;
        }
        public int getTextLength()
        {
            return mtx.TextLength;
        }
        public void clearText()
        {
            mtx.Clear();
        }

        private void mtx_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
 
}
