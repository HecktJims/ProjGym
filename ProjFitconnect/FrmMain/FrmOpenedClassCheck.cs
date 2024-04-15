using FrmMain.tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmMain
{
    public partial class FrmOpenedClassCheck : Form
    {
        public tIdentity coach { get; set; }
        public FrmOpenedClassCheck()
        {
            InitializeComponent();
        }

        private void FrmOpenedClassCheck_Load(object sender, EventArgs e)
        {
            if (this.coach.role_id != 2)
            {
                MessageBox.Show("並非以教練身份登入!");
                this.Close();
                return;
            }
            using (gymEntities db = new gymEntities())
            {
                var opened = from cs in db.tclass_schedule
                             where cs.coach_id == this.coach.id
                             where cs.course_date > DateTime.Now
                             select cs;

                foreach (var item in opened)
                {
                    ReservedMemberCheck rmc = new ReservedMemberCheck();
                    rmc.classname = db.tclasses.FirstOrDefault(x => x.class_id == item.class_id).class_name;
                    rmc.floor = db.tfield.FirstOrDefault(x => x.field_id == item.field_id).floor;
                    rmc.field = db.tfield.FirstOrDefault(x => x.field_id == item.field_id).field_name;
                    rmc.date = item.course_date;
                    rmc.classmember = db.tclass_reserve.Count(x => x.class_schedule_id == item.class_schedule_id);
                    rmc.maxpeople = item.Max_student;

                    int L = db.ttimes_detail.FirstOrDefault(x => x.time_id == item.course_time_id).time_name.Length;
                    rmc.time1 = db.ttimes_detail.FirstOrDefault(x => x.time_id == item.course_time_id).time_name.Substring(0, 5);
                    rmc.time2 = db.ttimes_detail.FirstOrDefault(x => x.time_id == item.course_time_id).time_name.Substring(L - 5, 5);

                    rmc.showinfo();
                    flowLayoutPanel1.Controls.Add(rmc);
                }
            }
            /*
            var classreserved = from c in db.tclasses
                                join s in db.tclass_schedule on c.class_id equals s.class_id
                                join t in db.ttimes_detail on s.course_time_id equals t.time_id
                                join r in db.tclass_reserve on s.class_schedule_id equals r.class_schedule_id
                                join i in db.tIdentity on r.member_id equals i.id
                                join f in db.tfield on s.field_id equals f.field_id
                                where s.coach_id == index//todo#0 returnCoachID
                                select new { classes = c, classSchedule = s, time = t, field = f };
            */
        }
    }
}
