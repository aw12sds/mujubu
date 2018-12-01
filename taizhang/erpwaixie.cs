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
    public partial class erpwaixie : DevExpress.XtraEditors.XtraForm
    {
        public erpwaixie(String id)
        {
            InitializeComponent();
            this.id = id;
        }
        public String id;
        public String yonghu;
        公共 公共 = new 公共();
        private void 提交_Click(object sender, EventArgs e)
        {
            String erp = textBox2.Text;
            if (公共.判断是否有重复erp(erp))
            {
                String sql = "update tb_caigouliaodan set 编码='" + erp + "',当前状态='3',收到料单日期='" + DateTime.Now + "',申购人='" + yonghu + "',到货情况='0' where id='" + id + "'";
                SQLhelp.ExecuteNonquery2(sql, CommandType.Text);

                公共.添加审批记录(yonghu, "外协待数据分析师通过", id);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("erp重复");
            }
           
        }

        private void erpwaixie_Load(object sender, EventArgs e)
        {
            string sql = "select id,工作令号,项目名称,型号 from tb_caigouliaodan where 料单类型='模具部' and id='" + id + "'";
            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            textBox1.Text = dt1.Rows[0]["工作令号"].ToString() + "  " + dt1.Rows[0]["项目名称"].ToString() + "   " +
                dt1.Rows[0]["型号"].ToString();
        }
    }
}
