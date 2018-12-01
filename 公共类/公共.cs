using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace mujubu.公共类
{
    class 公共
    {
        public void 添加审批记录(String name,string cato,string id)
        {
            String sql = "insert into tb_shengpijilu(业务id,审批人,审批类型,审批时间) values('" + id + "','" + name + "','" + cato + "','"+ DateTime.Now + "')";
                 SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
        }
        public void 添加修改记录(String name, string cato, string comment, string id)
        {
            String sql = "insert into tb_xiugaijilu(业务id,修改人,修改类型,修改内容,修改时间) values('" + id + "','" + name + "','" + cato + "','" + comment+"','" + DateTime.Now + "')";
            SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
        }
        public bool 判断是否有重复erp(String erp)
        {
            bool flag;
            String sql = "select * from tb_caigouliaodan where 编码='"+erp+"'";
            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            if (dt1.Rows.Count == 0)
            {
                flag=true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        public string 得到人员(string 职位, string 部门)
        {
            string 人员 = null;
            string sql = "select * from tb_operator where 部门='"+部门+"' and 级别='" + 职位+"'";
            DataTable dt1 = SQLhelp.GetDataTable_office(sql, CommandType.Text);
            人员 = dt1.Rows[0]["用户名"].ToString();
            return 人员;
        }
        public DataTable 根据部门得到人员( string 部门)
        {
            string 人员 = null;
            string sql = "select * from tb_operator where 部门='" + 部门 + "'";
            DataTable dt1 = SQLhelp.GetDataTable_office(sql, CommandType.Text);
            人员 = dt1.Rows[0]["用户名"].ToString();
            return dt1;
        }
    }
  
}
