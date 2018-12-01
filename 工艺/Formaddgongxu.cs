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
using Aspose.Words;
using NetWorkLib.View;

namespace mujubu.工艺
{
    public partial class Formaddgongxu : Form
    {
        public string id;
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

        public Formaddgongxu(string id)
        {
            InitializeComponent();
            this.id = id;
        }
       
        private void Formaddgongxu_Load(object sender, EventArgs e)
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
            txt_xiadanriqi.Text= b[2].ToString();//模具部接单日期
            txt_gonglinghao.Text = b[1].ToString();//工作令号
            txt_jiagongshuliang.Text = b[4].ToString();
            txt_jiaohuoriqi.Text = b[3].ToString();//交货日期
            CodeReplay();


        }
        private DataTable xin(string id)
        {
            DataTable dt = new DataTable();


            string s1 = "select 项目名称,工作令号,模具部接单日期,模具部交货日期,实际采购数量 from tb_caigouliaodan where id='" + id + "'";
            dt = SQLhelp.GetDataTable(s1, CommandType.Text);
            return dt;
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
       

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select 附件类型,附件名称 from tb_caigouliaodan where  id='" + id + "'";
            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            if (dt1.Rows[0]["附件类型"].ToString() == "" && dt1.Rows[0]["附件名称"].ToString() == "")
            {
                MessageBox.Show("没有图纸");
            }
           else
            {
                string sql2 = "select 附件 from tb_caigouliaodan where  id='" + id + "'";
                byte[] mypdffile = null;
                mypdffile = SQLhelp.duqu(sql2, CommandType.Text);
                string aaaa = System.Environment.CurrentDirectory;
                lujing = aaaa + "\\" + dt1.Rows[0]["附件名称"].ToString() + "." + dt1.Rows[0]["附件类型"].ToString();
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();

            }
            txt_lujin.Text = lujing;

            if (btn_jisuan != null && !btn_jisuan.IsDisposed)
            {
                this.btn_jisuan.Navigate(txt_lujin.Text);
            }
        }
        private void CodeReplay()
        {
            string b = addmingcheng;//名称
            string d = txt_gonglinghao.Text;//工作令号
            string f = txt_jiagong.Text;//项目名称

            //string dataCode = f + "\n" + a + "\n" + b + "\n" + c + "\n" + d + "\n";
            string dataCode = f + "\n" + d + "\n"  + b + "\n";
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
            string uid = System.Guid.NewGuid().ToString("N");
            string 编制 = yonghu + DateTime.Now;
            string timeNow = DateTime.Now.ToString();

            #region 价格与数量的提示
            //if (comboBox1.Text != "")
            //{
            //    if (textBox_shuliang_1.Text.Trim() == "" || txt_gx1.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第1道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox2.Text != "")
            //{

            //    if (textBox_shuliang_2.Text.Trim() == "" || txt_gx2.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第2道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox3.Text != "")
            //{

            //    if (textBox_shuliang_3.Text.Trim() == "" || txt_gx3.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第3道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox4.Text != "")
            //{

            //    if (textBox_shuliang_4.Text.Trim() == "" || txt_gx4.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第4道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox5.Text != "")
            //{

            //    if (textBox_shuliang_5.Text.Trim() == "" || txt_gx5.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第5道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox6.Text != "")
            //{

            //    if (textBox_shuliang_6.Text.Trim() == "" || txt_gx6.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第6道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox7.Text != "")
            //{

            //    if (textBox_shuliang_7.Text.Trim() == "" || txt_gx7.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第7道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox8.Text != "")
            //{

            //    if (textBox_shuliang_8.Text.Trim() == "" || txt_gx8.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第8道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox9.Text != "")
            //{

            //    if (textBox_shuliang_9.Text.Trim() == "" || txt_gx9.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第9道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox10.Text != "")
            //{

            //    if (textBox_shuliang_10.Text.Trim() == "" || txt_gx10.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第10道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox11.Text != "")
            //{

            //    if (textBox_shuliang_11.Text.Trim() == "" || txt_gx11.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第11道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox12.Text != "")
            //{

            //    if (textBox_shuliang_12.Text.Trim() == "" || txt_gx12.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第12道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox13.Text != "")
            //{

            //    if (textBox_shuliang_13.Text.Trim() == "" || txt_gx13.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第13道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox14.Text != "")
            //{

            //    if (textBox_shuliang_14.Text.Trim() == "" || txt_gx14.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第14道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox15.Text != "")
            //{

            //    if (textBox_shuliang_15.Text.Trim() == "" || txt_gx15.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第15道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox16.Text != "")
            //{

            //    if (textBox_shuliang_16.Text.Trim() == "" || txt_gx16.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第16道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox17.Text != "")
            //{

            //    if (textBox_shuliang_17.Text.Trim() == "" || txt_gx17.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第17道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox18.Text != "")
            //{

            //    if (textBox_shuliang_18.Text.Trim() == "" || txt_gx18.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第18道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox19.Text != "")
            //{

            //    if (textBox_shuliang_19.Text.Trim() == "" || txt_gx19.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第19道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            //if (comboBox20.Text != "")
            //{

            //    if (textBox_shuliang_20.Text.Trim() == "" || txt_gx20.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请检查第20道工序数量和价格是否未填写！", "提示");
            //        return;
            //    }
            //}
            #endregion

            //if (dateTimePicker1.Text == dateTimePicker2.Text)
            //{
            //    MessageBox.Show("请检查第一道工序排产时间!", "提示");
            //    return;
            //}

            if (cailiaoguige1.Text.Trim() == "" || zhongliang1.Text.Trim() == "")
            {
                MessageBox.Show("请输入自制件的材料以及重量！", "提示");
                return;
            }

            if (cailiaoguige1.Text.Trim() == "")
            {
                cailiaoguige1.Text = "无";
                zhongliang1.Text = "0";
            }
            if (cailiaoguige2.Text.Trim() == "")
            {
                cailiaoguige2.Text = "无";
                zhongliang2.Text = "0";
            }
            if (cailiaoguige3.Text.Trim() == "")
            {
                cailiaoguige3.Text = "无";
                zhongliang3.Text = "0";
            }
            if (cailiaoguige4.Text.Trim() == "")
            {
                cailiaoguige4.Text = "无";
                zhongliang4.Text = "0";
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
                for (int i = 1; i <= 20; i++) 
                {
                    string 工序名称 = (this.Controls["panel1"].Controls["comboBox" + i.ToString()] as ComboBox).Text;
                    string 数量 = (this.Controls["panel1"].Controls["textBox_shuliang_" + i.ToString()] as TextBox).Text;
                    string 材料 = "";
                    string 重量 = "";

                    string 设备名称 = (this.Controls["panel1"].Controls["shebei" + i.ToString()] as ComboBox).Text;

                    if (i <= 4)
                    {
                        材料 = (this.Controls["groupBox7"].Controls["cailiaoguige" + i.ToString()] as TextBox).Text;
                        重量 = (this.Controls["groupBox7"].Controls["zhongliang" + i.ToString()] as TextBox).Text;
                    }
                    if(i > 4 && i <= 20)
                    {
                        材料 = "无";
                        重量 = "0";
                    }


                    if (工序名称 != "")
                    {
                        string 工序内容 = (this.Controls["panel1"].Controls["richTextBox" + i.ToString()]).Text;
                        string sql1 = "insert into tb_gongxu_manage(零件id,工序名称,工序内容,加工数量,顺序,材料,重量,编写时间) values('" + 零件id + "','" + 工序名称 + "','" + 工序内容 + "','" + 数量 + "','" + i + "','" + 材料+ "','"+ 重量 + "','"+ timeNow+"')";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                    }

                    //if (设备名称 != "")
                    //{
                    //    string 时间1 = (this.Controls["panel1"].Controls["dateTimePicker" + (2 * i - 1).ToString()]).Text;
                    //    string 时间2 = (this.Controls["panel1"].Controls["dateTimePicker" + (2 * i).ToString()]).Text;

                    //    string sqlstr1 = "insert into tb_mujubu_paichan(序号,图号,零件名称,工序名称,工序顺序,数量,工序设备,设定开始时间,设定结束时间,工艺制定时间) values('" + id + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + 工序名称 + "','" + i + "','" + 数量 + "','" + 设备名称 + "','" + 时间1 + "','" + 时间2 + "','" + timeNow + "')";
                    //    SQLhelp.ExecuteScalar(sqlstr1, CommandType.Text);
                    //}

                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
           
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txt_tuhao.Text =="")
            {
                MessageBox.Show("图号不能为空");
            }
            else
            {
                for (int i = 0; i < 20; i++)
                {
                    int j = i + 1;
                    (this.Controls["panel1"].Controls["comboBox" + j.ToString()] as ComboBox).Text = "";
                    (this.Controls["panel1"].Controls["richTextBox" + j.ToString()]).Text ="";
                    //(this.Controls["panel1"].Controls["textBox_shuliang_" + j.ToString()] as ComboBox).Text = "";
                    //(this.Controls["panel1"].Controls["txt_gx" + j.ToString()]).Text = "";
                }

                string 图号 = txt_tuhao.Text;
                string sql = "select * from tb_mujubu_lingjian where 图号='"+图号+"'";
                DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
                if (dt1.Rows.Count==0)
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



            //string strmingcheng = txt_mingcheng.Text;
            //if (strmingcheng.Contains("+"))
            //{
            //    strmingcheng = strmingcheng.Replace("+", "-");
            //}
            //if (strmingcheng.Contains("*"))
            //{
            //    strmingcheng = strmingcheng.Replace("*", "-");
            //}

            string docName = "aa.doc";

            //if (docName.Contains("\t"))
            //{
            //    docName = docName.Replace("\t", "");
            //}
            //FileInfo info1 = new FileInfo(Application.StartupPath + "\\" + docName);
            FileInfo info1 = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + docName);
            string fileName11 = info1.Name.ToString();

            doc.Save(info1.DirectoryName + "\\" + fileName11);
            string lujing = info1.DirectoryName + "\\" + fileName11;
            System.Diagnostics.Process.Start(lujing);
        }
        private void button5_Click(object sender, EventArgs e)
        {
          

            cailiaozhongliang1 form = new cailiaozhongliang1();
            form.gx1 = comboBox1.Text.Trim();
            form.gx2 = comboBox2.Text.Trim();
            form.gx3 = comboBox3.Text.Trim();
            form.gx4 = comboBox4.Text.Trim();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                cailiaoguige1.Text = form.cailiao1;
                zhongliang1.Text = form.zhongliang1;
                cailiaoguige2.Text = form.cailiao2;
                zhongliang2.Text = form.zhongliang2;
                cailiaoguige3.Text = form.cailiao3;
                zhongliang3.Text = form.zhongliang3;
                cailiaoguige4.Text = form.cailiao4;
                zhongliang4.Text = form.zhongliang4;
            }
        }

        private void textBox_shuliang_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

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

        private void shuaxin()
        {
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            dateTimePicker3.Text = "";
            dateTimePicker4.Text = "";
            dateTimePicker5.Text = "";
            dateTimePicker6.Text = "";
            dateTimePicker7.Text = "";
            dateTimePicker8.Text = "";
            dateTimePicker9.Text = "";
            dateTimePicker10.Text = "";
            dateTimePicker11.Text = "";
            dateTimePicker12.Text = "";
            dateTimePicker13.Text = "";
            dateTimePicker14.Text = "";
            dateTimePicker15.Text = "";
            dateTimePicker16.Text = "";
            dateTimePicker17.Text = "";
            dateTimePicker18.Text = "";
            dateTimePicker19.Text = "";
            dateTimePicker20.Text = "";
            dateTimePicker21.Text = "";
            dateTimePicker22.Text = "";
            dateTimePicker23.Text = "";
            dateTimePicker24.Text = "";
            dateTimePicker25.Text = "";
            dateTimePicker26.Text = "";
            dateTimePicker27.Text = "";
            dateTimePicker28.Text = "";
            dateTimePicker29.Text = "";
            dateTimePicker30.Text = "";
            dateTimePicker31.Text = "";
            dateTimePicker32.Text = "";
            dateTimePicker33.Text = "";
            dateTimePicker34.Text = "";
            dateTimePicker35.Text = "";
            dateTimePicker36.Text = "";
            dateTimePicker37.Text = "";
            dateTimePicker38.Text = "";
            dateTimePicker39.Text = "";
            //dateTimePicker40.Text = "";
            //dateTimePicker41.Text = "";
            //dateTimePicker42.Text = "";
            //dateTimePicker43.Text = "";
            //dateTimePicker44.Text = "";
            //dateTimePicker45.Text = "";
            //dateTimePicker46.Text = "";
            //dateTimePicker47.Text = "";
            //dateTimePicker48.Text = "";
            //dateTimePicker49.Text = "";
            //dateTimePicker50.Text = "";

        }

        /// <summary>
        /// 返回设备的类型--数控与非数控
        /// </summary>
        /// <param name="shebei"></param>
        /// <returns></returns>
        private string panduanshebi(string shebei)
        {
            string sqlstr = "select identification from tb_mujubu_shebei where 设备名='" + shebei + "'";//查询设备对应的是否为数控设备
            string retstr = Convert.ToString(SQLhelp.ExecuteScalar(sqlstr, CommandType.Text));

            return retstr;
        }


        /// <summary>
        /// 数控设备排产----24小时制
        /// </summary>
        /// <param name="time1time"></param>
        /// <param name="time1date1"></param>
        /// <param name="shebei"></param>
        /// <param name="jiage"></param>
        /// <param name="shuliang"></param>
        /// <param name="picker1"></param>
        /// <param name="picker2"></param>
        private void paichan1(string time1time, string time1date1, string shebei, string jiage, string shuliang, DateTimePicker picker1, DateTimePicker picker2)
        {
            DateTime time1 = DateTime.Now;//现在的当前时间（日期+时分秒）

            //当前时分秒--time1time
            //当前时间日期---time1date1

            string sql1 = "select 设定开始时间 from tb_mujubu_paichan where 工序设备='" + shebei + "'";
            string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            #region 设备空闲中

            if (ret1 == "")//设备空闲中的时候，根据前面的datetimepicker的value值算
            {
                //算总的工时
                double price = Convert.ToDouble(jiage);
                price = price * (Convert.ToInt32(shuliang));
                double t = (double)price / 27;
                double flag = t / 21.5;
                int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);
                //DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);
                //if(time >= time1)
                //{
                //    picker1.Value = time;
                //    picker2.Value = time.AddHours(t);
                //}
                //if(time1 >= time)
                //{
                //    picker1.Value = time1;
                //    picker2.Value = time1.AddHours(t);
                //}

                //中午休息时间：12:00-13:00  -----4.5
                //下午休息     17:30-18:00   ----5.5
                //午夜休息     23:30-00:30   ----

                //当前设置工序的时间 < 12:00:00
                int ta1 = shijian2.CompareTo(time1time);

                if (ta1 == 1)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30


                    TimeSpan ta2 = strtimeshangwu - strtime;//上午加工的时间
                    if (t >= ta2.TotalHours)//上午没有加工完成
                    {
                        double t1 = t - 21.5 * at - ta2.TotalHours;
                        if (t1 > 0 && t1 <= 4.5)//下午加工完成不了
                        {
                            picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);
                        }

                        if (4.5 < t1 && t1 <= 10)//午夜完成
                        {
                            picker2.Value = strtimewuye.AddDays(at).AddHours(t1 - 4.5);
                        }
                        if (10 < t1 && t1 <= 21.5)//第二天上午完成
                        {
                            picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t1 - 10);
                        }
                    }
                    else
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t);
                    }
                }

                //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                int ta3 = time1time.CompareTo(shijian2);
                int ta4 = shijian3.CompareTo(time1time);

                if (ta4 == 1 && ta3 == 1)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    picker1.Value = Convert.ToDateTime(strtimexiawu);

                    if (0 < t - 21.5 * at && t - 21.5 * at <= 4.5)//下午完成
                    {
                        picker2.Value = strtimexiawu.AddDays(at).AddHours(t - 21.5 * at);
                    }
                    if (4.5 < t - 21.5 * at && t - 21.5 * at <= 10)//午夜完成
                    {
                        picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - 4.5);
                    }
                    if (10 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天完成
                    {
                        picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 10);
                    }
                }

                //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                int ta5 = time1time.CompareTo(shijian3);
                int ta6 = shijian4.CompareTo(time1time);

                if (ta5 == 1 && ta6 == 1)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                    DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    picker1.Value = strtime;
                    TimeSpan t1 = strtime1 - strtime;//下午加工的时间
                    if (t - 21.5 * at >= t1.TotalHours)//下午没有加工完成
                    {
                        if ((t - 21.5 * at - t1.TotalHours) <= 5.5)//午夜之前可以完成
                        {
                            picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - t1.TotalHours);
                        }
                        if (5.5 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 17)//第二天上午完成
                        {
                            picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 5.5);
                        }
                        if (17 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 21.5)//第二天下午完成
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 17);
                        }
                    }
                    else//下午加工完成
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 21.5 * at);
                    }

                }

                //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                int ta7 = time1time.CompareTo(shijian4);
                int ta8 = shijian5.CompareTo(time1time);

                if (ta7 == 1 && ta8 == 1)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                    DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    picker1.Value = strtimewuye;
                    if (0 < t - 21.5 * at && t - 21.5 * at <= 5.5)//午夜前完成
                    {
                        picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at);
                    }
                    if (5.5 < t - 21.5 * at && t - 21.5 * at <= 17)//第二天上午完成
                    {
                        picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 5.5);
                    }
                    if (17 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天下午完成
                    {
                        picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - 17);
                    }
                }

                //当前设置工序的时间 18:00:00< 时间 < 
                int ta9 = time1time.CompareTo(shijian5);
                if (ta9 == 1)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                    DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + shijian7);//日期+23:30

                    picker1.Value = strtime;
                    TimeSpan t1 = strtime2 - strtime;//午夜加工的时间
                    double tsheng = t - 21.5 * at - t1.TotalHours;
                    if (tsheng >= 0)
                    {
                        if (tsheng <= 11.5)
                        {
                            picker2.Value = strtimediertian.AddDays(at + 1).AddHours(tsheng);
                        }
                        if (11.5 < tsheng && tsheng <= 16)
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(tsheng - 11.5);
                        }
                        if (16 < tsheng && tsheng <= 21.5)
                        {
                            picker2.Value = strtimewuye.AddDays(at + 1).AddHours(tsheng - 16);
                        }
                    }
                    else
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 21.5 * at);
                    }
                }

              

            }

            #endregion

            #region 设备不空闲
            else
            {
                string sql2 = "select max(设定开始时间) from tb_mujubu_paichan where 工序设备='" + shebei + "'";//查询该设备的最大设定的开始时间
                string ret2 = Convert.ToString(SQLhelp.ExecuteScalar(sql2, CommandType.Text));

                string sql3 = "select 设定结束时间 from tb_mujubu_paichan where 工序设备='" + shebei + "' and 设定开始时间='" + ret2 + "'";//最大的设定开始时间对应的结束事假，结束时间就是当前时间
                DateTime ret3 = Convert.ToDateTime(SQLhelp.ExecuteScalar(sql3, CommandType.Text));
                //ret3是最后一个设定结束时间

                if (ret3 < time1)//设备的任务都完成了，最后一个设定结束时间小于现在的时间---(空闲中)
                {

                    DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);

                    //算总的工时
                    double price = Convert.ToDouble(jiage);
                    price = price * (Convert.ToInt32(shuliang));
                    double t = (double)price / 27;
                    double flag = t / 21.5;
                    int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);


                    //当前设置工序的时间 < 12:00:00
                    int ta1 = shijian2.CompareTo(time1time);

                    if (ta1 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30


                        TimeSpan ta2 = strtimeshangwu - strtime;//上午加工的时间
                        if (t >= ta2.TotalHours)//上午没有加工完成
                        {
                            double t1 = t - 21.5 * at - ta2.TotalHours;
                            if (t1 > 0 && t1 <= 4.5)//下午加工完成不了
                            {
                                picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);
                            }

                            if (4.5 < t1 && t1 <= 10)//午夜完成
                            {
                                picker2.Value = strtimewuye.AddDays(at).AddHours(t1 - 4.5);
                            }
                            if (10 < t1 && t1 <= 21.5)//第二天上午完成
                            {
                                picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t1 - 10);
                            }
                        }
                        else
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t);
                        }
                    }

                    //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                    int ta3 = time1time.CompareTo(shijian2);
                    int ta4 = shijian3.CompareTo(time1time);

                    if (ta4 == 1 && ta3 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        picker1.Value = Convert.ToDateTime(strtimexiawu);

                        if (0 < t - 21.5 * at && t - 21.5 * at <= 4.5)//下午完成
                        {
                            picker2.Value = strtimexiawu.AddDays(at).AddHours(t - 21.5 * at);
                        }
                        if (4.5 < t - 21.5 * at && t - 21.5 * at <= 10)//午夜完成
                        {
                            picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - 4.5);
                        }
                        if (10 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天完成
                        {
                            picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 10);
                        }
                    }

                    //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                    int ta5 = time1time.CompareTo(shijian3);
                    int ta6 = shijian4.CompareTo(time1time);

                    if (ta5 == 1 && ta6 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        picker1.Value = strtime;
                        TimeSpan t1 = strtime1 - strtime;//下午加工的时间
                        if (t - 21.5 * at >= t1.TotalHours)//下午没有加工完成
                        {
                            if ((t - 21.5 * at - t1.TotalHours) <= 5.5)//午夜之前可以完成
                            {
                                picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - t1.TotalHours);
                            }
                            if (5.5 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 17)//第二天上午完成
                            {
                                picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 5.5);
                            }
                            if (17 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 21.5)//第二天下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 17);
                            }
                        }
                        else//下午加工完成
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 21.5 * at);
                        }

                    }

                    //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                    int ta7 = time1time.CompareTo(shijian4);
                    int ta8 = shijian5.CompareTo(time1time);

                    if (ta7 == 1 && ta8 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        picker1.Value = strtimewuye;
                        if (0 < t - 21.5 * at && t - 21.5 * at <= 5.5)//午夜前完成
                        {
                            picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at);
                        }
                        if (5.5 < t - 21.5 * at && t - 21.5 * at <= 17)//第二天上午完成
                        {
                            picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 5.5);
                        }
                        if (17 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天下午完成
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - 17);
                        }
                    }

                    //当前设置工序的时间 18:00:00< 时间 < 
                    int ta9 = time1time.CompareTo(shijian5);
                    if (ta9 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + shijian7);//日期+23:30

                        picker1.Value = strtime;
                        TimeSpan t1 = strtime2 - strtime;//午夜加工的时间
                        double tsheng = t - 21.5 * at - t1.TotalHours;
                        if (tsheng >= 0)
                        {
                            if (tsheng <= 11.5)
                            {
                                picker2.Value = strtimediertian.AddDays(at + 1).AddHours(tsheng);
                            }
                            if (11.5 < tsheng && tsheng <= 16)
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(tsheng - 11.5);
                            }
                            if (16 < tsheng && tsheng <= 21.5)
                            {
                                picker2.Value = strtimewuye.AddDays(at + 1).AddHours(tsheng - 16);
                            }
                        }
                        else
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 21.5 * at);
                        }
                    }

                   


                }
                else//设定的结束时间大于现在的时间（排产排到后面）------ret3 > time1(设定的结束时间大于当前时间)
                {
                    DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);

                    string ret3date = ret3.ToString("yyyy/MM/dd");
                    //算总的工时
                    double price = Convert.ToDouble(jiage);
                    price = price * (Convert.ToInt32(shuliang));
                    double t = (double)price / 27;
                    double flag = t / 21.5;
                    int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                    if (ret3 >= time)//---------ret3 > datetimepicker(用ret3date1和ret3time)
                    {

                        //当前设置工序的时间 < 12:00:00
                        int ta1 = shijian2.CompareTo(time1time);

                        if (ta1 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            picker1.Value = Convert.ToDateTime(ret3);
                            DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30


                            TimeSpan ta2 = strtimeshangwu - ret3;//上午加工的时间
                            if (t >= ta2.TotalHours)//上午没有加工完成
                            {
                                double t1 = t - 21.5 * at - ta2.TotalHours;
                                if (t1 > 0 && t1 <= 4.5)//下午加工完成不了
                                {
                                    picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);
                                }

                                if (4.5 < t1 && t1 <= 10)//午夜完成
                                {
                                    picker2.Value = strtimewuye.AddDays(at).AddHours(t1 - 4.5);
                                }
                                if (10 < t1 && t1 <= 21.5)//第二天上午完成
                                {
                                    picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t1 - 10);
                                }
                            }
                            else
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t);
                            }
                        }

                        //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                        int ta3 = time1time.CompareTo(shijian2);
                        int ta4 = shijian3.CompareTo(time1time);

                        if (ta4 == 1 && ta3 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                            picker1.Value = Convert.ToDateTime(strtimexiawu);

                            if (0 < t - 21.5 * at && t - 21.5 * at <= 4.5)//下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at).AddHours(t - 21.5 * at);
                            }
                            if (4.5 < t - 21.5 * at && t - 21.5 * at <= 10)//午夜完成
                            {
                                picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - 4.5);
                            }
                            if (10 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天完成
                            {
                                picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 10);
                            }
                        }

                        //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                        int ta5 = time1time.CompareTo(shijian3);
                        int ta6 = shijian4.CompareTo(time1time);

                        if (ta5 == 1 && ta6 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian4);//当前日期+17:30
                            DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                            picker1.Value = ret3;
                            TimeSpan t1 = strtime1 - ret3;//下午加工的时间
                            if (t - 21.5 * at >= t1.TotalHours)//下午没有加工完成
                            {
                                if ((t - 21.5 * at - t1.TotalHours) <= 5.5)//午夜之前可以完成
                                {
                                    picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - t1.TotalHours);
                                }
                                if (5.5 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 17)//第二天上午完成
                                {
                                    picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 5.5);
                                }
                                if (17 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 21.5)//第二天下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 17);
                                }
                            }
                            else//下午加工完成
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t - 21.5 * at);
                            }

                        }

                        //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                        int ta7 = time1time.CompareTo(shijian4);
                        int ta8 = shijian5.CompareTo(time1time);

                        if (ta7 == 1 && ta8 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian4);//当前日期+17:30
                            DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                            picker1.Value = strtimewuye;
                            if (0 < t - 21.5 * at && t - 21.5 * at <= 5.5)//午夜前完成
                            {
                                picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at);
                            }
                            if (5.5 < t - 21.5 * at && t - 21.5 * at <= 17)//第二天上午完成
                            {
                                picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 5.5);
                            }
                            if (17 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - 17);
                            }
                        }

                        //当前设置工序的时间 18:00:00< 时间 < 
                        int ta9 = time1time.CompareTo(shijian5);
                        if (ta9 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian4);//当前日期+17:30
                            DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                            DateTime strtime2 = Convert.ToDateTime(ret3date + " " + shijian7);//日期+23:30

                            picker1.Value = ret3;
                            TimeSpan t1 = strtime2 - ret3;//午夜加工的时间
                            double tsheng = t - 21.5 * at - t1.TotalHours;
                            if (tsheng >= 0)
                            {
                                if (tsheng <= 11.5)
                                {
                                    picker2.Value = strtimediertian.AddDays(at + 1).AddHours(tsheng);
                                }
                                if (11.5 < tsheng && tsheng <= 16)
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(tsheng - 11.5);
                                }
                                if (16 < tsheng && tsheng <= 21.5)
                                {
                                    picker2.Value = strtimewuye.AddDays(at + 1).AddHours(tsheng - 16);
                                }
                            }
                            else
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t - 21.5 * at);
                            }
                        }

             
                    }
                    else//-----------------ret3 < datetimepicker(用time1date和time1time)----time
                    {

                        //当前设置工序的时间 < 12:00:00
                        int ta1 = shijian2.CompareTo(time1time);

                        if (ta1 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            picker1.Value = Convert.ToDateTime(time);
                            DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30


                            TimeSpan ta2 = strtimeshangwu - time;//上午加工的时间
                            if (t >= ta2.TotalHours)//上午没有加工完成
                            {
                                double t1 = t - 21.5 * at - ta2.TotalHours;
                                if (t1 > 0 && t1 <= 4.5)//下午加工完成不了
                                {
                                    picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);
                                }

                                if (4.5 < t1 && t1 <= 10)//午夜完成
                                {
                                    picker2.Value = strtimewuye.AddDays(at).AddHours(t1 - 4.5);
                                }
                                if (10 < t1 && t1 <= 21.5)//第二天上午完成
                                {
                                    picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t1 - 10);
                                }
                            }
                            else
                            {
                                picker2.Value = time.AddDays(at).AddHours(t);
                            }
                        }

                        //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                        int ta3 = time1time.CompareTo(shijian2);
                        int ta4 = shijian3.CompareTo(time1time);

                        if (ta4 == 1 && ta3 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                            picker1.Value = Convert.ToDateTime(strtimexiawu);

                            if (0 < t - 21.5 * at && t - 21.5 * at <= 4.5)//下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at).AddHours(t - 21.5 * at);
                            }
                            if (4.5 < t - 21.5 * at && t - 21.5 * at <= 10)//午夜完成
                            {
                                picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - 4.5);
                            }
                            if (10 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天完成
                            {
                                picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 10);
                            }
                        }

                        //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                        int ta5 = time1time.CompareTo(shijian3);
                        int ta6 = shijian4.CompareTo(time1time);

                        if (ta5 == 1 && ta6 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                            DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                            picker1.Value = time;
                            TimeSpan t1 = strtime1 - time;//下午加工的时间
                            if (t - 21.5 * at >= t1.TotalHours)//下午没有加工完成
                            {
                                if ((t - 21.5 * at - t1.TotalHours) <= 5.5)//午夜之前可以完成
                                {
                                    picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - t1.TotalHours);
                                }
                                if (5.5 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 17)//第二天上午完成
                                {
                                    picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 5.5);
                                }
                                if (17 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 21.5)//第二天下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 17);
                                }
                            }
                            else//下午加工完成
                            {
                                picker2.Value = time.AddDays(at).AddHours(t - 21.5 * at);
                            }

                        }

                        //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                        int ta7 = time1time.CompareTo(shijian4);
                        int ta8 = shijian5.CompareTo(time1time);

                        if (ta7 == 1 && ta8 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                            DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                            picker1.Value = strtimewuye;
                            if (0 < t - 21.5 * at && t - 21.5 * at <= 5.5)//午夜前完成
                            {
                                picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at);
                            }
                            if (5.5 < t - 21.5 * at && t - 21.5 * at <= 17)//第二天上午完成
                            {
                                picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 5.5);
                            }
                            if (17 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - 17);
                            }
                        }

                        //当前设置工序的时间 18:00:00< 时间 < 
                        int ta9 = time1time.CompareTo(shijian5);
                        if (ta9 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                            DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                            DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + shijian7);//日期+23:30

                            picker1.Value = time;
                            TimeSpan t1 = strtime2 - time;//午夜加工的时间
                            double tsheng = t - 21.5 * at - t1.TotalHours;
                            if (tsheng >= 0)
                            {
                                if (tsheng <= 11.5)
                                {
                                    picker2.Value = strtimediertian.AddDays(at + 1).AddHours(tsheng);
                                }
                                if (11.5 < tsheng && tsheng <= 16)
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(tsheng - 11.5);
                                }
                                if (16 < tsheng && tsheng <= 21.5)
                                {
                                    picker2.Value = strtimewuye.AddDays(at + 1).AddHours(tsheng - 16);
                                }
                            }
                            else
                            {
                                picker2.Value = time.AddDays(at).AddHours(t - 21.5 * at);
                            }
                        }

    
                    }

                }

            }

            #endregion
        }

        /// <summary>
        /// 非数控设备排产----8小时制
        /// </summary>
        /// <param name="time1time"></param>
        /// <param name="time1date1"></param>
        /// <param name="shebei"></param>
        /// <param name="jiage"></param>
        /// <param name="shuliang"></param>
        /// <param name="picker1"></param>
        /// <param name="picker2"></param>
        private void paichan(string time1time, string time1date1, string shebei, string jiage, string shuliang, DateTimePicker picker1, DateTimePicker picker2)
        {

            //DateTime time1 = DateTime.Now;//现在的当前时间（日期+时分秒）

            //string sql1 = "select 设定开始时间 from db_gongxu1 where 工序设备='" + shebei + "'";
            //string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            //#region 设备空闲中
            //if (ret1 == "")//现在这个设备空闲中
            //{
            //    //算总的工时
            //    double price = Convert.ToDouble(jiage);
            //    price = price * (Convert.ToInt32(shuliang));
            //    double t = (double)price / 27;
            //    double aa = t / 8.5;
            //    int a = Convert.ToInt32(aa.ToString().Split(char.Parse("."))[0]);

            //    //总的一天的工时
            //    TimeSpan thourshangwu = T2 - T1;//上午的时间差
            //    TimeSpan thourxiawu = T4 - T3;//下午的时间差
            //    //double gongshi = thourshangwu.TotalHours + thourxiawu.TotalHours;
            //    //gongshi = Math.Round(gongshi, 2);


            //    int ta1 = Time1.CompareTo(time1time);

            //    if (ta1 == 1)//当前时间小于8:00 (Time1>time1time)
            //    {
            //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
            //        picker1.Value = Convert.ToDateTime(strtime);
            //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

            //        int ta2 = strtime.AddDays(a).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time2);

            //        if (ta2 == 1 || ta2 == 0)//时间大于11:20 （第三天下午完成）
            //        {

            //            double t1 = t - 8.5 * a - thourshangwu.TotalHours;//剩余加工时间下午完成
            //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
            //            {
            //                picker2.Value = strtimexiawu.AddDays(a + 1).AddHours(t1);
            //            }
            //        }
            //        else//时间小于11:20（第三天早上完成）
            //        {
            //            picker2.Value = strtime.AddDays(a + 1).AddHours(t - 8.5 * a);
            //        }

            //    }

            //    int ta3 = time1time.CompareTo(Time1);
            //    int ta4 = Time2.CompareTo(time1time);
            //    if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
            //    {
            //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
            //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
            //        picker1.Value = Convert.ToDateTime(strtime);
            //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

            //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

            //        int ta5 = strtime.AddDays(a + 1).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time2);

            //        if (ta5 == 1 || ta5 == 0)//时间大于11:20
            //        {
            //            TimeSpan tcha = Time22 - strtime;
            //            double t1 = t - 8.5 * a - tcha.TotalHours;//剩余加工的时间
            //            if (t1 <= thourxiawu.TotalHours)//第三天下午可以加工完
            //            {
            //                picker2.Value = strtimexiawu.AddDays(a - 1).AddHours(t1);
            //            }
            //            else//大于下午的时间差 && 小于第二天的上午的时间差
            //            {
            //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
            //                picker2.Value = strtime1.AddDays(a + 1).AddHours(tsheng);
            //            }
            //        }
            //        else//16.几 小时的工时
            //        {
            //            picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
            //        }
            //    }

            //    int ta6 = time1time.CompareTo(Time2);
            //    int ta7 = Time3.CompareTo(time1time);

            //    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
            //    {
            //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
            //        picker1.Value = Convert.ToDateTime(strtime);
            //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

            //        int ta8 = strtime.AddDays(a + 1).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time4);

            //        if (ta8 == 1 || ta8 == 0)//时间大于17:30
            //        {

            //            double t1 = t - 8.5 * a - thourxiawu.TotalHours;
            //            if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于第三天上午的时间差
            //            {
            //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
            //                picker2.Value = strtime1.AddDays(a + 1).AddHours(t1);
            //            }
            //            //大于2天小于等于3天 最多到第三天的上午结束
            //        }
            //        else//时间小于17:30
            //        {
            //            picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
            //        }
            //    }

            //    int ta9 = time1time.CompareTo(Time3);
            //    int ta10 = Time4.CompareTo(time1time);

            //    if (ta9 == 1 && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
            //    {
            //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
            //        picker1.Value = Convert.ToDateTime(strtime);
            //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1+ " " + Time3);//日期+12:50
            //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
            //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
            //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

            //        int ta11 = strtime.AddDays(a + 1).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time4);

            //        if (ta11 == 1 || ta11 == 0)
            //        {
            //            TimeSpan tzhi = Time44 - strtime;//下午工作的时间
            //            double ttzhi = t - 8.5 * a - tzhi.TotalHours;//剩余加工的时间
            //            if (ttzhi <= thourshangwu.TotalHours)//如果小于第三天上午的工时
            //            {
            //                picker2.Value = strtime1.AddDays(a).AddHours(ttzhi);
            //            }
            //            else//大于上午的时间
            //            {
            //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（下午完成）
            //                picker2.Value = strtime2.AddDays(a + 1).AddHours(ttzhi);
            //            }
            //        }
            //        else
            //        {
            //            picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
            //        }

            //    }

            //    int ta12 = time1time.CompareTo(Time4);

            //    if (ta12 == 1)//第二天做
            //    {
            //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
            //        picker1.Value = Convert.ToDateTime(strtime).AddDays(1);
            //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

            //        int ta13 = strtime.AddDays(a + 1).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time2);

            //        if (ta13 == 1 || ta13 == 0)//时间大于11:20
            //        {

            //            double t1 = t - 8.5 * a - thourshangwu.TotalHours;
            //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
            //            {
            //                picker2.Value = strtimexiawu.AddDays(a + 1).AddHours(t1);
            //            }
            //        }
            //        else//时间小于11:20
            //        {
            //            picker2.Value = strtime.AddDays(a + 1).AddHours(t);
            //        }
            //    }

              

            //}
            //#endregion

            //#region 设备不空闲
            //else//设备不空闲的时候
            //{
            //    string sql2 = "select max(设定开始时间) from db_gongxu1 where 工序设备='" + shebei + "'";//查询该设备的最大设定的开始时间
            //    string ret2 = Convert.ToString(SQLhelp.ExecuteScalar(sql2, CommandType.Text));

            //    string sql3 = "select 设定结束时间 from db_gongxu1 where 工序设备='" + shebei + "' and 设定开始时间='" + ret2 + "'";//最大的设定开始时间对应的结束时间，结束时间就是当前时间
            //    DateTime ret3 = Convert.ToDateTime(SQLhelp.ExecuteScalar(sql3, CommandType.Text));
            //    DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);//time:工序1是当前时间 工序2-25是前面的时间
            //    if (ret3 < time1)//设定结束时间 < 现在的时间 （最大的结束时间小于现在的时间也就是没有任务了）---空闲了
            //    {

            //        //算总的工时
            //        double price = Convert.ToDouble(jiage);
            //        price = price * (Convert.ToInt32(shuliang));
            //        double t = (double)price / 27;
            //        double flag = t / 8.5;
            //        int a = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

            //        //总的一天的工时
            //        TimeSpan thourshangwu = T2 - T1;//上午的时间差
            //        TimeSpan thourxiawu = T4 - T3;//下午的时间差
            //        //double gongshi = thourshangwu.TotalHours + thourxiawu.TotalHours;
            //        //gongshi = Math.Round(gongshi, 2);

            //        int ta1 = Time1.CompareTo(time1time);

            //        if (ta1 == 1)//当前时间小于8:00 (Time1>time1time)
            //        {
            //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
            //            picker1.Value = Convert.ToDateTime(strtime);
            //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

            //            int ta2 = strtime.AddDays(a).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time2);//与下一天的11:20比较

            //            if (ta2 == 1 || ta2 == 0)//时间大于11:20  
            //            {

            //                double t1 = t - 8.5 * a - thourshangwu.TotalHours;//第二天剩余加工的时间
            //                if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
            //                {
            //                    picker2.Value = strtimexiawu.AddDays(a).AddHours(t1);
            //                }
            //                //剩余加工的时间一定小于等于下午的工时（8<t<=16）
            //            }
            //            else//时间小于11:20
            //            {
            //                picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
            //            }

            //        }

            //        int ta3 = time1time.CompareTo(Time1);
            //        int ta4 = Time2.CompareTo(time1time);
            //        if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
            //        {
            //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
            //            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
            //            picker1.Value = Convert.ToDateTime(strtime);
            //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

            //            DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

            //            int ta5 = strtime.AddDays(a).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time2);//下一天的结束时间与11:20比较

            //            if (ta5 == 1 || ta5 == 0)//时间大于11:20
            //            {
            //                TimeSpan tcha = Time22 - strtime;
            //                double t1 = t - 8.5 * a - tcha.TotalHours;//剩余加工的时间
            //                if (t1 <= thourxiawu.TotalHours)//如果下午能够加工完成
            //                {
            //                    picker2.Value = strtimexiawu.AddDays(a).AddHours(t1);
            //                }
            //                else//大于下午的时间差 && 小于第二天的上午的时间差
            //                {
            //                    double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间(第三天上午加工完成)
            //                    picker2.Value = strtime1.AddDays(a + 1).AddHours(tsheng);
            //                }
            //            }
            //            else
            //            {
            //                picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
            //            }
            //        }

            //        int ta6 = time1time.CompareTo(Time2);
            //        int ta7 = Time3.CompareTo(time1time);

            //        if (ta6 == 1 && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
            //        {
            //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
            //            picker1.Value = Convert.ToDateTime(strtime);
            //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

            //            int ta8 = strtime.AddDays(a).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time4);//相当于工时是8.几小时

            //            if (ta8 == 1 || ta8 == 0)//时间大于17:30
            //            {

            //                double t1 = t - 8.5 * a - thourxiawu.TotalHours;//剩余的第三天上午做完（相当于第二天下午做不完）
            //                if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于等于第三天上午的时间差（8<t<=16）
            //                {
            //                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
            //                    picker2.Value = strtime1.AddDays(a + 1).AddHours(t1);
            //                }
            //            }
            //            else//时间小于17:30
            //            {
            //                picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
            //            }
            //        }

            //        int ta9 = time1time.CompareTo(Time3);
            //        int ta10 = Time4.CompareTo(time1time);

            //        if (ta9 == 1 && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
            //        {
            //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
            //            picker1.Value = Convert.ToDateTime(strtime);
            //            //DateTime strtimexiawu = Convert.ToDateTime(time1date1+ " " + Time3);//日期+12:50
            //            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
            //            DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
            //            DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

            //            string aql = strtime.AddDays(a).AddHours(t - 8.5 * a).ToString("HH:mm:ss");
            //            int ta11 = aql.CompareTo(Time4);//相当于8.5小时工时

            //            if (ta11 == 1 || ta11 == 0)//第二天下午做不完
            //            {
            //                TimeSpan tzhi = Time44 - strtime;//第二天下午工作的时间
            //                double ttzhi = t - 8.5 * a - tzhi.TotalHours;//剩余加工的时间（第三天做）
            //                if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
            //                {
            //                    picker2.Value = strtime1.AddDays(a + 1).AddHours(ttzhi);
            //                }
            //                else//大于上午的时间
            //                {
            //                    double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（第三天下午做完）
            //                    if (tttzhi <= thourxiawu.TotalHours)//小于下午加工的时间
            //                    {
            //                        picker2.Value = strtime2.AddDays(a + 1).AddHours(ttzhi);
            //                    }

            //                }
            //            }//第二天下午做完
            //            else
            //            {
            //                picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
            //            }

            //        }

            //        int ta12 = time1time.CompareTo(Time4);

            //        if (ta12 == 1)//第二天开始做、需要到第三天才完成(设置工序的时间大于17:50 -----> 即工艺员加班)
            //        {
            //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
            //            picker1.Value = Convert.ToDateTime(strtime).AddDays(1);//第二天8:00开始做
            //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

            //            int ta13 = strtime.AddDays(a + 1).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time2);

            //            if (ta13 == 1 || ta13 == 0)//时间大于11:20 //第三天下午做完
            //            {

            //                double t1 = t - 8.5 * a - thourshangwu.TotalHours;
            //                if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于等于下午的时间差
            //                {
            //                    picker2.Value = strtimexiawu.AddDays(a + 1).AddHours(t1);
            //                }
            //            }
            //            else//时间小于11:20 //第三天上午做完
            //            {
            //                picker2.Value = strtime.AddDays(a + 1).AddHours(t - 8.5 * a);
            //            }
            //        }


            //    }
            //    else//(设定结束时间 > 现在的时间（用设定结束时间算）)----将设定结束时间当做现在时间算  ret3---结束时间
            //    {
            //        //DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);//time:工序1是当前时间 工序2-25是前面的时间

            //        if (ret3 >= time)//---------ret3 > datetimepicker(用ret3date1和ret3time)
            //        {

            //            string ret3date = ret3.ToString("yyyy/MM/dd");
            //            string ret3time = ret3.ToString("HH:mm:dd");
            //            //算总的工时
            //            double price = Convert.ToDouble(jiage);
            //            price = price * (Convert.ToInt32(shuliang));
            //            double t = (double)price / 27;
            //            double flag = t / 8.5;
            //            int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

            //            //总的一天的工时
            //            TimeSpan thourshangwu = T2 - T1;//上午的时间差
            //            TimeSpan thourxiawu = T4 - T3;//下午的时间差
            //                                          //double gongshi = thourshangwu.TotalHours + thourxiawu.TotalHours;
            //                                          //gongshi = Math.Round(gongshi, 2);

            //            //结束时间---ret3范围[8:00 <= ret3 <= 11:20 && 12:50 <= ret3 <= 17:30]

            //            //8:00 <= ret3 <= 11:20
            //            int ta1 = ret3time.CompareTo(Time1);
            //            int ta11 = Time2.CompareTo(ret3time);

            //            //12:50 <= ret3 <= 17:30
            //            int ta111 = ret3time.CompareTo(Time3);
            //            int ta1111 = Time4.CompareTo(ret3time);

            //            int tb1 = Time2.CompareTo(ret3time);
            //            int tb11 = ret3time.CompareTo("12:00:00");

            //            if (tb1 == -1 && tb11 == -1)//---ret3在11:30和12：00之间
            //            {
            //                //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
            //                //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
            //                DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//日期+8:00:00
            //                DateTime strtime2 = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:30:00                                
            //                DateTime Time44 = Convert.ToDateTime(ret3date + " " + Time4);//日期 + 17:30

            //                picker1.Value = Convert.ToDateTime(strtime2);//.AddHours(0.2);
            //                int b2 = strtime2.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);

            //                if (b2 == 1 || b2 == 0)//加工时间大于下午时间差
            //                {
            //                    TimeSpan tzhi = Time44 - strtime2;//下午工作的时间
            //                    double ttzhi = t - 8.5 * at - tzhi.TotalHours;//剩余加工的时间
            //                    if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
            //                    {
            //                        picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
            //                    }
            //                    else//大于上午的时间
            //                    {
            //                        double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
            //                        picker2.Value = strtime2.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
            //                    }
            //                }
            //                else
            //                {
            //                    picker2.Value = strtime2.AddDays(at).AddHours(t);// + 0.2);
            //                }
            //            }

            //            if (ta1 == -1)//ret3 <= 8:00----上午工作
            //            {
            //                //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
            //                DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//当前日期 + 8:00:00
            //                                                                               //DateTime strtime2 =     Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
            //                picker1.Value = Convert.ToDateTime(strtime1);//.AddHours(0.2);
            //                DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:50

            //                DateTime Time22 = Convert.ToDateTime(ret3date + " " + Time2);//日期+11:20

            //                int b1 = strtime1.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

            //                if (b1 == 1 || b1 == 0)//时间大于11:20
            //                {
            //                    TimeSpan tcha = Time22 - strtime1;
            //                    double t1 = t - 8.5 * at - tcha.TotalHours;//剩余加工的时间
            //                    if (t1 <= thourxiawu.TotalHours)
            //                    {
            //                        picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);// + 0.2);
            //                    }
            //                    else//大于下午的时间差 && 小于第二天的上午的时间差
            //                    {
            //                        double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
            //                        picker2.Value = strtime1.AddDays(at + 1).AddHours(tsheng);// + 0.2);
            //                    }
            //                }
            //                else
            //                {
            //                    picker2.Value = strtime1.AddDays(at).AddHours(t);// + 0.2);
            //                }
            //            }

            //            if ((ta1 == 1 || ta1 == 0) && (ta11 == 1 || ta11 == 0))//上午工作
            //            {
            //                //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
            //                DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//当前日期 + 8:00:00
            //                                                                               //DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
            //                picker1.Value = Convert.ToDateTime(ret3);//.AddHours(0.2);
            //                DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:50

            //                DateTime Time22 = Convert.ToDateTime(ret3date + " " + Time2);//日期+11:20

            //                int b1 = ret3.AddDays(at).AddHours(t - 8.5 * at).ToString("HH:mm:ss").CompareTo(Time2);

            //                if (b1 == 1 || b1 == 0)//时间大于11:20
            //                {
            //                    TimeSpan tcha = Time22 - ret3;
            //                    double t1 = t - 8.5 * at - tcha.TotalHours;//剩余加工的时间
            //                    if (t1 <= thourxiawu.TotalHours)
            //                    {
            //                        picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);// + 0.2);
            //                    }
            //                    else//大于下午的时间差 && 小于第二天的上午的时间差
            //                    {
            //                        double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
            //                        picker2.Value = strtime1.AddDays(at + 1).AddHours(tsheng);// + 0.2);
            //                    }
            //                }
            //                else
            //                {
            //                    picker2.Value = ret3.AddDays(at).AddHours(t - 8.5 * at);// + 0.2);
            //                }
            //            }

            //            if ((ta111 == 1 || ta111 == 0) && (ta1111 == 1 || ta1111 == 0))//下午工作
            //            {
            //                //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
            //                picker1.Value = Convert.ToDateTime(ret3);//.AddHours(0.2);
            //                                                         //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
            //                DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//日期+8:00:00
            //                DateTime strtime2 = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:50:00                                
            //                DateTime Time44 = Convert.ToDateTime(ret3date + " " + Time4);//日期 + 17:50

            //                int b2 = ret3.AddDays(at).AddHours(t - 8.5 * at).ToString("HH:mm:ss").CompareTo(Time4);

            //                if (b2 == 1 || b2 == 0)//加工时间大于下午时间差
            //                {
            //                    TimeSpan tzhi = Time44 - ret3;//下午工作的时间
            //                    double ttzhi = t - 8.5 * at - tzhi.TotalHours;//剩余加工的时间
            //                    if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
            //                    {
            //                        picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
            //                    }
            //                    else//大于上午的时间
            //                    {
            //                        double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
            //                        picker2.Value = strtime2.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
            //                    }
            //                }
            //                else
            //                {
            //                    picker2.Value = ret3.AddDays(at).AddHours(t - 8.5 * at);
            //                }
            //            }

                        
            //        }

            //        if (ret3 < time)//-----------------ret3 < datetimepicker(用time1date和time1time)----time
            //        {
            //            //算总的工时
            //            double price = Convert.ToDouble(jiage);
            //            price = price * (Convert.ToInt32(shuliang));
            //            double t = (double)price / 27;
            //            double flag = t / 8.5;
            //            int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

            //            //总的一天的工时
            //            TimeSpan thourshangwu = T2 - T1;//上午的时间差
            //            TimeSpan thourxiawu = T4 - T3;//下午的时间差
            //                                          //double gongshi = thourshangwu.TotalHours + thourxiawu.TotalHours;
            //                                          //gongshi = Math.Round(gongshi, 2);

            //            //结束时间---ret3范围[8:00 <= ret3 <= 11:20 && 12:50 <= ret3 <= 17:30]

            //            //8:00 <= ret3 <= 11:20
            //            int ta1 = time1time.CompareTo(Time1);
            //            int ta11 = Time2.CompareTo(time1time);

            //            //12:50 <= ret3 <= 17:30
            //            int ta111 = time1time.CompareTo(Time3);
            //            int ta1111 = Time4.CompareTo(time1time);


            //            int tb1 = Time2.CompareTo(time1time);
            //            int tb11 = time1time.CompareTo("12:00:00");

            //            //int tb2 = Time3.CompareTo(time1time);
            //            //int tb22 = ("13:00:00").CompareTo(time1time);


            //            if (tb1 == -1 && tb11 == -1)//---ret3在11:30和12：00之间
            //            {
            //                //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
            //                //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
            //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
            //                DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:30:00                                
            //                DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

            //                picker1.Value = Convert.ToDateTime(strtime2);//.AddHours(0.2);
            //                int b2 = strtime2.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);

            //                if (b2 == 1)//加工时间大于下午时间差
            //                {
            //                    TimeSpan tzhi = Time44 - strtime2;//下午工作的时间
            //                    double ttzhi = t - 8.5 * at - tzhi.TotalHours;//剩余加工的时间
            //                    if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
            //                    {
            //                        picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
            //                    }
            //                    else//大于上午的时间
            //                    {
            //                        double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
            //                        picker2.Value = strtime2.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
            //                    }
            //                }
            //                else
            //                {
            //                    picker2.Value = strtime2.AddDays(at).AddHours(t);// + 0.2);
            //                }
            //            }

            //            if (ta1 == -1)//ret3 <= 8:00----上午工作
            //            {
            //                //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
            //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期 + 8:00:00
            //                                                                                 //DateTime strtime2 =   Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
            //                picker1.Value = Convert.ToDateTime(strtime1);//.AddHours(0.2);
            //                DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

            //                DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

            //                int b1 = strtime1.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

            //                if (b1 == 1)//时间大于11:20
            //                {
            //                    TimeSpan tcha = Time22 - strtime1;
            //                    double t1 = t - 8.5 * at - tcha.TotalHours;//剩余加工的时间
            //                    if (t1 <= thourxiawu.TotalHours)
            //                    {
            //                        picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);// + 0.2);
            //                    }
            //                    else//大于下午的时间差 && 小于第二天的上午的时间差
            //                    {
            //                        double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
            //                        picker2.Value = strtime1.AddDays(at + 1).AddHours(tsheng);// + 0.2);
            //                    }
            //                }
            //                else
            //                {
            //                    picker2.Value = strtime1.AddDays(at).AddHours(t);// + 0.2);
            //                }
            //            }


            //            if ((ta1 == 0 || ta1 == 1) && (ta11 == 0 || ta11 == 1))//上午工作
            //            {
            //                //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
            //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期 + 8:00:00
            //                                                                                 //DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
            //                picker1.Value = Convert.ToDateTime(time);//.AddHours(0.2);
            //                DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

            //                DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

            //                int b1 = time.AddDays(at).AddHours(t - 8.5 * at).ToString("HH:mm:ss").CompareTo(Time2);


            //                if (b1 == 1 || b1 == 0)//时间大于11:20
            //                {
            //                    TimeSpan tcha = Time22 - time;
            //                    double t1 = t - 8.5 * at - tcha.TotalHours;//剩余加工的时间
            //                    if (t1 <= thourxiawu.TotalHours)
            //                    {
            //                        picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);// + 0.2);
            //                    }
            //                    else//大于下午的时间差 && 小于第二天的上午的时间差
            //                    {
            //                        double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
            //                        picker2.Value = strtime1.AddDays(at + 1).AddHours(tsheng);// + 0.2);
            //                    }
            //                }
            //                else
            //                {
            //                    picker2.Value = time.AddDays(at).AddHours(t - 8.5 * at);// + 0.2);
            //                }
            //            }

            //            if ((ta111 == 0 || ta111 == 1) && (ta1111 == 0 || ta1111 == 1))//下午工作
            //            {
            //                //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
            //                picker1.Value = Convert.ToDateTime(time);//.AddHours(0.2);
            //                                                         //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
            //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
            //                DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
            //                DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:50

            //                int b2 = time.AddDays(at).AddHours(t - 8.5 * at).ToString("HH:mm:ss").CompareTo(Time4);

            //                if (b2 == 1 || b2 == 0)//加工时间大于下午时间差
            //                {
            //                    TimeSpan tzhi = Time44 - time;//下午工作的时间
            //                    double ttzhi = t - 8.5 * at - tzhi.TotalHours;//剩余加工的时间
            //                    if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
            //                    {
            //                        picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
            //                    }
            //                    else//大于上午的时间
            //                    {
            //                        double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
            //                        picker2.Value = strtime2.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
            //                    }
            //                }
            //                else
            //                {
            //                    picker2.Value = time.AddDays(at).AddHours(t - 8.5 * at);
            //                }
            //            }

                
            //        }


            //    }

            //}
            //#endregion
        }

        /// <summary>
        /// 数控设备排产-----12小时制
        /// </summary>
        /// <param name="time1time"></param>
        /// <param name="time1date1"></param>
        /// <param name="shebei"></param>
        /// <param name="jiage"></param>
        /// <param name="shuliang"></param>
        /// <param name="picker1"></param>
        /// <param name="picker2"></param>
        private void paichan2(string time1time, string time1date1, string shebei, string jiage, string shuliang, DateTimePicker picker1, DateTimePicker picker2)
        {
            DateTime time1 = DateTime.Now;//日期+时分秒（当前）

            string sql1 = "select 设定开始时间 from tb_mujubu_paichan where 工序设备='" + shebei + "'";
            string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            #region 设备空闲中
            if (ret1 == "")//设备空闲中
            {
                //算总的工时
                double price = Convert.ToDouble(jiage);
                price = price * (Convert.ToInt32(shuliang));
                double t = (double)price / 27;
                double flag = t / 10.5;
                int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                //上午4小时、下午4.5小时、晚上2小时
                //总的一天的工时
                //TimeSpan thourshangwu = T2 - T1;//上午的时间差
                //TimeSpan thourxiawu = T4 - T3;//下午的时间差
                //double gongshi = thourshangwu.TotalHours + thourxiawu.TotalHours;
                //gongshi = Math.Round(gongshi, 2);
                //double gongshi = 10.5;

                //string shijian1 = "08:00:00";//上班
                //string shijian2 = "12:00:00";//开始休息----4小时

                //string shijian3 = "13:00:00";//结束休息
                //string shijian4 = "17:30:00";//开始休息----4.5小时

                //string shijian5 = "18:00:00";//结束休息
                //string shijian6 = "20:00:00";//下班---------2小时------>一共10.5小时

                int ta1 = shijian1.CompareTo(time1time);

                if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                    if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                    if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                    {
                        picker2.Value = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                    }
                    if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                    {
                        picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                    }

                }

                //当前时间大于8:00 小于12:00
                int ta3 = time1time.CompareTo(shijian1);
                int ta4 = shijian2.CompareTo(time1time);
                if (ta3 == 1 && (ta4 == 1 || ta4 == 0))
                {

                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                    DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                    TimeSpan a = Time22 - strtime;//上午加工的时间
                    if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                    {

                        double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                        if (tt <= 4)//下午做完
                        {
                            picker2.Value = strtimexiawu.AddDays(at).AddHours(tt);
                        }
                        if (4 < tt && tt <= 6.5)//晚上做完
                        {
                            picker2.Value = strtimewanshang.AddDays(at).AddHours(tt - 4);
                        }
                        if (tt >= 6.5)//第二天上午做完
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                        }
                    }
                    else
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                }

                //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                int ta6 = time1time.CompareTo(shijian2);
                int ta7 = shijian3.CompareTo(time1time);

                if (ta6 == 1 && (ta7 == 1 || ta7 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                    if (10.5 * at < t && t <= 10.5 * at + 4)//下午完成
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                    if (10.5 * at + 4 < t && t <= 10.5 * at + 6.5)//晚上完成
                    {
                        picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                    }
                    if (10.5 * at + 6.5 < t && t <= 10.5 * at + 10.5)//第二天上午完成
                    {
                        picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                    }

                }

                //当前时间大于13:00 小于17:30
                int ta9 = time1time.CompareTo(shijian3);
                int ta10 = shijian4.CompareTo(time1time);

                if (ta9 == 1 && (ta10 == 1 || ta10 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+12:30
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                    DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                    TimeSpan tzhi = Time44.AddDays(at) - strtime.AddDays(at);//下午工作的时间
                    if (t - 10.5 * at > tzhi.TotalHours)//第二天下午做不完
                    {

                        double ttzhi = t - 10.5 * at - tzhi.TotalHours;//剩余加工的时间
                        if (ttzhi <= 2)//晚上完成
                        {
                            picker2.Value = strtimewanshang.AddDays(at).AddHours(ttzhi);
                        }
                        if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                        }
                        if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                        }

                    }
                    else
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }

                }

                //当前时间大于17:30 小于18:00
                int ta12 = time1time.CompareTo(shijian4);
                int ta13 = shijian5.CompareTo(time1time);

                if (ta12 == 1 && (ta13 == 1 || ta13 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                    if (10.5 * at < t && t <= 2 + 10.5 * at)//晚上完成
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                    if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                    {
                        picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                    }
                    if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                    {
                        picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                    }

                }

                //当前时间大于18:00 小于20:00
                int ta14 = time1time.CompareTo(shijian5);
                int ta15 = shijian6.CompareTo(time1time);

                if (ta14 == 1 && (ta15 == 1 || ta15 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                    TimeSpan t1 = strtimewuye.AddDays(at) - strtime.AddDays(at);//晚上加工的时间
                    if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                    {
                        double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                        if (t2 <= 4)//第二天上午可以完成
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(t2);
                        }
                        if (4 < t && t <= 8.5)//第二天下午完成
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                        }
                        if (8.5 < t && t <= 10.5)//第二天晚上完成
                        {
                            picker2.Value = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                        }
                    }
                    else
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                }

                //当前时间大于20:00
                //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                int ta16 = time1time.CompareTo(shijian6);

                if (ta16 == 1)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                    picker1.Value = strtime1.AddDays(1);

                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                    DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                    if (10.5 * at < t && t <= 10.5 * at + 4)
                    {
                        picker2.Value = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                    }
                    if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                    {
                        picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                    }
                    if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                    {
                        picker2.Value = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
                    }
                }

           
            }
            #endregion

            #region 设备不空闲
            else
            {
                string sql2 = "select max(设定开始时间) from tb_mujubu_paichan where 工序设备='" + shebei + "'";//查询该设备的最大设定的开始时间
                string ret2 = Convert.ToString(SQLhelp.ExecuteScalar(sql2, CommandType.Text));

                string sql3 = "select 设定结束时间 from tb_mujubu_paichan where 工序设备='" + shebei + "' and 设定开始时间='" + ret2 + "'";//最大的设定开始时间对应的结束事假，结束时间就是当前时间
                DateTime ret3 = Convert.ToDateTime(SQLhelp.ExecuteScalar(sql3, CommandType.Text));
                if (ret3 < time1)//设定结束时间 < 现在的时间 （最大的结束时间小于现在的时间也就是没有任务了）---空闲了
                {
                    DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);//time:工序1是当前时间 工序2-25是前面的时间

                    //算总的工时
                    double price = Convert.ToDouble(jiage);
                    price = price * (Convert.ToInt32(shuliang));
                    double t = (double)price / 27;
                    double flag = t / 10.5;
                    int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                    int ta1 = shijian1.CompareTo(time1time);

                    if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                        if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                        if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                        {
                            picker2.Value = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                        }
                        if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                        {
                            picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                        }

                    }

                    //当前时间大于8:00 小于12:00
                    int ta3 = time1time.CompareTo(shijian1);
                    int ta4 = shijian2.CompareTo(time1time);
                    if (ta3 == 1 && ta4 == 1)
                    {

                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                        TimeSpan a = Time22.AddDays(at) - strtime.AddDays(at);//上午加工的时间
                        if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                        {

                            double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                            if (tt <= 4)//下午做完
                            {
                                picker2.Value = strtimexiawu.AddDays(at).AddHours(tt);
                            }
                            if (4 < tt && tt <= 6.5)//晚上做完
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(tt - 4);
                            }
                            if (tt >= 6.5)//第二天上午做完
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                            }
                        }
                        else
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                    }

                    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                    int ta6 = time1time.CompareTo(shijian2);
                    int ta7 = shijian3.CompareTo(time1time);

                    if (ta6 == 1 && ta7 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                        if (10.5 * at < t && t <= 4 + 10.5 * at)//下午完成
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                        if (4 + 10.5 * at < t && t <= 6.5 + 10.5 * at)//晚上完成
                        {
                            picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                        }
                        if (6.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天上午完成
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                        }

                    }

                    //当前时间大于13:00 小于17:30
                    int ta9 = time1time.CompareTo(shijian3);
                    int ta10 = shijian4.CompareTo(time1time);

                    if (ta9 == 1 && ta10 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+12:30
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                        TimeSpan tzhi = Time44.AddDays(at) - strtime.AddDays(at);//下午工作的时间
                        if (t - 10.5 * at > tzhi.TotalHours)//第二天下午做不完
                        {

                            double ttzhi = t - 10.5 * at - tzhi.TotalHours;//剩余加工的时间
                            if (ttzhi <= 2)//晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(ttzhi);
                            }
                            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                            }
                            if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                            }

                        }
                        else
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }

                    }

                    //当前时间大于17:30 小于18:00
                    int ta12 = time1time.CompareTo(shijian4);
                    int ta13 = shijian5.CompareTo(time1time);

                    if (ta12 == 1 && ta13 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                        if (10.5 * at < t && t <= 2 + 10.5 * at)//晚上完成
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                        if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                        }
                        if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                        }

                    }

                    //当前时间大于18:00 小于20:00
                    int ta14 = time1time.CompareTo(shijian5);
                    int ta15 = shijian6.CompareTo(time1time);

                    if (ta14 == 1 && ta15 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                        TimeSpan t1 = strtimewuye.AddDays(at) - strtime.AddDays(at);//晚上加工的时间
                        if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                        {
                            double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                            if (t2 <= 4)//第二天上午可以完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t2);
                            }
                            if (4 < t && t <= 8.5)//第二天下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                            }
                            if (8.5 < t && t <= 10.5)//第二天晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                            }
                        }
                        else
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                    }

                    //当前时间大于20:00
                    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                    int ta16 = time1time.CompareTo(shijian6);

                    if (ta16 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                        picker1.Value = strtime1.AddDays(1);

                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                        DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                        if (10.5 * at < t && t <= 4 + 10.5 * at)
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                        }
                        if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                        }
                        if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                        {
                            picker2.Value = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
                        }
                    }


         

                }
                else//(设定结束时间 > 现在的时间（用设定结束时间算）)----将设定结束时间当做现在时间算  ret3---结束时间
                {
                    DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);//time:工序1是当前时间 工序2-25是前面的时间

                    if (ret3 >= time)//---------ret3 > datetimepicker(用ret3date1和ret3time)
                    {

                        string ret3date = ret3.ToString("yyyy/MM/dd");
                        string ret3time = ret3.ToString("HH:mm:ss");
                        //算总的工时
                        double price = Convert.ToDouble(jiage);
                        price = price * (Convert.ToInt32(shuliang));
                        double t = (double)price / 27;
                        double flag = t / 10.5;
                        int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                        int ta1 = shijian1.CompareTo(time1time);

                        if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                        {
                            DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于8:00 小于12:00
                        int ta3 = time1time.CompareTo(shijian1);
                        int ta4 = shijian2.CompareTo(time1time);
                        if (ta3 == 1 && ta4 == 1)
                        {

                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期 + 8:00:00
                            picker1.Value = Convert.ToDateTime(ret3);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期 + 17:30:00

                            DateTime Time22 = Convert.ToDateTime(ret3date + " " + shijian2);//日期+12:00

                            TimeSpan a = Time22.AddDays(at) - ret3.AddDays(at);//上午加工的时间
                            if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                            {

                                double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                                if (tt <= 4)//下午做完
                                {
                                    picker2.Value = strtimexiawu.AddDays(at).AddHours(tt);
                                }
                                if (4 < tt && tt <= 6.5)//晚上做完
                                {
                                    picker2.Value = strtimewanshang.AddDays(at).AddHours(tt - 4);
                                }
                                if (tt >= 6.5)//第二天上午做完
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                                }
                            }
                            else
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                        int ta6 = time1time.CompareTo(shijian2);
                        int ta7 = shijian3.CompareTo(time1time);

                        if (ta6 == 1 && ta7 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00:00
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//下午完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 6.5 + 10.5 * at)//晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (6.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天上午完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于13:00 小于17:30
                        int ta9 = time1time.CompareTo(shijian3);
                        int ta10 = shijian4.CompareTo(time1time);

                        if (ta9 == 1 && ta10 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            picker1.Value = Convert.ToDateTime(ret3);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+12:30
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00:00                                
                            DateTime Time44 = Convert.ToDateTime(ret3date + " " + shijian4);//日期 + 17:30

                            TimeSpan tzhi = Time44.AddDays(at) - ret3.AddDays(at);//下午工作的时间
                            if (t - 10.5 * at > tzhi.TotalHours)//第二天下午做不完
                            {

                                double ttzhi = t - 10.5 * at - tzhi.TotalHours;//剩余加工的时间
                                if (ttzhi <= 2)//晚上完成
                                {
                                    picker2.Value = strtimewanshang.AddDays(at).AddHours(ttzhi);
                                }
                                if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                                }
                                if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                                }

                            }
                            else
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t - 10.5 * at);
                            }

                        }

                        //当前时间大于17:30 小于18:00
                        int ta12 = time1time.CompareTo(shijian4);
                        int ta13 = shijian5.CompareTo(time1time);

                        if (ta12 == 1 && ta13 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00

                            if (10.5 * at < t && t <= 2 + 10.5 * at)//晚上完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                            }
                            if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                            }

                        }

                        //当前时间大于18:00 小于20:00
                        int ta14 = time1time.CompareTo(shijian5);
                        int ta15 = shijian6.CompareTo(time1time);

                        if (ta14 == 1 && ta15 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期+8:00
                            picker1.Value = Convert.ToDateTime(ret3);
                            DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian6);//当前日期+20:00
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期+18:00
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00

                            TimeSpan t1 = strtimewuye.AddDays(at) - ret3.AddDays(at);//晚上加工的时间
                            if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                            {
                                double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                                if (t2 <= 4)//第二天上午可以完成
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(t2);
                                }
                                if (4 < t && t <= 8.5)//第二天下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                                }
                                if (8.5 < t && t <= 10.5)//第二天晚上完成
                                {
                                    picker2.Value = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                                }
                            }
                            else
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于20:00
                        //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                        int ta16 = time1time.CompareTo(shijian6);

                        if (ta16 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期+8:00
                            picker1.Value = strtime1.AddDays(1);

                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00
                            DateTime strtimewansahng = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                            {
                                picker2.Value = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
                            }
                        }

                     
                    }
                    else//-----------------ret3 < datetimepicker(用time1date和time1time)----time
                    {
                        //算总的工时
                        double price = Convert.ToDouble(jiage);
                        price = price * (Convert.ToInt32(shuliang));
                        double t = (double)price / 27;
                        double flag = t / 10.5;
                        int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                        int ta1 = shijian1.CompareTo(time1time);

                        if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于8:00 小于12:00
                        int ta3 = time1time.CompareTo(shijian1);
                        int ta4 = shijian2.CompareTo(time1time);
                        if (ta3 == 1 && ta4 == 1)
                        {

                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                            DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                            TimeSpan a = Time22.AddDays(at) - strtime.AddDays(at);//上午加工的时间
                            if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                            {

                                double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                                if (tt <= 4)//下午做完
                                {
                                    picker2.Value = strtimexiawu.AddDays(at).AddHours(tt);
                                }
                                if (4 < tt && tt <= 6.5)//晚上做完
                                {
                                    picker2.Value = strtimewanshang.AddDays(at).AddHours(tt - 4);
                                }
                                if (tt >= 6.5)//第二天上午做完
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                                }
                            }
                            else
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                        int ta6 = time1time.CompareTo(shijian2);
                        int ta7 = shijian3.CompareTo(time1time);

                        if (ta6 == 1 && ta7 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//下午完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 6.5 + 10.5 * at)//晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (6.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天上午完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于13:00 小于17:30
                        int ta9 = time1time.CompareTo(shijian3);
                        int ta10 = shijian4.CompareTo(time1time);

                        if (ta9 == 1 && ta10 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+12:30
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                            DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                            TimeSpan tzhi = Time44.AddDays(at) - strtime.AddDays(at);//下午工作的时间
                            if (t - 10.5 * at > tzhi.TotalHours)//第二天下午做不完
                            {

                                double ttzhi = t - 10.5 * at - tzhi.TotalHours;//剩余加工的时间
                                if (ttzhi <= 2)//晚上完成
                                {
                                    picker2.Value = strtimewanshang.AddDays(at).AddHours(ttzhi);
                                }
                                if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                                }
                                if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                                }

                            }
                            else
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }

                        }

                        //当前时间大于17:30 小于18:00
                        int ta12 = time1time.CompareTo(shijian4);
                        int ta13 = shijian5.CompareTo(time1time);

                        if (ta12 == 1 && ta13 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                            if (10.5 * at < t && t <= 10.5 * at + 2)//晚上完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                            }
                            if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                            }

                        }

                        //当前时间大于18:00 小于20:00
                        int ta14 = time1time.CompareTo(shijian5);
                        int ta15 = shijian6.CompareTo(time1time);

                        if (ta14 == 1 && ta15 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                            TimeSpan t1 = strtimewuye.AddDays(at) - strtime.AddDays(at);//晚上加工的时间
                            if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                            {
                                double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                                if (t2 <= 4)//第二天上午可以完成
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(t2);
                                }
                                if (4 < t && t <= 8.5)//第二天下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                                }
                                if (8.5 < t && t <= 10.5)//第二天晚上完成
                                {
                                    picker2.Value = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                                }
                            }
                            else
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于20:00
                        //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                        int ta16 = time1time.CompareTo(shijian6);

                        if (ta16 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                            picker1.Value = strtime1.AddDays(1);

                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                            DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                            {
                                picker2.Value = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
                            }
                        }

               
                    }
                }

            }
            #endregion
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

        private void btn_paichan_Click(object sender, EventArgs e)
        {
            try
            {
                #region 排产

                shuaxin();

                string time1time = DateTime.Now.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                string time1date1 = DateTime.Now.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                                        //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                if (shebei1.Text.Trim() == "")
                {
                    MessageBox.Show("请添加工序！", "提示");
                    return;
                }


                if (shebei1.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei1.Text.Trim());//判断设备
                    if (flagShebei == "24")
                    {
                        paichan1(time1time, time1date1, shebei1.Text.Trim(), txt_gx1.Text.Trim(), textBox_shuliang_1.Text.Trim(), dateTimePicker1, dateTimePicker2);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(time1time, time1date1, shebei1.Text.Trim(), txt_gx1.Text.Trim(), txt_shuliang1.Text.Trim(), dateTimePicker1, dateTimePicker2);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(time1time, time1date1, shebei1.Text.Trim(), txt_gx1.Text.Trim(), textBox_shuliang_1.Text.Trim(), dateTimePicker1, dateTimePicker2);
                    }
                }

                if (shebei2.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei2.Text.Trim());//判断设备

                    DateTime da = dateTimePicker2.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei2.Text.Trim(), txt_gx2.Text.Trim(), textBox_shuliang_2.Text.Trim(), dateTimePicker3, dateTimePicker4);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei2.Text.Trim(), txt_gx2.Text.Trim(), txt_shuliang2.Text.Trim(), dateTimePicker3, dateTimePicker4);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei2.Text.Trim(), txt_gx2.Text.Trim(), textBox_shuliang_2.Text.Trim(), dateTimePicker3, dateTimePicker4);
                    }

                }

                if (shebei3.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei3.Text.Trim());//判断设备

                    DateTime da = dateTimePicker4.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei3.Text.Trim(), txt_gx3.Text.Trim(), textBox_shuliang_3.Text.Trim(), dateTimePicker5, dateTimePicker6);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei3.Text.Trim(), txt_gx3.Text.Trim(), txt_shuliang3.Text.Trim(), dateTimePicker5, dateTimePicker6);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei3.Text.Trim(), txt_gx3.Text.Trim(), textBox_shuliang_3.Text.Trim(), dateTimePicker5, dateTimePicker6);
                    }


                }

                if (shebei4.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei4.Text.Trim());//判断设备

                    DateTime da = dateTimePicker6.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei4.Text.Trim(), txt_gx4.Text.Trim(), textBox_shuliang_4.Text.Trim(), dateTimePicker7, dateTimePicker8);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei4.Text.Trim(), txt_gx4.Text.Trim(), txt_shuliang4.Text.Trim(), dateTimePicker7, dateTimePicker8);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei4.Text.Trim(), txt_gx4.Text.Trim(), textBox_shuliang_4.Text.Trim(), dateTimePicker7, dateTimePicker8);
                    }

                }

                if (shebei5.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei5.Text.Trim());//判断设备

                    DateTime da = dateTimePicker8.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei5.Text.Trim(), txt_gx5.Text.Trim(), textBox_shuliang_5.Text.Trim(), dateTimePicker9, dateTimePicker10);
                    }

                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei5.Text.Trim(), txt_gx5.Text.Trim(), txt_shuliang5.Text.Trim(), dateTimePicker9, dateTimePicker10);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei5.Text.Trim(), txt_gx5.Text.Trim(), textBox_shuliang_5.Text.Trim(), dateTimePicker9, dateTimePicker10);
                    }

                }

                if (shebei6.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei6.Text.Trim());//判断设备

                    DateTime da = dateTimePicker10.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei6.Text.Trim(), txt_gx6.Text.Trim(), textBox_shuliang_6.Text.Trim(), dateTimePicker11, dateTimePicker12);
                    }

                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei6.Text.Trim(), txt_gx6.Text.Trim(), txt_shuliang6.Text.Trim(), dateTimePicker11, dateTimePicker12);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei6.Text.Trim(), txt_gx6.Text.Trim(), textBox_shuliang_6.Text.Trim(), dateTimePicker11, dateTimePicker12);
                    }

                }

                if (shebei7.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei7.Text.Trim());//判断设备

                    DateTime da = dateTimePicker12.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei7.Text.Trim(), txt_gx7.Text.Trim(), textBox_shuliang_7.Text.Trim(), dateTimePicker13, dateTimePicker14);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei7.Text.Trim(), txt_gx7.Text.Trim(), txt_shuliang7.Text.Trim(), dateTimePicker13, dateTimePicker14);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei7.Text.Trim(), txt_gx7.Text.Trim(), textBox_shuliang_7.Text.Trim(), dateTimePicker13, dateTimePicker14);
                    }

                }

                if (shebei8.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei8.Text.Trim());//判断设备

                    DateTime da = dateTimePicker14.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei8.Text.Trim(), txt_gx8.Text.Trim(), textBox_shuliang_8.Text.Trim(), dateTimePicker15, dateTimePicker16);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei8.Text.Trim(), txt_gx8.Text.Trim(), txt_shuliang8.Text.Trim(), dateTimePicker15, dateTimePicker16);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei8.Text.Trim(), txt_gx8.Text.Trim(), textBox_shuliang_8.Text.Trim(), dateTimePicker15, dateTimePicker16);
                    }

                }

                if (shebei9.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei9.Text.Trim());//判断设备

                    DateTime da = dateTimePicker16.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei9.Text.Trim(), txt_gx9.Text.Trim(), textBox_shuliang_9.Text.Trim(), dateTimePicker17, dateTimePicker18);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei9.Text.Trim(), txt_gx9.Text.Trim(), txt_shuliang9.Text.Trim(), dateTimePicker17, dateTimePicker18);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei9.Text.Trim(), txt_gx9.Text.Trim(), textBox_shuliang_9.Text.Trim(), dateTimePicker17, dateTimePicker18);
                    }

                }

                if (shebei10.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei10.Text.Trim());//判断设备

                    DateTime da = dateTimePicker18.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei10.Text.Trim(), txt_gx10.Text.Trim(), textBox_shuliang_10.Text.Trim(), dateTimePicker19, dateTimePicker20);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei10.Text.Trim(), txt_gx10.Text.Trim(), txt_shuliang10.Text.Trim(), dateTimePicker19, dateTimePicker20);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei10.Text.Trim(), txt_gx10.Text.Trim(), textBox_shuliang_10.Text.Trim(), dateTimePicker19, dateTimePicker20);
                    }

                }

                if (shebei11.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei11.Text.Trim());//判断设备

                    DateTime da = dateTimePicker20.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei11.Text.Trim(), txt_gx11.Text.Trim(), textBox_shuliang_11.Text.Trim(), dateTimePicker21, dateTimePicker22);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei11.Text.Trim(), txt_gx11.Text.Trim(), txt_shuliang11.Text.Trim(), dateTimePicker21, dateTimePicker22);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei11.Text.Trim(), txt_gx11.Text.Trim(), textBox_shuliang_11.Text.Trim(), dateTimePicker21, dateTimePicker22);
                    }

                }

                if (shebei12.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei12.Text.Trim());//判断设备

                    DateTime da = dateTimePicker22.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei12.Text.Trim(), txt_gx12.Text.Trim(), textBox_shuliang_12.Text.Trim(), dateTimePicker23, dateTimePicker24);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei12.Text.Trim(), txt_gx12.Text.Trim(), txt_shuliang12.Text.Trim(), dateTimePicker23, dateTimePicker24);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei12.Text.Trim(), txt_gx12.Text.Trim(), textBox_shuliang_12.Text.Trim(), dateTimePicker23, dateTimePicker24);
                    }

                }

                if (shebei13.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei13.Text.Trim());//判断设备

                    DateTime da = dateTimePicker24.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei13.Text.Trim(), txt_gx13.Text.Trim(), textBox_shuliang_13.Text.Trim(), dateTimePicker25, dateTimePicker26);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei13.Text.Trim(), txt_gx13.Text.Trim(), txt_shuliang13.Text.Trim(), dateTimePicker25, dateTimePicker26);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei13.Text.Trim(), txt_gx13.Text.Trim(), textBox_shuliang_13.Text.Trim(), dateTimePicker25, dateTimePicker26);
                    }

                }

                if (shebei14.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei14.Text.Trim());//判断设备

                    DateTime da = dateTimePicker26.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei14.Text.Trim(), txt_gx14.Text.Trim(), textBox_shuliang_14.Text.Trim(), dateTimePicker27, dateTimePicker28);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei14.Text.Trim(), txt_gx14.Text.Trim(), txt_shuliang14.Text.Trim(), dateTimePicker27, dateTimePicker28);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei14.Text.Trim(), txt_gx14.Text.Trim(), textBox_shuliang_14.Text.Trim(), dateTimePicker27, dateTimePicker28);
                    }

                }

                if (shebei15.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei15.Text.Trim());//判断设备

                    DateTime da = dateTimePicker28.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei15.Text.Trim(), txt_gx15.Text.Trim(), textBox_shuliang_15.Text.Trim(), dateTimePicker29, dateTimePicker30);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei15.Text.Trim(), txt_gx15.Text.Trim(), txt_shuliang15.Text.Trim(), dateTimePicker29, dateTimePicker30);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei15.Text.Trim(), txt_gx15.Text.Trim(), textBox_shuliang_15.Text.Trim(), dateTimePicker29, dateTimePicker30);
                    }
                }

                if (shebei16.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei16.Text.Trim());//判断设备

                    DateTime da = dateTimePicker30.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei16.Text.Trim(), txt_gx16.Text.Trim(), textBox_shuliang_16.Text.Trim(), dateTimePicker31, dateTimePicker32);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei16.Text.Trim(), txt_gx16.Text.Trim(), txt_shuliang16.Text.Trim(), dateTimePicker31, dateTimePicker32);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei16.Text.Trim(), txt_gx16.Text.Trim(), textBox_shuliang_16.Text.Trim(), dateTimePicker31, dateTimePicker32);
                    }

                }

                if (shebei17.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei17.Text.Trim());//判断设备

                    DateTime da = dateTimePicker32.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei17.Text.Trim(), txt_gx17.Text.Trim(), textBox_shuliang_17.Text.Trim(), dateTimePicker33, dateTimePicker34);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei17.Text.Trim(), txt_gx17.Text.Trim(), txt_shuliang17.Text.Trim(), dateTimePicker33, dateTimePicker34);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei17.Text.Trim(), txt_gx17.Text.Trim(), textBox_shuliang_17.Text.Trim(), dateTimePicker33, dateTimePicker34);
                    }

                }

                if (shebei18.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei18.Text.Trim());//判断设备

                    DateTime da = dateTimePicker34.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei18.Text.Trim(), txt_gx18.Text.Trim(), textBox_shuliang_18.Text.Trim(), dateTimePicker35, dateTimePicker36);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei18.Text.Trim(), txt_gx18.Text.Trim(), txt_shuliang18.Text.Trim(), dateTimePicker35, dateTimePicker36);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei18.Text.Trim(), txt_gx18.Text.Trim(), textBox_shuliang_18.Text.Trim(), dateTimePicker35, dateTimePicker36);
                    }

                }

                if (shebei19.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei19.Text.Trim());//判断设备

                    DateTime da = dateTimePicker36.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei19.Text.Trim(), txt_gx19.Text.Trim(), textBox_shuliang_19.Text.Trim(), dateTimePicker37, dateTimePicker38);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei19.Text.Trim(), txt_gx19.Text.Trim(), txt_shuliang19.Text.Trim(), dateTimePicker37, dateTimePicker38);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei19.Text.Trim(), txt_gx19.Text.Trim(), textBox_shuliang_19.Text.Trim(), dateTimePicker37, dateTimePicker38);
                    }
                }

                if (shebei20.Text.Trim() != "")
                {
                    string flagShebei = panduanshebi(shebei20.Text.Trim());//判断设备

                    DateTime da = dateTimePicker38.Value;
                    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

                    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
                                                           //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

                    if (flagShebei == "24")
                    {
                        paichan1(da1, da2, shebei20.Text.Trim(), txt_gx20.Text.Trim(), textBox_shuliang_20.Text.Trim(), dateTimePicker39, dateTimePicker40);
                    }
                    //if (flagShebei == "8")
                    //{
                    //    paichan(da1, da2, shebei20.Text.Trim(), txt_gx20.Text.Trim(), txt_shuliang20.Text.Trim(), dateTimePicker39, dateTimePicker40);
                    //}
                    if (flagShebei == "12")
                    {
                        paichan2(da1, da2, shebei20.Text.Trim(), txt_gx20.Text.Trim(), textBox_shuliang_20.Text.Trim(), dateTimePicker39, dateTimePicker40);
                    }

                }


                #endregion
            }
            catch
            {
                MessageBox.Show("请检查价格、数量是否输入完全", "提示");
            }
        }
    }

}