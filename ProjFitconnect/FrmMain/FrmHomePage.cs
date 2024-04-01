using FrmMain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjGym
{
    public partial class FrmHomePage : Form
    {
        public tIdentity identity { get; set; }

        public FrmHomePage()
        {
            InitializeComponent();
            splitContainer1.SplitterWidth = 3;
            //OpenLoginForm();

        }
        /*
        private void OpenLoginForm()
        {
            FrmLogin loginForm = new FrmLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                FrmMain courseForm = new FrmMain();
                courseForm.MdiParent = this;
                courseForm.Show();
            }
            else
            {
                Application.Exit(); // 如果取消登入，關閉應用程式
            }
        } 
        */
        private void 首頁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            Frm_首頁 mm = new Frm_首頁();
            mm.TopLevel = false;
            mm.FormBorderStyle =FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add( mm );
            mm.Show();
        }

        private void 修改會員資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeCurrentForm();
            lbl_Info.Visible = false;

            FrmEditMemberRegister frm = new FrmEditMemberRegister();
            frm.afterEdit += this.showinfo;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.MdiParent = this;
            frm.Show();
        }

        private void showinfo(tIdentity m)
        {
            if (m.role_id == 1)
                showmember(m);
            if (m.role_id == 2)
                showcoach(m);
            if (m.role_id == 3)
                showadmin(m);
        }

        private void closeCurrentForm()
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        private void 常見問題ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmFAQ fAQ = new FrmFAQ();
            fAQ.TopLevel = false;
            fAQ.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(fAQ);
            fAQ.Show();
        }
        /*
        private void FrmHomePage_Load_1(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
            frmLogin.afterLogin += this.showinfo;
            if (frmLogin.isOK != DialogResult.OK)
                return;
            this.Visible = true;
            lbl_Info.Text = string.Empty;
        }
        */
        private void 會員登出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logoutevent();
            MainLogin();
        }

        private void logoutevent()
        {
            DialogResult Logout = MessageBox.Show("確定要登出？", "", MessageBoxButtons.OKCancel);
            if (Logout != DialogResult.OK)
                return;
            this.identity = null;
        }

        private void FrmHomePage_Load(object sender, EventArgs e)
        {
            MainLogin();
        }

        private void MainLogin()
        {
            lbl_Info.Text = string.Empty;
            FrmLogin frm = new FrmLogin();
            frm.afterLogin += this.showinfo;
            frm.ShowDialog();
        }

        private void getidentityrole(int i)
        {

        }

        private void showmember(tIdentity m)
        {
            this.identity = m;
            //getidentityrole(m.role_id);

            this.教練中心ToolStripMenuItem.Visible = false;
            this.管理者中心ToolStripMenuItem.Visible = false;

            lbl_Info.Visible = true;
            gymEntities db = new gymEntities();
            tgender_Table g = db.tgender_Table.FirstOrDefault(x => x.gender_id == m.gender_id);
            //this.lbl_Info.Text =
            //    $"歡迎登入，會員： {m.name}\r\n" +
            //    $"生日: {m.birthday.ToString("yyyy/MM/dd")}\r\n" +
            //    $"性別: {g.gender_text}\r\n" +
            //    $"電話: {m.phone}\r\n" +
            //    $"地址: {m.address}\r\n" +
            //    $"信箱: {m.e_mail}";
        }
        private void showcoach(tIdentity m)
        {
            this.identity = m;
            //getidentityrole(m.role_id);

            this.會員中心ToolStripMenuItem.Visible = false;
            this.管理者中心ToolStripMenuItem.Visible = false;

            lbl_Info.Visible = true;
            gymEntities db = new gymEntities();
            tgender_Table g = db.tgender_Table.FirstOrDefault(x => x.gender_id == m.gender_id);
            //this.lbl_Info.Text =
            //    $" {m.name} 教練，您好\r\n" +
            //    $"生日: {m.birthday.ToString("yyyy/MM/dd")}\r\n" +
            //    $"性別: {g.gender_text}\r\n" +
            //    $"電話: {m.phone}\r\n" +
            //    $"地址: {m.address}\r\n" +
            //    $"信箱: {m.e_mail}";
        }
        private void showadmin(tIdentity m)
        {
            this.identity = m;
            //getidentityrole(m.role_id);

            lbl_Info.Visible = true;
            gymEntities db = new gymEntities();
            tgender_Table g = db.tgender_Table.FirstOrDefault(x => x.gender_id == m.gender_id);
            //this.lbl_Info.Text =
            //    $"歡迎登入： {m.name}\r\n" +
            //    $"帳號註冊時間: {m.birthday.ToString("yyyy/MM/dd")}\r\n";
        }

        private void 新增課程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOpenClass f = new FrmOpenClass();
            f.ShowDialog();
            if (f.isOk != DialogResult.OK)
                return;
            tclass_schedule s = f.schedule;
            gymEntities db = new gymEntities();
            db.tclass_schedule.Add(s);
            db.SaveChanges();
        }

        private void 帳號登出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logoutevent();
            MainLogin();
        }
    }
}
