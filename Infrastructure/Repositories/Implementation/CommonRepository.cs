using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using ApplicationCore.Model;
namespace Infrastructure.Repository.Memorial
{
   public class CommonRepository:ICommon
    {
        private IConfiguration _config;
        public CommonRepository(IConfiguration config)
        {
            _config = config;
        }

        public List<States> SearchState(string State)
        {
            List<StateModel> list = new List<StateModel>();
            DBConnection sc = new DBConnection(_config);
            sc.connect();
            SqlCommand cmd;
            cmd = new SqlCommand("States_Search", sc.con);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.CommandType = CommandType.StoredProcedure;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new StateModel()
                    {
                        StateID = Convert.ToInt32(reader["StateID"].ToString()),                        
                        StateDescription = reader["StateDescription"].ToString() ,
                        Name = reader["StateName"].ToString(),
                    });
                }
            }

            sc.disconnect();
            return list;
        }

        public List<DistrictModel> SearchDistrict(int StateID,string District)
        {
            List<DistrictModel> list = new List<DistrictModel>();
            DBConnection sc = new DBConnection(_config);
            sc.connect();
            SqlCommand cmd;
            cmd = new SqlCommand("Districts_Search", sc.con);
            cmd.Parameters.AddWithValue("@StateID", StateID);
            cmd.Parameters.AddWithValue("@District", District);
           
            cmd.CommandType = CommandType.StoredProcedure;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new DistrictModel()
                    {
                        StateID = Convert.ToInt32(reader["StateID"].ToString()),
                        DistrictID = Convert.ToInt32(reader["DistrictID"].ToString()),
                        DistrictName = reader["DistrictName"].ToString(),
                        DistrictDescription = reader["DistrictDescription"].ToString(),
                        Name = reader["DistrictName"].ToString(),

                    });
                }
            }

            sc.disconnect();
            return list;
        }

        public List<CityModel> SearchCity(int StateID, string DistrictID, string City)
        {
            List<CityModel> list = new List<CityModel>();
            DBConnection sc = new DBConnection(_config);
            sc.connect();
            SqlCommand cmd;
            cmd = new SqlCommand("Cities_Search", sc.con);
            cmd.Parameters.AddWithValue("@StateID", StateID);
            cmd.Parameters.AddWithValue("@DistrictID", DistrictID);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.CommandType = CommandType.StoredProcedure;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new CityModel()
                    {
                        CityID = Convert.ToInt32(reader["CityID"].ToString()),
                        StateID = Convert.ToInt32(reader["StateID"].ToString()),
                        DistrictID = Convert.ToInt32(reader["DistrictID"].ToString()),
                        CityName = reader["CityName"].ToString(),
                        CityDescription = reader["CityDescription"].ToString(),
                        Name = reader["CityName"].ToString(),

                    });
                }
            }

            sc.disconnect();
            return list;
        }


    }



}
