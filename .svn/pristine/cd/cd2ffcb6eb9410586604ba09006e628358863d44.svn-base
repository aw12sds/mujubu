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
    public partial class 新增设备 : Form
    {
        public 新增设备()
        {
            InitializeComponent();
        }

        private void 新增设备_Load(object sender, EventArgs e)
        {
            string sql = "select  工序名 from tb_gongxu_name";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            this.cbGongxu.DataSource = dt;
            cbGongxu.DisplayMember = "工序名";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string SQL = "select id from tb_gongxu_name where 工序名 ='" + cbGongxu.Text + "'";
            string uid = Convert.ToString(SQLhelp.ExecuteScalar(SQL, CommandType.Text));
           
            string sql1 = "insert into tb_gongxu_device (工序id,设备名) values('" + uid + "','" + tbShebei.Text.Trim() + "')";
            string ret = Convert.ToString(SQLhelp.ExecuteNonquery2(sql1, CommandType.Text));



            if (ret != "")
            {
                MessageBox.Show("插入成功！");
                this.Close();
                this.DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show("插入失败！");
            }
        }
    }
}
