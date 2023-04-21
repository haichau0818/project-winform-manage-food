using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataAccessLayer
{
    public class ConnectionSql
    {

        private readonly string conectionString;
       
        public ConnectionSql()
        {
            conectionString = @"Data Source = KaneChau\SQLEXPRESS; Initial Catalog = FoodManager; Integrated Security = True";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(conectionString);
        }

        private SqlConnection Conection = new SqlConnection(@"Data Source =  KaneChau\SQLEXPRESS; Initial Catalog = FoodManager; Integrated Security = True");
        public SqlConnection OpenConnection()
        {
            if (Conection.State == ConnectionState.Closed)
                Conection.Open();
            return Conection;
        }
        public SqlConnection CloseConnection()
        {
            if (Conection.State == ConnectionState.Open)
                Conection.Close();
            return Conection;
        }


        //static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

    }
}
