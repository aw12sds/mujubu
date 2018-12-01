using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace mujubu.公共类
{
    class 数据公用
    {
        public DataTable 得到数据(string id)
        {
            string sql = "select id,工作令号,项目名称,模具部订单号申请号,模具部销售合同号,编码,模具部申请人,模具部客户,模具部联系人,型号,单位,数量,合同类型,合同名称,模具部销售单价,模具部成本分摊,模具部交货日期,模具部销售开票日期,模具部实际交货日期,备注,模具部发货数量,模具部销售开票金额,名称,模具部成本分摊 from tb_caigouliaodan where 料单类型='模具部' and id='" + id + "'";


            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            return dt1;

        }
    }
}
