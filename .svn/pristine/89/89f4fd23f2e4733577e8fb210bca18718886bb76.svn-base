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
    public partial class 上传bom清单 : Form
    {
        public 上传bom清单(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        public string yonghu;
        public string tuzhimingcheng;
        public string tuzhileixing;
        private byte[] tuzhifiles;//文件
        private BinaryReader read = null;//二进制读取
        public string id;
        private void button2_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            string sql= "update tb_caigouliaodan set 模具部bom清单名称='" + tuzhimingcheng + "',模具部bom清单类型='"+ tuzhileixing+ "',bom清单=@pic where id='" + id + "'";
            SQLhelp.ExecuteNonquery(sql, CommandType.Text, tuzhifiles);
            this.Close();

          
        }
    }
}
