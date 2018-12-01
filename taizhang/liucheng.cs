﻿//using mujubu.工艺;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mujubu.公共类;
using mujubu.工艺;
using NetWorkLib.erp号;

namespace mujubu.taizhang
{
    public partial class liucheng : DevExpress.XtraEditors.XtraForm
    {
        public liucheng()
        {
            InitializeComponent();
        }
        public String yonghu;
        public string lujing;
        public string 经理;
        private ComboBox cmb_Temp = new ComboBox();
        公共 公共 = new 公共();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void BindSex()
        {
            DataTable dtSex = new DataTable();
            dtSex.Columns.Add("Value");
            dtSex.Columns.Add("Name");
            DataRow drSex;
            drSex = dtSex.NewRow();
            drSex[0] = "1";
            drSex[1] = "男";
            dtSex.Rows.Add(drSex);
            drSex = dtSex.NewRow();
            drSex[0] = "0";
            drSex[1] = "女";
            dtSex.Rows.Add(drSex);
            cmb_Temp.ValueMember = "Value";
            cmb_Temp.DisplayMember = "Name";
            cmb_Temp.DataSource = dtSex;
            cmb_Temp.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void liucheng_Load(object sender, EventArgs e)
        {
            //this.timer1.Start();
            经理= 公共.得到人员("经理", "模具事业部");
            if (yonghu == "陈健鑫"|| yonghu == "顾英杰")
            {
                工艺已编写完ToolStripMenuItem.Visible = true;
                已完成生产ToolStripMenuItem.Visible = true;
                安排生产ToolStripMenuItem.Visible = true;
                审批ToolStripMenuItem.Visible = true;
                无法编erp驳回已处理ToolStripMenuItem.Visible = true;
                审批ToolStripMenuItem1.Visible = false;
                驳回ToolStripMenuItem1.Visible = false;
                查看ToolStripMenuItem1.Visible = false;
                自动生成erp号ToolStripMenuItem.Visible = false;
            }

            if (yonghu == "施琴")
            {
                审批ToolStripMenuItem.Visible = false;
                工艺已查看图纸ToolStripMenuItem.Visible = true;
                工价编写完ToolStripMenuItem.Visible = true;
                工艺不合格退回工艺ToolStripMenuItem.Visible = true;
            }
            if (yonghu == 经理)
            {
                驳回ToolStripMenuItem.Visible = true;
              
            }
            if (yonghu == 经理)
            {
                驳回ToolStripMenuItem.Visible = true;

            }
            if (yonghu == "缪继鹏"||yonghu=="徐海燕")
            {
                查看工艺ToolStripMenuItem.Visible = false;
                审批ToolStripMenuItem.Visible = false;

            }
            if (yonghu == "邹春光")
            {
                驳回ToolStripMenuItem2.Visible = true;

            }
            
            show业务台账();
            show采购台账();
            BindSex();
            popout();

        }

        public void popout()
        {
            if (yonghu == "陈健鑫"|| yonghu == "施琴"|| yonghu == 经理 || yonghu == "邹春光")
            {
                timer1.Start();
            }
          
        }
        public DataTable reload()
        {
            String sqlselct = "select * from tb_state where name like '%" + yonghu + "%' and cato='模具部'";
            DataTable dt1 = SQLhelp.GetDataTable(sqlselct, CommandType.Text);
            String state="''";
            DataTable dt2 = new DataTable();
            if (dt1.Rows.Count != 0)
            {
                state = "'"+dt1.Rows[0]["state"].ToString()+"'";
                if (dt1.Rows.Count == 1)
                {
                    state = "'" + dt1.Rows[0]["state"].ToString()+ "'";
                }
                else
                {
                    for (int i = 1; i < dt1.Rows.Count; i++)
                    {
                        state = state + ",'" + dt1.Rows[i]["state"].ToString() + "'";
                    }
                }
                if (yonghu == "陈健鑫")
                {
                    string sql = "select  distinct a.id,a.工作令号,b.statename,a.项目名称,a.模具部产品类型,a.名称,a.模具部接单日期,a.图纸上传次数,a.模具部订单号申请号,a.模具部销售合同号,a.模具部申请人,a.模具部客户,a.模具部联系人,a.型号,a.单位,a.实际采购数量,a.图纸上传次数,a.模具部交货日期,a.制造类型,a.模具部生产车间,a.合同类型,a.合同名称," +
"a.附件名称,a.附件类型,a.备注," +
"(CASE  WHEN a.合同类型 is null THEN '无合同' WHEN a.合同类型 = '' THEN '无合同' else '有合同'  END) as '是否有合同'," + "(CASE  WHEN a.附件类型 is null THEN  '无附件'  WHEN 附件类型 = '' THEN '无合同' else '有附件'  END) as '是否有图纸'" +
" from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state and b.cato='模具部' where a.料单类型 = '模具部' and a.当前状态 in (" + state + ") and 模具部生产车间='南通车间'";
                    dt2 = SQLhelp.GetDataTable(sql, CommandType.Text);
                }else if (yonghu == "顾英杰")
                {
                    string sql = "select  distinct a.id,a.工作令号,b.statename,a.项目名称,a.模具部产品类型,a.名称,a.模具部接单日期,a.图纸上传次数,a.模具部订单号申请号,a.模具部销售合同号,a.模具部申请人,a.模具部客户,a.模具部联系人,a.型号,a.单位,a.实际采购数量,a.制造类型,a.图纸上传次数,a.模具部交货日期,a.模具部生产车间,a.合同类型,a.合同名称," +
"a.附件名称,a.附件类型,a.备注," +
"(CASE  WHEN a.合同类型 is null THEN '无合同' WHEN a.合同类型 = '' THEN '无合同' else '有合同'  END) as '是否有合同'," + "(CASE  WHEN a.附件类型 is null THEN  '无附件'  WHEN 附件类型 = '' THEN '无合同' else '有附件'  END) as '是否有图纸'" +
" from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state and b.cato='模具部' where a.料单类型 = '模具部' and a.当前状态 in (" + state + ") and 模具部生产车间='河口车间'";
                    dt2 = SQLhelp.GetDataTable(sql, CommandType.Text);
                }
                else
                {
                    string sql = "select  distinct a.id,a.工作令号,b.statename,a.项目名称,a.模具部产品类型,a.名称,a.模具部接单日期,a.备注,a.图纸上传次数,a.模具部订单号申请号,a.模具部销售合同号,a.模具部申请人,a.模具部客户,a.模具部联系人,a.型号,a.单位,a.实际采购数量,a.制造类型,a.图纸上传次数,a.模具部交货日期,a.模具部生产车间,a.合同类型,a.合同名称," +
"a.附件名称,a.附件类型," +
"(CASE  WHEN a.合同类型 is null THEN '无合同' WHEN a.合同类型 = '' THEN '无合同' else '有合同'  END) as '是否有合同'," + "(CASE  WHEN a.附件类型 is null THEN  '无附件'  WHEN 附件类型 = '' THEN '无合同' else '有附件'  END) as '是否有图纸'" +
" from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state and b.cato='模具部' where a.料单类型 = '模具部' and a.当前状态 in (" + state + ")";
                    dt2 = SQLhelp.GetDataTable(sql, CommandType.Text);
                }

                   
               
            }
            return dt2;
        }


        public DataTable reload1()
        {
            String sqlselct = "select * from tb_state where name like '%" + yonghu + "%' and cato='模具部原材料'";
            DataTable dt1 = SQLhelp.GetDataTable(sqlselct, CommandType.Text);
            String state = "''"; ;
            DataTable dt2 = new DataTable();
            if (dt1.Rows.Count != 0)
            {
                state = "'" + dt1.Rows[0]["state"].ToString() + "'";
                if (dt1.Rows.Count == 1)
                {
                    state = "'" + dt1.Rows[0]["state"].ToString() + "'";
                }
                else
                {
                    for (int i = 1; i < dt1.Rows.Count; i++)
                    {
                        state = state + ",'" + dt1.Rows[i]["state"].ToString() + "'";
                    }
                }
              
                    string sql = "select  distinct a.id,a.工作令号,a.模具部接单日期,a.名称,b.statename,a.工作令号+'  '+名称+'  '+a.型号  as 合并,a.当前状态,项目名称,a.模具部申请人,a.备注,a.型号 as 模具部规格,a.模具部成本是否工序 as 是否工序,a.类型 as 材质,a.单位,a.实际采购数量,a.合同类型,a.合同名称,a.编码," +
"a.附件名称,a.附件类型,a.备注,a.模具部驳回原因," +
"(CASE  WHEN a.合同类型 is null THEN '无合同' WHEN a.合同类型 = '' THEN '无合同' else '有合同'  END) as '是否有合同'," + "(CASE  WHEN a.附件类型 is null THEN  '无附件'  WHEN 附件类型 = '' THEN '无合同' else '有附件'  END) as '是否有图纸'" +
" from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state and b.cato='模具部原材料' where a.料单类型 = '模具部原材料' and a.当前状态 in (" + state + ")";
                    dt2 = SQLhelp.GetDataTable(sql, CommandType.Text);


                  
               

            }
            return dt2;
        }

        public void show业务台账()
        {
            gridControl1.DataSource = reload();
        }
        public void show采购台账()
        {
            gridControl2.DataSource = reload1();
        }

        private static Alertbox Alertbox = new Alertbox();
        public void checkif代办()
        {

            DataTable dt1 = reload();
            DataTable dt2 = reload1();
            if (dt1.Rows.Count > 0|| dt2.Rows.Count > 0)
                {
                if((Application.OpenForms["Alertbox"] as Alertbox) == null){
                    Alertbox = new Alertbox();
                    Alertbox.Show();

                }


            }
               
        }
       
        
        private void 审批ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            if (yonghu.Equals("邹春光"))
            {
                erpwaixie erpwaixie = new erpwaixie(id);
                erpwaixie.yonghu= yonghu;
                erpwaixie.ShowDialog();
                if (erpwaixie.DialogResult == DialogResult.OK)
                {
                    gridControl1.DataSource = reload();
                }
            }




           



            //else if (yonghu.Equals("陈健鑫"))
            //{
            //    DialogResult result = DevExpress.XtraEditors.XtraMessageBox.Show("确定要安排生产", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (result == DialogResult.Yes)
            //    {
            //        string sqlfac = "update tb_caigouliaodan set 当前状态='7' where id='" + id + "'";
            //        SQLhelp.ExecuteNonquery2(sqlfac, CommandType.Text);
            //        gridControl1.DataSource = reload();
            //    }
            //    //string sqlfac = "update tb_caigouliaodan set 当前状态='7' where id='" + id + "'";
            //    //SQLhelp.ExecuteNonquery2(sqlfac, CommandType.Text);
            //    //reload();
            //}
            else if (yonghu.Equals(经理))
            {

                DialogResult result = MessageBox.Show("确实要审批吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string state="";
                    string leixing = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "制造类型"));
                    string shengchanchejian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "模具部生产车间"));
                    if (leixing=="")
                    {
                        MessageBox.Show("请输入类型");
                        return;
                    }
                   
                    else
                    {
                        
                        if (leixing == "自制")
                        {
                            if (shengchanchejian=="")
                            {
                                MessageBox.Show("请输入生产车间");
                                return;
                            }
                            else
                            {
                                state = "4";
                            }
                            公共.添加审批记录(yonghu, "待主管审批-自制", id);

                        }
                        else if (leixing == "外协")
                        {
                            state = "2";
                            公共.添加审批记录(yonghu, "待主管审批-外协", id);
                        }
                        else if (leixing == "仓库")
                        {
                            state = "76";
                            公共.添加审批记录(yonghu, "待主管审批-仓库", id);
                        }
                        else if (leixing == "生产部")
                        {
                            state = "77";
                            公共.添加审批记录(yonghu, "待主管审批-生产部", id);
                        }
                     
                        string sqlfac = "update tb_caigouliaodan set 模具部生产车间='" +shengchanchejian+ "',制造类型='" + leixing + "',当前状态='" + state + "' where id='" + id + "'";
                        SQLhelp.ExecuteNonquery2(sqlfac, CommandType.Text);

                        gridControl1.DataSource = reload();
                    }
                   
                }
            }
            
        }
        
        private void 审批ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (yonghu.Equals("邹春光"))
            {
                string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
                string erp = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "编码"));
                string 是否工序 = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "是否工序"));
               
                if (erp == "")
                {
                    MessageBox.Show("请输入erp号");
                    return;
                }
                //else
                //{
                //    string sql = "update tb_caigouliaodan  set 当前状态='4',编码='" + erp + "' where id='" + id + "'";

                //    SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
                //    reload1();
                //}

                if (公共.判断是否有重复erp(erp))
                {
                    if (是否工序.Equals("工序外协"))
                    {
                        string sql = "update tb_caigouliaodan  set 当前状态='4',物资分类='物资分类',编码='" + erp + "' where id='" + id + "'"; 

                        SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
                    }
                    else
                    {
                        string sql = "update tb_caigouliaodan  set 当前状态='4',编码='" + erp + "' where id='" + id + "'";

                        SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
                    }

                    gridControl2.DataSource = reload1();
                    公共.添加审批记录(yonghu, "数据分析师编erp", id);
                }
                else
                {
                    MessageBox.Show("erp重复");
                }
                
            }
            if (yonghu.Equals(经理))
            {
                string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
                string 是否工序 = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "是否工序"));
                string sql = "update tb_caigouliaodan  set 当前状态='3' where id='" + id + "'";

                SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
               

                gridControl2.DataSource = reload1();
                公共.添加审批记录(yonghu, "待主管审批", id);
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            checkif代办();
        }

        private void repositoryItemComboBox3_Click(object sender, EventArgs e)
        {
           
        }
        

        private void 查看ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
            string sql = "select 附件名称 from tb_caigouliaodan  where id='" + id + "'";
            string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            if (jiance == "")
            {
                MessageBox.Show("无附件！");
                return;

            }
            string leixing = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件类型").ToString();
            string mingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件名称").ToString();
            String sqljudgeem = "Select 附件类型,附件名称 From tb_caigouliaodan  Where id='" + id + "'";
            DataTable dt1 = SQLhelp.GetDataTable(sqljudgeem, CommandType.Text);
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

        private void 同意ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (yonghu.Equals("邹春光"))
            {
                string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
                string sql = "update tb_caigouliaodan  set 当前状态='3' where id='" + id + "'";

                SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
            }
            if (yonghu.Equals(经理))
            {
                string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
                string sql = "update tb_caigouliaodan  set 当前状态='3' where id='" + id + "'";

                SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
            }
            if (yonghu.Equals("施琴"))
            {
                string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
                string sql = "update tb_caigouliaodan  set 当前状态='3' where id='" + id + "'";

                SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
            }
        }
        
        private void 驳回ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            if (yonghu.Equals(经理))
            {
                string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
                string sql = "update tb_caigouliaodan  set 当前状态='10' where id='" + id + "'";
                公共.添加审批记录(yonghu, "驳回", id);
                SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
            }
            

        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void 查看图纸文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            //string sql = "select 附件名称 from tb_caigouliaodan  where id='" + id + "'";

            //string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            //string 图纸上传次数 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "图纸上传次数").ToString();
            //if (jiance == "")
            //{
            //    if (图纸上传次数 == "")
            //    {
            //        MessageBox.Show("无附件！");
            //        return;
            //    }
            //    else
            //    {
            //        MessageBox.Show("此图纸不是最新图纸,如若查看最新图纸,请到业务台账右击在查看-修改记录中查看图纸文件");
            //    }
            //}else
            //{

            //    string leixing = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件类型").ToString();
            //    string mingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件名称").ToString();
            //    if (mingcheng != "")
            //    {
            //        string sql1 = "Select 附件 From tb_caigouliaodan  Where id='" + id + "'";
            //        byte[] mypdffile = null;
            //        mypdffile = SQLhelp.duqu(sql1, CommandType.Text);
            //        string aaaa = System.Environment.CurrentDirectory;
            //        lujing = aaaa + "\\" + mingcheng + "." + leixing;
            //        FileStream fs = new FileStream(lujing, FileMode.Create);
            //        fs.Write(mypdffile, 0, mypdffile.Length);
            //        fs.Flush();
            //        fs.Close();

            //        System.Diagnostics.Process.Start(lujing);
            //    }
            //}






            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string 图纸上传次数 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "图纸上传次数").ToString();
            if (图纸上传次数 == "")
            {
                string leixing = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件类型").ToString();
                string mingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件名称").ToString();

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
            else
            {
                xiugaijilu xiugaijilu = new xiugaijilu(id);
                xiugaijilu.ShowDialog();
            }
            string sql = "select 附件名称 from tb_caigouliaodan  where id='" + id + "'";

            string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            if (jiance == "")
            {
                MessageBox.Show("无附件！");
                return;

            }
            





        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = reload();
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = reload1();
        }

        private void 设计工艺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //shejigongyi shejigongyi = new shejigongyi();
        }
        private void 查看工艺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            Formlingjian Formlingjian = new Formlingjian(id);
                Formlingjian.yonghu = yonghu;
            Formlingjian.ShowDialog();

           
        }
        private void 自动生成erp号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //erpauto erpauto = new erpauto();
            //erpauto.ShowDialog();
            string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
            string 工作令号1 = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));
            string 项目名称1 = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "项目名称"));
            Frerpcreat1 Frerpcreat = new Frerpcreat1(id, 工作令号1, 项目名称1, yonghu);
            Frerpcreat.ShowDialog();

            if (Frerpcreat.DialogResult == DialogResult.OK)
            {

                String erp = Frerpcreat.erpnumber;
                String 名称 = Frerpcreat.三级名称;
                String 型号 = Frerpcreat.型号;
                String 单位 = Frerpcreat.单位;



                gridControl2.DataSource = reload1();
                if (id == "")
                {
                    MessageBox.Show("请选择一项");

                    gridControl1.DataSource = reload();
                }
                else
                {
                    String sql = "update tb_caigouliaodan set 编码='" + erp + "',名称='" + 名称 + "',型号='" + 型号 + "',单位='" + 单位 + "',当前状态='4' where id='" + id + "'";
                    SQLhelp.ExecuteNonquery2(sql, CommandType.Text);

                    公共.添加审批记录(yonghu, "外协待数据分析师通过", id);

                    gridControl2.DataSource = reload1();
                }
            }
        }

        private void 已查看图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 工艺已查看图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (yonghu.Equals("施琴"))
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string statename = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "statename"));
                if(statename== "自制单,待技术审批")
                {
                    string sql = "update tb_caigouliaodan  set 当前状态='48' where id='" + id + "'";

                    SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
                    gridControl1.DataSource = reload();
                }else
                {
                    MessageBox.Show("无法操作");
                }
               
            }
        }

        private void 工艺已编写完ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            string sql = "update tb_caigouliaodan  set 当前状态='49' where id='" + id + "'";

            SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
            string sql1 = "update tb_mujubu_lingjian  set 时间='"+ DateTime.Now+"' where id='" + id + "'";

            SQLhelp.ExecuteNonquery2(sql1, CommandType.Text);
            gridControl1.DataSource = reload();
        }

        private void 已完成生产ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            string sql = "update tb_caigouliaodan  set 当前状态='6' where id='" + id + "'";

            SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
            gridControl1.DataSource = reload();
        }

        private void 工价编写完ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            string statename = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "statename"));
            if (statename == "待编写工价")
            {
                string sql = "update tb_caigouliaodan  set 当前状态='50' where id='" + id + "'";

                SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
                gridControl1.DataSource = reload();
            }
            else
            {
                MessageBox.Show("无法操作");
            }
         
        }

        private void 安排生产ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            string sql = "update tb_caigouliaodan  set 当前状态='51' where id='" + id + "'";

            SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
            gridControl1.DataSource = reload();
        }
        private void 自动生成erp号ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //erpauto erpauto = new erpauto();
            //erpauto.ShowDialog();
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            string 工作令号 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            string 项目名称= Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "名称"));
            Frerpcreat1 Frerpcreat = new Frerpcreat1(id, 工作令号, 项目名称,yonghu);
            Frerpcreat.ShowDialog();


           


            if (Frerpcreat.DialogResult == DialogResult.OK)
            {
                String erp = Frerpcreat.erpnumber;
                String 名称 = Frerpcreat.三级名称;
                String 型号 = Frerpcreat.型号;
                String 单位 = Frerpcreat.单位;
                String sql = "update tb_caigouliaodan set 编码='" + erp + "',名称='" + 名称 + "',型号='" + 型号 + "',单位='" + 单位+ "',当前状态='3' where id='" + id + "'";
                
                if(id == "")
                {
                    MessageBox.Show("请选择一项");

                    gridControl1.DataSource = reload();
                }
                else
                {
                    SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
                    公共.添加审批记录(yonghu, "外协待数据分析师通过", id);

                    gridControl1.DataSource = reload();
                }
              
            }
        }

        private void 工艺不合格退回工艺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            string sql = "update tb_caigouliaodan  set 当前状态='52' where id='" + id + "'";

            SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
            gridControl1.DataSource = reload();
        }

        private void 驳回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (yonghu.Equals(经理))
            {
                DialogResult result = MessageBox.Show("确实要驳回吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                    string sql = "update tb_caigouliaodan  set 当前状态='10' where id='" + id + "'";
                    公共.添加审批记录(yonghu, "驳回", id);
                    SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
                    gridControl1.DataSource = reload();
                }
                 
            }

        }

        private void 已查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("已查看？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string sql = "update tb_caigouliaodan  set 当前状态='71' where id='" + id + "'";
                公共.添加审批记录(yonghu, "驳回", id);
                SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
                gridControl1.DataSource = reload();
            }
        }

        private void 驳回ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定驳回？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
                string 模具部驳回原因 = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "模具部驳回原因"));
                string sql = "update tb_caigouliaodan  set 当前状态='73',模具部驳回原因='"+ 模具部驳回原因+" 'where id ='" + id + "'";
                公共.添加审批记录(yonghu, "驳回", id);
                SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
                gridControl2.DataSource = reload1();
            }
        }

        private void 无法编erp驳回已处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

                string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
                string sql = "update tb_caigouliaodan  set 当前状态='3' where id='" + id + "'";
                公共.添加审批记录(yonghu, "驳回已处理", id);
                SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
                gridControl2.DataSource = reload1();
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
            string 当前状态 = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "statename"));
           
                Frxiugaicaigou form1 = new Frxiugaicaigou();
                form1.yonghu = yonghu;
                form1.id = id;
                form1.ShowDialog();
                if (form1.DialogResult == DialogResult.OK)
                {
                reload1();
                }
           
        }
    }
}
 