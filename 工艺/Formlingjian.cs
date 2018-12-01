﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mujubu.工艺
{
    public partial class Formlingjian : Form
    {
        public string yonghu;
        public string id;
        public DataTable dt1;
        public Formlingjian(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Formlingjian_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formaddgongxu Formaddgongxu = new Formaddgongxu(id);
            Formaddgongxu.yonghu = yonghu;
            Formaddgongxu.ShowDialog();
            if (Formaddgongxu.DialogResult == DialogResult.OK)
            {
                reload();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
      


            DialogResult result = MessageBox.Show("确实要删除吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
                string sql = "delete  from tb_mujubu_lingjian where id='" + id + "'";
                SQLhelp.ExecuteNonquery2(sql, CommandType.Text);

                //string sql1 = "select 业务id from tb_mujubu_lingjian where id='"+ id +"'";
                //string xuhao = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

                //string sql2 = "delete from tb_mujubu_paichan where where 序号='"+ xuhao +"'";
                //SQLhelp.ExecuteNonquery2(sql2, CommandType.Text);

                reload();
            }
        }
        public void reload()
        {
            string sql = "select * from tb_mujubu_lingjian where 业务id='" + id + "'";
            dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            this.gridControl1.DataSource = dt1;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            //string id1 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string sql = "select * from tb_mujubu_lingjian where 业务id='" + id + "'";
            dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            //this.gridControl1.DataSource = dt1;
            if ( dt1.Rows.Count== 0)
            {
                MessageBox.Show("没有工艺卡片！");
            }
            else
            {
                string id1 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
                修改工艺 修改工艺 = new 修改工艺(id, id1);
                修改工艺.yonghu = yonghu;
                修改工艺.ShowDialog();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void 修改图号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id1 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            xiugaituhaohemingcheng1 xiugai = new xiugaituhaohemingcheng1(id1);
            xiugai.ShowDialog();
            reload();
        }
    }
}
