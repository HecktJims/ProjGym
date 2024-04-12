using mid_Coonect.Tools;
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

namespace FrmMain.tool
{
    public partial class rateClassBox : UserControl
    {
        public rateClassBox()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private tIdentity _identity;
        private string _name;
        private DateTime _date;
        private string _cname;
        private double _rate;
        private string _words;

        public tIdentity identity
        {
            get { return _identity; }
            set { _identity = value; }
        }
        public string classname
        {
            get { return _name; }
            set { _name = value; }
        }
        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string coachname
        {
            get { return _cname; }
            set { _cname = value; }
        }
        public double rate
        {
            get { return _rate; }
            set { _rate = value; }
        }
        public string classfeedback
        {
            get { return _words; }
            set { _words = value; }
        }
    }
}
