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
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }
        Sunisoft.IrisSkin.SkinEngine skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
        StaffDocument staff = new StaffDocument();
        private void Staff_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"/Skins/Calmness.ssk";
            dataGridView1.DataSource = staff.GetList2();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int age = Convert.ToInt32(textage.Text.Trim());
            if (staff.Add(textB_sno.Text.ToString().Trim(),textB_Name.Text.ToString().Trim(),age,comboBox1.Text.Trim(),textB_major.Text.ToString().Trim(), textB_address.Text.ToString().Trim()))
            {
                MessageBox.Show("插入成功");
            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次插入", "提示信息");
            }
            dataGridView1.DataSource = staff.GetList2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textB_sno.Text.ToString().Trim() =="")
            {
                dataGridView1.DataSource = staff.GetList2();
            }
            else
            {
                if (staff.GetList(textB_sno.Text.Trim(), textB_Name.Text.Trim()).Count != 0)
                {
                    var quiryD = staff.GetList(textB_sno.Text.Trim(), textB_Name.Text.Trim());
                    textB_sno.Text = quiryD[0].W_id;
                    textB_Name.Text = quiryD[0].Wname;
                    textage.Text = quiryD[0].Wage.ToString();
                    comboBox1.Text = quiryD[0].Wsex;
                    textB_major.Text = quiryD[0].Wpost;
                    textB_address.Text = quiryD[0].Wdepartment_id;
                    dataGridView1.DataSource = quiryD;
                    MessageBox.Show("查询成功");
                }
                else
                {
                    MessageBox.Show("存在问题，请核查后再次查询", "提示信息");
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (staff.Remove(textB_sno.Text.ToString().Trim()))
            {
                MessageBox.Show("删除成功");

            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次删除", "提示信息");
            }
            dataGridView1.DataSource = staff.GetList2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int age = Convert.ToInt32(textage.Text.Trim());
            if (staff.Edit(textB_sno.Text.ToString().Trim(),textB_Name.Text.ToString().Trim(),age,comboBox1.Text.Trim(),textB_major.Text.ToString().Trim(),textB_address.Text.ToString().Trim()))
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次修改", "提示信息");
            }
            dataGridView1.DataSource = staff.GetList2();
        }

        private void textage_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }



    }
}
