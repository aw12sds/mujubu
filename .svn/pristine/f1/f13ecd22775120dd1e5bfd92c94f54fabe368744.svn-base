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
    public partial class edithetong : Form
    {
        public String id;
        public string tuzhimingcheng;
        public string tuzhileixing;
    
        private byte[] tuzhifiles;//文件
    
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private BinaryReader read = null;//二进制读取
        public edithetong(String id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string sql2 = "update tb_caigouliaodan  set 合同=@pic,合同名称='" + tuzhimingcheng + "',合同类型='" + tuzhileixing + "' where id='" + id + "'";
            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, tuzhifiles);
            MessageBox.Show("修改成功,请刷新界面");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxX1.Text = dialog.FileName;
                    FileInfo info = new FileInfo(@textBoxX1.Text);
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
                    FileStream file = new FileStream(textBoxX1.Text, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(tuzhifiles, 0, Convert.ToInt32(fileSize));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
        }

        private void edithetong_Load(object sender, EventArgs e)
        {
          
        }
    }
}
