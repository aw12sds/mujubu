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
    public partial class 修改生产车间 : DevExpress.XtraEditors.XtraForm
    {
        public string id;
        public string yonghu;
        公共 公共 = new 公共();
        public 修改生产车间(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void 修改_生产车间_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string 类型 = "修改车间";
            string 车间 = comboBox1.SelectedItem.ToString();
            if (车间 == "")
            {
                MessageBox.Show("请选择车间");
            }
            if (comboBox1.SelectedItem.ToString().Equals("河口车间"))
            {
                string sql2 = "update tb_caigouliaodan set 模具部生产车间='" + 车间 + "' where id='" + id + "'";
                SQLhelp.ExecuteNonquery2(sql2, CommandType.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (comboBox1.SelectedItem.ToString().Equals("南通车间"))
            {
                string sql2 = "update tb_caigouliaodan set 模具部生产车间='" + 车间 + "' where id='" + id + "'";
                SQLhelp.ExecuteNonquery2(sql2, CommandType.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
            公共.添加修改记录(yonghu, 类型, comboBox1.SelectedItem.ToString(), id);
    }
    }
}
