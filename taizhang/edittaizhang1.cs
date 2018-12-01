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
    public partial class edittaizhang1 : DevExpress.XtraEditors.XtraForm
    {
        public String id;
        public string yonghu;

        public string hetongmingcheng;
        public string hetongleixing;
        公共 公共 = new 公共();
        string sqlbefore = "";
        public edittaizhang1(String id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void edittaizhang1_Load(object sender, EventArgs e)
        {
            string sql = "select id,工作令号,项目名称,模具部订单号申请号,模具部销售合同号,编码,模具部申请人,模具部客户,模具部联系人,型号,单位,实际采购数量,合同类型,合同名称,模具部销售单价,模具部成本分摊,模具部交货日期,模具部销售开票日期,模具部实际交货日期,备注,模具部发货数量,模具部销售开票金额,名称,模具部成本分摊 from tb_caigouliaodan where 料单类型='模具部部件' and id='" + id + "'";

            string Sql1 = "select name from tb_client";
            DataSet Ds = new DataSet();
            DataTable dt2 = SQLhelp.GetDataTable(Sql1, CommandType.Text);

            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            txtgonglighao.Text = dt1.Rows[0]["工作令号"].ToString();
            txtkuhu.Text = dt1.Rows[0]["模具部客户"].ToString();
            txtlianxiren.Text = dt1.Rows[0]["模具部联系人"].ToString();
            txthetonghao.Text = dt1.Rows[0]["模具部销售合同号"].ToString();
            txterp.Text = dt1.Rows[0]["编码"].ToString();
            txtxiangmumingcheng.Text = dt1.Rows[0]["项目名称"].ToString();
            txtxinghao.Text = dt1.Rows[0]["型号"].ToString();
            textEdit1.Text = dt1.Rows[0]["模具部订单号申请号"].ToString();
            txtdanwei.Text = dt1.Rows[0]["单位"].ToString();
            txtshuliang.Text = dt1.Rows[0]["实际采购数量"].ToString();
            txtdanjia.Text = dt1.Rows[0]["模具部销售单价"].ToString();
            txtchengben.Text = dt1.Rows[0]["模具部成本分摊"].ToString();
            txtbeizhu.Text = dt1.Rows[0]["备注"].ToString();
            txtxiaoshoukaipiao.Text = dt1.Rows[0]["模具部销售开票金额"].ToString();
            datejiaohuo.Text = dt1.Rows[0]["模具部交货日期"].ToString();
            txtfahuoshuliang.Text = dt1.Rows[0]["模具部发货数量"].ToString();
            txtmingcheng.Text = dt1.Rows[0]["名称"].ToString();
            this.datekaipiao.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            datekaipiao.Text = dt1.Rows[0]["模具部销售开票日期"].ToString();
            this.dateshijijiaohuo.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            dateshijijiaohuo.Text = dt1.Rows[0]["模具部实际交货日期"].ToString();
            sqlbefore = "update tb_caigouliaodan set 工作令号=" + txtgonglighao.Text.Trim() +
                ",模具部客户=" + txtkuhu.Text.Trim() +
                ",模具部联系人=" + txtlianxiren.Text.Trim() +
                 ",模具部销售合同号=" + txthetonghao.Text.Trim() +
                  ",模具部订单号申请号=" + textEdit1.Text.Trim() +
                  ",编码=" + txterp.Text.Trim() +
                    ",模具部成本分摊=" + txtchengben.Text.Trim() +
                      ",项目名称=" + txtxiangmumingcheng.Text.Trim() +
                      ",型号=" + txtxinghao.Text.Trim() +
                      ",单位=" + txtdanwei.Text.Trim() +
                      ",数量=" + txtshuliang.Text.Trim() +
                       ",模具部销售单价=" + txtdanjia.Text.Trim() +
                        ",模具部交货日期=" + datejiaohuo.Text.Trim() +
                           ",模具部销售开票日期=" + datekaipiao.Text.Trim() +
                           ",模具部实际交货日期=" + dateshijijiaohuo.Text +
                            ",备注=" + txtbeizhu.Text.Trim() +
                             ",模具部发货数量=" + txtfahuoshuliang.Text.Trim() +
                           ",模具部销售开票金额=" + txtxiaoshoukaipiao.Text.Trim();
        }
        public void update日期()
        {
            string sql1 = "update tb_caigouliaodan set 供应商开票日期=null where 供应商开票日期='1900-01-01 00:00:00.000' and 料单类型='模具部'";
            SQLhelp.ExecuteScalar(sql1, CommandType.Text);
            string sql2 = "update tb_caigouliaodan set 模具部销售开票日期=null where 模具部销售开票日期='1900-01-01 00:00:00.000' and 料单类型='模具部'";
            SQLhelp.ExecuteScalar(sql2, CommandType.Text);
            string sql3 = "update tb_caigouliaodan set 模具部实际交货日期=null where 模具部实际交货日期='1900-01-01 00:00:00.000' and 料单类型='模具部'";
            SQLhelp.ExecuteScalar(sql3, CommandType.Text);
        }
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (txtgonglighao.Text.Trim() == "")
            {
                MessageBox.Show("工作令号不能为空！");

                return;
            }
            if (txtkuhu.Text.Trim() == "")
            {
                MessageBox.Show("客户名称不能为空！");

                return;
            }
            String 模具部销售开票日期 = datekaipiao.Text;
            String 模具部实际交货日期 = dateshijijiaohuo.Text;

            string sql1 = "update tb_caigouliaodan set 工作令号='" + txtgonglighao.Text.Trim() +
                "',模具部客户='" + txtkuhu.Text.Trim() +
                "',模具部联系人='" + txtlianxiren.Text.Trim() +
                 "',模具部销售合同号='" + txthetonghao.Text.Trim() +
                 "',模具部订单号申请号='" + textEdit1.Text.Trim() +
                  "',编码='" + txterp.Text.Trim() +
                    "',模具部成本分摊='" + txtchengben.Text.Trim() +
                      "',项目名称='" + txtxiangmumingcheng.Text.Trim() +
                      "',型号='" + txtxinghao.Text.Trim() +
                      "',单位='" + txtdanwei.Text.Trim() +
                      "',实际采购数量='" + txtshuliang.Text.Trim() +
                       "',模具部销售单价='" + txtdanjia.Text.Trim() +
                        "',模具部交货日期='" + datejiaohuo.Text.Trim() +
                         "',模具部销售开票日期='" + datekaipiao.Text.Trim() +
                           "',模具部实际交货日期='" + dateshijijiaohuo.Text +
                            "',备注='" + txtbeizhu.Text.Trim() +
                             "',模具部发货数量='" + txtfahuoshuliang.Text.Trim() +
                           "',模具部销售开票金额='" + txtxiaoshoukaipiao.Text.Trim() + "' where id='" + id + "'";
            string sqlafter = "update tb_caigouliaodan set 工作令号=" + txtgonglighao.Text.Trim() +
                ",模具部客户=" + txtkuhu.Text.Trim() +
                ",模具部联系人=" + txtlianxiren.Text.Trim() +
                 ",模具部销售合同号=" + txthetonghao.Text.Trim() +
                  ",模具部订单号申请号=" + textEdit1.Text.Trim() +
                  ",编码=" + txterp.Text.Trim() +
                    ",模具部成本分摊=" + txtchengben.Text.Trim() +
                      ",项目名称=" + txtxiangmumingcheng.Text.Trim() +
                      ",型号=" + txtxinghao.Text.Trim() +
                      ",单位=" + txtdanwei.Text.Trim() +
                      ",数量=" + txtshuliang.Text.Trim() +
                       ",模具部销售单价=" + txtdanjia.Text.Trim() +
                        ",模具部交货日期=" + datejiaohuo.Text.Trim() +
                         ",模具部销售开票日期=" + datekaipiao.Text.Trim() +
                           ",模具部实际交货日期=" + dateshijijiaohuo.Text +
                            ",备注=" + txtbeizhu.Text.Trim() +
                             ",模具部发货数量=" + txtfahuoshuliang.Text.Trim() +
                           ",模具部销售开票金额=" + txtxiaoshoukaipiao.Text.Trim();

            SQLhelp.ExecuteNonquery2(sql1, CommandType.Text);
            update日期();
            公共.添加修改记录(yonghu, "修改明细", sqlbefore + "--------------" + sqlafter, id);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtdanjia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txtdanjia.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtdanjia.Text, out oldf);
                    b2 = float.TryParse(txtdanjia.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void txtxiaoshoukaipiao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txtxiaoshoukaipiao.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtxiaoshoukaipiao.Text, out oldf);
                    b2 = float.TryParse(txtxiaoshoukaipiao.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void txtshuliang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txtshuliang.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtshuliang.Text, out oldf);
                    b2 = float.TryParse(txtshuliang.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void txtfahuoshuliang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txtfahuoshuliang.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtfahuoshuliang.Text, out oldf);
                    b2 = float.TryParse(txtfahuoshuliang.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

    }
}
