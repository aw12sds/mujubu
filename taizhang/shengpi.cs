using mujubu.公共类;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mujubu.taizhang
{
    public partial class shengpi : Form
    {
        public String id;
             public String yonghu;
        public shengpi(String id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String state = "10";
            string sql1 = "update tb_caigouliaodan set 模具部状态='" + state + "' where id='" + id + "'";
            SQLhelp.ExecuteNonquery2(sql1, CommandType.Text);
        }
        公共 公共 = new 公共();
        private void button1_Click(object sender, EventArgs e)
        {
            String state = "1";
            if (comboBox1.SelectedItem==null)
            {
                MessageBox.Show("请选择加工类型");
                return;
            }
           else if (comboBox1.SelectedItem.ToString().Equals("自制"))
            {
                if (comboBox2.SelectedItem == null)
                {
                    MessageBox.Show("请选择加工车间");
                    return;
                }
                else
                {
                    String factory = comboBox2.SelectedItem.ToString();
                    state = "2";
                    string sqlfac = "update tb_caigouliaodan set 模具部生产车间='" + factory + "',模具部类型='" + comboBox1.SelectedItem.ToString() + "' where id='" + id + "'";
                    SQLhelp.ExecuteNonquery2(sqlfac, CommandType.Text);
                }
                    
            }
            else if (comboBox1.SelectedItem.ToString().Equals("外协"))
            {
                state = "3";
            }
            string sql1 = "update tb_caigouliaodan set 模具部状态='"+state+ "',模具部类型='" + comboBox1.SelectedItem.ToString()+"' where id='" + id+"'";
            SQLhelp.ExecuteNonquery2(sql1, CommandType.Text);
            公共.添加审批记录(yonghu,"待主管审批", id);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void shengpi_Load(object sender, EventArgs e)
        {


            comboBox1.Items.Add("自制");
            comboBox1.Items.Add("外协");
            comboBox1.Items.Add("仓库");
            comboBox1.Items.Add("生产部");
            comboBox1.Items.Add("其他");

            comboBox2.Items.Add("南通车间");
            comboBox2.Items.Add("河口车间");




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString().Equals("自制"))
            {
                label2.Visible = true;
                comboBox2.Visible = true;
            }else
            {
                label2.Visible = false;
                comboBox2.Visible = false;
            }
        }
    }
}
