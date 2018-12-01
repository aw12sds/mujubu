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
    public partial class fahuoForm : Form
    {
        public string id;
        public int 已发货数量;
        public int 实际采购数量;
        public fahuoForm(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string 发货数量 = textBox1.Text;
            string 发货时间 = dateEdit1.Text;
            if (发货数量 == "")
            {
                MessageBox.Show("发货数量不能为空");
                return;
            }
            if (发货时间 == "")
            {
                MessageBox.Show("发货时间不能为空");
                return;
            }
            string sql = "insert into tb_fahuojilu(定位,部门,发货数量,发货时间) values('" + id + "','模具部','" + 发货数量 + "','" + 发货时间 + "')";
            string 模具部发货数量 = int.Parse(发货数量) + 已发货数量 + "";
            int 模具部发货数量int = int.Parse(发货数量) + 已发货数量;
            SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
            string sql1 = "update tb_caigouliaodan set 模具部发货数量='" + 模具部发货数量 + "' where id='" + id + "'";
            SQLhelp.ExecuteNonquery2(sql1, CommandType.Text);
            if(实际采购数量== 模具部发货数量int){
                string sql3= "update tb_caigouliaodan set 模具部发货确认='已发货',"+ "模具部发货时间='"+ 发货时间+"' where id='" + id + "'";
                SQLhelp.ExecuteNonquery2(sql3, CommandType.Text);

                string sql4 = "update tb_caigouliaodan set 当前状态='42' where id='" + id + "'";
                SQLhelp.ExecuteNonquery2(sql4, CommandType.Text);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void fahuoForm_Load(object sender, EventArgs e)
        {
            string sql = "select 模具部发货数量,实际采购数量 from tb_caigouliaodan where id='" + id+"'";
            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            if(dt1.Rows[0]["模具部发货数量"].ToString()==""){
                已发货数量 =0;
            }else
            {
                已发货数量 = int.Parse(dt1.Rows[0]["模具部发货数量"].ToString());
            }
           
            实际采购数量 = int.Parse(dt1.Rows[0]["实际采购数量"].ToString());
            textBox2.Text = 已发货数量 + "";
        }
    }
}
