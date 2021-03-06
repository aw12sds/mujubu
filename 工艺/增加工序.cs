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
    public partial class 增加工序 : Form
    {
        public string id;
        public 增加工序(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void 增加工序_Load(object sender, EventArgs e)
        {
            string sql = "select  工序名 from tb_gongxu_name";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            this.cbGongxu.DataSource = dt;
            cbGongxu.DisplayMember = "工序名";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string 插入顺序 = textBox2.Text;
            int a = 0;
            if (int.TryParse(插入顺序, out a)==false)
            {
                MessageBox.Show("顺序必须是数字！");
                return;
            }
            string uid = System.Guid.NewGuid().ToString("N");
            string 修改顺序sql = "update tb_gongxu_manage set 顺序=顺序+1 where 零件id='"+ id+"' and 顺序>='"+ 插入顺序+"'";
            SQLhelp.ExecuteScalar(修改顺序sql, CommandType.Text);

           
            string sql1 = "INSERT INTO tb_gongxu_manage(零件id,工序名称,工序内容,顺序) VALUES('" + id + "', '" + cbGongxu.Text + "','" + textBox1.Text + "','" + 插入顺序 + "')";
            SQLhelp.ExecuteNonquery2(sql1, CommandType.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
