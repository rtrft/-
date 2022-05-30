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
    public partial class Main2 : Form
    {
        Sunisoft.IrisSkin.SkinEngine skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
        absenceDocument ab = new absenceDocument();
        kaoqinDocument kq = new kaoqinDocument();
        string open;
        public Main2(string username)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"/Skins/Calmness.ssk";
            InitializeComponent();
            username = "2201";
            this.Text = username;
        }

        private void 我的考勤ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open = "我的考勤";
            Kaoqin(text_id.Text.Trim(), text_name.Text.Trim());
            kaoqin_col();

        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updatepasswd f2 = new updatepasswd(this.Text.ToString().Trim());
            f2.StartPosition = FormStartPosition.CenterScreen;
            f2.ShowDialog();
        }

        private void 我的请假ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open = "我的请假";
            Absence(text_id.Text.Trim(), text_name.Text.Trim());
            absence_col();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (open)
            {
                case "我的考勤":
                    Kaoqin(text_id.Text.Trim(), text_name.Text.Trim());
                    kaoqin_col();
                    break;
                case "我的请假":
                    Absence(text_id.Text.Trim(), text_name.Text.Trim());
                    absence_col();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (open)
            {
                case "我的考勤":
                    userkaoqin f2 = new userkaoqin(this.Text.Trim());
                    f2.StartPosition = FormStartPosition.CenterScreen;
                    f2.ShowDialog();
                    break;
                case "我的请假":
                    userabsence f3 = new userabsence(this.Text.Trim());
                    f3.StartPosition = FormStartPosition.CenterScreen;
                    f3.ShowDialog();
                    break;
            }
        }

        public void Kaoqin(string id, string name)
        {
            if (id == "")
            {
                dataGridView1.DataSource = kq.GetList("",this.Text, name);
            }
            else
            {
                if (kq.GetList("",id, name).Count != 0)
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
                if (ab.GetList(id, name).Count != 0)
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

        private void 人脸识别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1(this.Text.ToString().Trim());
            f2.StartPosition = FormStartPosition.CenterScreen;
            f2.ShowDialog();
        }

        public void absence_col()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "工号";
            dataGridView1.Columns[1].HeaderCell.Value = "姓名";
            dataGridView1.Columns[2].HeaderCell.Value = "类型";
            dataGridView1.Columns[3].HeaderCell.Value = "开始时间";
            dataGridView1.Columns[4].HeaderCell.Value = "结束时间";
        }
        public void kaoqin_col()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "编号";
            dataGridView1.Columns[1].HeaderCell.Value = "工号";
            dataGridView1.Columns[2].HeaderCell.Value = "姓名";
            dataGridView1.Columns[3].HeaderCell.Value = "考勤状态";
            dataGridView1.Columns[4].HeaderCell.Value = "日期";
        }
    }
}
