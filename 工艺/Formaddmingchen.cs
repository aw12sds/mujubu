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
    public partial class Formaddmingchen : Form
    {
        public Formaddmingchen()
        {
            InitializeComponent();
            reload();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Formgongxuadd a = new Formgongxuadd();
            
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                this.reload();//重新绑定
            }
        }

        private void Formaddmingchen_Load(object sender, EventArgs e)
        {

        }
        public void reload()
        {
            string s1 = "select * from tb_gongxu_name";
            DataTable dt = SQLhelp.GetDataTable(s1, CommandType.Text);
            this.dataGridView1.DataSource = dt;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult RSS = MessageBox.Show(this, "确定要删除选中行数据吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (RSS)
            {
                case DialogResult.Yes:
                    for (int i = this.dataGridView1.SelectedRows.Count; i > 0; i--)
                    {
                        int ID = Convert.ToInt32(dataGridView1.SelectedRows[i - 1].Cells[0].Value);
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[i - 1].Index);
                        string sql = "delete from tb_gongxu_name where id='" + ID.ToString() + "' ";
                        int s = Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text));
                      
                    }
                    MessageBox.Show("成功删除选中行数据！", "提示");
                    break;
                case DialogResult.No:
                    MessageBox.Show("删除数据失败！", "提示");
                    break;
            }

            reload();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}
