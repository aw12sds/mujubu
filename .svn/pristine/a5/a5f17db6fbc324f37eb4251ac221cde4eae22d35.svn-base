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

namespace mujubu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string lujing;
        getData getData = new getData();
        private void Form2_Load(object sender, EventArgs e)
        {
            
            string sql = "select id,附件名称,附件类型,用户,时间 from tb_test";
            DataTable dt =getData.getdata(sql, "db_xiangmuguanli");
            gridControl1.DataSource = dt;
        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
         
          
            string leixing = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件类型").ToString();
            string mingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件名称").ToString();

            string sql1 = "Select 附件 From tb_test  Where id='" + id + "'";



            byte[] mypdffile = SQLhelp.duqu(sql1, CommandType.Text);




            string aaaa = System.Environment.CurrentDirectory;
            lujing = aaaa + "\\" + mingcheng + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();

            System.Diagnostics.Process.Start(lujing);
        }
    }
}
