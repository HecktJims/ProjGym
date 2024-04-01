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

    public partial class FrmMain : Form
    {
        //設置主表單一個名為member的屬性，用來記錄目前的[登入者]
        public tIdentity member { get; set; }

        //FrmMain的建構子，在new FrmMain()時被執行
        public FrmMain()
        {
            InitializeComponent();
            //this.教練ToolStripMenuItem.Visible = false;
        }

        //關閉前一個form
        private void closeCurrentForm()
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        //[主程式]表單在載入階段要做的事情(此時的主程式還沒顯示在畫面上)
        private void FrmMain_Load(object sender, EventArgs e)
        {
            MainLogin();
        }

        private void MainLogin()
        {
            //將首頁的Info文字設為空字串
            lbl_Info.Text = string.Empty;
            //載入主程式前，先新增[登入頁面]
            FrmLogin frmLogin = new FrmLogin();
            //在[登入頁面]表單的afterLogin事件上，註冊showinfo方法，觸發條件:當[登入頁面]的[登入]按鈕被按下時，執行showinfo
            frmLogin.afterLogin += this.showinfo;
            //將[登入頁面]顯示出來，並禁止使用者與其他視窗互動
            frmLogin.ShowDialog();
        }

        //處理首頁Info文字的內容(用來顯示使用者基本資料)
        private void showinfo(tIdentity m)//m為[登入頁面]表單傳回的一筆[登入者]資料
        {
            //將m記錄在[主程式]表單的member屬性
            //任何子表單都可以透過MdiParent屬性找到[主程式]表單
            //再利用[主程式]表單的member屬性，找到當前的[登入者]資料
            this.member = m;
            //將Info設為可視
            lbl_Info.Visible = true;
            //產生[gym資料庫實體]
            gymEntities db = new gymEntities();
            //利用m的性別ID，找出ID對應的真實性別(g為m的性別ID所對應到的資料行)
            tgender_Table g = db.tgender_Table.FirstOrDefault(x => x.gender_id == m.gender_id);
            //將m的名稱、生日、電話、地址、信箱屬性與g的性別名稱屬性，寫入Info的Text屬性
            this.lbl_Info.Text = $"會員名稱: {m.name}\r\n" +
                $"生日: {m.birthday.ToString("yyyy/MM/dd")}\r\n" +
                $"性別: {g.gender_text}\r\n" +
                $"電話: {m.phone}\r\n" +
                $"地址: {m.address}\r\n" +
                $"信箱: {m.e_mail}";
        }

        private void 修改會員資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //先關閉前一個視窗
            closeCurrentForm();
            //將Info設為隱藏
            lbl_Info.Visible = false;
            //新增一個[編輯會員資料]表單
            FrmEditMemberRegister editMemberRegister = new FrmEditMemberRegister();
            //在[編輯會員資料]表單上，註冊showinfo方法，觸發條件:當[編輯會員資料]表單的[保存]按鈕被按下時，執行showinfo
            editMemberRegister.afterEdit += this.showinfo;
            //將新增的[編輯會員資料]表單設為[主程式]表單的子表單
            //讓[編輯會員資料]可以透過MdiParent屬性找到[主程式]表單
            //再利用[主程式]表單的member屬性，取得當前的[登入者]資料
            //取得的[登入者]資料就可以寫入到[編輯會員資料]表單內的欄位
            editMemberRegister.StartPosition = FormStartPosition.CenterParent;
            editMemberRegister.MdiParent = this;
            editMemberRegister.Show();
        }

        private void toolStripButton_LogOut_Click(object sender, EventArgs e)
        {
            DialogResult Logout = MessageBox.Show("確定要登出？", "", MessageBoxButtons.OKCancel);
            if (Logout != DialogResult.OK)
                return;
            this.member = null;
            MainLogin();
        }

        private void 新增課程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeCurrentForm();
            lbl_Info.Visible = false;
            FrmOpenClass f = new FrmOpenClass();
            //f.StartPosition = FormStartPosition.CenterParent;
            //f.WindowState = FormWindowState.Maximized;
            //f.MdiParent = this;
            f.ShowDialog();
            if (f.isOk != DialogResult.OK)
                return;
            tclass_schedule s = f.schedule;
            gymEntities gym = new gymEntities();
            gym.tclass_schedule.Add(s);
            gym.SaveChanges();
        }
    }
}