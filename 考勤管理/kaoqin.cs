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
    public partial class kaoqin : Form
    {
        Sunisoft.IrisSkin.SkinEngine skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
        public kaoqin()
        {
            InitializeComponent();
           
        }
        
        private void kaoqin_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"/Skins/Calmness.ssk";
            dataGridView1.DataSource = staff.GetList2();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        kaoqinDocument staff = new kaoqinDocument();
        private void button1_Click(object sender, EventArgs e)
        {

            if (staff.Add(textB_sno.Text.ToString().Trim(), textB_Name.Text.ToString().Trim(), comboBox1.Text.Trim(),dateTimePicker1.Value))
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
            if (textB_Id.Text.Trim()!= ""|| textB_sno.Text.Trim() != ""|| textB_Name.Text.Trim() != "")
            {
                if (staff.GetList(textB_Id.Text.Trim(),textB_sno.Text.Trim(), textB_Name.Text.Trim()).Count != 0)
                {
                    var quiryD = staff.GetList(textB_Id.Text.Trim(),textB_sno.Text.Trim(), textB_Name.Text.Trim());
                    textB_sno.Text = quiryD[0].user_id;
                    textB_Name.Text = quiryD[0].user_name;
                    comboBox1.Text = quiryD[0].type;
                    dateTimePicker1.Value = quiryD[0].date;
                    dataGridView1.DataSource = quiryD;
                    MessageBox.Show("查询成功");
                }
                else
                {
                    MessageBox.Show("存在问题，请核查后再次查询", "提示信息");
                }
            }
            else
            {
                dataGridView1.DataSource = staff.GetList2();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (staff.Remove(textB_Id.Text.Trim()))
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
            if (staff.Edit(textB_Id.Text.Trim(),textB_sno.Text.ToString().Trim(),textB_Name.Text.ToString().Trim(),comboBox1.Text.Trim(), dateTimePicker1.Value))
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次修改", "提示信息");
            }
            dataGridView1.DataSource = staff.GetList2();
        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

      
        private void button1_(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
