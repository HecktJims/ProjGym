using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmMain.tool
{
    public partial class ClassReservingBox : UserControl
    {
        public ClassReservingBox()
        {
            InitializeComponent();
        }
        public void showinfo()
        {
            this.lbClassName.Text = classname;
            this.lbCoachName.Text = coachname;
            this.lbDate.Text = date.ToString("M");
            this.lbTime.Text = $"{time1} ~ {time2}";
            this.lbPrice.Text = "NT " + $"{price:d2}" + " $";
            this.lbDescription.Text = description;  //文字編輯
            //this.pictureBox1                      //照片
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private tIdentity _identity;
        private string _classname;
        private string _coachname;
        private DateTime _date;
        private string _time1;
        private string _time2;
        private double _price;
        private string _desc;
        private string _pic;

        public tIdentity Identity
        {
            get { return this._identity; }
            set { this._identity = value; }
        }
        public string classname
        {
            get { return _classname; }
            set { _classname = value; }
        }
        public string coachname
        {
            get { return _coachname; }
            set { _coachname = value; }
        }
        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string time1
        {
            get { return _time1; }
            set { _time1 = value; }
        }
        public string time2
        {
            get { return _time2; }
            set { _time2 = value; }
        }
        public double price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string description
        {
            get { return _desc; }
            set { _desc = value; }
        }
        public string picture
        {
            get { return _pic; }
            set { _pic = value; }
        }
    }
}
