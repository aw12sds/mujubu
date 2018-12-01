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
    public partial class FrPurchase : Form
    {
        public string yonghu;
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        public string tuzhimingcheng;
        public string tuzhileixing;
        private byte[] tuzhifiles;//文件
        public DataTable dt;
        private BinaryReader read = null;//二进制读取
        public FrPurchase()
        {
            InitializeComponent();
        }

        private void 新采购1_Load(object sender, EventArgs e)
        {   
            this.repositoryItemComboBox1.Items.Add("五金辅材");
            this.repositoryItemComboBox1.Items.Add("原材料");
            this.repositoryItemComboBox1.Items.Add("工序外协");
            this.gridControl1.DataSource = dt;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string xiangmumingcheng = gridview1.GetRowCellDisplayText(i, "项目名称").Trim();
                string jiaohuoriqi = gridview1.GetRowCellDisplayText(i, "交货日期");
                string caizhi = gridview1.GetRowCellDisplayText(i, "材质");
                string shuliang = gridview1.GetRowCellDisplayText(i, "数量");
                string guige = gridview1.GetRowCellDisplayText(i, "规格");
                string fujian = gridview1.GetRowCellDisplayText(i, "附件");
                if(gridview1.GetRowCellDisplayText(i, "工作令号").Trim() == ""|| gridview1.GetRowCellDisplayText(i, "工作令号").Trim()==null)
                {
                    MessageBox.Show("工作令号不能为空!");
                    return;
                }
                if(gridview1.GetRowCellDisplayText(i, "零件名称").Trim() == ""|| gridview1.GetRowCellDisplayText(i, "零件名称").Trim()==null)
                {
                    MessageBox.Show("名称不能为空!");
                    return;
                }
                if(gridview1.GetRowCellDisplayText(i, "备注").Trim() == ""|| gridview1.GetRowCellDisplayText(i, "备注").Trim()==null)
                {
                    MessageBox.Show("备注不能为空!");
                    return;
                }
                if(gridview1.GetRowCellDisplayText(i, "模具部成本是否工序").Trim() == ""|| gridview1.GetRowCellDisplayText(i, "模具部成本是否工序").Trim()==null)
                {
                    MessageBox.Show("请选择类型!");
                    return;
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string gongzuolinghao = gridview1.GetRowCellDisplayText(i, "工作令号").Trim(); ;
                string xiangmumingcheng = gridview1.GetRowCellDisplayText(i, "项目名称").Trim();
                string jiaohuoriqi = gridview1.GetRowCellDisplayText(i, "交货日期");
                string mingcheng = gridview1.GetRowCellDisplayText(i, "零件名称").Trim();
                string caizhi = gridview1.GetRowCellDisplayText(i, "材质");
                string leixing = gridview1.GetRowCellDisplayText(i, "模具部成本是否工序").Trim();
                string shuliang = gridview1.GetRowCellDisplayText(i, "数量");
                string guige = gridview1.GetRowCellDisplayText(i, "规格");
                string beizhu = gridview1.GetRowCellDisplayText(i, "备注").Trim();
                string fujian = gridview1.GetRowCellDisplayText(i, "附件");
                MessageBox.Show("" + tuzhimingcheng+","+tuzhileixing+","+tuzhifiles);
                //if (fujian == "")
                //{
                //    string sql1 = "INSERT INTO tb_caigouliaodan(工作令号,模具部接单日期,当前状态,模具部交货日期,项目名称,名称,型号,类型,备注,模具部申请人,附件名称,附件类型,料单类型,到货情况,申购人,收到料单日期,模具部成本是否工序) VALUES('" + gongzuolinghao + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '1','" + jiaohuoriqi + "', '" + xiangmumingcheng + "', '" + mingcheng + "','" + guige + "','" + caizhi + "','" + beizhu + "','" + yonghu + "','" + tuzhimingcheng + "','" + tuzhileixing + "','模具部原材料',0,'" + yonghu + "','" + DateTime.Now + "','" + leixing + "')";
                //    SQLhelp.ExecuteNonquery2(sql1, CommandType.Text);
                //}
                //else
                //{
                //    string sql1 = "INSERT INTO tb_caigouliaodan(工作令号,模具部接单日期,当前状态,模具部交货日期,项目名称,名称,型号,类型,备注,模具部申请人,附件名称,附件类型,料单类型,附件,到货情况,申购人,收到料单日期,模具部成本是否工序) VALUES('" + gongzuolinghao + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '1','" + jiaohuoriqi + "', '" + xiangmumingcheng + "', '" + mingcheng + "','" + guige  + "','" + caizhi  + "','" + beizhu  + "','" + yonghu + "','" + tuzhimingcheng + "','" + tuzhileixing + "','模具部原材料',@pictuzhi,0,'" + yonghu + "','" + DateTime.Now + "','" + leixing  + "')";
                //    SQLhelp.ExecuteNonquerytuzhi(sql1, CommandType.Text, tuzhifiles);
                //}

                this.DialogResult = DialogResult.OK;
                this.Close();
            }


            }
        private void fujianxuanze(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {

                    DataRow dr = gridview1.GetDataRow(gridview1.FocusedRowHandle);
                    dr["附件"] = dialog.FileName;
                    FileInfo info = new FileInfo(@dr["附件"].ToString());
                    //获得文件大小
                    fileSize = info.Length;
                    ////提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName = info.FullName.Remove(index);
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                    tuzhimingcheng = fileName;
                    ////获得文件扩展名
                    tuzhileixing = info.Extension.Replace(".", "");
                    ////把文件转换成二进制流
                    tuzhifiles = new byte[Convert.ToInt32(fileSize)];
                    FileStream file = new FileStream(dr["附件"].ToString(), FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(tuzhifiles, 0, Convert.ToInt32(fileSize));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
        }
    }
}
