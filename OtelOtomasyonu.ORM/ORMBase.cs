using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu.ORM
{
    public class ORMBase<T> : IORM<T> where T:class
    {
        private string ClassName
        {
            get
            {
                return typeof(T).Name;
            }
        }
        public bool Delete(T entity)
        {
            SqlCommand cmd = new SqlCommand(string.Format("prc_{0}_Delete",ClassName),Tools.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            Tools.ParametreOlustur<T>(cmd, KomutTip.Delete, entity);
            return Tools.ExecCommand(cmd);
        }

        public bool Insert(T entity)
        {
            SqlCommand cmd = new SqlCommand(string.Format("prc_{0}_Insert",ClassName),Tools.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            /* PropertyInfo[] properties = typeof(T).GetProperties();

             foreach (PropertyInfo item in properties)
             {
                 string name = item.Name;
                 if (name.ToLower()=="id" || name.ToLower()=="ıd")
                 {
                     continue;
                 }
                 object value = item.GetValue(entity);
                 cmd.Parameters.AddWithValue("@" + name,value);
             }*/
            Tools.ParametreOlustur<T>(cmd, KomutTip.Insert, entity);
            return Tools.ExecCommand(cmd);
        }

        public object InsertScalar(T entity)
        {
            SqlCommand cmd = new SqlCommand(string.Format("prc_{0}_Insert",ClassName),Tools.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            Tools.ParametreOlustur<T>(cmd, KomutTip.Insert, entity);
            return Tools.ExecScalar(cmd);
        }
        public DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("prc_{0}_Select", ClassName), Tools.Con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public bool Update(T entity)
        {
            SqlCommand cmd = new SqlCommand(string.Format("prc_{0}_Update",ClassName),Tools.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            Tools.ParametreOlustur<T>(cmd, KomutTip.Update, entity);
            return Tools.ExecCommand(cmd);
        }

        public bool Updated(T entity)
        {
            SqlCommand cmd = new SqlCommand(string.Format("prc_{0}_Updated", ClassName), Tools.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            Tools.ParametreOlustur<T>(cmd, KomutTip.Updated, entity);
            return Tools.ExecCommand(cmd);
        }
    }
}
