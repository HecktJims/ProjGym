using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjGym
{
    public partial class FrmNewAdminRegister : Form
    {
        public delegate void D3(FrmNewAdminRegister frm);
        public FrmNewAdminRegister()
        {
            InitializeComponent();
        }
        public event D3 savedata;
        public string phone { get { return this.tb_Name.Text.ToString(); } }
        public string password { get { return this.tb_Password.Text.ToString(); } }
        public DialogResult result { get; set; }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            this.result = DialogResult.OK;
            if (this.savedata != null)
            {
                savedata(this);
            }
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.result = DialogResult.No;
            this.Close();
        }
    }
}
