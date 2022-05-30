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
    public partial class absence : Form
    {
        Sunisoft.IrisSkin.SkinEngine skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
        public absence()
        {
            skinEngine1.SkinFile = Application.StartupPath + @"/Skins/Calmness.ssk";
            InitializeComponent();
            dataGridView1.DataSource = dp.GetList2();
            absence_col();
        }
        absenceDocument dp = new absenceDocument();
        private void button2_Click(object sender, EventArgs e)
        {
            if (dp.GetList(textB_sno.Text.ToString().Trim(),textB_Name.Text.ToString().Trim()).Count != 0)
            {
                var quiryD = dp.GetList(textB_sno.Text.ToString().Trim(), textB_Name.Text.ToString().Trim());
                textB_sno.Text = quiryD[0].A_id;
                textB_Name.Text = quiryD[0].A_name;
                textB_major.Text = quiryD[0].A_type;
                dataGridView1.DataSource = quiryD;
                absence_col();
                MessageBox.Show("查询成功");
            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次查询", "提示信息");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dp.Edit(textB_sno.Text.ToString().Trim(), comboBox1.Text.ToString().Trim()))
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次修改", "提示信息");
            }
            dataGridView1.DataSource = dp.GetList2();
            absence_col();
        }

        public void absence_col()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "工号";
            dataGridView1.Columns[1].HeaderCell.Value = "姓名";
            dataGridView1.Columns[2].HeaderCell.Value = "类型";
            dataGridView1.Columns[3].HeaderCell.Value = "开始时间";
            dataGridView1.Columns[4].HeaderCell.Value = "结束时间";
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
