using FrmMain.tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmMain
{
    public partial class FrmRateClass : Form
    {
        public tIdentity member { get;set; }
        public FrmRateClass()
        {
            InitializeComponent();
        }

        private void FrmRateClass_Load(object sender, EventArgs e)
        {
            LoadClasses();
        }

        private void LoadClasses()
        {
            //using (gymEntities db = new gymEntities())
            //{
            //    var 
            //}
            gymEntities db = new gymEntities();
            /*
            int findID = this.member.id;
            var rateClass = from c in db.tclasses
                            join s in db.tclass_schedule on c.class_id equals s.class_id
                            join rc in db.tmember_rate_class on s.class_schedule_id equals rc.class_schedule_id
                            join cr in db.tclass_reserve on s.class_schedule_id equals cr.class_schedule_id
                            join ri in db.tIdentity on cr.member_id equals ri.id
                            join i in db.tIdentity on rc.class_schedule_id equals i.id
                            where rc.member_id == findID && cr.reserve_status == true
                            select new { classes = c, classSchedule = s ,classReserve = cr, identity = ri, memberRateClass = rc ,iidentity = ri };// new { classes = c, classSchedule = s, identity = i, memberRateClass = rc };
            //dataGridView1.DataSource = rateClass.ToList();
            */

            if (rateClass.ToList().Count == 0) MessageBox.Show("喔喔~您還沒有預約課程，趕快去選課吧~~");
            foreach (var item in rateClass)
            {

                rateClassBox rb = new rateClassBox();

                rb.Width = flowLayoutPanel1.Width; // 2 ;
                rb.Height = 400;
                rb.c = item.classes; 
                rb.i = item.identity;
                rb.cs = item.classSchedule;
                rb.rc = item.memberRateClass;
                rb.cr = item.classReserve;
                rb.i = item.iidentity;
                rb.DRateClass += renewRate;
                flowLayoutPanel1.Controls.Add(rb);
            }
        }

        private void renewRate(rateClassBox p)
        {
            using (gymEntities db = new gymEntities())
            {
                
                tmember_rate_class rateclass = db.tmember_rate_class.FirstOrDefault(r => r.member_id == p.i.id && r.class_schedule_id == p.cs.class_schedule_id);
                //將目前資料庫資料讀取出來
                rateclass.rate = Convert.ToDecimal("" + p.rateTextBox.Text);
                
                if (rateclass.rate < 0 || rateclass.rate > 10)
                {
                    MessageBox.Show("請輸入0.0~10之間數值!");
                    return;
                }
                else
                {
                    //複寫評價
                    rateclass.describe = p.FeedbackTextBox.Text;
                    db.SaveChanges();

                    db.Entry(rateclass).Reload();

                    MessageBox.Show("感謝您的評價!");
                    this.flowLayoutPanel1.Controls.Clear();
                    LoadClasses();
                }
            }
        }
    }
}
