using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Domain.Exceptions;
using Domain.Constant;
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
            ConnectionString = _config.GetConnectionString("ApplicationConnection") ?? throw new ArgumentNullException(nameof(config)); ;
            con = new SqlConnection(ConnectionString);
        }    
       
        public void connect()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (Exception ex) when (ex.Message!=null)
            {
                throw new DatabaseException(ex.Message);
            }
            
        }
        public void disconnect()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex) when (ex.Message != null)
            {
                throw new DatabaseException("Database connection problems");
            }           
        }
    }
}

        
    

