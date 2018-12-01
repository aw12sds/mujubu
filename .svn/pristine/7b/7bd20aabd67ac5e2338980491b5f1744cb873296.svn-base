using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using mujubu.客户;

namespace mujubu.taizhang
{
    public partial class Frxinzengtaizhang : DevExpress.XtraEditors.XtraForm
    {
        public Frxinzengtaizhang()
        {
            InitializeComponent();
        }
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        public string yonghu;
        public string tuzhimingcheng;
        public string tuzhileixing;
        private byte[] tuzhifiles;//文件
        private BinaryReader read = null;//二进制读取
        private void Frxinzengtaizhang_Load(object sender, EventArgs e)
        {
            string sql = "select  MAX(CAST(substring(a.工作令号,7,500) AS int)) as '最大工令' from tb_caigouliaodan a where a.料单类型 = '模具部' and substring(a.工作令号,0,3)='18'";
            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            if (dt1.Rows[0]["最大工令"].ToString() != "")
            {
                txtgonglinghao2.Text = int.Parse(dt1.Rows[0]["最大工令"].ToString()) + 1 + "";
            }

            txtgonglighao1.Text = "18";
      
            string Sql1 = "select name from tb_client";
            DataSet Ds = new DataSet();
            DataTable dt2 = SQLhelp.GetDataTable(Sql1, CommandType.Text);

            for(int i=0;i<dt2.Rows.Count;i++)
            {
                comkehu.Properties.Items.Add(dt2.Rows[i]["name"]);
                
            }
        
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtfujian.Text = dialog.FileName;
                    FileInfo info = new FileInfo(@txtfujian.Text);
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
                    FileStream file = new FileStream(txtfujian.Text, FileMode.Open, FileAccess.Read);
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtgonglighao1.Text.Trim() == "" || txtgonglinghao2.Text.Trim() == "")
            {
                MessageBox.Show("工作令号不能为空！");

                return;
            }
            if (dateEdit1.Text.Trim() == "")
            {
                MessageBox.Show("交货日期不能为空");
                return;
            }

            String gonglinghao = txtgonglighao1.Text.Trim() + "-MD-" + txtgonglinghao2.Text.Trim();
            string sql1 = "";
            txtmingcheng.Text = txtxiangmumingcheng.Text;
            if (txtfujian.Text.Trim() == "")
            {
                sql1 = "INSERT INTO tb_caigouliaodan(工作令号,模具部订单号申请号,项目名称,模具部接单日期,当前状态,模具部交货日期,型号,名称,单位,模具部销售单价,附件名称,附件类型,料单类型,模具部客户,模具部联系人,模具部申请人,数量,实际采购数量) VALUES('" + gonglinghao + "', '" + textEdit1.Text.Trim() + "', '" + txtxiangmumingcheng.Text.Trim() + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '1','" + dateEdit1.Text + "', '" + txtxinghao.Text.Trim() + "','" + txtmingcheng.Text.Trim() + "','" + txtdanwei.Text.Trim() + "','" + txtdanjia.Text + "','" + tuzhimingcheng + "','" + tuzhileixing + "','模具部','" + comkehu.Text + "','" + txtlianxiren.Text + "','" + yonghu + "','" + txtshuliang.Text.Trim() + "','" + txtshuliang.Text.Trim() + "')";
                SQLhelp.ExecuteNonquery2(sql1, CommandType.Text);
            }
            else{
                sql1 = "INSERT INTO tb_caigouliaodan(工作令号,模具部订单号申请号,项目名称,模具部接单日期,当前状态,模具部交货日期,型号,名称,单位,模具部销售单价,附件名称,附件类型,料单类型,模具部客户,模具部联系人,模具部申请人,附件,数量,实际采购数量) VALUES('" + gonglinghao + "', '" + textEdit1.Text.Trim() + "', '" + txtxiangmumingcheng.Text.Trim() + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '1','" + dateEdit1.Text + "', '" + txtxinghao.Text.Trim() + "','" + txtmingcheng.Text.Trim() + "','" + txtdanwei.Text.Trim() + "','" + txtdanjia.Text + "','" + tuzhimingcheng + "','" + tuzhileixing + "','模具部','" + comkehu.Text + "','" + txtlianxiren.Text + "','" + yonghu + "',@pictuzhi,'" + txtshuliang.Text.Trim() + "','" + txtshuliang.Text.Trim() + "')";
                SQLhelp.ExecuteNonquerytuzhi(sql1, CommandType.Text, tuzhifiles);
            }



            

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtshuliang_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtshuliang_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtdanjia_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            client client = new client();
            client.ShowDialog();
        }
    }
}