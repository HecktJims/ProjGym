using FrmMain;
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

namespace mid_Coonect.Tools
{
    public partial class CoachBox : UserControl
    {
        public CoachBox()
        {
            InitializeComponent();
            this.btnCourse.Visible = false;
        }
        public void loaddata()
        {
            this.labelCoachName.Text = coachname;
            this.labelGender.Text = "性別： " + gender;
            this.labelCourse.Text = course;
            this.lbclassinfo.Text = classintro;
            //picture
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private tIdentity _identity;
        private string _name;
        private string _sex;
        private string _course;
        private string _intro;
        private string _pic;

        public tIdentity Identity
        {
            get { return this._identity; }
            set { this._identity = value; }
        }
        public string coachname
        {
            get { return _name; }
            set { _name = value; }
        }
        public string gender
        {
            get { return _sex; }
            set { _sex = value; }
        }
        public string course
        {
            get { return _course; }
            set { _course = value; }
        }
        public string classintro
        {
            get { return _intro; }
            set { _intro = value; }
        }
        public string picture
        {
            get { return _pic; }
            set { _pic = value; }
        }   
    }
}
