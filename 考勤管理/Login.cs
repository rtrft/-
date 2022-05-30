using Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 考勤管理
{
    public partial class Login : Form
    {
        Sunisoft.IrisSkin.SkinEngine skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
        public Login()
        {
            InitializeComponent();
           
        }


        private void label4_Click(object sender, EventArgs e)
        {
            register f = new register();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rDocument rD = new rDocument();
            if (comboBox1.Text.ToString().Trim() == "员工")
            {
                if (rD.useQuiry(Uname.Text.ToString().Trim(), Upasswd.Text.ToString().Trim()).Count != 0)
                {
                    MessageBox.Show("登录成功");
                    Main2 f2 = new Main2(Uname.Text.ToString().Trim());
                    f2.StartPosition = FormStartPosition.CenterScreen;
                    f2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("存在问题，账号或密码错误", "提示信息");
                }
            }
            else if (comboBox1.Text.ToString().Trim() == "主管")
            {
                if (rD.useQuiry(Uname.Text.ToString().Trim(), Upasswd.Text.ToString().Trim()).Count != 0)
                {
                    MessageBox.Show("登录成功");
                    Main1 f = new Main1();
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("存在问题，账号或密码错误", "提示信息");
                }
            }
            else
            {
                MessageBox.Show("请选择身份", "提示信息");
            }

        }

        private void rgelnfo_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"/Skins/Calmness.ssk";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Upasswd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Uname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
        }
    }
}
