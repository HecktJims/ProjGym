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
    public partial class CourseBox : UserControl
    {
        private tIdentity _identity;
        private string _name;
        private string _intro;
        private string _pic;

        public tIdentity setidentity
        {
            get { return _identity; }
            set { _identity = value; }
        }
        public string coursename
        {
            get { return _name; }
            set { _name = value; }
        }
        public string courseintro
        {
            get { return _intro; }
            set { _intro = value; }
        }
        public string coursephoto
        {
            get { return _pic; }
            set { _pic = value; }
        }

        public void loaddata()
        {
            this.lbl_CourseName.Text = coursename;
            this.lbl_CourseIntro.Text = courseintro;
            //  pic
            //pb_CoursePhoto.Image = new Bitmap(Application.StartupPath + "\\ClassPic\\" + value);
        }
        public CourseBox()
        {
            InitializeComponent();
        }
    }
}
