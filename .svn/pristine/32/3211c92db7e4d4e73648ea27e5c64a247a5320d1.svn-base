using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mujubu.工艺
{
    public partial class shebei : Form
    {
        public shebei()
        {
            InitializeComponent();
        }
        private void reload()
        {
            string s1 = "select a.*,b.工序名 from tb_gongxu_device a left  join tb_gongxu_name b on a.工序id = b.id";
            DataTable dt = SQLhelp.GetDataTable(s1, CommandType.Text);
            this.gridControl1.DataSource = dt;

        }
        private void shebei_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            新增设备 新增设备 = new 新增设备();
            新增设备.ShowDialog();
            if (新增设备.DialogResult == DialogResult.OK)
            {
                reload();
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
           

            DialogResult RSS = MessageBox.Show(this, "确定要删除选中行数据吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (RSS)
            {
                case DialogResult.Yes:
                   
                        string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
                        string sql = "delete from tb_gongxu_device where id='" + id + "' ";
                        int s = Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text));

                    MessageBox.Show("删除数据成功！", "提示");
                    break;
                case DialogResult.No:
                    MessageBox.Show("删除数据失败！", "提示");
                    break;
            }

            reload();
        }
    }
}
