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
    public partial class userabsence : Form
    {
        string username;
        string id="2201";
        Sunisoft.IrisSkin.SkinEngine skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
        public userabsence(string name)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"/Skins/Calmness.ssk";
            InitializeComponent();
            username=name ;
 
        }

        absenceDocument dp = new absenceDocument();
       
        private void button4_Click(object sender, EventArgs e)
        {
            if (dp.GetList3(username,comboBox_type.Text.Trim()).Count!=0)
            {
                var quiryD = dp.GetList3(username, comboBox_type.Text.Trim());
                dataGridView1.DataSource = quiryD;
                MessageBox.Show("查询成功");
            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次查询", "提示信息");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dp.Add(id,"孔涛",comboBox_type.Text.Trim(),dateTimePicker1.Value,dateTimePicker2.Value))
            {
                var quiryD = dp.GetList3(username, comboBox_type.Text.Trim());
                dataGridView1.DataSource = quiryD;
                MessageBox.Show("添加成功");
                
            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次查询", "提示信息");
            }
            dataGridView1.DataSource = dp.GetList(username,"");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dp.Edit2(username,comboBox_type.Text.Trim(),dateTimePicker1.Value,dateTimePicker2.Value))
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次修改", "提示信息");
            }
            dataGridView1.DataSource = dp.GetList2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dp.Remove(username))
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次修改", "提示信息");
            }
            dataGridView1.DataSource = dp.GetList2();
        }

        private void userabsence_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dp.GetList(username, "");
        }
    }
}
