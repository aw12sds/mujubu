using NetWork.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mujubu
{
    public partial class FrLogin : Form
    {
        public FrLogin()
        {
            InitializeComponent();
        }
        Form1 Form1 = new Form1();
        getData getData = new getData();
        private void buttonX1_Click(object sender, EventArgs e)
        {
            // getData getData = new getData();
            //if (getData.ifping("10.15.1.252"))
            // {

            // }else if(getData.ifping("47.97.210.239"))
            // {

            // }
            getData.getiprouter();
            if (textBoxX2.Text == string.Empty)
            {
                MessageBox.Show("请输入密码！", "提示");
                return;
            }

            string sql = "select * from tb_operator where 用户名 = '" + textBoxX1.Text + "' and 密码='" + textBoxX2.Text + "'";
           
            DataTable result = SQLhelp.GetDataTable_office(sql, CommandType.Text);
            if (result.Rows.Count > 0) 
            {
                this.Hide();
                Form1.yonghu = textBoxX1.Text;
                Form1.ShowDialog();

            }
        }
       
        private void FrLogin_Load(object sender, EventArgs e)
        {
            //String sql = "select * from tb_caigouliaodan where 料单类型='模具部' and 制造类型='外协' and 供方名称='昆山禾颂丰模具科技有限公司'";

            //DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            //string ret = DataTableToString(dt);

            byte[] b= { 37,12,23,37,161,179 };
            string ret = System.Text.Encoding.UTF8.GetString(b);
            byte[] b2 = System.Text.Encoding.UTF8.GetBytes(ret);
            byte[] mypdffile2 = System.Text.Encoding.Unicode.GetBytes(ret);

        }
        public static string DataTableToString(DataTable dt)
        {
            StringBuilder strData = new StringBuilder();
            StringWriter sw = new StringWriter();
            dt.TableName = "aa";
            //DataTable 的当前数据结构以 XML 架构形式写入指定的流
            dt.WriteXmlSchema(sw);
            strData.Append(sw.ToString());
            sw.Close();
            strData.Append("@&@");
            for (int i = 0; i < dt.Rows.Count; i++)           //遍历dt的行
            {
                DataRow row = dt.Rows[i];
                if (i > 0)                                    //从第二行数据开始，加上行的连接字符串
                {
                    strData.Append("#$%");
                }
                for (int j = 0; j < dt.Columns.Count; j++)    //遍历row的列
                {
                    if (j > 0)                                //从第二个字段开始，加上字段的连接字符串
                    {
                        strData.Append("^&*");
                    }
                    strData.Append(Convert.ToString(row[j])); //取数据
                }
            }

            return strData.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process pr = new Process();//声明一个进程类对象
            pr.StartInfo.FileName = "D:\\svn\\ztt\\unity\\project\\zttfactory\\生成\\生成.exe";
            pr.Start();
        }
    }
}
