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
using Model;
namespace 考勤管理
{
    public partial class userkaoqin : Form
    {
        string name;
        Sunisoft.IrisSkin.SkinEngine skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
        public userkaoqin(string username)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"/Skins/Calmness.ssk";
            InitializeComponent();
            name = username;
            dataGridView1.DataSource = staff.GetList("",name,"");
        }

        kaoqinDocument staff = new kaoqinDocument();

        private void button2_Click(object sender, EventArgs e)
        {

            if (staff.GetList("",name,"").Count != 0)
            {
                var quiryD = staff.GetList("", name, "");
                MessageBox.Show("查询成功");
                dataGridView1.DataSource = quiryD;
            }
            else
            {
                MessageBox.Show("无考勤记录", "提示信息");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (staff.GetList3(name,"迟到").Count != 0)
            {
                var quiryD = staff.GetList3(name, "迟到");
                MessageBox.Show("查询成功");
                dataGridView1.DataSource = quiryD;
            }
            else
            {
                MessageBox.Show("无迟到记录", "提示信息");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (staff.GetList3(name, "缺勤").Count != 0)
            {
                var quiryD = staff.GetList3(name, "缺勤");
                MessageBox.Show("查询成功");
                dataGridView1.DataSource = quiryD;
            }
            else
            {
                MessageBox.Show("缺勤记录", "提示信息");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (staff.GetList3(name, "正常").Count != 0)
            {
                var quiryD = staff.GetList3(name, "正常");
                MessageBox.Show("查询成功");
                dataGridView1.DataSource = quiryD;
            }
            else
            {
                MessageBox.Show("无正常考勤记录", "提示信息");
            }
        }
    }
}
