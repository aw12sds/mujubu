﻿using Aspose.Words;
using DevExpress.Xpf.Editors;
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
    public partial class 修改工艺1 : Form
    {
        public string yonghu;
        public string id;
        public string id1;
        public string lingjianmingcheng;
        public DataTable dt1;
        public 修改工艺1(string id,string id1,string lingjianmingcheng)
        {
            InitializeComponent();
            this.id = id;
            this.id1 = id1;
            this.lingjianmingcheng = lingjianmingcheng;
        }
        private void 修改工艺1_Load(object sender, EventArgs e)
        {
            DataTable a = xin(id);
            DataRow b = a.Rows[0];

            DataTable m;
            string sql = "select * from tb_mujubu_lingjian where 业务id='"+id+"'";
            m = SQLhelp.GetDataTable(sql, CommandType.Text);
            txt_jiagong.Text = b[0].ToString();//项目名称
            txt_xiadanriqi.Text = b[2].ToString();//模具部接单日期
            txt_gonglinghao.Text = b[1].ToString();//工作令号
            txt_jiagongshuliang.Text = b[4].ToString();
            txt_jiaohuoriqi.Text = b[3].ToString();//交货日期
            txt_shebei.Text = b[5].ToString();//设备名称
            txt_tuhao.Text = m.Rows[0]["图号"].ToString();
            txt_mingcheng.Text = lingjianmingcheng;

            reload();
        }
        public void reload()
        {
            string sql = "select * from tb_gongxu_manage where 零件id='" + id1 + "' order by cast(顺序 as int) ";
            dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
 
                for (int i=0;i<dt1.Rows.Count;i++)
            {
                DataRow drg = dt1.Rows[i];//拿到每一行的数据
                if (drg["顺序"].ToString() == "1")
                {
                    comboBox1.Text = drg["工序名称"].ToString();
                    richTextBox1.Text = drg["工序内容"].ToString();
                    txt_gx1.Text = drg["金额单价"].ToString();
                    comboBox21.Text = drg["操作人"].ToString();
                    textBox14.Text = drg["材料"].ToString();
                    textBox34.Text = drg["重量"].ToString();
                    //richTextBox27.Text = drg["工艺注意点"].ToString();
                    //shebei1.Text = drg["工序设备"].ToString();
                    txt_shuliang1.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "2")
                {
                    comboBox2.Text = drg["工序名称"].ToString();
                    richTextBox2.Text = drg["工序内容"].ToString();
                    txt_gx2.Text = drg["金额单价"].ToString();
                    comboBox22.Text = drg["操作人"].ToString();
                    textBox7.Text = drg["材料"].ToString();
                    textBox27.Text = drg["重量"].ToString();
                    //richTextBox28.Text = drg["工艺注意点"].ToString();
                    //shebei2.Text = drg["工序设备"].ToString();
                    txt_shuliang2.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "3")
                {
                    comboBox3.Text = drg["工序名称"].ToString();
                    richTextBox3.Text = drg["工序内容"].ToString();
                    txt_gx3.Text = drg["金额单价"].ToString();
                    comboBox23.Text = drg["操作人"].ToString();
                    textBox10.Text = drg["材料"].ToString();
                    textBox30.Text = drg["重量"].ToString();
                    //richTextBox29.Text = drg["工艺注意点"].ToString();
                    //shebei3.Text = drg["工序设备"].ToString();
                    txt_shuliang3.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "4")
                {
                    comboBox4.Text = drg["工序名称"].ToString();
                    richTextBox4.Text = drg["工序内容"].ToString();
                    txt_gx4.Text = drg["金额单价"].ToString();
                    comboBox24.Text = drg["操作人"].ToString();
                    textBox3.Text = drg["材料"].ToString();
                    textBox2.Text = drg["重量"].ToString();
                    //richTextBox30.Text = drg["工艺注意点"].ToString();
                    //shebei4.Text = drg["工序设备"].ToString();
                    txt_shuliang4.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "5")
                {
                    comboBox5.Text = drg["工序名称"].ToString();
                    richTextBox5.Text = drg["工序内容"].ToString();
                    txt_gx5.Text = drg["金额单价"].ToString();
                    comboBox25.Text = drg["操作人"].ToString();
                    //richTextBox31.Text = drg["工艺注意点"].ToString();
                    //shebei5.Text = drg["工序设备"].ToString();
                    txt_shuliang5.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "6")
                {
                    comboBox6.Text = drg["工序名称"].ToString();
                    richTextBox6.Text = drg["工序内容"].ToString();
                    txt_gx6.Text = drg["金额单价"].ToString();
                    comboBox26.Text = drg["操作人"].ToString();
                    //richTextBox32.Text = drg["工艺注意点"].ToString();
                    //shebei6.Text = drg["工序设备"].ToString();
                    txt_shuliang6.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "7")
                {
                    comboBox7.Text = drg["工序名称"].ToString();
                    richTextBox7.Text = drg["工序内容"].ToString();
                    txt_gx7.Text = drg["金额单价"].ToString();
                    comboBox27.Text = drg["操作人"].ToString();
                    //richTextBox33.Text = drg["工艺注意点"].ToString();
                    //shebei7.Text = drg["工序设备"].ToString();
                    txt_shuliang7.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "8")
                {
                    comboBox8.Text = drg["工序名称"].ToString();
                    richTextBox8.Text = drg["工序内容"].ToString();
                    txt_gx8.Text = drg["金额单价"].ToString();
                    comboBox28.Text = drg["操作人"].ToString();
                    //richTextBox34.Text = drg["工艺注意点"].ToString();
                    //shebei8.Text = drg["工序设备"].ToString();
                    txt_shuliang8.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "9")
                {
                    comboBox9.Text = drg["工序名称"].ToString();
                    richTextBox9.Text = drg["工序内容"].ToString();
                    txt_gx9.Text = drg["金额单价"].ToString();
                    comboBox29.Text = drg["操作人"].ToString();
                    //richTextBox35.Text = drg["工艺注意点"].ToString();
                    //shebei9.Text = drg["工序设备"].ToString();
                    txt_shuliang9.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "10")
                {
                    comboBox10.Text = drg["工序名称"].ToString();
                    richTextBox10.Text = drg["工序内容"].ToString();
                    txt_gx10.Text = drg["金额单价"].ToString();
                    comboBox30.Text = drg["操作人"].ToString();
                    //richTextBox36.Text = drg["工艺注意点"].ToString();
                    //shebei10.Text = drg["工序设备"].ToString();
                    txt_shuliang10.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "11")
                {
                    comboBox11.Text = drg["工序名称"].ToString();
                    richTextBox11.Text = drg["工序内容"].ToString();
                    txt_gx11.Text = drg["金额单价"].ToString();
                    comboBox31.Text = drg["操作人"].ToString();
                    //richTextBox37.Text = drg["工艺注意点"].ToString();
                    //shebei11.Text = drg["工序设备"].ToString();
                    txt_shuliang11.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "12")
                {
                    comboBox12.Text = drg["工序名称"].ToString();
                    richTextBox12.Text = drg["工序内容"].ToString();
                    txt_gx12.Text = drg["金额单价"].ToString();
                    comboBox32.Text = drg["操作人"].ToString();
                    //richTextBox38.Text = drg["工艺注意点"].ToString();
                    //shebei12.Text = drg["工序设备"].ToString();
                    txt_shuliang12.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "13")
                {
                    comboBox13.Text = drg["工序名称"].ToString();
                    richTextBox13.Text = drg["工序内容"].ToString();
                    txt_gx13.Text = drg["金额单价"].ToString();
                    comboBox33.Text = drg["操作人"].ToString();
                    //richTextBox39.Text = drg["工艺注意点"].ToString();
                    //shebei13.Text = drg["工序设备"].ToString();
                    txt_shuliang13.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "14")
                {
                    comboBox14.Text = drg["工序名称"].ToString();
                    richTextBox14.Text = drg["工序内容"].ToString();
                    txt_gx14.Text = drg["金额单价"].ToString();
                    comboBox34.Text = drg["操作人"].ToString();
                    //richTextBox40.Text = drg["工艺注意点"].ToString();
                    //shebei14.Text = drg["工序设备"].ToString();
                    txt_shuliang14.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "15")
                {
                    comboBox15.Text = drg["工序名称"].ToString();
                    richTextBox15.Text = drg["工序内容"].ToString();
                    txt_gx15.Text = drg["金额单价"].ToString();
                    comboBox35.Text = drg["操作人"].ToString();
                    //richTextBox41.Text = drg["工艺注意点"].ToString();
                    //shebei15.Text = drg["工序设备"].ToString();
                    txt_shuliang15.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "16")
                {
                    comboBox16.Text = drg["工序名称"].ToString();
                    richTextBox16.Text = drg["工序内容"].ToString();
                    txt_gx16.Text = drg["金额单价"].ToString();
                    comboBox36.Text = drg["操作人"].ToString();
                    //richTextBox42.Text = drg["工艺注意点"].ToString();
                    //shebei16.Text = drg["工序设备"].ToString();
                    txt_shuliang16.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "17")
                {
                    comboBox17.Text = drg["工序名称"].ToString();
                    richTextBox17.Text = drg["工序内容"].ToString();
                    txt_gx17.Text = drg["金额单价"].ToString();
                    comboBox37.Text = drg["操作人"].ToString();
                    //richTextBox43.Text = drg["工艺注意点"].ToString();
                    //shebei17.Text = drg["工序设备"].ToString();
                    txt_shuliang17.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "18")
                {
                    comboBox18.Text = drg["工序名称"].ToString();
                    richTextBox18.Text = drg["工序内容"].ToString();
                    txt_gx18.Text = drg["金额单价"].ToString();
                    comboBox38.Text = drg["操作人"].ToString();
                    //richTextBox44.Text = drg["工艺注意点"].ToString();
                    //shebei18.Text = drg["工序设备"].ToString();
                    txt_shuliang18.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "19")
                {
                    comboBox19.Text = drg["工序名称"].ToString();
                    richTextBox19.Text = drg["工序内容"].ToString();
                    txt_gx19.Text = drg["金额单价"].ToString();
                    comboBox39.Text = drg["操作人"].ToString();
                    //richTextBox45.Text = drg["工艺注意点"].ToString();
                    //shebei19.Text = drg["工序设备"].ToString();
                    txt_shuliang19.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "20")
                {
                    comboBox20.Text = drg["工序名称"].ToString();
                    richTextBox20.Text = drg["工序内容"].ToString();
                    txt_gx20.Text = drg["金额单价"].ToString();
                    comboBox40.Text = drg["操作人"].ToString();
                    //richTextBox46.Text = drg["工艺注意点"].ToString();
                    //shebei20.Text = drg["工序设备"].ToString();
                    txt_shuliang20.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "21")
                {
                    comboBox46.Text = drg["工序名称"].ToString();
                    richTextBox22.Text = drg["工序内容"].ToString();
                    txt_gx21.Text = drg["金额单价"].ToString();
                    comboBox41.Text = drg["操作人"].ToString();
                    //richTextBox47.Text = drg["工艺注意点"].ToString();
                    //shebei21.Text = drg["工序设备"].ToString();
                    txt_shuliang21.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "22")
                {
                    comboBox47.Text = drg["工序名称"].ToString();
                    richTextBox23.Text = drg["工序内容"].ToString();
                    txt_gx22.Text = drg["金额单价"].ToString();
                    comboBox42.Text = drg["操作人"].ToString();
                    //richTextBox48.Text = drg["工艺注意点"].ToString();
                    //shebei22.Text = drg["工序设备"].ToString();
                    txt_shuliang22.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "23")
                {
                    comboBox48.Text = drg["工序名称"].ToString();
                    richTextBox24.Text = drg["工序内容"].ToString();
                    txt_gx23.Text = drg["金额单价"].ToString();
                    comboBox43.Text = drg["操作人"].ToString();
                    //richTextBox49.Text = drg["工艺注意点"].ToString();
                    //shebei23.Text = drg["工序设备"].ToString();
                    txt_shuliang23.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "24")
                {
                    comboBox49.Text = drg["工序名称"].ToString();
                    richTextBox25.Text = drg["工序内容"].ToString();
                    txt_gx24.Text = drg["金额单价"].ToString();
                    comboBox44.Text = drg["操作人"].ToString();
                    //richTextBox50.Text = drg["工艺注意点"].ToString();
                    //shebei24.Text = drg["工序设备"].ToString();
                    txt_shuliang24.Text = drg["加工数量"].ToString();
                }
                if (drg["顺序"].ToString() == "25")
                {
                    comboBox50.Text = drg["工序名称"].ToString();
                    richTextBox26.Text = drg["工序内容"].ToString();
                    txt_gx25.Text = drg["金额单价"].ToString();
                    comboBox45.Text = drg["操作人"].ToString();
                    //richTextBox51.Text = drg["工艺注意点"].ToString();
                    //shebei25.Text = drg["工序设备"].ToString();
                    txt_shuliang25.Text = drg["加工数量"].ToString();
                }

            }
            
        }
        private DataTable xin(string id)
        {
            DataTable dt = new DataTable();
            string s1 = "select 项目名称,工作令号,模具部接单日期,模具部交货日期,实际采购数量,设备名称 from tb_caigouliaodan where 定位='" + id + "'and 名称='" + lingjianmingcheng + "'";
            dt = SQLhelp.GetDataTable(s1, CommandType.Text);
            return dt;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            增加工序1 增加工序1 = new 增加工序1(id1);
            增加工序1.ShowDialog();
            if (增加工序1.DialogResult == DialogResult.OK)
            { this.Close(); }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            删除工序 删除工序1 = new 删除工序(id1);
            删除工序1.ShowDialog();
            if (删除工序1.DialogResult == DialogResult.OK)
            { this.Close(); }
            
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            修改工序内容和数量 修改工序内容和数量 = new 修改工序内容和数量(id1,lingjianmingcheng);
            修改工序内容和数量.ShowDialog();
            if (修改工序内容和数量.DialogResult == DialogResult.OK)
            { this.Close(); }

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();

            string sql = "select * from tb_caigouliaodan where 定位='" + id + "'and 名称='"+lingjianmingcheng+"'";
            dt3 = SQLhelp.GetDataTable(sql, CommandType.Text);
            string sql1 = "select * from tb_mujubu_lingjian where id='" + id1 + "'";
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
            string 校对 = yonghu + "  " + DateTime.Now + "";
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
            string sql2 = "select * from tb_gongxu_manage where 零件id='" + id1 + "'";
            DataTable dt2 =SQLhelp.GetDataTable(sql2, CommandType.Text);
            int rows = dt2.Rows.Count;
            //生成数据行   
            if(rows==0)
            {
                MessageBox.Show("没有工序！");
                return;
            }
            for (int i = 0; i < rows; i++)
            {
                int j = i + 1;
                string 工序书签 = "工序" + j;
                string 工序内容书签 = "内容" + j;
                string 加工数量书签 = "数量" + j;
                string 价格书签 = "价格" + j;
                
                if (j == 1)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox1.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox1.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang1.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx1.Text);
                }
                if (j == 2)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox2.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox2.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang2.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx2.Text);
                }
                if (j == 3)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox3.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox3.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang3.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx3.Text);
                }
                if (j == 4)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox4.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox4.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang4.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx4.Text);
                }
                if (j == 5)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox5.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox5.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang5.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx5.Text);
                }
                if (j == 6)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox6.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox6.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang6.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx6.Text);
                }
                if (j == 7)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox7.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox7.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang7.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx7.Text);
                }
                if (j == 8)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox8.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox8.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang8.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx1.Text);
                }
                if (j == 9)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox9.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox9.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang9.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx9.Text);
                }
                if (j == 10)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox10.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox10.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang10.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx10.Text);
                }
                if (j == 11)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox11.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox11.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang11.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx11.Text);
                }
                if (j == 12)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox12.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox12.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang12.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx12.Text);
                }
                if (j == 13)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox13.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox13.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang13.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx13.Text);
                }
                if (j == 14)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox14.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox14.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang14.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx14.Text);
                }
                if (j == 15)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox15.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox15.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang15.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx15.Text);
                }
                if (j == 16)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox16.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox16.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang16.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx16.Text);
                }
                if (j == 17)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox17.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox17.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang17.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx17.Text);
                }
                if (j == 18)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox18.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox18.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang18.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx18.Text);
                }
                if (j == 19)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox19.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox19.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang19.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx19.Text);
                }
                if (j == 20)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox20.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox20.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang20.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx20.Text);
                }
                if (j == 21)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox21.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox21.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang21.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx21.Text);
                }
                if (j == 22)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox22.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox22.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang22.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx22.Text);
                }
                if (j == 23)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox23.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox23.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang23.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx23.Text);
                }
                if (j == 24)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox24.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox24.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang24.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx24.Text);
                }
                if (j == 25)
                {
                    builder.MoveToBookmark(工序书签);
                    builder.Write(this.comboBox25.Text);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(this.richTextBox25.Text);
                    builder.MoveToBookmark(加工数量书签);
                    builder.Write(this.txt_shuliang25.Text);
                    builder.MoveToBookmark(价格书签);
                    builder.Write(this.txt_gx25.Text);
                }
               
            }
            string docName =工作令号+" "+零件名称+".doc";

            FileInfo info1 = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + docName);
            string fileName11 = info1.Name.ToString();

            doc.Save(info1.DirectoryName + "\\" + fileName11);
            string lujing = info1.DirectoryName + "\\" + fileName11;
            System.Diagnostics.Process.Start(lujing);
            //MessageBox.Show("工艺卡保存到桌面成功！", "提示");
           
            
        }
    }
}
