﻿using Aspose.Words;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mujubu.工艺
{
    public partial class 修改工艺 : Form
    {
        public string id;
        public string id2;
        public string yonghu;
        public DataTable dt1;
        public 修改工艺(string id,string id1)
        {
            InitializeComponent();
            this.id2 = id;
            this.id = id1;
        }

        private void 修改工艺_Load(object sender, EventArgs e)
        {
            reload();
        }
        public void reload()
        {
            string sql = "select * from tb_gongxu_manage where 零件id='" + id + "' order by cast(顺序 as int) ";
            dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            this.gridControl1.DataSource = dt1;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            增加工序 增加工序 = new 增加工序(id);
            增加工序.ShowDialog();
                reload();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();

            string sql = "select * from tb_caigouliaodan where id='" + id2 + "'";
            dt3 = SQLhelp.GetDataTable(sql, CommandType.Text);
            string sql1 = "select * from tb_mujubu_lingjian where id='" + id + "'";
            dt4 = SQLhelp.GetDataTable(sql1, CommandType.Text);
            string 工作令号 = dt3.Rows[0]["工作令号"].ToString();
            string 产品名称 = dt3.Rows[0]["名称"].ToString();
            string 项目名称 = dt3.Rows[0]["项目名称"].ToString();
            string 数量 = dt3.Rows[0]["实际采购数量"].ToString();
            string 下单日期 = dt3.Rows[0]["模具部接单日期"].ToString();
            string 客户 = dt3.Rows[0]["模具部客户"].ToString();
            string 交货日期 = dt3.Rows[0]["模具部交货日期"].ToString();

            string 图号 = dt4.Rows[0]["图号"].ToString();
            string 零件名称 = dt4.Rows[0]["零件名称"].ToString();
            string 材质 = dt4.Rows[0]["材质"].ToString();
            string 编制 = dt4.Rows[0]["编制"].ToString();
            string 校对 = yonghu + "  "+DateTime.Now + "";
            string tempFile = Application.StartupPath + "\\零部件流转本.doc";
            //string tempFile = "../../bin/resouce/工艺卡模板新.doc";
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);
            builder.MoveToBookmark("项目名称");
            builder.Write(项目名称);
            builder.MoveToBookmark("工作令1");
            builder.Write(工作令号);
            builder.MoveToBookmark("工作令2");
            builder.Write(工作令号);
            builder.MoveToBookmark("交货日期1");
            builder.Write(交货日期);
            builder.MoveToBookmark("交货日期2");
            builder.Write(交货日期);
            builder.MoveToBookmark("产品名称");
            builder.Write(产品名称);
            builder.MoveToBookmark("数量");
            builder.Write(数量); 
            builder.MoveToBookmark("客户");
            builder.Write(客户);
            builder.MoveToBookmark("零件名称");
            builder.Write(零件名称);
            builder.MoveToBookmark("图号");
            builder.Write(图号);
            builder.MoveToBookmark("材质");
            builder.Write(材质);
            int Colnum = gridView1.Columns.Count;//表格列数   
            int Rownum = gridView1.RowCount;//表格行数   
            //生成数据行   
            for (int i =0; i < Rownum; i++)
            {
                int j = i + 1;
                string 工序书签 = "工序" + j;
                string 工序内容书签 = "内容" + j;
                string 加工数量书签 = "数量" + j;
                string 价格书签 = "价格" + j;
                builder.MoveToBookmark(工序书签);
                builder.Write(gridView1.GetRowCellDisplayText(i, "工序名称"));
                builder.MoveToBookmark(工序内容书签);
                builder.Write(gridView1.GetRowCellDisplayText(i, "工序内容"));
                builder.MoveToBookmark(加工数量书签);
                builder.Write(gridView1.GetRowCellDisplayText(i, "加工数量"));
                builder.MoveToBookmark(价格书签);
                builder.Write(gridView1.GetRowCellDisplayText(i, "金额单价"));
            }
            string docName = 工作令号 + " " + 零件名称 + ".doc";

            FileInfo info1 = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + docName);
            string fileName11 = info1.Name.ToString();

            doc.Save(info1.DirectoryName + "\\" + fileName11);
            string lujing = info1.DirectoryName + "\\" + fileName11;
            System.Diagnostics.Process.Start(lujing);
            //MessageBox.Show("工艺卡保存到桌面成功！", "提示");

        }

      

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int Colnum = gridView1.Columns.Count;//表格列数   
            int Rownum = gridView1.RowCount;//表格行数   

            for (int i = 0; i < Rownum; i++)
            {
                int j = i + 1;
                string id = gridView1.GetRowCellDisplayText(i, "id");
                string 工序内容 = gridView1.GetRowCellDisplayText(i, "工序内容");
                string 金额 = gridView1.GetRowCellDisplayText(i, "金额单价");
                string 数量 = gridView1.GetRowCellDisplayText(i, "加工数量");
                string sql = "update tb_gongxu_manage  set 工序内容='" + 工序内容 + "',加工数量='" + 数量+ "',金额单价='" + 金额 + "' where id = '" + id + "'";

                SQLhelp.ExecuteNonquery2(sql, CommandType.Text);

            }
        }
          private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //int Colnum = gridView1.Columns.Count;//表格列数   
            //int Rownum = gridView1.RowCount;//表格行数   

            //for (int i = 0; i < Rownum; i++)
            //{
            //    int j = i + 1;
            //    string id = gridView1.GetRowCellDisplayText(i, "id");
            //    string 金额 = gridView1.GetRowCellDisplayText(i, "金额单价");
            //    string sql = "update tb_gongxu_manage  set 金额单价='" + 金额+"' where id = '" + id + "'";

            //    SQLhelp.ExecuteNonquery2(sql, CommandType.Text);

            //}

        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string 删除id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string 顺序 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "顺序").ToString();
            string 删除sql = "delete from tb_gongxu_manage  where id = '" + 删除id + "'";

            SQLhelp.ExecuteNonquery2(删除sql, CommandType.Text);
            string 修改顺序sql = "update tb_gongxu_manage set 顺序=顺序-1 where 零件id='" + id + "' and 顺序>'" + 顺序 + "'";
            SQLhelp.ExecuteScalar(修改顺序sql, CommandType.Text);
           
                reload();

        }
    }
}
