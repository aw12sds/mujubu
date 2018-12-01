using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mujubu.工艺
{
    public partial class Formgongxuadd : Form
    {
        public Formgongxuadd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入要添加的工序名称!", "提示");
                return;
            }

            string s3 = "select * from tb_gongxu_name where 工序名='" + textBox1.Text.Trim() + "'";
            string r3 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

            if (r3 != "")
            {
                MessageBox.Show("该工序名称已存在！", "提示");
                textBox1.Text = "";
            }
            else
            {
                string s1 = "insert into tb_gongxu_name(工序名) values('" + textBox1.Text.Trim() + "')";
                string r1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
              
                    MessageBox.Show("新增工序成功！", "提示");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
            }
        }
    }
}
