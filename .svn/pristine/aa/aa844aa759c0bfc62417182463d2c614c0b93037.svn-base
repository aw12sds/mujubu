using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using mujubu.工艺;
using System.Windows.Forms;

namespace mujubu.taizhang
{
    public partial class chakanbom1 : Form
    {
        public string yonghu;
        public string id;
        public DataTable dt1;
        public DataTable dt2;
        public chakanbom1(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void chakanbom1_Load(object sender, EventArgs e)
        {
            reload();
        }
        public void reload()
        {
            string sql3 = "Select 序号,编码,型号,名称,单位,数量,类型,项目工令号,时间,制造类型,备注 From tb_caigouliaodan  Where 定位='" + id + "'";
            dt1 = SQLhelp.GetDataTable(sql3, CommandType.Text);
            dt1.Columns.Add("工艺");
            this.gridControl1.DataSource = dt1;
            for(int i=0;i<dt1.Rows.Count;i++)
            {
                string sql = "select * from tb_mujubu_lingjian where 业务id='" + id + "'and 零件名称='"+dt1.Rows[i]["名称"].ToString()+"' ";
                dt2 = SQLhelp.GetDataTable(sql, CommandType.Text);
                if (dt2.Rows.Count == 0)
                {
                    dt1.Rows[i]["工艺"] = "不存在";
                }
                else dt1.Rows[i]["工艺"] = "存在";
            }
 
        }

        private void 查看工序ToolStripMenuItem_Click(object sender, EventArgs e)
        {   string lingjianmingcheng=Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "名称"));
            Formlingjian1 formlingjian1 = new Formlingjian1(id,lingjianmingcheng);
            formlingjian1.yonghu = yonghu;
            formlingjian1.ShowDialog();
            return;
            //var uid = Guid.NewGuid().ToString(); uuid

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            
            DataTable dt3=new DataTable();
            DataTable dt4 = new DataTable() ;
            dt3.Columns.Add("工作令号");
            dt3.Columns.Add("项目名称");
            dt3.Columns.Add("图号");
            dt3.Columns.Add("零件名称");
            dt3.Columns.Add("材质");
            dt3.Columns.Add("时间");
            dt3.Columns.Add("数量");


            dt4.Columns.Add("工作令号");
            dt4.Columns.Add("项目名称");
            dt4.Columns.Add("交货日期");
            dt4.Columns.Add("零件名称");
            dt4.Columns.Add("材质");
            dt4.Columns.Add("类型");
            dt4.Columns.Add("数量");
            dt4.Columns.Add("规格");
            dt4.Columns.Add("模具部成本是否工序");
            dt4.Columns.Add("备注");
            dt4.Columns.Add("附件");


            int[] a= gridView1.GetSelectedRows();
            if(a.Length==0)
            {
                MessageBox.Show("请先勾选要采购的零件！");
            }
            else
            {
                foreach(int i in a )
                {
                    string mingcheng = Convert.ToString(gridView1.GetRowCellValue(i, "名称"));
                    string sql = "select a.项目名称,a.工作令号,b.图号,b.零件名称,b.材质,b.时间,a.数量 from tb_caigouliaodan as a, tb_mujubu_lingjian as b where a.名称=b.零件名称 and a.定位=b.业务id and a.定位='"+id+"'and a.名称='"+mingcheng+"'";
                    dt3 = SQLhelp.GetDataTable(sql, CommandType.Text);
                    dt4.Merge(dt3, true,MissingSchemaAction.Ignore);
                }
                //FrPurchase xin = new FrPurchase();
                //xin.dt = dt4;
                //xin.ShowDialog();
                //CaigouLingjian1 caigoulingjian1 = new CaigouLingjian1(id);
                //caigoulingjian1.dt = dt4;
                //caigoulingjian1.ShowDialog();
            }
        }
    }
}
    

