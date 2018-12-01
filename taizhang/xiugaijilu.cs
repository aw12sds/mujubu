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
    public partial class xiugaijilu : Form
    {
        public string id;
        public string lujing;
        public xiugaijilu(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void xiugaijilu_Load(object sender, EventArgs e)
        {
            gridView1.Columns["修改内容"].OptionsColumn.AllowEdit = true;
            string Sql1 = "select * from tb_xiugaijilu where 业务id='" + id + "' order by 修改时间 desc";
            DataTable dt2 = SQLhelp.GetDataTable(Sql1, CommandType.Text);
            gridControl1.DataSource = dt2;
        }

        private void 查看附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string sql = "select 附件名称 from tb_xiugaijilu  where id='" + id + "'";

            string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            if (jiance == "")
            {
                MessageBox.Show("无附件！");
                return;

            }
            string leixing = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件类型").ToString();
            string mingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件名称").ToString();

            string sql1 = "Select 附件 From tb_xiugaijilu  Where id='" + id + "'";
            byte[] mypdffile = null;
            mypdffile = SQLhelp.duqu(sql1, CommandType.Text);
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
