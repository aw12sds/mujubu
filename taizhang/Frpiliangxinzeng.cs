﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Aspose.Cells;

namespace mujubu.taizhang
{
    public partial class Frpiliangxinzeng : DevExpress.XtraEditors.XtraForm
    {
        public Frpiliangxinzeng()
        {
            InitializeComponent();
        }

        public string yonghu;
        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textEdit1.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textEdit1.Text, out oldf);
                    b2 = float.TryParse(textEdit1.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(textEdit1.Text=="")
            {
                MessageBox.Show("请填写需要插入的行数");
                return;
            }
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string b = dialog.FileName;
                DataTable dt = new DataTable();
                Workbook book = new Workbook(b);
                Worksheet sheet = book.Worksheets["Sheet1"];
                dt.Columns.Add("名称");
                dt.Columns.Add("型号");
                dt.Columns.Add("类型");
                dt.Columns.Add("备注");             
                dt = sheet.Cells.ExportDataTableAsString(1, 0, Convert.ToInt32(textEdit1.Text), 5);
                gridControl2.DataSource = dt;
                gridView2.Columns[0].Caption = "名称";
                gridView2.Columns[1].Caption = "型号";
                gridView2.Columns[2].Caption = "类型";
                gridView2.Columns[3].Caption = "备注";
                gridView2.Columns[4].Caption = "工序类型(原材料,五金辅材,工序外协)";
            }
        }

        private void Frpiliangxinzeng_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            String gonglinghao = "";
            if (radioButton1.Checked == true)
            {
                if (txtgonglighao1.Text.Trim() == "")
                {
                    gonglinghao = txtgonglighao1.Text.Trim();
                    MessageBox.Show("工作令号不能为空,如无工作令号,请选择描述！");

                    return;
                }
                else
                {
                    if (txtgonglighao1.Text.Trim() == "" && txtgonglinghao2.Text.Trim() == "")
                    {
                        gonglinghao = "";
                    }
                    else
                    {
                        gonglinghao = txtgonglighao1.Text.Trim() + "-MD-" + txtgonglinghao2.Text.Trim();
                    }

                }
            }
            else if (radioButton2.Checked == true)
            {
                if (textEdit2.Text == "")
                {
                    MessageBox.Show("描述不能为空！");
                }
                else
                {
                    gonglinghao = textEdit2.Text;
                }
            }
            string flag = "正确";
           
            if (txtgonglighao1.Text.Trim() == "" && txtgonglinghao2.Text.Trim() == "")
            {
                gonglinghao = "";
            }
            else
            {
                gonglinghao = txtgonglighao1.Text.Trim() + "-MD-" + txtgonglinghao2.Text.Trim();
            }

            if (dateEdit1.Text == "")
            {
                MessageBox.Show("请填写需要的交货日期！");
                return;
            }
            if (gridView2.RowCount ==0)
            {
                MessageBox.Show("请先导入表格！");
                return;
            }
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                string 模具部成本是否工序 = gridView2.GetRowCellValue(i, "Column5").ToString();
                if (模具部成本是否工序 == "")
                {
                    MessageBox.Show("是否工序不能为空");
                    flag = "错误";
                    return;
                }
                if (模具部成本是否工序 == "原材料" || 模具部成本是否工序 == "五金辅材" || 模具部成本是否工序 == "工序外协")
                {
                }
                else
                {
                    MessageBox.Show("是否工序格式错误");
                    flag = "错误";
                    return;
                }
            }
           
                if (flag == "正确")
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    string mingcheng = gridView2.GetRowCellValue(i, "Column1").ToString();

                    string xinghao = gridView2.GetRowCellValue(i, "Column2").ToString();
                    string leixing = gridView2.GetRowCellValue(i, "Column3").ToString();
                    string beizhu = gridView2.GetRowCellValue(i, "Column4").ToString();
                    string 模具部成本是否工序 = gridView2.GetRowCellValue(i, "Column5").ToString();
                  
                        string sql1 = "INSERT INTO tb_caigouliaodan(工作令号,模具部接单日期,当前状态,模具部交货日期,项目名称,名称,型号,类型,备注,模具部申请人,料单类型,到货情况,申购人,收到料单日期,模具部成本是否工序) VALUES('" + gonglinghao + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '1','" + dateEdit1.Text + "', '" + txtxiangmumingcheng.Text.Trim() + "', '" + mingcheng + "','" + xinghao + "','" + leixing + "','" + beizhu + "','" + yonghu + "','模具部原材料',0,'" + yonghu + "','" + DateTime.Now + "','" + 模具部成本是否工序 + "')";
                        SQLhelp.ExecuteNonquery2(sql1, CommandType.Text);
                   
                }
                MessageBox.Show("提交成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
                 
        }
    }
}