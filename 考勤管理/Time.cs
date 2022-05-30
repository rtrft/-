using Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 考勤管理
{
    public partial class Time : Form
    {
        public Time()
        {
            InitializeComponent();
        }
        TimeDocument ti = new TimeDocument();
        private void button1_Click(object sender, EventArgs e)
        {
            if (ti.Edit(dateTimePicker1.Value, dateTimePicker2.Value, dateTimePicker3.Value, dateTimePicker4.Value))
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次修改", "提示信息");
            }
        }
    }
}
