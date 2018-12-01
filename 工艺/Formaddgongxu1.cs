using Aspose.Words;
using mujubu.公共类;
using NetWorkLib.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;

namespace mujubu.工艺
{
    public partial class Formaddgongxu1 : Form
    {
        public string id;
        public string lingjianmingcheng;
        public string yonghu;
        public string flag;
        public string addtuhao;//图号
        public string addmingcheng;//名称
        public string addxiangmuming;//项目名称
        public string addgonglinghao;//工作令号
        public string addshebeimingcheng;//设备名称
        public string addxuhao;//标志id
        public string lujing;

        string shijian1 = "08:00:00";//上班
        string shijian2 = "11:20:00";//开始休息----4小时
        string shijian3 = "12:50:00";//结束休息
        string shijian4 = "17:30:00";//开始休息----4.5小时
        string shijian5 = "18:00:00";//结束休息
        string shijian6 = "20:00:00";//下班    -----2小时------>一共10.5小时

        string shijian7 = "23:30:00";
        string shijian8 = "00:30:00";

        public Formaddgongxu1(string id,string lingjianmingcheng)
        {
            InitializeComponent();
            this.id = id;
            this.lingjianmingcheng = lingjianmingcheng;
        }

        private void Formaddgongxu1_Load(object sender, EventArgs e)
        {
            string sqlstr1 = "select * from tb_personList";
            DataTable dt1 = SQLhelp.GetDataTable(sqlstr1, CommandType.Text);
            foreach (DataRow dr1 in dt1.Rows)
            {
                this.comboBox21.Items.Add(dr1["Name"].ToString());
                this.comboBox22.Items.Add(dr1["Name"].ToString());
                this.comboBox23.Items.Add(dr1["Name"].ToString());
                this.comboBox24.Items.Add(dr1["Name"].ToString());
                this.comboBox25.Items.Add(dr1["Name"].ToString());
                this.comboBox26.Items.Add(dr1["Name"].ToString());
                this.comboBox27.Items.Add(dr1["Name"].ToString());
                this.comboBox28.Items.Add(dr1["Name"].ToString());
                this.comboBox29.Items.Add(dr1["Name"].ToString());
                this.comboBox30.Items.Add(dr1["Name"].ToString());
                this.comboBox31.Items.Add(dr1["Name"].ToString());
                this.comboBox32.Items.Add(dr1["Name"].ToString());
                this.comboBox33.Items.Add(dr1["Name"].ToString());
                this.comboBox34.Items.Add(dr1["Name"].ToString());
                this.comboBox35.Items.Add(dr1["Name"].ToString());
                this.comboBox36.Items.Add(dr1["Name"].ToString());
                this.comboBox37.Items.Add(dr1["Name"].ToString());
                this.comboBox38.Items.Add(dr1["Name"].ToString());
                this.comboBox39.Items.Add(dr1["Name"].ToString());
                this.comboBox40.Items.Add(dr1["Name"].ToString());

            }

            string sqlstr2 = "select * from tb_mujubu_shebei";
            DataTable dt2 = SQLhelp.GetDataTable(sqlstr2, CommandType.Text);
            foreach (DataRow dr2 in dt2.Rows)
            {
                this.shebei1.Items.Add(dr2["设备名"].ToString());
                this.shebei2.Items.Add(dr2["设备名"].ToString());
                this.shebei3.Items.Add(dr2["设备名"].ToString());
                this.shebei4.Items.Add(dr2["设备名"].ToString());
                this.shebei5.Items.Add(dr2["设备名"].ToString());
                this.shebei6.Items.Add(dr2["设备名"].ToString());
                this.shebei7.Items.Add(dr2["设备名"].ToString());
                this.shebei8.Items.Add(dr2["设备名"].ToString());
                this.shebei9.Items.Add(dr2["设备名"].ToString());
                this.shebei10.Items.Add(dr2["设备名"].ToString());
                this.shebei11.Items.Add(dr2["设备名"].ToString());
                this.shebei12.Items.Add(dr2["设备名"].ToString());
                this.shebei13.Items.Add(dr2["设备名"].ToString());
                this.shebei14.Items.Add(dr2["设备名"].ToString());
                this.shebei15.Items.Add(dr2["设备名"].ToString());
                this.shebei16.Items.Add(dr2["设备名"].ToString());
                this.shebei17.Items.Add(dr2["设备名"].ToString());
                this.shebei18.Items.Add(dr2["设备名"].ToString());
                this.shebei19.Items.Add(dr2["设备名"].ToString());
                this.shebei20.Items.Add(dr2["设备名"].ToString());
            }

            string s1 = "select * from tb_gongxu_name";
            DataTable row = SQLhelp.GetDataTable(s1, CommandType.Text);
            foreach (DataRow dr in row.Rows)
            {
                this.comboBox1.Items.Add(dr["工序名"].ToString());
                this.comboBox2.Items.Add(dr["工序名"].ToString());
                this.comboBox3.Items.Add(dr["工序名"].ToString());
                this.comboBox4.Items.Add(dr["工序名"].ToString());
                this.comboBox5.Items.Add(dr["工序名"].ToString());
                this.comboBox7.Items.Add(dr["工序名"].ToString());
                this.comboBox6.Items.Add(dr["工序名"].ToString());
                this.comboBox8.Items.Add(dr["工序名"].ToString());
                this.comboBox9.Items.Add(dr["工序名"].ToString());
                this.comboBox13.Items.Add(dr["工序名"].ToString());
                this.comboBox11.Items.Add(dr["工序名"].ToString());
                this.comboBox15.Items.Add(dr["工序名"].ToString());
                this.comboBox10.Items.Add(dr["工序名"].ToString());
                this.comboBox14.Items.Add(dr["工序名"].ToString());
                this.comboBox12.Items.Add(dr["工序名"].ToString());
                this.comboBox16.Items.Add(dr["工序名"].ToString());
                this.comboBox17.Items.Add(dr["工序名"].ToString());
                this.comboBox19.Items.Add(dr["工序名"].ToString());
                this.comboBox18.Items.Add(dr["工序名"].ToString());
                this.comboBox20.Items.Add(dr["工序名"].ToString());

                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox7.Enabled = false;
                comboBox6.Enabled = false;
                comboBox8.Enabled = false;
                comboBox9.Enabled = false;
                comboBox13.Enabled = false;
                comboBox11.Enabled = false;
                comboBox15.Enabled = false;
                comboBox10.Enabled = false;
                comboBox14.Enabled = false;
                comboBox12.Enabled = false;
                comboBox16.Enabled = false;
                comboBox17.Enabled = false;
                comboBox19.Enabled = false;
                comboBox18.Enabled = false;
                comboBox20.Enabled = false;

                richTextBox1.Enabled = false;
                richTextBox9.Enabled = false;
                richTextBox10.Enabled = false;
                richTextBox11.Enabled = false;
                richTextBox12.Enabled = false;
                richTextBox13.Enabled = false;
                richTextBox14.Enabled = false;
                richTextBox15.Enabled = false;
                richTextBox16.Enabled = false;
                richTextBox17.Enabled = false;
                richTextBox18.Enabled = false;
                richTextBox19.Enabled = false;
                richTextBox2.Enabled = false;
                richTextBox20.Enabled = false;
                richTextBox3.Enabled = false;
                richTextBox4.Enabled = false;
                richTextBox5.Enabled = false;
                richTextBox6.Enabled = false;
                richTextBox7.Enabled = false;
                richTextBox8.Enabled = false;
            }
            DataTable a = xin(id);
            DataRow b = a.Rows[0];

            txt_jiagong.Text = b[0].ToString();//项目名称
            txt_xiadanriqi.Text = b[2].ToString();//模具部接单日期
            txt_gonglinghao.Text = b[1].ToString();//工作令号
            txt_jiagongshuliang.Text = b[4].ToString();
            txt_jiaohuoriqi.Text = b[3].ToString();//交货日期
            txt_mingcheng.Text = lingjianmingcheng;
            CodeReplay();


        }
        private DataTable xin(string id)
        {
            DataTable dt = new DataTable();
            string s1 = "select 项目名称,工作令号,模具部接单日期,模具部交货日期,实际采购数量 from tb_caigouliaodan where 定位='" + id + "'and 名称='"+lingjianmingcheng+"'";
            dt = SQLhelp.GetDataTable(s1, CommandType.Text);
            return dt;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() != "")
            {
                richTextBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox21.Enabled = true;
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text.Trim() != "")
            {
                richTextBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox22.Enabled = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text.Trim() != "")
            {
                richTextBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox23.Enabled = true;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text.Trim() != "")
            {
                richTextBox4.Enabled = true;
                comboBox5.Enabled = true;
                comboBox24.Enabled = true;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text.Trim() != "")
            {
                richTextBox5.Enabled = true;
                comboBox6.Enabled = true;
                comboBox25.Enabled = true;
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text.Trim() != "")
            {
                richTextBox6.Enabled = true;
                comboBox7.Enabled = true;
                comboBox26.Enabled = true;
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text.Trim() != "")
            {
                richTextBox7.Enabled = true;
                comboBox8.Enabled = true;
                comboBox27.Enabled = true;
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.Text.Trim() != "")
            {
                richTextBox8.Enabled = true;
                comboBox9.Enabled = true;
                comboBox28.Enabled = true;
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.Text.Trim() != "")
            {
                richTextBox9.Enabled = true;
                comboBox10.Enabled = true;
                comboBox29.Enabled = true;
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox10.Text.Trim() != "")
            {
                richTextBox10.Enabled = true;
                comboBox11.Enabled = true;
                comboBox30.Enabled = true;
            }
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox11.Text.Trim() != "")
            {
                richTextBox11.Enabled = true;
                comboBox12.Enabled = true;
                comboBox31.Enabled = true;
            }
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox12.Text.Trim() != "")
            {
                richTextBox12.Enabled = true;
                comboBox13.Enabled = true;
                comboBox32.Enabled = true;
            }
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox13.Text.Trim() != "")
            {
                richTextBox13.Enabled = true;
                comboBox14.Enabled = true;
                comboBox33.Enabled = true;
            }
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox14.Text.Trim() != "")
            {
                richTextBox14.Enabled = true;
                comboBox15.Enabled = true;
                comboBox34.Enabled = true;
            }
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox15.Text.Trim() != "")
            {
                richTextBox15.Enabled = true;
                comboBox16.Enabled = true;
                comboBox35.Enabled = true;
            }
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox16.Text.Trim() != "")
            {
                richTextBox16.Enabled = true;
                comboBox17.Enabled = true;
                comboBox36.Enabled = true;
            }
        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox17.Text.Trim() != "")
            {
                richTextBox17.Enabled = true;
                comboBox18.Enabled = true;
                comboBox37.Enabled = true;
            }
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox18.Text.Trim() != "")
            {
                richTextBox18.Enabled = true;
                comboBox19.Enabled = true;
                comboBox38.Enabled = true;
            }
        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox19.Text.Trim() != "")
            {
                richTextBox19.Enabled = true;
                comboBox20.Enabled = true;
                comboBox39.Enabled = true;
            }
        }



        private void comboBox20_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox20.Text.Trim() != "")
            {
                richTextBox20.Enabled = true;
                comboBox40.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() != "")
            {
                richTextBox1.Enabled = true;
                comboBox21.Enabled = true;
                comboBox2.Enabled = true;
            }
        }
        private void CodeReplay()
        {
            string b = addmingcheng;//名称
            string d = txt_gonglinghao.Text;//工作令号
            string f = txt_jiagong.Text;//项目名称

            //string dataCode = f + "\n" + a + "\n" + b + "\n" + c + "\n" + d + "\n";
            string dataCode = f + "\n" + d + "\n" + b + "\n";
            //string dataCode = f + "|" + a + "|" + b + "|";
            richTextBox21.Text = dataCode;
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            Image image;
            string data = dataCode;
            image = qrCodeEncoder.Encode(data, Encoding.UTF8);
            pictureBox1.Size = new Size(186, 186);
            pictureBox1.Image = image;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            double b = 0.0;
            string uid = System.Guid.NewGuid().ToString("N");
            string 编制 = yonghu + DateTime.Now;
            string timeNow = DateTime.Now.ToString();
            bool gongxuBiTian = false;
            for (int i = 1; i <=20; i++)
             { 
                if ((this.Controls["panel1"].Controls["comboBox" + i.ToString()] as ComboBox).Text != "")
                  {
                    gongxuBiTian = true;
                    if ((this.Controls["panel1"].Controls["textBox_shuliang_" + i.ToString()] as TextBox).Text == ""||(this.Controls["panel1"].Controls["txt_gx" + i.ToString()] as TextBox).Text =="")
                    {
                        MessageBox.Show("请检查第"+i+"道工序数量和价格是否未填写！", "提示");
                        return;
                    }
                    if(Double.TryParse((this.Controls["panel1"].Controls["textBox_shuliang_" + i.ToString()] as TextBox).Text,out b)==false)
                    {
                        MessageBox.Show("第"+i+"道工序数量不为数字!");
                        return;
                    }
                    if (Double.TryParse((this.Controls["panel1"].Controls["txt_gx" + i.ToString()] as TextBox).Text, out b) == false)
                    {
                        MessageBox.Show("第" + i + "道工序价格不为数字!");
                        return;
                     }
                   };
               }
            if(gongxuBiTian==false)
            {
                MessageBox.Show("至少填一道工序!");
                return;
            }
            if (txt_tuhao.Text == "")
            {
                MessageBox.Show("请输入图号");
                return;
            }
            else
            {
                string sql = "insert into tb_mujubu_lingjian(id,业务id,图号,零件名称,材质,顺序,时间,编制) values('" + uid + "','" + id + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_danhao.Text + "','" + txt_mingcheng.Text + "','" + DateTime.Now + "','" + 编制 + "')";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

                string sql2 = "select * from tb_mujubu_lingjian where id='" + uid + "'";
                DataTable dt1 = SQLhelp.GetDataTable(sql2, CommandType.Text);
                string 零件id = dt1.Rows[0]["id"].ToString();
                string time1time = DateTime.Now.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串
                string time1date1 = DateTime.Now.ToString("yyyy/MM/dd");//截取到的当前的日期
                for (int i = 1; i <= 20; i++)
                {
                    string 工序名称 = (this.Controls["panel1"].Controls["comboBox" + i.ToString()] as ComboBox).Text;
                    string 数量 = (this.Controls["panel1"].Controls["textBox_shuliang_" + i.ToString()] as TextBox).Text;
                    string 价格 = (this.Controls["panel1"].Controls["txt_gx" + i.ToString()] as TextBox).Text;
                    string 材料 = "";
                    string 重量 = "";
                    string 设备名称 = (this.Controls["panel1"].Controls["shebei" + i.ToString()] as ComboBox).Text;
                    if (i <= 4)
                    {
                        材料 = (this.Controls["groupBox7"].Controls["cailiaoguige" + i.ToString()] as TextBox).Text;
                        重量 = (this.Controls["groupBox7"].Controls["zhongliang" + i.ToString()] as TextBox).Text;
                    }
                    if (i > 4 && i <= 20)
                    {
                        材料 = "无";
                        重量 = "0";
                    }
                    if (工序名称 != "")
                    {
                        string 工序内容 = (this.Controls["panel1"].Controls["richTextBox" + i.ToString()]).Text;
                        string sql1 = "insert into tb_gongxu_manage(零件id,工序名称,工序内容,加工数量,顺序,材料,重量,编写时间) values('" + 零件id + "','" + 工序名称 + "','" + 工序内容 + "','" + 数量 + "','" + i + "','" + 材料 + "','" + 重量 + "','" + timeNow + "')";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                        if(设备名称!="")
                        {
                                string sql3 = "insert into tb_mujubu_paichan(序号,图号,零件名称,工序名称,工序顺序,数量,价格,工序设备,工艺制定时间) values('" + 零件id + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + 工序名称 + "','" + i + "','" + 数量 + "','" + 价格 + "','" + 设备名称 + "','" + DateTime.Now + "'";
                                SQLhelp.ExecuteScalar(sql3, CommandType.Text);
                        }
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            if (txt_tuhao.Text == "")
            {
                MessageBox.Show("图号不能为空");
            }
            else
            {
                for (int i = 0; i < 20; i++)
                {
                    int j = i + 1;
                    (this.Controls["panel1"].Controls["comboBox" + j.ToString()] as ComboBox).Text = "";
                    (this.Controls["panel1"].Controls["richTextBox" + j.ToString()]).Text = "";
                    //(this.Controls["panel1"].Controls["textBox_shuliang_" + j.ToString()] as ComboBox).Text = "";
                    //(this.Controls["panel1"].Controls["txt_gx" + j.ToString()]).Text = "";
                }
                string 图号 = txt_tuhao.Text;
                string sql = "select * from tb_mujubu_lingjian where 图号='" + 图号 + "'";
                DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("查不到此图号");
                    return;
                }
                else
                {
                    string id = dt1.Rows[0]["id"].ToString();
                    string sql1 = "select * from tb_gongxu_manage where 零件id='" + id + "'";
                    DataTable dt2 = SQLhelp.GetDataTable(sql1, CommandType.Text);
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        int j = i + 1;
                        (this.Controls["panel1"].Controls["comboBox" + j.ToString()] as ComboBox).SelectedIndex = comboBox1.Items.IndexOf(dt2.Rows[i]["工序名称"]);
                        (this.Controls["panel1"].Controls["richTextBox" + j.ToString()]).Text = dt2.Rows[i]["工序内容"] + "";
                    }
                }
            }
        }
        private void btn_Gongyika_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请添加工序！", "提示");
                return;
            }
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("请添加工序内容！", "提示");
                return;
            }
            DataTable dt = new DataTable();
            string tempFile = Application.StartupPath + "\\工艺卡模板新.doc";
            //string tempFile = "../../bin/resouce/工艺卡模板新.doc";
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);
            builder.MoveToBookmark("工令号");
            String 工令号 = txt_gonglinghao.Text;
            builder.Write(工令号);
            builder.MoveToBookmark("交货日");
            String 交货日 = txt_jiaohuoriqi.Text;
            builder.Write(交货日);
            builder.MoveToBookmark("零件名称");
            String 零件名称 = txt_mingcheng.Text;
            builder.Write(零件名称);
            builder.MoveToBookmark("零件图号");
            String 零件图号 = txt_tuhao.Text;
            builder.Write(零件图号);
            builder.MoveToBookmark("下单日期");
            String 下单日期 = txt_tuhao.Text;
            builder.Write(下单日期);
            for (int i = 1; i <= 20; i++)
            {
                string 工序名称 = (this.Controls["panel1"].Controls["comboBox" + i.ToString()] as ComboBox).Text;
                string 工序内容 = (this.Controls["panel1"].Controls["richTextBox" + i.ToString()]).Text;
                string 数量 = (this.Controls["panel1"].Controls["textBox_shuliang_" + i.ToString()] as TextBox).Text;
                if (工序名称 != "")
                {
                    string 工序书签 = "工序" + i;
                    string 工序内容书签 = "内容" + i;
                    string 数量书签 = "数量" + i;
                    builder.MoveToBookmark(工序书签);
                    builder.Write(工序名称);
                    builder.MoveToBookmark(工序内容书签);
                    builder.Write(工序内容);
                    builder.MoveToBookmark(数量书签);
                    builder.Write(数量);
                }
            }
            string docName = "aa.doc";
            FileInfo info1 = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + docName);
            string fileName11 = info1.Name.ToString();

            doc.Save(info1.DirectoryName + "\\" + fileName11);
            string lujing = info1.DirectoryName + "\\" + fileName11;
            System.Diagnostics.Process.Start(lujing);
        }

        private void textBox_shuliang_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            if ((int)e.KeyChar == 46)                           //小数点

            {
                if (textBox_shuliang_1.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox_shuliang_1.Text, out oldf);

                    b2 = float.TryParse(textBox_shuliang_1.Text + e.KeyChar.ToString(), out f);

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
        private void textBox_shuliang_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox_shuliang_2.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox_shuliang_2.Text, out oldf);
                    b2 = float.TryParse(textBox_shuliang_2.Text + e.KeyChar.ToString(), out f);
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

        private void textBox_shuliang_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox_shuliang_3.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox_shuliang_3.Text, out oldf);
                    b2 = float.TryParse(textBox_shuliang_3.Text + e.KeyChar.ToString(), out f);
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
        private void textBox_shuliang_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox_shuliang_4.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox_shuliang_4.Text, out oldf);
                    b2 = float.TryParse(textBox_shuliang_4.Text + e.KeyChar.ToString(), out f);
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
        private void textBox_shuliang_5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox_shuliang_5.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox_shuliang_5.Text, out oldf);
                    b2 = float.TryParse(textBox_shuliang_5.Text + e.KeyChar.ToString(), out f);
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
        private void textBox_shuliang_6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox_shuliang_6.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox_shuliang_6.Text, out oldf);
                    b2 = float.TryParse(textBox_shuliang_6.Text + e.KeyChar.ToString(), out f);
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
        private void textBox_shuliang_7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox_shuliang_7.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox_shuliang_7.Text, out oldf);
                    b2 = float.TryParse(textBox_shuliang_7.Text + e.KeyChar.ToString(), out f);
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
        private void textBox_shuliang_8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox_shuliang_8.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox_shuliang_8.Text, out oldf);
                    b2 = float.TryParse(textBox_shuliang_8.Text + e.KeyChar.ToString(), out f);
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
        private void textBox_shuliang_9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox_shuliang_9.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox_shuliang_9.Text, out oldf);
                    b2 = float.TryParse(textBox_shuliang_9.Text + e.KeyChar.ToString(), out f);
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
        private void textBox_shuliang_10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox_shuliang_10.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox_shuliang_10.Text, out oldf);
                    b2 = float.TryParse(textBox_shuliang_10.Text + e.KeyChar.ToString(), out f);
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
        private void textBox_shuliang_11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (textBox_shuliang_11.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox_shuliang_11.Text, out oldf);

                    b2 = float.TryParse(textBox_shuliang_11.Text + e.KeyChar.ToString(), out f);

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

        private void textBox_shuliang_12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (textBox_shuliang_12.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox_shuliang_12.Text, out oldf);

                    b2 = float.TryParse(textBox_shuliang_12.Text + e.KeyChar.ToString(), out f);

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

        private void textBox_shuliang_13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (textBox_shuliang_13.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox_shuliang_13.Text, out oldf);

                    b2 = float.TryParse(textBox_shuliang_13.Text + e.KeyChar.ToString(), out f);

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

        private void textBox_shuliang_14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (textBox_shuliang_14.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox_shuliang_14.Text, out oldf);

                    b2 = float.TryParse(textBox_shuliang_14.Text + e.KeyChar.ToString(), out f);

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

        private void textBox_shuliang_15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (textBox_shuliang_15.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox_shuliang_15.Text, out oldf);

                    b2 = float.TryParse(textBox_shuliang_15.Text + e.KeyChar.ToString(), out f);

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

        private void textBox_shuliang_16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (textBox_shuliang_16.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox_shuliang_16.Text, out oldf);

                    b2 = float.TryParse(textBox_shuliang_16.Text + e.KeyChar.ToString(), out f);

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

        private void textBox_shuliang_17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (textBox_shuliang_17.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox_shuliang_17.Text, out oldf);

                    b2 = float.TryParse(textBox_shuliang_17.Text + e.KeyChar.ToString(), out f);

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

        private void textBox_shuliang_18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (textBox_shuliang_18.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox_shuliang_18.Text, out oldf);

                    b2 = float.TryParse(textBox_shuliang_18.Text + e.KeyChar.ToString(), out f);

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

        private void textBox_shuliang_19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (textBox_shuliang_19.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox_shuliang_19.Text, out oldf);

                    b2 = float.TryParse(textBox_shuliang_19.Text + e.KeyChar.ToString(), out f);

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

        private void textBox_shuliang_20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (textBox_shuliang_20.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox_shuliang_20.Text, out oldf);

                    b2 = float.TryParse(textBox_shuliang_20.Text + e.KeyChar.ToString(), out f);

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
        private void txt_gx1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx1.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx1.Text, out oldf);

                    b2 = float.TryParse(txt_gx1.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx2.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx2.Text, out oldf);

                    b2 = float.TryParse(txt_gx2.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx3.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx3.Text, out oldf);

                    b2 = float.TryParse(txt_gx3.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx4.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx4.Text, out oldf);

                    b2 = float.TryParse(txt_gx4.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx5.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx5.Text, out oldf);

                    b2 = float.TryParse(txt_gx5.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx6.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx6.Text, out oldf);

                    b2 = float.TryParse(txt_gx6.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx7.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx7.Text, out oldf);

                    b2 = float.TryParse(txt_gx7.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx8.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx8.Text, out oldf);

                    b2 = float.TryParse(txt_gx8.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx9.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx9.Text, out oldf);

                    b2 = float.TryParse(txt_gx9.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx10.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx10.Text, out oldf);

                    b2 = float.TryParse(txt_gx10.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx11.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx11.Text, out oldf);

                    b2 = float.TryParse(txt_gx11.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx12.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx12.Text, out oldf);

                    b2 = float.TryParse(txt_gx12.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx13.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx13.Text, out oldf);

                    b2 = float.TryParse(txt_gx13.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx14.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx14.Text, out oldf);

                    b2 = float.TryParse(txt_gx14.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx15.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx15.Text, out oldf);

                    b2 = float.TryParse(txt_gx15.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx16.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx16.Text, out oldf);

                    b2 = float.TryParse(txt_gx16.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx17.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx17.Text, out oldf);

                    b2 = float.TryParse(txt_gx17.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx18.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx18.Text, out oldf);

                    b2 = float.TryParse(txt_gx18.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx19.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx19.Text, out oldf);

                    b2 = float.TryParse(txt_gx19.Text + e.KeyChar.ToString(), out f);

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

        private void txt_gx20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx20.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx20.Text, out oldf);

                    b2 = float.TryParse(txt_gx20.Text + e.KeyChar.ToString(), out f);

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

    }
}
