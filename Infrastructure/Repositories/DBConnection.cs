using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
namespace Infrastructure
{
    public class DBConnection
    {
        public SqlConnection con;
        public string ConnectionString { get; set; }
        private IConfiguration _config;
        public DBConnection(IConfiguration config)
        {
           _config = config;
            ConnectionString = _config.GetConnectionString("ApplicationConnection");
            con = new SqlConnection(ConnectionString);
        }    
       
        public void connect()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void disconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}

        
    

