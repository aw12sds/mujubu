using mujubu.公共类;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using NetWork.util;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetWorkLib;

namespace mujubu.taizhang
{
    public partial class zhizaoleixing1 : DevExpress.XtraEditors.XtraForm
    {
        public string id;
        public string yonghu;
        public string 工作令号;
        DataTable 人员;
        public zhizaoleixing1(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        公共 公共 = new 公共();
        private void zhizaoleixing1_Load(object sender, EventArgs e)
        {
            string sql = "select id,工作令号,项目名称,模具部订单号申请号,模具部销售合同号,编码,模具部申请人,模具部客户,模具部联系人,型号,单位,数量,合同类型,合同名称,模具部销售单价,模具部成本分摊,模具部交货日期,模具部销售开票日期,模具部实际交货日期,备注,模具部发货数量,模具部销售开票金额,名称,模具部成本分摊 from tb_caigouliaodan where 料单类型='模具部部件' and id='" + id + "'";
            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            工作令号 = dt1.Rows[0]["工作令号"].ToString();
            人员 = 公共.根据部门得到人员("模具事业部");
        }

        public bool showdialog(string comment)
        {
            bool flag;
            if (comment.Equals(""))
            {
                MessageBox.Show("请写明修改原因");
                flag = false;
            }
            else
            {
                flag = true;
            }
            return flag;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string 类型 = "";
            String comment = textBox1.Text.ToString();
            if (comboBox1.SelectedItem == null)
            {

            }

            else if (comboBox1.SelectedItem.ToString().Equals("自制改外协"))
            {
                if (showdialog(comment))
                {
                    string sql2 = "update tb_caigouliaodan  set 制造类型='外协',备注='" + comment + "',模具部自制外协修改='自制改外协',当前状态='2'  where id='" + id + "'";
                    类型 = "自制改外协";
                    string message = "工作令号" + 工作令号 + "自制改外协,请生产和工艺人员注意";
                    NetWork3J NetWork3J = new NetWork3J(yonghu, "http://10.15.1.252:81/");

                    for (int i = 0; i < 人员.Rows.Count; i++)
                    {
                        string 发送人员 = 人员.Rows[i]["用户名"].ToString();
                        NetWork3J.sendmessageById(发送人员, message);
                    }

                    SQLhelp.ExecuteNonquery2(sql2, CommandType.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }


            }
            else if (comboBox1.SelectedItem.ToString().Equals("外协改自制"))
            {
                if (showdialog(comment))
                {
                    string sql2 = "update tb_caigouliaodan  set 制造类型='自制',备注='" + comment + "',模具部自制外协修改='外协改自制',当前状态='4'  where id='" + id + "'";
                    类型 = "外协改自制";
                    string message = "工作令号" + 工作令号 + "外协改自制,请相关人员注意";
                    NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                    for (int i = 0; i < 人员.Rows.Count; i++)
                    {
                        string 发送人员 = 人员.Rows[i]["用户名"].ToString();
                        NetWork3J.sendmessageById(发送人员, message);
                    }
                    SQLhelp.ExecuteNonquery2(sql2, CommandType.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            公共.添加修改记录(yonghu, 类型, comment, id);
        }
    }
}
