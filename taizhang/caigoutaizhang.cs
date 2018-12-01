﻿using Aspose.Cells;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using mujubu.工艺;
using mujubu.taizhang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetWork.util;
using mujubu.公共类;
using NetWorkLib;

namespace mujubu.taizhang
{
    public partial class caigoutaizhang : Form
    {
        public caigoutaizhang()
        {
            InitializeComponent();
        }
        public string yonghu;
        public string lujing;
        public string gonglinghao;
        public string gonglinghaotiaojian;
        public DataTable dt1;
        public DataTable dt2;
        public DataTable dt3;
        public string 经理;
        公共 公共 = new 公共();
        private void caigoutaizhang_Load(object sender, EventArgs e)
        {
            NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
            //this.timer2.Start();
            //this.timer1.Start();
            经理 = 公共.得到人员("经理", "模具事业部");
            gridControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Blue;
            this.gridView2.IndicatorWidth = 40;
            gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.LightBlue;
            gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.LightBlue;
            update日期();
            reload();
            reload2();
            reload3();
            reload4();
            if (yonghu == 经理)
            {
                生产车间ToolStripMenuItem.Visible = true;
            }
            if (yonghu == "邹春光")
            {
                模具部销售单价.Visible = false;
                销售总价.Visible = false;
                成本单价.Visible = false;
                成本总价.Visible = false;
                开票金额.Visible = false;
            }

        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        public void reload()
        {
            if (gonglinghao != null)
            {
                gonglinghaotiaojian = " and a.工作令号='" + gonglinghao + "'";
            }
            string sql = "select a.id,a.项目名称,a.名称,a.模具部接单日期,a.工作令号,b.statename,a.型号,a.编码,a.模具部成本是否工序 as 是否工序,a.实际到货日期,a.模具部交货日期,a.实际到货数量,a.出库数量,a.库存数量,a.模具部申请人,a.采购单价 as 模具部成本单价,a.实际到货日期,a.供应商开票日期,a.税率,a.供应商开票金额,a.模具部成本总价,a.型号,a.供方名称,a.类型 as 材质,a.实际采购数量 as 数量,a.单位,a.模具部发货确认,a.备注," +
"a.附件名称,a.模具部申请人,a.附件类型," + "(CASE  WHEN a.附件类型 is null THEN  '无附件'  WHEN 附件类型 = '' THEN '无合同' else '有附件'  END) as '是否有图纸'" +
" from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state and b.cato='模具部原材料' where a.料单类型 = '模具部原材料'  " + gonglinghaotiaojian + "  ORDER BY 模具部接单日期 desc";
           dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            this.gridControl2.DataSource = dt1;
          

        }
        getData getData = new getData();
        public void reload2()
        {
            if (gonglinghao != null)
            {
                gonglinghaotiaojian = " and a.工作令号='" + gonglinghao + "'";
            }
            //            string sql = "select   a.id,a.模具部接单日期,a.工作令号,b.statename,a.当前状态,a.模具部生产车间,a.制造类型,a.项目名称,a.模具部订单号申请号,a.编码,a.模具部销售合同号,a.模具部交货日期,a.模具部申请人,a.模具部客户,a.模具部联系人,a.型号,a.名称,a.单位,a.数量,a.制造类型,Cast(a.模具部销售单价 as decimal(10,2))*Cast(a.数量 as decimal(10,0)) as '销售总价',a.模具部销售单价,a.模具部销售开票日期,a.模具部实际交货日期,a.模具部销售开票金额,a.模具部成本分摊,a.合同类型,a.合同名称,a.模具部发货数量," +
            //"a.附件名称,a.附件类型," +
            //"(CASE  WHEN a.合同类型 is null THEN '无合同' WHEN a.合同类型 = '' THEN '无合同' else '有合同'  END) as '是否有合同'," + "(CASE  WHEN a.附件类型 is null THEN  '无附件'  WHEN 附件类型 = '' THEN '无合同' else '有附件'  END) as '是否有图纸',a.备注 " +
            //" from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state  and b.cato='模具部' where a.料单类型 = '模具部'" + gonglinghaotiaojian + "  ORDER BY (left(a.工作令号, 2)+0) DESC,(substring(a.工作令号, 7,500)+0) DESC";

            //            string sql = "select   a.id,a.模具部项目名称,a.模具部发货时间,a.模具部bom清单名称,a.模具部产品类型,cast(a.模具部接单日期 as datetime) as 模具部接单日期,a.工作令号,a.图纸上传次数,b.statename,a.当前状态,a.模具部生产车间,a.制造类型,a.项目名称,a.模具部订单号申请号,a.编码,a.模具部销售合同号,cast(a.模具部交货日期 as datetime) as 模具部交货日期,a.模具部申请人,a.模具部客户,a.模具部联系人,a.型号,a.名称,a.供方名称,a.单位,a.实际采购数量 as 数量,a.制造类型,a.模具部销售单价,a.模具部自制外协修改,实际采购数量*Cast(a.模具部销售单价 as float) as '销售总价',a.模具部销售开票日期,a.模具部实际交货日期,a.模具部销售开票金额,a.模具部成本分摊,a.采购单价 as 成本单价,a.总价 as 成本总价,a.合同类型,a.合同名称,a.供应商开票日期,a.模具部发货确认,a.供应商开票金额,a.模具部发货数量," +
            //"a.附件名称,a.附件类型," +
            //"(CASE  WHEN a.合同类型 is null THEN '无合同' WHEN a.合同类型 = '' THEN '无合同' else '有合同'  END) as '是否有合同'," + "(CASE  WHEN a.附件类型 is null THEN  '无附件'  WHEN 附件类型 = '' THEN '无合同' else '有附件'  END) as '是否有图纸',a.备注 " +
            //" from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state  and b.cato='模具部' where a.料单类型 = '模具部自制件'"
            //+ "  ORDER BY (left(a.工作令号, 2)+0) DESC,(substring(a.工作令号, 7,500)+0) DESC";
            string sql = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称  from  tb_caigouliaodan  where  制造类型='模具自制件' ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridControl3.DataSource = dt;
            //dt3 = SQLhelp.GetDataTable(sql, CommandType.Text);
            //this.gridControl1.DataSource= dt3; 
            gridView1.Columns.ColumnByName("模具部状态").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView1.Columns.ColumnByName("工作令号").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView1.Columns.ColumnByName("接单日期").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            gridView1.Columns.ColumnByName("交货日期").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            gridView1.Columns.ColumnByName("模具部实际交货日期").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;

        }
        public void reload3()
        {
            if (gonglinghao != null)
            {
                gonglinghaotiaojian = " and a.工作令号='" + gonglinghao + "'";
            }
            //            string sql = "select   a.id,a.模具部接单日期,a.工作令号,b.statename,a.当前状态,a.模具部生产车间,a.制造类型,a.项目名称,a.模具部订单号申请号,a.编码,a.模具部销售合同号,a.模具部交货日期,a.模具部申请人,a.模具部客户,a.模具部联系人,a.型号,a.名称,a.单位,a.数量,a.制造类型,Cast(a.模具部销售单价 as decimal(10,2))*Cast(a.数量 as decimal(10,0)) as '销售总价',a.模具部销售单价,a.模具部销售开票日期,a.模具部实际交货日期,a.模具部销售开票金额,a.模具部成本分摊,a.合同类型,a.合同名称,a.模具部发货数量," +
            //"a.附件名称,a.附件类型," +
            //"(CASE  WHEN a.合同类型 is null THEN '无合同' WHEN a.合同类型 = '' THEN '无合同' else '有合同'  END) as '是否有合同'," + "(CASE  WHEN a.附件类型 is null THEN  '无附件'  WHEN 附件类型 = '' THEN '无合同' else '有附件'  END) as '是否有图纸',a.备注 " +
            //" from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state  and b.cato='模具部' where a.料单类型 = '模具部'" + gonglinghaotiaojian + "  ORDER BY (left(a.工作令号, 2)+0) DESC,(substring(a.工作令号, 7,500)+0) DESC";

            string sql = "select   a.id,a.模具部项目名称,a.模具部发货时间,a.模具部bom清单名称,a.模具部产品类型,cast(a.模具部接单日期 as datetime) as 模具部接单日期,a.工作令号,a.图纸上传次数,b.statename,a.当前状态,a.模具部生产车间,a.制造类型,a.项目名称,a.模具部订单号申请号,a.编码,a.模具部销售合同号,cast(a.模具部交货日期 as datetime) as 模具部交货日期,a.模具部申请人,a.模具部客户,a.模具部联系人,a.型号,a.名称,a.供方名称,a.单位,a.实际采购数量 as 数量,a.制造类型,a.模具部销售单价,a.模具部自制外协修改,实际采购数量*Cast(a.模具部销售单价 as float) as '销售总价',a.模具部销售开票日期,a.模具部实际交货日期,a.模具部销售开票金额,a.模具部成本分摊,a.采购单价 as 成本单价,a.总价 as 成本总价,a.合同类型,a.合同名称,a.供应商开票日期,a.模具部发货确认,a.供应商开票金额,a.模具部发货数量," +
"a.附件名称,a.附件类型," +
"(CASE  WHEN a.合同类型 is null THEN '无合同' WHEN a.合同类型 = '' THEN '无合同' else '有合同'  END) as '是否有合同'," + "(CASE  WHEN a.附件类型 is null THEN  '无附件'  WHEN 附件类型 = '' THEN '无合同' else '有附件'  END) as '是否有图纸',a.备注 " +
" from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state  and b.cato='模具部' where a.料单类型 = '模具部'"
+ "  ORDER BY (left(a.工作令号, 2)+0) DESC,(substring(a.工作令号, 7,500)+0) DESC";

            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridControl1.DataSource = dt;
            //dt3 = SQLhelp.GetDataTable(sql, CommandType.Text);
            //this.gridControl1.DataSource= dt3; 
                   gridView1.Columns.ColumnByName("模具部状态").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView1.Columns.ColumnByName("工作令号").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left; 
            gridView1.Columns.ColumnByName("接单日期").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            gridView1.Columns.ColumnByName("交货日期").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right; 
                gridView1.Columns.ColumnByName("模具部实际交货日期").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;

        }

        public void reload4()
        {
            if (gonglinghao != null)
            {
                gonglinghaotiaojian = " and a.工作令号='" + gonglinghao + "'";
            }


            string sql = "select   a.id,a.模具部项目名称,a.模具部发货时间,a.模具部bom清单名称,a.模具部产品类型,cast(a.模具部接单日期 as datetime) as 模具部接单日期,a.工作令号,a.图纸上传次数,b.statename,a.当前状态,a.模具部生产车间,a.制造类型,a.项目名称,a.模具部订单号申请号,a.编码,a.模具部销售合同号,cast(a.模具部交货日期 as datetime) as 模具部交货日期,a.模具部申请人,a.模具部客户,a.模具部联系人,a.型号,a.名称,a.供方名称,a.单位,a.实际采购数量 as 数量,a.制造类型,a.模具部销售单价,a.模具部自制外协修改,实际采购数量*Cast(a.模具部销售单价 as float) as '销售总价',a.模具部销售开票日期,a.模具部实际交货日期,a.模具部销售开票金额,a.模具部成本分摊,a.采购单价 as 成本单价,a.总价 as 成本总价,a.合同类型,a.合同名称,a.供应商开票日期,a.模具部发货确认,a.供应商开票金额,a.模具部发货数量," +
"a.附件名称,a.附件类型," +
"(CASE  WHEN a.合同类型 is null THEN '无合同' WHEN a.合同类型 = '' THEN '无合同' else '有合同'  END) as '是否有合同'," + "(CASE  WHEN a.附件类型 is null THEN  '无附件'  WHEN 附件类型 = '' THEN '无合同' else '有附件'  END) as '是否有图纸',a.备注 " +
" from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state  and b.cato='模具部' where a.料单类型 = '模具部部件'"
+ "  ORDER BY (left(a.工作令号, 2)+0) DESC,(substring(a.工作令号, 7,500)+0) DESC";

            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridControl4.DataSource = dt;
            //dt3 = SQLhelp.GetDataTable(sql, CommandType.Text);
            //this.gridControl1.DataSource= dt3; 
        

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确实要删除吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
                string 当前状态 = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "statename").ToString();
                if (当前状态 == "待主管审批")
                {
                    String sql = "delete from tb_caigouliaodan where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    reload();
                }
                else
                {
                    MessageBox.Show("主管已经通过,无法删除");
                }
              
            }
            
        }
        
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确实要删除吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

               



                string 当前状态 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "statename").ToString();
                if (当前状态 == "待主管审批")
                {
                    string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
                    String sql = "delete from tb_caigouliaodan where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    reload3();
                }
                else
                {
                    MessageBox.Show("主管已经通过,无法删除");
                }
            }



        }
        
        private void 合同文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string sql = "select 合同名称 from tb_caigouliaodan  where id='" + id + "'";

            string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            if (jiance == "")
            {
                MessageBox.Show("无合同！");
                return;

            }

            string leixing = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "合同类型").ToString();
            string mingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "合同名称").ToString();
           
            String sqljudgeem = "Select 合同类型,合同名称 From tb_caigouliaodan  Where id='" + id + "'";
            DataTable dt1 = SQLhelp.GetDataTable(sqljudgeem, CommandType.Text);
            if (dt1.Rows[0]["合同类型"].ToString() == "" && dt1.Rows[0]["合同名称"].ToString() == "")
            {
                MessageBox.Show("没有合同");
            }
            else
            {
                string sql1 = "Select 合同 From tb_caigouliaodan  Where id='" + id + "'";
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string 图纸上传次数 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "图纸上传次数").ToString();
            if (图纸上传次数 == "")
            {
              
            }
            else{
                MessageBox.Show("此图纸不是最新图纸,如若查看最新图纸,请右击在查看-修改记录中查看图纸文件");
            }
            string sql = "select 附件名称 from tb_caigouliaodan  where id='" + id + "'";

            string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            if (jiance == "")
            {
                MessageBox.Show("无附件！");
                return;

            }
            string leixing = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件类型").ToString();
            string mingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件名称").ToString();

            string sql1 = "Select 附件 From tb_caigouliaodan  Where id='" + id + "'";



            byte[] mypdffile = SQLhelp.duqu(sql1, CommandType.Text);




            string aaaa = System.Environment.CurrentDirectory;
            lujing = aaaa + "\\" + mingcheng + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();

            System.Diagnostics.Process.Start(lujing);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            edittaizhang edittaizhang = new edittaizhang(id);
            edittaizhang.yonghu = yonghu;
            edittaizhang.ShowDialog();
            if (edittaizhang.DialogResult == DialogResult.OK)
            {
                reload3();
            }
        }

        private void 合同ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string tuzhimingcheng="";
            string tuzhileixing="";
            string fileName = "";
            long fileSize = 0;//文件大小
            byte[] tuzhifiles=null;//文件
            BinaryReader read = null;//二进制读取
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tuzhimingcheng = dialog.FileName;
                    FileInfo info = new FileInfo(dialog.FileName);
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
                    FileStream file = new FileStream(tuzhimingcheng, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(tuzhifiles, 0, Convert.ToInt32(fileSize));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }

            string sql2 = "update tb_caigouliaodan  set 合同=@pic,合同名称='" + tuzhimingcheng + "',合同类型='" + tuzhileixing + "' where id='" + id + "'";
            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, tuzhifiles);
            MessageBox.Show("修改成功！");
           
        

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            修改图纸 修改图纸 = new 修改图纸(id);
            修改图纸.yonghu = yonghu;
            修改图纸.ShowDialog();
           

            //string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();

            //string tuzhimingcheng = "";
            //string tuzhileixing = "";
            //string fileName = "";
            //long fileSize = 0;//文件大小
            //byte[] tuzhifiles = null;//文件
            //BinaryReader read = null;//二进制读取
            //try
            //{
            //    //打开对话框
            //    OpenFileDialog dialog = new OpenFileDialog();
            //    if (dialog.ShowDialog() == DialogResult.OK)
            //    {
            //        tuzhimingcheng = dialog.FileName;
            //        FileInfo info = new FileInfo(@tuzhimingcheng);
            //        //获得文件大小
            //        fileSize = info.Length;
            //        //提取文件名,三步走
            //        int index = info.FullName.LastIndexOf(".");
            //        //fileName = info.FullName.Remove(index);
            //        //fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
            //        //tuzhimingcheng = fileName;
            //        //获得文件扩展名
            //        fileName = info.FullName.Remove(index);
            //        fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
            //        tuzhimingcheng = fileName;

            //        tuzhileixing = info.Extension.Replace(".", "");
            //        //把文件转换成二进制流
            //        tuzhifiles = new byte[Convert.ToInt32(fileSize)];
            //        FileStream file = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
            //        read = new BinaryReader(file);
            //        read.Read(tuzhifiles, 0, Convert.ToInt32(fileSize));

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            //}

            //string sql2 = "update tb_caigouliaodan  set 附件=@pictuzhi,附件名称='" + tuzhimingcheng + "',附件类型='" + tuzhileixing + "' where id='" + id + "'";
            //SQLhelp.ExecuteNonquerytuzhi(sql2, CommandType.Text, tuzhifiles);
            //MessageBox.Show("修改成功！");

            //reload3();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            reload();
           
            reload3();
        }

      

        private void 导出到excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }
        
        private void 审批记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            shengpijilu shengpijilu = new shengpijilu(id);
            shengpijilu.ShowDialog();
        }

        private void 制造类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            zhizaoleixing zhizaoleixing = new zhizaoleixing(id);
            zhizaoleixing.yonghu = yonghu;
            zhizaoleixing.ShowDialog();
            if (zhizaoleixing.DialogResult == DialogResult.OK)
            {
                reload3();
            }
        }
        
        private void 导出到excelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gridControl2.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            shaixuan shaixuan = new shaixuan();
            shaixuan.ShowDialog();
            if (shaixuan.DialogResult == DialogResult.OK)
            {
                gonglinghao = shaixuan.gonglinghao;
                reload3();
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {

            gonglinghao = null;
            gonglinghaotiaojian = null;
            reload3();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Frxinzengtaizhang Addtaizhang = new Frxinzengtaizhang();
            Addtaizhang.yonghu = yonghu;
            Addtaizhang.ShowDialog();
            if (Addtaizhang.DialogResult == DialogResult.OK)
            {
                reload3();
            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            //gridView1.Columns.ColumnByName("id1").Visible = true;
            //gridView1.Columns.ColumnByName("id1").VisibleIndex = 0;
            //gridView1.Columns.ColumnByName("模具部状态").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            //gridView1.Columns.ColumnByName("工作令号").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            //SaveFileDialog fileDialog = new SaveFileDialog();
            //fileDialog.Title = "导出Excel";
            //fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            //DialogResult dialogResult = fileDialog.ShowDialog(this);
            //if (dialogResult == DialogResult.OK)
            //{
            //    DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
            //    gridControl1.ExportToXls(fileDialog.FileName);
            //    DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            //gridView1.Columns.ColumnByName("id1").Visible = false;
            //gridView1.Columns.ColumnByName("id1").VisibleIndex = -1;



            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "EXCEL文件|*.xls;*,xlsx;";
            if (op.ShowDialog() == DialogResult.OK)//显示保存文件对话框
            {



                lujing = op.FileName;
                string savePath = lujing;

                Workbook book = new Workbook();
                Worksheet sheet = book.Worksheets[0];
                Cells cells = sheet.Cells;


                int Colnum = gridView1.Columns.Count;//表格列数   
                int Rownum = gridView1.RowCount;//表格行数   



                //生成行 列名行   
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    cells[0, i].PutValue(gridView1.Columns[i].Caption);
                }


                //生成数据行   
                for (int i = 0; i < Rownum; i++)
                {
                    for (int k = 0; k < Colnum; k++)
                    {

                        cells[1 + i, k].PutValue(gridView1.GetRowCellValue(i, gridView1.Columns[k]).ToString());
                    }

                }

                book.Save(savePath);


                FileInfo fileInf = new FileInfo(savePath);

                MessageBox.Show("导出成功！");

            }
            else
            {

            }

           




        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            if (yonghu == "陈健鑫")
            {
                Addcaigou Addcaigou = new Addcaigou();
                Addcaigou.yonghu = yonghu;
                Addcaigou.ShowDialog();


                if (Addcaigou.DialogResult == DialogResult.OK)
                {
                    reload();
                }
            }else
            {
                MessageBox.Show("无权限");
            }
           
        }

    
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
            string 当前状态 = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "statename"));
            if(当前状态== "待主管审批"|| 当前状态 == "主管已同意")
            {
                Frxiugaicaigou form1 = new Frxiugaicaigou();
                form1.yonghu = yonghu;
                form1.id = id;
                form1.ShowDialog();
                if (form1.DialogResult == DialogResult.OK)
                {
                    reload();
                }
            }
            else
            {
                MessageBox.Show("不能修改");
            }

         
        }
        
        private void buttonItem7_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            gridView2.Columns.ColumnByName("id").Visible = true;
            gridView2.Columns.ColumnByName("id").VisibleIndex = 0;
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gridControl2.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            gridView2.Columns.ColumnByName("id").Visible = false;
            gridView2.Columns.ColumnByName("id").VisibleIndex = -1;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void 确认修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确实要修改吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
                string 供方名称 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "供方名称").ToString();
                string 模具部订单号申请号 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "模具部订单号申请号").ToString();
                //string 成本单价 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "成本单价").ToString();
                //string 成本总价 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "成本总价").ToString();
                //string 供应商开票日期 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "供应商开票日期").ToString();
                string 模具部销售合同号= this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "模具部销售合同号").ToString();
                string 发货数量 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "模具部发货数量").ToString();
                //string 供应商开票金额 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "供应商开票金额").ToString();
              string 模具部实际交货日期 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "模具部实际交货日期").ToString(); 
                //string 供应商开票金额 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "供应商开票金额").ToString();
                string 模具部销售开票日期 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "模具部销售开票日期").ToString();
                string 模具部销售开票金额 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "模具部销售开票金额").ToString();

                //String sql = "update tb_caigouliaodan set 供方名称='" + 供方名称 + "',供应商开票日期='" + 供应商开票日期+ "',供应商开票金额='" + 供应商开票金额 + "',模具部发货数量='"+ 发货数量+ "',模具部订单号申请号='" + 模具部订单号申请号 + "',模具部销售合同号='" + 模具部销售合同号 + "',模具部销售开票日期='" + 模具部销售开票日期 + "' where id='" +id+"'";


                String sql = "update tb_caigouliaodan set 模具部发货数量='" + 发货数量 + "',模具部订单号申请号='" + 模具部订单号申请号 + "',模具部销售合同号='" + 模具部销售合同号 + "',模具部销售开票日期='" + 模具部销售开票日期 + "',模具部销售开票金额='" + 模具部销售开票金额 + "' where id='" + id + "'";

                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                update日期();
                //reload3();
            }
        }
        public void update日期()
        {
            string sql1 = "update tb_caigouliaodan set 供应商开票日期=null where 供应商开票日期='1900-01-01 00:00:00.000' and 料单类型='模具部'";
            SQLhelp.ExecuteScalar(sql1, CommandType.Text);
            string sql2 = "update tb_caigouliaodan set 模具部销售开票日期=null where 模具部销售开票日期='1900-01-01 00:00:00.000' and 料单类型='模具部'";
            SQLhelp.ExecuteScalar(sql2, CommandType.Text);
         
            string sql11 = "update tb_caigouliaodan set 供应商开票日期=null where 供应商开票日期='1900-01-01 00:00:00.000' and 料单类型='模具部原材料'";
            SQLhelp.ExecuteScalar(sql11, CommandType.Text);
            string sql22 = "update tb_caigouliaodan set 模具部销售开票日期=null where 模具部销售开票日期='1900-01-01 00:00:00.000' and 料单类型='模具部原材料'";
            SQLhelp.ExecuteScalar(sql22, CommandType.Text);
            string sql33 = "update tb_caigouliaodan set 模具部实际交货日期=null where 模具部实际交货日期='1900-01-01 00:00:00.000' and 料单类型='模具部原材料'";
            SQLhelp.ExecuteScalar(sql33, CommandType.Text); 
            string sql44 = "update tb_caigouliaodan set 实际到货日期=null where 实际到货日期='1900-01-01 00:00:00.000' and 料单类型='模具部原材料'";
            SQLhelp.ExecuteScalar(sql44, CommandType.Text);
            string sql55 = "update tb_caigouliaodan set 模具部交货日期=null where 模具部交货日期='1900-01-01 00:00:00.000' and 料单类型='模具部'";
            SQLhelp.ExecuteScalar(sql55, CommandType.Text);
        }
        private void 发货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            fahuoForm fahuoForm = new fahuoForm(id);
            if (fahuoForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                reload3();
            }
               
        }

        private void 发货记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            fahuojilu fahuojilu = new fahuojilu(id);
            fahuojilu.ShowDialog();
        }

        private void buttonItem3_Click_1(object sender, EventArgs e)
        {
            if (yonghu == "邹春光")
            {
                业务台账导出();
            }
            else
            {
                MessageBox.Show("无权限操作");
            }
           
        }
        public void 成本分摊导入()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                Workbook book = new Workbook(file);
                Worksheet sheet = book.Worksheets["Sheet"];
                Cells cells = sheet.Cells;
                int 行数 = cells.MaxDataRow;
                int 列数 = cells.MaxDataColumn;
                DataTable DT = sheet.Cells.ExportDataTableAsString(0, 0, 行数 + 1, 列数);
               
                int 模具部成本分摊 = -1;
                int 工作令号 = -1;
                //int 订单号申请号 = -1;

                for (int i = 0; i < 列数; i++)
                {
                  
                    if (DT.Rows[0][i].ToString() == "成本分摊")
                    {
                        模具部成本分摊 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "工令号")
                    {
                        工作令号 = i;
                    }
                }

                for (int i = 1; i <= 行数; i++)
                {
                    //if (i == 行数-1)
                    //{
                    //    MessageBox.Show(DT.Rows[i][id].ToString());
                    //}
                    //if (i== 行数)
                    //{
                    //    MessageBox.Show(DT.Rows[i][id].ToString());
                    //}
                  
                    string 模具部成本分摊1 = DT.Rows[i][模具部成本分摊].ToString();
                    string 工作令号1 = DT.Rows[i][工作令号].ToString();
                   
                    string sql = "update tb_caigouliaodan set 模具部成本分摊='" + 模具部成本分摊1 + "' where 料单类型='模具部' and 工作令号 ='" + 工作令号1 + "'";

                    SQLhelp.ExecuteScalar(sql, CommandType.Text);

                }
                update日期();
                MessageBox.Show("导入已完成");
            }
        }

        public void 业务台账导出()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                Workbook book = new Workbook(file);
                Worksheet sheet = book.Worksheets["Sheet1"];
                Cells cells = sheet.Cells;
                int 行数 = cells.MaxDataRow;
                int 列数 = cells.MaxDataColumn;
                DataTable DT = sheet.Cells.ExportDataTableAsString(0, 0, 行数 + 1, 列数);
                int id = -1;
                int 订单号申请号 = -1;
                int 合同号 = -1;
                int 产品名称 = -1;
                int 规格 = -1;
                int 单位 = -1;
                int 数量 = -1;
                int 销售单价 = -1;
                int 开票日期 = -1;
                int 开票金额 = -1;
                int 实际交货日期 = -1;
                int 供应商开票日期 = -1;
                int 供应商开票金额 = -1;
                int 成本单价 = -1;
                int 成本总价 = -1;
                int 供方名称 = -1;
                //int 订单号申请号 = -1;

                for (int i = 0; i < 列数; i++)
                {
                    if (DT.Rows[0][i].ToString() == "id1")
                    {
                        id = i;
                    }
                    if (DT.Rows[0][i].ToString() == "订单号申请号")
                    {
                        订单号申请号 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "合同号")
                    {
                        合同号 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "产品名称")
                    {
                        产品名称 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "规格")
                    {
                        规格 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "单位")
                    {
                        单位 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "数量")
                    {
                        数量 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "销售单价")
                    {
                        销售单价 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "开票日期")
                    {
                        开票日期 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "开票金额")
                    {
                        开票金额 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "实际交期")
                    {
                        实际交货日期 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "供应商开票日期")
                    {
                        供应商开票日期 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "供应商开票金额")
                    {
                        供应商开票金额 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "成本单价")
                    {
                        成本单价 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "成本总价")
                    {
                        成本总价 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "供方名称")
                    {
                        供方名称 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "供方名称")
                    {
                        供方名称 = i;
                    }
                }

                for (int i = 1; i <= 行数; i++)
                {
                    //if (i == 行数-1)
                    //{
                    //    MessageBox.Show(DT.Rows[i][id].ToString());
                    //}
                    //if (i== 行数)
                    //{
                    //    MessageBox.Show(DT.Rows[i][id].ToString());
                    //}

                    string id1 = DT.Rows[i][id].ToString();
                    string 订单号申请号1 = DT.Rows[i][订单号申请号].ToString();
                    string 合同号1 = DT.Rows[i][合同号].ToString();
                    string 产品名称1 = DT.Rows[i][产品名称].ToString();
                    string 规格1 = DT.Rows[i][规格].ToString();
                    string 单位1 = DT.Rows[i][单位].ToString();
                    string 数量1 = DT.Rows[i][数量].ToString();
                    string 销售单价1 = DT.Rows[i][销售单价].ToString();
                    string 开票日期1 = DT.Rows[i][开票日期].ToString();
                    string 开票金额1 = DT.Rows[i][开票金额].ToString();
                    string 供方名称1 = DT.Rows[i][供方名称].ToString();
                    string 实际交货日期1 = DT.Rows[i][实际交货日期].ToString();
                    string 供应商开票日期1 = DT.Rows[i][供应商开票日期].ToString();
                    string 供应商开票金额1 = DT.Rows[i][供应商开票金额].ToString();
                    string 成本单价1 = DT.Rows[i][成本单价].ToString();
                    string 成本总价1 = DT.Rows[i][成本总价].ToString();
                    string sql = "update tb_caigouliaodan set 模具部订单号申请号='" + 订单号申请号1 + "',模具部销售合同号='" + 合同号1 + "',单位='" + 单位1 + "',项目名称='" + 产品名称1 + "',型号='" + 规格1 + "',实际采购数量='" + 数量1 + "',模具部销售单价='" + 销售单价1 + "',模具部销售开票日期='" + 开票日期1 + "',模具部销售开票金额='" + 开票金额1 + "',模具部实际交货日期='" + 实际交货日期1 + "',供方名称='" + 供方名称1 + "',供应商开票日期='" + 供应商开票日期1 + "',供应商开票金额='" + 供应商开票金额1 + "',采购单价='" + 成本单价1
                        + "',总价='" + 成本总价1 + "' where id ='" + id1 + "'";

                    //MessageBox.Show(sql);
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);

                }
                update日期();
                MessageBox.Show("导入已完成");
            }
        }
        private void buttonItem7_Click_1(object sender, EventArgs e)
        {
            Frpiliangxinzeng Addcaigou = new Frpiliangxinzeng();
            Addcaigou.yonghu = yonghu;
            Addcaigou.ShowDialog();
        
            if (Addcaigou.DialogResult == DialogResult.OK)
            {
                reload();
            }
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                Workbook book = new Workbook(file);
                Worksheet sheet = book.Worksheets["Sheet1"];
                Cells cells = sheet.Cells;
                int 行数 = cells.MaxDataRow;
                int 列数 = cells.MaxDataColumn;
                DataTable DT = sheet.Cells.ExportDataTableAsString(0, 0, 行数 + 1, 列数+1);
                int id = -1;
                int 项目名称 = -1;
                int 名称 = -1;
                int 规格 = -1;
                int 单位 = -1;
                int 数量 = -1;
                int 成本总价 = -1;
                int 成本单价 = -1;
                int 供应商 = -1;
                int 供应商开票日期 = -1;
                int 供应商开票金额 = -1;
                int 税点 = -1;
                int 实际到货日期 = -1;
               

                for (int i = 0; i <=列数; i++)
                {
                    if (DT.Rows[0][i].ToString() == "id")
                    {
                        id = i;
                    }
                    if (DT.Rows[0][i].ToString() == "项目名称")
                    {
                        项目名称 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "名称")
                    {
                        名称 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "规格")
                    {
                        规格 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "单位")
                    {
                        单位 = i;
                    }
                   
                    if (DT.Rows[0][i].ToString() == "数量")
                    {
                        数量 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "成本总价")
                    {
                        成本总价 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "成本单价")
                    {
                        成本单价 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "供应商")
                    {
                        供应商 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "供应商开票日期")
                    {
                        供应商开票日期 = i;
                    }
                  
                    if (DT.Rows[0][i].ToString() == "供应商开票金额")
                    {
                        供应商开票金额 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "税点")
                    {
                        税点 = i;
                    }
                    if (DT.Rows[0][i].ToString() == "实际到货日期")
                    {
                        实际到货日期 = i;
                    }
                 
                }

                for (int i = 1; i <= 行数; i++)
                {

                    string id1 = DT.Rows[i][id].ToString();
                    string 项目名称1 = DT.Rows[i][项目名称].ToString();
                    string 供应商1 = DT.Rows[i][供应商].ToString();
                    string 名称1 = DT.Rows[i][名称].ToString();
                    string 规格1 = DT.Rows[i][规格].ToString();
                    string 单位1 = DT.Rows[i][单位].ToString();
                    string 数量1 = DT.Rows[i][数量].ToString();
                    string 税点1 = DT.Rows[i][税点].ToString();
                    //string 实际到货日期1 = DT.Rows[i][实际到货日期].ToString();
                    string 供应商开票日期1 = DT.Rows[i][供应商开票日期].ToString();
                    string 供应商开票金额1 = DT.Rows[i][供应商开票金额].ToString();
                    string 成本单价1 = DT.Rows[i][成本单价].ToString();
                    string 成本总价1 = DT.Rows[i][成本总价].ToString();
                    //string sql = "update tb_caigouliaodan set 项目名称='" + 项目名称1   + "',名称='" + 名称1 + "',型号='" + 规格1 + "',实际采购数量='" + 数量1 + "',单位='" + 单位1 + "',税率='" + 税点1 + "',实际到货日期='" + 实际到货日期1 + "',供应商开票日期='" + 供应商开票日期1 + "',供方名称='" + 供应商1 + "',供应商开票金额='" + 供应商开票金额1 + "',采购单价='" + 成本单价1
                    //    + "',模具部成本总价='" + 成本总价1 + "' where id ='" + id1 + "'";

                    string sql = "update tb_caigouliaodan set 项目名称='" + 项目名称1 + "',名称='" + 名称1 + "',型号='" + 规格1 + "',实际采购数量='" + 数量1 + "',单位='" + 单位1 + "',税率='" + 税点1 + "',供应商开票日期='" + 供应商开票日期1 + "',供方名称='" + 供应商1 + "',供应商开票金额='" + 供应商开票金额1 + "',采购单价='" + 成本单价1
                      + "',模具部成本总价='" + 成本总价1 + "' where id ='" + id1 + "'";
                    //MessageBox.Show(sql);
                    //if (id1 == "117946")
                    //{
                    //    MessageBox.Show(sql);
                    //}

                    SQLhelp.ExecuteScalar(sql, CommandType.Text);

                }
                update日期();
                MessageBox.Show("导入已完成");
            }
        }
        private void 查看工艺ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            Formlingjian Formlingjian = new Formlingjian(id);
            Formlingjian.yonghu = yonghu;
            Formlingjian.ShowDialog();

            
        }

        private void 修改记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            xiugaijilu xiugaijilu = new xiugaijilu(id);
            xiugaijilu.ShowDialog();
        }
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            
        }

        private void gridView1_CustomDrawCell_1(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "statename")
            {
                GridCellInfo GridCellInfo = e.Cell as GridCellInfo;
                if (GridCellInfo.CellValue.ToString() == "已安排生产")
                {
                    e.Appearance.BackColor = Color.LimeGreen;
                }
                if (GridCellInfo.CellValue.ToString() == "待主管审批")
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                if (GridCellInfo.CellValue.ToString() == "无图纸/图纸不符\r\n")
                {
                    e.Appearance.BackColor = Color.Red;
                }
                if (GridCellInfo.CellValue.ToString() == "驳回未处理")
                {
                    e.Appearance.BackColor = Color.Red;
                }
                if (GridCellInfo.CellValue.ToString() == "取消订单")
                {
                    e.Appearance.BackColor = Color.Gray;
                }
                //    e.Appearance.BackColor = Color.Yellow;
                //else if (GridCellInfo.IsDataCell && double.Parse(GridCellInfo.CellValue.ToString()) > -30
                //&& double.Parse(GridCellInfo.CellValue.ToString()) <= -50)
                //    e.Appearance.BackColor = Color.Green;
                //else if (GridCellInfo.IsDataCell && double.Parse(GridCellInfo.CellValue.ToString()) > -50)
                //    e.Appearance.BackColor = Color.Red;
            }
            if (e.Column.FieldName == "模具部自制外协修改")
            {
                GridCellInfo GridCellInfo = e.Cell as GridCellInfo;
                if (GridCellInfo.CellValue.ToString() == "外协改自制")
                {
                    e.Appearance.BackColor = Color.Orange;
                }
                if (GridCellInfo.CellValue.ToString() == "自制改外协")
                {
                    e.Appearance.BackColor = Color.Pink;
                }
             
                //    e.Appearance.BackColor = Color.Yellow;
                //else if (GridCellInfo.IsDataCell && double.Parse(GridCellInfo.CellValue.ToString()) > -30
                //&& double.Parse(GridCellInfo.CellValue.ToString()) <= -50)
                //    e.Appearance.BackColor = Color.Green;
                //else if (GridCellInfo.IsDataCell && double.Parse(GridCellInfo.CellValue.ToString()) > -50)
                //    e.Appearance.BackColor = Color.Red;
            }
        }

        private void 修改前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            成本分摊导入();
        }

        private void 审批记录ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
            shengpijilu shengpijilu = new shengpijilu(id);
            shengpijilu.ShowDialog();
        }

        private void 查看图纸ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
            string sql = "select 附件名称 from tb_caigouliaodan  where id='" + id + "'";

            string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            if (jiance == "")
            {
                MessageBox.Show("无附件！");
                return;

            }

            string leixing = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "附件类型").ToString();

            string mingcheng = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "附件名称").ToString();

            String sqljudgeem = "Select 附件类型,附件名称 From tb_caigouliaodan  Where id='" + id + "'";
            DataTable dt1 = SQLhelp.GetDataTable(sqljudgeem, CommandType.Text);
            if (dt1.Rows[0]["附件类型"].ToString() == "" && dt1.Rows[0]["附件名称"].ToString() == "")
            {
                MessageBox.Show("没有图纸");
            }
            else
            {
                string sql1 = "Select 附件 From tb_caigouliaodan  Where id='" + id + "'";
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

        private void 修改记录ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
            xiugaijilu xiugaijilu = new xiugaijilu(id);
            xiugaijilu.ShowDialog();
        }

        private void 无图纸退回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            无图纸退回 无图纸退回 = new 无图纸退回(id);
            无图纸退回.ShowDialog();

        }
        private void 生产车间ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            修改生产车间 修改生产车间 = new 修改生产车间(id);
            修改生产车间.yonghu = yonghu;
            修改生产车间.ShowDialog();
            if (修改生产车间.DialogResult == DialogResult.OK)
            {
                reload3();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void 客户取消订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要取消订单？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string sql = "update tb_caigouliaodan  set 当前状态='72' where id='" + id + "'";
                公共.添加审批记录(yonghu, "取消订单", id);
                SQLhelp.ExecuteNonquery2(sql, CommandType.Text);



                string sql5 = "select id,工作令号,项目名称,模具部订单号申请号,模具部销售合同号,编码,模具部申请人,模具部客户,模具部联系人,型号,单位,数量,合同类型,合同名称,模具部销售单价,模具部成本分摊,模具部交货日期,模具部销售开票日期,模具部实际交货日期,备注,模具部发货数量,模具部销售开票金额,名称,模具部成本分摊 from tb_caigouliaodan where 料单类型='模具部' and id='" + id + "'";
                DataTable dt1 = SQLhelp.GetDataTable(sql5, CommandType.Text);
                string 工作令号 = dt1.Rows[0]["工作令号"].ToString();
                DataTable 人员 = 公共.根据部门得到人员("模具事业部");
                string message = "工作令号" + 工作令号 + "客户取消了订单,请相关人员注意,请查看相应台账的修改记录";
                NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");

                for (int i = 0; i < 人员.Rows.Count; i++)
                {
                    string 发送人员 = 人员.Rows[i]["用户名"].ToString();
                    NetWork3J.sendmessageById(发送人员, message);
                }


                reload3();
            }
        }

        private void gridView1_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        private void gridView2_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        private void 上传bom清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            上传bom清单 上传bom清单 = new 上传bom清单(id);
            上传bom清单.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
          

            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            string sql3 = "Select bom清单 From tb_caigouliaodan  Where id='" + id + "'";
            DataTable dt2 = SQLhelp.GetDataTable(sql3, CommandType.Text);
            string bom清单= dt2.Rows[0]["bom清单"].ToString();
            if (bom清单 == "")
            {
                MessageBox.Show("没有bom清单");
            }else
            {
                string sql1 = "select * from tb_caigouliaodan where id='" + id + "'";
                DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
                string 模具部bom清单名称 = dt1.Rows[0]["模具部bom清单名称"].ToString();
                string 模具部bom清单类型 = dt1.Rows[0]["模具部bom清单类型"].ToString();
                string sql = "Select bom清单 From tb_caigouliaodan  Where id='" + id + "'";
                byte[] mypdffile = null;
                mypdffile = SQLhelp.duqu(sql, CommandType.Text);


                string aaaa = System.Environment.CurrentDirectory;
                lujing = aaaa + "\\" + 模具部bom清单名称 + "." + 模具部bom清单类型;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();

                System.Diagnostics.Process.Start(lujing);
            }

           
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        private void 上传bom清单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
            string shuliang= Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "数量"));
            string xiangmumingcheng= Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "项目名称"));
            上传bom清单1 上传bom清单1 = new 上传bom清单1(id,shuliang,xiangmumingcheng);
            上传bom清单1.ShowDialog();
        }

        private void 图纸文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
            string 图纸上传次数 = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "图纸上传次数").ToString();
            if (图纸上传次数 == "")
            {

            }
            else
            {
                MessageBox.Show("此图纸不是最新图纸,如若查看最新图纸,请右击在查看-修改记录中查看图纸文件");
            }
            string sql = "select 附件名称 from tb_caigouliaodan  where id='" + id + "'";

            string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            if (jiance == "")
            {
                MessageBox.Show("无附件！");
                return;

            }
            string leixing = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "附件类型").ToString();
            string mingcheng = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "附件名称").ToString();

            string sql1 = "Select 附件 From tb_caigouliaodan  Where id='" + id + "'";



            byte[] mypdffile = SQLhelp.duqu(sql1, CommandType.Text);




            string aaaa = System.Environment.CurrentDirectory;
            lujing = aaaa + "\\" + mingcheng + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();

            System.Diagnostics.Process.Start(lujing);
        }

        private void 审批记录ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string id = this.gridView4.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            shengpijilu shengpijilu = new shengpijilu(id);
            shengpijilu.ShowDialog();
        }

        private void 发货记录ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
            fahuojilu fahuojilu = new fahuojilu(id);
            fahuojilu.ShowDialog();
        }

        private void 修改记录ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
            xiugaijilu xiugaijilu = new xiugaijilu(id);
            xiugaijilu.ShowDialog();
        }

        private void bom清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
            chakanbom1 chakanbom1 = new chakanbom1(id);
            chakanbom1.ShowDialog();
        }

        private void 明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
            edittaizhang1 edittaizhang1 = new edittaizhang1(id);
            edittaizhang1.ShowDialog();
        }

        private void 合同ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
            edithetong edithetong = new edithetong(id);
            edithetong.ShowDialog();
        }

        private void 图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
            edittuzhi edittuzhi = new edittuzhi(id);
            edittuzhi.ShowDialog();
        }

        private void 制造类型ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
            zhizaoleixing1  zhizaoleixing1 = new zhizaoleixing1(id);
            zhizaoleixing1.ShowDialog();
        }

        private void 生产车间ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
            修改生产车间 修改生产车间 = new 修改生产车间(id);
            修改生产车间.ShowDialog();
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("确实要删除吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string 当前状态 = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "statename").ToString();
                if (当前状态 == "待主管审批")
                {
                    string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
                    String sql = "delete from tb_caigouliaodan where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    reload4();
                }
                else
                {
                    MessageBox.Show("主管已经通过,无法删除");
                }
            }
        }
    }
}
