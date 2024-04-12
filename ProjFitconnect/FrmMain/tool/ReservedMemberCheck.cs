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
    public partial class ReservedMemberCheck : UserControl
    {
        public void showinfo()
        {
            this.lbClassName.Text = classname;
            this.lbFloor.Text = floor;
            this.lbField.Text = field;
            this.lbDate.Text = date.ToString("M");
            this.lbTime.Text = $"{time1} ~ {time2}";
            this.lbMemberCount.Text = classmember.ToString();
            this.lbMAXcount.Text = "/ " + maxpeople;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private tIdentity _identity;
        private string _name;
        private int _person;
        private int _max;
        private string _floor;
        private string _field;
        private DateTime _date;
        private string _time1;
        private string _time2;

        public tIdentity Identity
        {
            get { return this._identity; }
            set { this._identity = value; }
        }
        public string classname
        {
            get { return _name; }
            set { _name = value; }
        }
        public int classmember
        {
            get { return _person; }
            set { _person = value; }
        }
        public int maxpeople
        {
            get { return _max; }
            set { _max = value; }
        }
        public string floor
        {
            get { return _floor; }
            set { _floor = value; }
        }
        public string field
        {
            get { return _field; }
            set { _field = value; }
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
    }
}
