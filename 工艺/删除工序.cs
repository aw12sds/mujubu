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
    public partial class 删除工序 : Form
    {
        public string id;
        public DataTable dt1;
        public 删除工序(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void 删除工序_Load(object sender, EventArgs e)
        {
            string sql = "select 顺序 from tb_gongxu_manage where 零件id='" + id + "' order by cast(顺序 as int) ";
            dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            for(int i=0;i<dt1.Rows.Count;i++)
            {
                this.comboBoxEdit1.Properties.Items.Add(dt1.Rows[i]["顺序"].ToString());
            }
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sql1 = "select * from tb_gongxu_manage where 零件id='" + id + "'and 顺序='" + comboBoxEdit1.Text + "'";
            dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
            if(dt1.Rows.Count==0)
            {
                MessageBox.Show("请选择已有的顺序!");
                return;
            }
            string sql= "delete from tb_gongxu_manage where 零件id='" + id + "'and 顺序='"+comboBoxEdit1.Text+"'" ;
            SQLhelp.ExecuteScalar(sql, CommandType.Text);
            string sql12 = "update tb_gongxu_manage set 顺序=顺序-1 where 零件id='" + id + "' and 顺序>" + comboBoxEdit1.Text + "";
            SQLhelp.ExecuteScalar(sql12, CommandType.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
