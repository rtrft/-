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
    public partial class updatepasswd : Form
    {
        string name;
        AccountDocument dp = new AccountDocument();
        Sunisoft.IrisSkin.SkinEngine skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
        public updatepasswd(string username)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"/Skins/Calmness.ssk";
            InitializeComponent();
            name = username;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textB_1.Text.Trim()==textB_2.Text.Trim())
            {
                 if (dp.Edit2(name,textB_passwd.Text.Trim(),"员工"))
                 {
                       MessageBox.Show("修改成功");
                 }
                 else
                 {
                       MessageBox.Show("存在问题，请核查后再次修改", "提示信息");
                 }
            }
            else
            {
                MessageBox.Show("存在问题，请核查后再次修改", "提示信息");
            }
           
        }

 
    }
}
