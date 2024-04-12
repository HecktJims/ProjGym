using FrmMain.tool;
using mid_Coonect.Tools;
using ProjGym;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FrmMain
{
    public delegate void DReserve(tIdentity m);
    public partial class FrmReservingClasses : Form
    {
        public tIdentity Identity { get; set; }

        public FrmReservingClasses()
        {
            InitializeComponent();
        }

        private void FrmReservingClasses_Load(object sender, EventArgs e)
        {
            CreateCategory();
        } 

        private void CreateCategory()
        {
            gymEntities db= new gymEntities();  
            var classCategories = from classCategory in db.tclass_sort_訓練
                                  select classCategory;
            classCategories.ToList().ForEach(category =>
            {
                System.Windows.Forms.CheckBox c = new System.Windows.Forms.CheckBox();
                c.Font = new Font("微軟正黑體", 14, FontStyle.Bold);
                c.AutoSize = true;
                c.Text = category.class_sort2_detail;
                c.Tag = category.class_sort2_detail;
                c.CheckStateChanged += CheckBox訓練Selected;
                this.flowLayoutPanel_ClassCategory.Controls.Add(c); 
            });
        }
         
        private void CheckBox訓練Selected(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox chb = (System.Windows.Forms.CheckBox)sender;
            if (chb.Checked)
            {
                gymEntities db = new gymEntities();
                string TrainClass = chb.Tag.ToString();
                var ReservingClasses = from s in db.tclass_schedule
                                       join c in db.tclasses on s.class_id equals c.class_id
                                       join t in db.ttimes_detail on s.course_time_id equals t.time_id
                                       join i in db.tIdentity on s.coach_id equals i.id
                                       join n in db.tclass_sort_訓練 on c.class_sort2_id equals n.class_sort2_id
                                       where n.class_sort2_detail.Equals(TrainClass)
                                       select new { classes = c, classSchedule = s, identity = i, time = t };
                foreach (var item in ReservingClasses)
                {
                    ClassReservingBox rb = new ClassReservingBox();
                    //rb.Width = flowLayoutPanel1.Width * 3 / 4;
                    //rb.tc = item.classes;
                    //rb.i = item.identity;
                    //rb.ts = item.classSchedule;
                    //rb.td = item.time;
                    //rb.train = item.classes.tclass_sort_訓練;
                    //rb.reserveConfirm += this.confirm;
                    //if (flowLayoutPanel1.Controls.Equals(rb)) return;
                    //flowLayoutPanel1.Controls.Add(rb);
                }
            }
            else
            {
                string TrainClass = chb.Tag.ToString();
                for (int i = flowLayoutPanel1.Controls.Count - 1; i >= 0; i--)
                { 
                    if (flowLayoutPanel1.Controls[i] is ClassReservingBox rb &&rb.train!=null&& rb.train.class_sort2_detail.Equals(TrainClass))
                    {
                        flowLayoutPanel1.Controls.Remove(rb);
                        rb.Dispose();
                    } 
                }
            }
        }

        private void CheckBoxOxygenSelected(int o)
        {
            gymEntities db = new gymEntities();

            var ReservingClasses = from s in db.tclass_schedule
                                   join c in db.tclasses on s.class_id equals c.class_id
                                   join t in db.ttimes_detail on s.course_time_id equals t.time_id
                                   join i in db.tIdentity on s.coach_id equals i.id
                                   where c.class_sort1_id == o
                                   select new { classes = c, classSchedule = s, identity = i, time = t };
            foreach (var item in ReservingClasses)
            {
                ClassReservingBox rb = new ClassReservingBox();
                //rb.Width = flowLayoutPanel1.Width * 3 / 4;
                //rb.tc = item.classes;
                //rb.i = item.identity;
                //rb.ts = item.classSchedule;
                //rb.td = item.time; 
                //if (flowLayoutPanel1.Controls.Equals(rb)) return;
                //flowLayoutPanel1.Controls.Add(rb);
                //rb.reserveConfirm += this.confirm;
            }
        }

        private void UndoOxygen(int o)
        {
            for (int i = flowLayoutPanel1.Controls.Count - 1; i >= 0; i--)
            {
                if (flowLayoutPanel1.Controls[i] is ClassReservingBox rb && rb.tc.class_sort1_id == o)
                {
                    flowLayoutPanel1.Controls.Remove(rb);
                    rb.Dispose();
                }
            }
        }

        private void ShowOpenedClasses()
        {
            gymEntities db = new gymEntities();

            var ReservingClasses = from s in db.tclass_schedule
                                   join c in db.tclasses on s.class_id equals c.class_id
                                   join t in db.ttimes_detail on s.course_time_id equals t.time_id
                                   join i in db.tIdentity on s.coach_id equals i.id
                                   select new { classes = c, classSchedule = s, identity = i, time = t };
            foreach (var item in ReservingClasses)
            {
                ClassReservingBox rb = new ClassReservingBox();
                //rb.Width = flowLayoutPanel1.Width * 3 / 4;
                //rb.tc = item.classes;
                //rb.i = item.identity;
                //rb.ts = item.classSchedule;
                //rb.td = item.time;
                //flowLayoutPanel1.Controls.Add(rb);
                //rb.reserveConfirm += this.confirm;
            }
        }

        private void confirm(ClassReservingBox p)
        {
            if (Identity == null) { MessageBox.Show("請登入會員"); return; }
            gymEntities db = new gymEntities();
            int index = this.Identity.id;
            tIdentity i=db.tIdentity.FirstOrDefault(x => x.id == index);
            if (i.role_id != 1) { MessageBox.Show("您的身分並非會員, 無法預約課程");return; }
            tclass_reserve cr = new tclass_reserve();

            cr.class_schedule_id = p.ts.class_schedule_id;
            cr.member_id = index;
            cr.payment_status = false;
            cr.reserve_status = true;
            db.tclass_reserve.Add(cr);

            if (afterCourseSubmit() == 0)
            {
                db.SaveChanges();
                MessageBox.Show("   課程預約成功!"+"\n請於期限內完成繳費"); 
            } else return;
        }

        private int afterCourseSubmit()
        {
            DialogResult result = MessageBox.Show("是否確定預約此課程", "預約課程", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK) { return 0; }
            else { return -1; }
        }

        private void checkBox0_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox0.Checked) ShowOpenedClasses();
            else flowLayoutPanel1.Controls.Clear();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            int o = 1;
            if (checkBox1.Checked) CheckBoxOxygenSelected(o);
            else UndoOxygen(o);
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            int o = 2;
            if (checkBox2.Checked) CheckBoxOxygenSelected(o);
            else UndoOxygen(o);
        }
         
    }
}
