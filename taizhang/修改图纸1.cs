using mujubu.公共类;
using NetWorkLib;
using NetWork.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mujubu.taizhang
{
    public partial class 修改图纸1 : DevExpress.XtraEditors.XtraForm
    {
        public 修改图纸1(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        公共 公共 = new 公共();
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        public string yonghu;
        public string tuzhimingcheng;
        public string tuzhileixing;
        private byte[] tuzhifiles;//文件
        public String id;
        private BinaryReader read = null;//二进制读取
        private void button1_Click1(object sender, EventArgs e)
        {
            string comment = richTextBox1.Text;
            string cato = "修改图纸";
            if(tuzhimingcheng=="")
            {
                MessageBox.Show("请选择图纸！");
                return;
            }
            if (comment == "")
            {
                MessageBox.Show("请输入原因");
            }
            else
            {
                String sql = "insert into tb_xiugaijilu(业务id,修改人,修改类型,修改内容,修改时间,附件,附件名称,附件类型) values('" + id + "','" + yonghu + "','" + cato + "','" + comment + "','" + DateTime.Now + "',@pictuzhi,'" + tuzhimingcheng + "','" + tuzhileixing + "')";
                SQLhelp.ExecuteNonquerytuzhi(sql, CommandType.Text, tuzhifiles);
                string sql2 = "select 图纸上传次数 from tb_caigouliaodan  where id='" + id + "'";
                string 图纸上传次数 = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();
                if (图纸上传次数 == "")
                {
                    图纸上传次数 = "0";
                }
                图纸上传次数 = int.Parse(图纸上传次数) + 1 + "";
                string sql3 = "update tb_caigouliaodan set 图纸上传次数='" + 图纸上传次数 + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql3, CommandType.Text);
            }
            string sql5 = "select id,工作令号,项目名称,模具部订单号申请号,模具部销售合同号,编码,模具部申请人,模具部客户,模具部联系人,型号,单位,数量,合同类型,合同名称,模具部销售单价,模具部成本分摊,模具部交货日期,模具部销售开票日期,模具部实际交货日期,备注,模具部发货数量,模具部销售开票金额,名称,模具部成本分摊 from tb_caigouliaodan where 料单类型='模具部部件' and id='" + id + "'";
            DataTable dt1 = SQLhelp.GetDataTable(sql5, CommandType.Text);
            string 工作令号 = dt1.Rows[0]["工作令号"].ToString();
            DataTable 人员 = 公共.根据部门得到人员("模具事业部");
            string message = "工作令号" + 工作令号 + "修改了图纸,请相关人员注意,请查看相应台账的修改记录";
            NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
            for (int i = 0; i < 人员.Rows.Count; i++)
            {
                string 发送人员 = 人员.Rows[i]["用户名"].ToString();
                NetWork3J.sendmessageById(发送人员, message);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click1(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = dialog.FileName;
                    FileInfo info = new FileInfo(@textBox1.Text);
                    //获得文件大小
                    fileSize = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName = info.FullName.Remove(index);
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                    tuzhimingcheng = fileName;
                    //获得文件扩展名
                    tuzhileixing = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    tuzhifiles = new byte[Convert.ToInt32(fileSize)];
                    FileStream file = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(tuzhifiles, 0, Convert.ToInt32(fileSize));
                    file.Flush();
                    file.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
        }

        private void 修改图纸_Load(object sender, EventArgs e)
        {

        }

    }
}
