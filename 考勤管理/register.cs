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
    public partial class register : Form
    {
        Sunisoft.IrisSkin.SkinEngine skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
        public register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rDocument rD = new rDocument();
            if (string.IsNullOrEmpty(Uname.Text.Trim()))
            {
                MessageBox.Show("姓名不能为空");
            }
            else
            {
                if(string.IsNullOrEmpty(Upasswd.Text.Trim()))
                {
                    MessageBox.Show("密码不能为空");
                }
                else
                {
                    if (rD.rOne(Uname.Text.Trim(), Upasswd.Text.Trim(), "员工",textBox_Tel.Text.Trim()))
                    {
                        MessageBox.Show("注册成功");
                    }
                    else
                    {
                        MessageBox.Show("存在问题，请核查后再次注册", "提示信息");
                    }
                }
                
            }
            
        }

        private void register_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"/Skins/Calmness.ssk";
        }
    }
}
