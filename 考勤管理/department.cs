using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bll;
namespace 考勤管理
{
    public partial class department : Form
    {
        Sunisoft.IrisSkin.SkinEngine skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
        departmentDocument dp = new departmentDocument();
        public department()
        {
            skinEngine1.SkinFile = Application.StartupPath + @"/Skins/Calmness.ssk";
           
            InitializeComponent();
        }


        
        private void button1_Click(object sender, EventArgs e)
        {

            if (dp.Add(textB_Id.Text.Trim(), textB_Name.Text.Trim(), textB_Load.Text.Trim(), textB_Place.Text.Trim()))
            {
                MessageBox.Show("插入成功");
            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次插入", "提示信息");
            }
            dataGridView1.DataSource = dp.GetList2();
            department_col();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textB_Id.Text.Trim() != ""|| textB_Name.Text.Trim()!="")
            {
                if (dp.GetList(textB_Id.Text.Trim(), textB_Name.Text.Trim()).Count != 0)
                {
                    var quiryD = dp.GetList(textB_Id.Text.Trim(), textB_Name.Text.Trim());
                    textB_Id.Text = quiryD[0].D_id;
                    textB_Name.Text = quiryD[0].D_name;
                    textB_Load.Text = quiryD[0].D_Load;
                    textB_Place.Text = quiryD[0].D_place;
                    dataGridView1.DataSource = quiryD;
                    department_col();
                    MessageBox.Show("查询成功");
                }
                else
                {
                    MessageBox.Show("存在问题，请核查后再次查询", "提示信息");
                }
            }
            else
            {
                dataGridView1.DataSource = dp.GetList2();
                department_col();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (dp.Remove(textB_sno.Text.ToString().Trim()))
            {
                MessageBox.Show("删除成功");

            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次删除", "提示信息");
            }
            dataGridView1.DataSource = dp.GetList2();
            department_col();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dp.Edit(textB_Id.Text.Trim(), textB_Name.Text.Trim(), textB_Load.Text.Trim(), textB_Place.Text.Trim()))
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次修改", "提示信息");
            }
            dataGridView1.DataSource = dp.GetList2();
            department_col();
        }


        private void department_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dp.GetList2();
            department_col();
        }

        public void department_col()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "编号";
            dataGridView1.Columns[1].HeaderCell.Value = "部门名";
            dataGridView1.Columns[2].HeaderCell.Value = "主管领导";
            dataGridView1.Columns[3].HeaderCell.Value = "位置";
        }
    }
}
