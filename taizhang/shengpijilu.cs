using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mujubu.taizhang
{
    public partial class shengpijilu : DevExpress.XtraEditors.XtraForm
    {
        public string id;
        public shengpijilu(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void shengpijilu_Load(object sender, EventArgs e)
        {
            string Sql1 = "select 审批人,审批时间,审批类型 from tb_shengpijilu where 业务id='"+id+ "' order by 审批时间 desc";
            DataTable dt2 = SQLhelp.GetDataTable(Sql1, CommandType.Text);
            gridControl1.DataSource = dt2;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
    }
}
