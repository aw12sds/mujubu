using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mujubu.客户
{
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
        }
        private void reload()
        {
            string s1 = "select id as 序号,name as 客户名,phone as 手机号 from tb_client";
            DataTable dt = SQLhelp.GetDataTable(s1, CommandType.Text);
            this.dataGridView1.DataSource = dt;

        }

        private void client_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            addclient addclient = new addclient();
            addclient.ShowDialog();
            if (addclient.DialogResult == DialogResult.OK)
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
                    for (int i = this.dataGridView1.SelectedRows.Count; i > 0; i--)
                    {
                        int ID = Convert.ToInt32(dataGridView1.SelectedRows[i - 1].Cells[0].Value);
                        string sql = "delete from tb_client where id='" + ID.ToString() + "' ";
                        int s = Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text));

                    }
                    MessageBox.Show("删除数据成功！", "提示");
                    break;
                case DialogResult.No:
                    MessageBox.Show("删除数据失败！", "提示");
                    break;
            }

            reload();
        }

        private void buttonItem1_Click_1(object sender, EventArgs e)
        {
            string ID = "";
            string name = "";
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择一行数据！");

            }
            else
            {
                for (int i = this.dataGridView1.SelectedRows.Count; i > 0; i--)
                {

                    ID = dataGridView1.SelectedRows[i - 1].Cells[0].Value.ToString();
                    name = dataGridView1.SelectedRows[i - 1].Cells[1].Value.ToString();

                }
                updateclient updateclient = new updateclient(ID, name);
                updateclient.ShowDialog();
                if (updateclient.DialogResult == DialogResult.OK)
                {
                    reload();
                }
            }

            //updateclient updateclient = new updateclient(ID,name);
            //updateclient.ShowDialog();

        }
    }
}
