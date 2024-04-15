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
            initinput();
        }
        public void loaddata()
        {
            this.lblClassName.Text = classname;
            this.lblDate.Text = date.ToString("M");
            this.lblCoach.Text = coachname;
            this.txtFeedback.Text = classfeedback;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //_isOK
        }
        public int ratevalue()
        {
            int score = this.cb.SelectedIndex + 1;
            if (score == -1)
            {
                this.lblError.Visible = true;
                return -1;
            }
            this.lblError.Visible = false;
            rate = (double)score;
            return score;
        }
        private void initinput()
        {
            this.lblError.Visible = false;
            cb = new ComboBox
            {
                DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList,
                FormattingEnabled = true,
                Location = new System.Drawing.Point(134, 180),
                Size = new System.Drawing.Size(94, 20),
                TabIndex = 1,
            };
            this.txtFeedback.TabIndex = 2;
            this.button3.TabIndex = 3;

            for (int i = 1; i <= 10; i++)
            {
                cb.Items.Add(i.ToString());
            }
            cb.Text = "請下拉評分";
        }

        private tIdentity _identity;
        private string _name;
        private DateTime _date;
        private string _cname;
        private double _rate;
        private string _words;
        ComboBox cb;
        private bool _isOK = false;

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
