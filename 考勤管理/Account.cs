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
    public partial class Account : Form
    {
        Sunisoft.IrisSkin.SkinEngine skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
        public Account()
        {
            skinEngine1.SkinFile = Application.StartupPath + @"/Skins/Calmness.ssk";
            InitializeComponent();
        }
        AccountDocument dp = new AccountDocument();
        private void button1_Click(object sender, EventArgs e)
        {

            if (dp.Add(textB_Name.Text.Trim(), textB_passwd.Text.Trim(),comboBox_type.Text.Trim(),textB_Tel.Text.Trim()))
            {
                MessageBox.Show("插入成功");
            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次插入", "提示信息");
            }
            dataGridView1.DataSource = dp.GetList2();
            account_col();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textB_Name.Text.ToString().Trim()!="")
            {
                if (dp.GetList(textB_Name.Text.Trim()).Count != 0)
                {
                    var quiryD = dp.GetList(textB_Name.Text.Trim());
                    textB_Name.Text = quiryD[0].usename;
                    textB_passwd.Text = quiryD[0].usepasswd;
                    comboBox_type.Text = quiryD[0].usetype;
                    textB_Tel.Text = quiryD[0].Tel.Trim();
                    MessageBox.Show("查询成功");
                    dataGridView1.DataSource = quiryD;
                    account_col();
                }
                else
                {
                    MessageBox.Show("存在问题，请核查后再次查询", "提示信息");
                }
            }
            else
            {
                dataGridView1.DataSource = dp.GetList2();
                account_col();
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dp.Remove(textB_Name.Text.Trim()))
            {
                MessageBox.Show("删除成功");

            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次删除", "提示信息");
            }
            dataGridView1.DataSource = dp.GetList2();
            account_col();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dp.Edit(textB_Name.Text.Trim(), textB_passwd.Text.Trim(),comboBox_type.Text.Trim(), textB_Tel.Text.Trim()))
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次修改", "提示信息");
            }
            dataGridView1.DataSource = dp.GetList2();
            account_col();
        }
        private void Account_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dp.GetList2();
            account_col();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void account_col()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "账号名";
            dataGridView1.Columns[1].HeaderCell.Value = "密码";
            dataGridView1.Columns[2].HeaderCell.Value = "身份";
            dataGridView1.Columns[3].HeaderCell.Value = "电话";
        }
    }
}
