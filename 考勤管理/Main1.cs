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
    public partial class Main1 : Form
    {
        Sunisoft.IrisSkin.SkinEngine skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
        string open;
        StaffDocument staff = new StaffDocument();
        departmentDocument dp = new departmentDocument();
        AccountDocument ac = new AccountDocument();
        kaoqinDocument kq = new kaoqinDocument();
        absenceDocument ab = new absenceDocument();
        public Main1()
        {
            skinEngine1.SkinFile = Application.StartupPath + @"/Skins/Calmness.ssk";
            InitializeComponent();
        }

        private void 员工管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open = "员工管理";
            User(text_id.Text.Trim(), text_name.Text.Trim());
            user_col();
        }

        private void 部门管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open = "部门管理";
            Department(text_id.Text.Trim(), text_name.Text.Trim());
            department_col();
        }

        private void 账号管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open = "账号管理";
            Account(text_id.Text.Trim());
            account_col();
        }

        private void 考勤管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open = "考勤管理";
            Kaoqin(text_id.Text.Trim(), text_name.Text.Trim());
            kaoqin_col();
        }

        private void 请假管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open = "请假管理";
            Absence(text_id.Text.Trim(), text_name.Text.Trim());
            absence_col();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (open)
            {
                case "员工管理":
                    User(text_id.Text.Trim(),text_name.Text.Trim());
                    user_col();
                    break;
                case "部门管理":
                   Department(text_id.Text.Trim(), text_name.Text.Trim());
                    department_col();
                    break;
                case "账号管理":
                    Account(text_id.Text.Trim());
                    account_col();
                    break;
                case "考勤管理":
                    Kaoqin(text_id.Text.Trim(), text_name.Text.Trim());
                    kaoqin_col();
                    break;
                case "请假管理":
                    Absence(text_id.Text.Trim(), text_name.Text.Trim());
                    absence_col();
                    break;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            switch (open)
            {
                case "员工管理":
                    Staff f2 = new Staff();
                    f2.StartPosition = FormStartPosition.CenterScreen;
                    f2.ShowDialog();
                    break;
                case "部门管理":
                    department f3 = new department();
                    f3.StartPosition = FormStartPosition.CenterScreen;
                    f3.ShowDialog();
                    break;
                case "账号管理":
                    Account f4 = new Account();
                    f4.StartPosition = FormStartPosition.CenterScreen;
                    f4.ShowDialog();
                    break;
                case "考勤管理":
                    kaoqin f5 = new kaoqin();
                    f5.StartPosition = FormStartPosition.CenterScreen;
                    f5.ShowDialog();
                    break;
                case "请假管理":
                    absence f6 = new absence();
                    f6.StartPosition = FormStartPosition.CenterScreen;
                    f6.ShowDialog();
                    break;
            }
        }
        public void User(string id,string name)
        {
            if (id==""&&name == "")
            {
                dataGridView1.DataSource = staff.GetList2();
                
            }
            else
            {
                if (staff.GetList(text_id.Text.Trim(),text_name.Text.Trim()).Count != 0)
                {
                    var quiryD = staff.GetList(id,name);
                    dataGridView1.DataSource = quiryD;
                    MessageBox.Show("查询成功");
                }
                else
                {
                    MessageBox.Show("存在问题，请核查后再次查询", "提示信息");
                }
            }
        }

        public void Department(string id, string name)
        {
            if (id == "" && name == "")
            {
                dataGridView1.DataSource = dp.GetList2();
            }
            else
            {
                if (dp.GetList(id,name).Count != 0)
                {
                    var quiryD = dp.GetList(id, name);
                    dataGridView1.DataSource = quiryD;
                    MessageBox.Show("查询成功");
                }
                else
                {
                    MessageBox.Show("存在问题，请核查后再次查询", "提示信息");
                }
            }
        }


        public void Account(string name)
        {
            if (name == "")
            {
                dataGridView1.DataSource = ac.GetList2();
            }
            else
            {
                if (ac.GetList(name).Count != 0)
                {
                    var quiryD = ac.GetList(name);
                    dataGridView1.DataSource = quiryD;
                    MessageBox.Show("查询成功");
                }
                else
                {
                    MessageBox.Show("存在问题，请核查后再次查询", "提示信息");
                }
            }
        }

        public void Kaoqin(string id, string name)
        {
            if (id == "" && name == "")
            {
                dataGridView1.DataSource = kq.GetList2();
            }
            else
            {
                if (kq.GetList("",id,name).Count != 0)
                {
                    var quiryD = kq.GetList("",id, name);
                    dataGridView1.DataSource = quiryD;
                    MessageBox.Show("查询成功");
                }
                else
                {
                    MessageBox.Show("存在问题，请核查后再次查询", "提示信息");
                }
            }
        }


        public void Absence(string id, string name)
        {
            if (id == "" && name == "")
            {
                dataGridView1.DataSource = ab.GetList2();
            }
            else
            {
                if (staff.GetList(id,name).Count != 0)
                {
                    var quiryD = ab.GetList(id, name);
                    dataGridView1.DataSource = quiryD;
                    MessageBox.Show("查询成功");
                }
                else
                {
                    MessageBox.Show("存在问题，请核查后再次查询", "提示信息");
                }
            }
        }

        public void user_col()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "编号";
            dataGridView1.Columns[1].HeaderCell.Value = "姓名";
            dataGridView1.Columns[2].HeaderCell.Value = "年龄";
            dataGridView1.Columns[3].HeaderCell.Value = "性别";
            dataGridView1.Columns[4].HeaderCell.Value = "部门";
            dataGridView1.Columns[5].HeaderCell.Value = "职位";
        }
        public void department_col()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "编号";
            dataGridView1.Columns[1].HeaderCell.Value = "部门名";
            dataGridView1.Columns[2].HeaderCell.Value = "主管领导";
            dataGridView1.Columns[3].HeaderCell.Value = "位置";
        }
        public void account_col()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "账号名";
            dataGridView1.Columns[1].HeaderCell.Value = "密码";
            dataGridView1.Columns[2].HeaderCell.Value = "身份";
            dataGridView1.Columns[3].HeaderCell.Value = "电话";
        }
        public void kaoqin_col()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "编号";
            dataGridView1.Columns[1].HeaderCell.Value = "工号";
            dataGridView1.Columns[2].HeaderCell.Value = "姓名";
            dataGridView1.Columns[3].HeaderCell.Value = "考勤状态";
            dataGridView1.Columns[4].HeaderCell.Value = "日期";
        }
        public void absence_col()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "工号";
            dataGridView1.Columns[1].HeaderCell.Value = "姓名";
            dataGridView1.Columns[2].HeaderCell.Value = "类型";
            dataGridView1.Columns[3].HeaderCell.Value = "开始时间";
            dataGridView1.Columns[4].HeaderCell.Value = "结束时间";
        }



        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Time f1 = new Time();
            f1.ShowDialog();
        }
    }
}
