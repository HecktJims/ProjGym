using FrmMain;
using Gym;
using mid_Coonect;
using Revised_V1._1;
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
        Label lblWelcome;

        public FrmHomePage()
        {
            InitializeComponent();
            splitContainer1.SplitterWidth = 3;
            this.管理者中心ToolStripMenuItem.Visible = false;
            this.lbl_Info.Visible = false;
        }

        private void FrmHomePage_Load_1(object sender, EventArgs e)
        { 
            //MainLog();
            //showinfo(this.identity);
            this.identity = null;
            showmain();
        }

        private void MainLog()
        {
            FrmLogin f = new FrmLogin();
            f.afterLogin += this.showinfo;
            f.ShowDialog();
            if (f.isOK != DialogResult.OK) return; 
            this.登入ToolStripMenuItem.Visible = false;
        }
        private void closeCurrentForm()
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        private void 首頁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showmain();
        }

        private void 修改會員資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmEditMemberRegister f = new FrmEditMemberRegister();
            f.member = this.identity; 
            f.afterEdit += this.showinfo;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }

        private void showinfo(tIdentity m)
        {
            if (m == null) return;
            this.identity = m;

            if (m.role_id == 1)
                info_member(m);
            if (m.role_id == 2)
                info_coach(m);
            if (m.role_id == 3)
                info_admin(m);
        }

        private void info_member(tIdentity m)
        {
            this.會員中心ToolStripMenuItem.Visible = true;
            this.教練中心ToolStripMenuItem.Visible = false;
            this.管理者中心ToolStripMenuItem.Visible = false;
            lblWecomeshow(m);
            this.Text = "歡迎登入 ： " + m.name;
        }

        private void lblWecomeshow(tIdentity m)
        {
            if (identity == null) return;
            Label lblWelcome = new Label();
            string s = "歡迎登入 ： " + m.name;
            if (m.role_id == 1)
                s += "\n您的身份是：會員";
            else if (m.role_id == 2)
                s += "\n您的身份是：教練";
            else
                s += "\n您的身份是：管理者";
            lblWelcome.Text = s;
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            lblWelcome.Font = new Font("微軟正黑體", 20, FontStyle.Bold);
            lblWelcome.ForeColor = Color.Blue;
            lblWelcome.AutoSize = true;
            lblWelcome.MaximumSize = new Size(this.splitContainer1.Panel2.Width, 0);

            int x = (splitContainer1.Panel2.Width - lblWelcome.Width) / 2;
            int y = (splitContainer1.Panel2.Height - lblWelcome.Height) / 2;
            lblWelcome.Location = new Point(x, y);

            this.splitContainer1.Panel2.Controls.Add(lblWelcome);
        }

        private void info_coach(tIdentity m)
        {
            this.會員中心ToolStripMenuItem.Visible = false;
            this.教練中心ToolStripMenuItem.Visible = true;
            this.管理者中心ToolStripMenuItem.Visible = false;

            lblWecomeshow(m);
            this.Text = "歡迎登入 ： " + m.name;
        }

        private void info_admin(tIdentity m)
        {
            this.會員中心ToolStripMenuItem.Visible = false;
            this.教練中心ToolStripMenuItem.Visible = false;
            this.管理者中心ToolStripMenuItem.Visible = true;

            lblWecomeshow(m);
            this.Text = "歡迎登入 ： " + m.name;
        }

        private void 常見問題ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmFAQ f = new FrmFAQ();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }

        private void 新增管理者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewAdminRegister frm = new FrmNewAdminRegister();
            frm.savedata += FrmAdmin_register;
            frm.TopLevel = false;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.Show(); 
            if (frm.result == DialogResult.No)
                return;
        }

        private void FrmAdmin_register(FrmNewAdminRegister frm)
        {
            gymEntities db = new gymEntities();
            tIdentity admin = new tIdentity();

            int admin_count = db.tIdentity.Count(x => x.role_id.Equals(3)) + 1;
            admin.role_id = 3;
            admin.name = $"Admin {admin_count}";
            admin.phone = frm.phone;
            admin.e_mail = "x";
            admin.password = frm.password;
            admin.photo = "x";
            admin.birthday = DateTime.Now;
            admin.address = "x";
            admin.gender_id = 3;
            admin.activated = true;
            db.tIdentity.Add(admin);
            db.SaveChanges();

            MessageBox.Show("新增管理員完成");
        }


        private void logoutevent()
        {
            DialogResult Logout = MessageBox.Show("確定要登出？", "", MessageBoxButtons.OKCancel);
            if (Logout != DialogResult.OK) return;
            this.identity = null;
            this.lblWelcome = null;
            showmain();
            this.登入ToolStripMenuItem.Visible = true;
        }

        private void showmain()
        {
            this.splitContainer1.Panel2.Controls.Clear();
            Frm_首頁 mm = new Frm_首頁();
            mm.identity = this.identity;
            mm.TopLevel = false;
            mm.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(mm);
            mm.Show();
        }

        private void 已預約課程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmClassReserved f = new FrmClassReserved();
            f.MdiParent = this;
            f.identity = this.identity;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }

        private void 找教練ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmFindCoach f = new FrmFindCoach();
            f.identity = this.identity;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }

        private void yOUTUBEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }

        private void 預約體驗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmfreetrial f = new Frmfreetrial();
            f.identity = this.identity;
            f.Show(); 
        }

        private void 新增課程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmCoach_AddNewCourse f = new FrmCoach_AddNewCourse();
            f.coach = this.identity;
            f.MdiParent = this;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }

        private void 開課審核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmAdmin_ClassUpdate f = new FrmAdmin_ClassUpdate();
            f.MdiParent = this;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            f.Visible = true;

            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }
        private void 訓練課程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmReservingClasses f = new FrmReservingClasses();
            f.Identity = this.identity; 
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }

        private void 預約場地ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmOpenedClassCheck f = new FrmOpenedClassCheck();
            f.MdiParent = this;
            f.coach = this.identity;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }
        private void Identity_Click(object sender, EventArgs e)
        {
            if (identity == null) {MessageBox.Show("請登入會員"); MainLog(); }
            else
            {
                this.splitContainer1.Panel2.Controls.Clear();
                lblWecomeshow(this.identity);
            }
        }

        private void 教練審核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmCoachVerify f = new FrmCoachVerify();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }

        private void 修改教練資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmEditCoachRegister f = new FrmEditCoachRegister();
            f.TopLevel = false;
            f.identity = this.identity;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        } 

        private void 會員資訊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmAdmin_Checkmember f = new FrmAdmin_Checkmember();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }

        private void 登出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (identity == null) return;
            this.Text = "Fitnessconnect 健身媒合平台";
            this.會員中心ToolStripMenuItem.Visible = true;
            this.教練中心ToolStripMenuItem.Visible = true;
            this.管理者中心ToolStripMenuItem.Visible = false;
            logoutevent();
        }

        private void 登入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainLog();
            showinfo(this.identity);
            showmain();
        }

        private void 對教練ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmFollow f = new FrmFollow();
            f.MdiParent = this;
            f.identity = this.identity;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }

        private void 付款資訊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmAdmin_Payment f = new FrmAdmin_Payment();
            f.MdiParent = this;
            f.Identity = this.identity; 
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None; 
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();

            this.splitContainer1.Panel2.Controls.Add(f);
        }

        private void 對課程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmRateClass f = new FrmRateClass();
            f.MdiParent = this;
            f.member = this.identity;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }

        private void 場地付款資訊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmCoach_Payment f = new FrmCoach_Payment();
            f.MdiParent = this;
            f.TopLevel = false;
            f.identity = this.identity;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }

        private void 新增場地ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmField f = new FrmField();
            f.MdiParent = this;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }
    }
}
