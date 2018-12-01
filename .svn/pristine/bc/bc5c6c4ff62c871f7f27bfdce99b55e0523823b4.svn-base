using Aspose.Cells;
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
    public partial class 上传bom清单1 : DevExpress.XtraEditors.XtraForm
    {
        public 上传bom清单1(string id,string shuliang,string xiangmumingcheng)
        {
            InitializeComponent();
            this.id = id;
            this.shuliang11 = shuliang;
            this.xiangmu = xiangmumingcheng;
        }
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        public string yonghu;
        public DataTable dt;
        public string tuzhimingcheng;
        public string tuzhileixing;
        private byte[] tuzhifiles;//文件
        private BinaryReader read = null;//二进制读取
        public string id;
        private string shuliang11;
        private string xiangmu;

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            /*string sql = "update tb_caigouliaodan set 模具部bom清单名称='" + tuzhimingcheng + "',模具部bom清单类型='" + tuzhileixing + "',bom清单=@pic where id='" + id + "'";
            SQLhelp.ExecuteNonquery(sql, CommandType.Text, tuzhifiles);
            this.Close();*/

            string b = textBox1.Text;
            if(b.Trim()=="")
            {
                MessageBox.Show("请选择文件！");
                return; 
            }
            int youxiaohangshu=0;
            Workbook book = new Workbook(b);
            Worksheet sheet = book.Worksheets["Sheet1"];
            Cells cells = sheet.Cells;
            string gonglinghao = sheet.Cells[3, 7].StringValue;
            string shebei = sheet.Cells[3,2].StringValue;
            dt = sheet.Cells.ExportDataTableAsString(7, 0, cells.MaxDataRow, 11);
            dt.Columns["Column1"].ColumnName = "序号";
            dt.Columns["Column2"].ColumnName = "编码";
            dt.Columns["Column3"].ColumnName = "型号";
            dt.Columns["Column4"].ColumnName = "名称";
            dt.Columns["Column5"].ColumnName = "单位";
            dt.Columns["Column6"].ColumnName = "数量";
            dt.Columns["Column7"].ColumnName = "类型";
            dt.Columns["Column8"].ColumnName = "库存数";
            dt.Columns["Column9"].ColumnName = "要求到货日期";
            dt.Columns["Column10"].ColumnName = "制造类型";
            dt.Columns["Column11"].ColumnName = "备注";

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    if(dt.Rows[i]["编码"].ToString()== ""&& dt.Rows[i]["型号"].ToString()== ""&& dt.Rows[i]["名称"].ToString()== ""&& dt.Rows[i]["单位"].ToString()==""&& dt.Rows[i]["数量"].ToString()== ""&& dt.Rows[i]["类型"].ToString() == ""&& dt.Rows[i]["库存数"].ToString()== ""&& dt.Rows[i]["要求到货日期"].ToString() == "" && dt.Rows[i]["制造类型"].ToString() == "" && dt.Rows[i]["备注"].ToString() == "" )
                    {
                        youxiaohangshu = i;
                        break;
                    }
                    float a = 0;
                    if (float.TryParse(dt.Rows[i]["数量"].ToString(), out a) == false)
                    {
                        int aaa = i + 1;
                        MessageBox.Show("第" + aaa + "行料单" + "数量必须是数字！");
                        return;
                    }

                    if (float.TryParse(shuliang11, out a) == false)
                    {
                        MessageBox.Show("技术指标的数量必须是数字！");
                        return;
                    }
                    if (float.TryParse(dt.Rows[i]["库存数"].ToString(), out a) == false)
                    {
                        int aaa = i + 1;
                        MessageBox.Show("第" + aaa + "行料单的" + "库存数必须是数字！");
                        return;
                    }

                    if (dt.Rows[i]["制造类型"].ToString() != "零件" && dt.Rows[i]["制造类型"].ToString() != "机械标准件" && dt.Rows[i]["制造类型"].ToString() != "电气标准件" && dt.Rows[i]["制造类型"].ToString() != "库存件" && dt.Rows[i]["制造类型"].ToString() != "外购")
                    {
                        int aaa = i + 1;
                        MessageBox.Show("第" + aaa + "行料单的" + "制造类型必须符合规范，只能是零件、机械标准件、电气标准件、库存件、外购！");
                        return;
                    }
                    double shijicaigou = Convert.ToDouble(shuliang11) * Convert.ToDouble(dt.Rows[i]["数量"].ToString()) - Convert.ToDouble(dt.Rows[i]["库存数"].ToString());
                    if (dt.Rows[i]["制造类型"].ToString() != "库存件")
                    {
                        int aaa = i + 1;
                        if (shijicaigou <= 0)
                        {
                            MessageBox.Show("第" + aaa + "行料单" + "计算得出的实际采购（加工）数量存在负数或者是0，请检查！");
                            return;

                        }
                    }
                    if (dt.Rows[i]["制造类型"].ToString() == "库存件")
                    {
                        int aaaa = i + 1;
                        if (shijicaigou != 0)
                        {
                            MessageBox.Show("第" + aaaa + "行料单" + "库存件算出不等于0，请重新填写库存数！");
                            return;
                        }
                    }

                }
                if(youxiaohangshu==0)
                {
                    MessageBox.Show("Excel中无有效数据！");
                    return;
                }
                for (int i = 0; i < youxiaohangshu; i++)
                {
                    string a = dt.Rows[i]["型号"].ToString().Trim();
                    string a1=a.Replace("Ø", "Φ");
                    double shijicaigou = Convert.ToDouble(shuliang11) * Convert.ToDouble(dt.Rows[i]["数量"].ToString()) - Convert.ToDouble(dt.Rows[i]["库存数"].ToString());
                    string sql = "insert into tb_caigouliaodan (序号,工作令号,项目名称,设备名称,时间,型号,名称,单位,数量,类型,备注,申购人,实际采购数量,收到料单日期,料单类型,项目工令号,制造类型,定位)  values ('" + dt.Rows[i]["序号"].ToString() + "','" + gonglinghao + "','" + xiangmu + "','" + shebei + "','" + dt.Rows[i]["要求到货日期"] + "','" + a1.Trim() + "','" + dt.Rows[i]["名称"].ToString().Trim() + "','" + dt.Rows[i]["单位"].ToString() + "','" + dt.Rows[i]["数量"].ToString() + "','" + dt.Rows[i]["类型"].ToString().Trim() + "','" + dt.Rows[i]["备注"].ToString() + "','" + yonghu + "','" + shijicaigou + "','" + DateTime.Now + "','"+"模具部清单" + "','"+ dt.Rows[i]["库存数"].ToString() + "','" + dt.Rows[i]["制造类型"].ToString() + "','" + id + "')  ";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                }
                MessageBox.Show("生成成功！");
                this.Close();
                return;
            }


        }

    }
}
