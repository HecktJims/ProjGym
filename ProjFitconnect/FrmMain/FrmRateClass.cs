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
        private List<object> list = new List<object>();
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
            using (gymEntities db = new gymEntities())
            {
                var courses = from cr in db.tclass_reserve
                              where cr.member_id == this.member.id
                              where cr.reserve_status == true
                              select cr;

                if (courses.Count() == 0)
                {
                    MessageBox.Show("喔喔~您還沒有上過我們的課程，趕快去選課吧~~");
                    //  TODO    rollback
                    return;
                }

                foreach (var item in courses)
                {
                    var c = from cs in db.tclass_schedule
                            where cs.class_schedule_id == item.class_schedule_id
                            select cs;

                    ClassReservingBox crb = new ClassReservingBox
                    {
                        Size = new System.Drawing.Size(440, 150),
                        tag = item.reserve_id,
                        classname = db.tclasses.FirstOrDefault(x => x.class_id == item.tclass_schedule.class_id).class_name,
                        coachname = db.tIdentity.FirstOrDefault(x => x.id == item.tclass_schedule.coach_id).name,
                        date = db.tclass_schedule.FirstOrDefault(x => x.class_schedule_id == item.class_schedule_id).course_date,
                        time1 = db.ttime_detail.FirstOrDefault(x => x.time_id == item.tclass_schedule.course_time_id1).time_name,
                        time2 = db.ttime_detail.FirstOrDefault(x => x.time_id == item.tclass_schedule.course_time_id2).time_name,
                        price = ((double)db.tclass_schedule.FirstOrDefault(x => x.class_schedule_id == item.class_schedule_id).class_payment),
                        description = string.Empty,
                    };
                    list.Add(crb.classname);
                    list.Add(crb.date);
                    list.Add(crb.coachname);
                    crb.Tag = list;
                    list.Clear();
                    crb.Click += Crb_Click;
                    crb.showinfo();
                    this.splitContainer2.Panel1.Controls.Add(crb);
                }
            }
        }

        private void Crb_Click(object sender, EventArgs e)
        {
            using (gymEntities db = new gymEntities())
            {
                var view = db.tmember_rate_class.FirstOrDefault(x => x.member_id == this.member.id && x.reserve_id == ((ClassReservingBox)sender).tag);
                if (view != null)
                {
                    // set parent, jump etc.
                    rateClassBox rcb = new rateClassBox
                    {
                        classname = ((ClassReservingBox)sender).classname,
                        date = ((ClassReservingBox)sender).date,
                        coachname = ((ClassReservingBox)sender).coachname,
                        rate = ((double)view.rate),
                        classfeedback = view.describe,
                    };

                    this.flowLayoutPanel1.Controls.Add(rcb);
                }
                else
                {
                    rateClassBox rcb = new rateClassBox
                    {
                        classname = ((ClassReservingBox)sender).classname,
                        date = ((ClassReservingBox)sender).date,
                        coachname = ((ClassReservingBox)sender).coachname,
                    };
                    this.flowLayoutPanel1.Controls.Add(rcb);
                }
            }
        }

        private void afterrate()
        {
            // to db
            // show msg
        }
    }
}
