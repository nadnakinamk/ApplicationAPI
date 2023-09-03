using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ApplicationCore.Models.Memorial;
using System.Data;
using System.Data.SqlClient;
using ApplicationCore.Interfaces.Memorial;
namespace Infrastructure.Repository.Memorial
{
    public class ObituariesRepository:IObituaries
    {
        private IConfiguration _config;
        public ObituariesRepository(IConfiguration config)
        {
            _config = config;
        }
        public string Add(ObituariesModel obj)
        {
            string result = "";
            string IsProfilePhoto="false";
            try
            {
                if (obj.ProfilePhoto != "" && obj.ProfilePhoto != null)
                {
                    IsProfilePhoto = "true";
                }



                DBConnection sc = new DBConnection(_config);
                sc.connect();
                SqlCommand cmd;
                cmd = new SqlCommand("M_Obituaries_Save", sc.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ObituaryID", obj.ObituaryID);
                cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
                cmd.Parameters.AddWithValue("@LastName", obj.LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth);
                cmd.Parameters.AddWithValue("@DateOfDeath", obj.DateOfDeath);
                cmd.Parameters.AddWithValue("@ProfilePhoto", IsProfilePhoto);
                cmd.Parameters.AddWithValue("@Description", obj.Description);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.Parameters.AddWithValue("@StateID", obj.StateID);
                cmd.Parameters.AddWithValue("@CityID", obj.CityID);
                cmd.Parameters.AddWithValue("@DistrictID", obj.DistrictID);
                ////cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
                ////cmd.Parameters.AddWithValue("@AlbumImage", obj.AlbumImage.Count());
                //cmd.Parameters.AddWithValue("@StateID", 1);             
                //cmd.Parameters.AddWithValue("@DistrictID",1);
                //cmd.Parameters.AddWithValue("@CityID", 1);
                cmd.Parameters.AddWithValue("@IsActive", 1);
                cmd.Parameters.AddWithValue("@AlbumImage", 0);
                cmd.Parameters.Add("@ReturnCode", SqlDbType.NVarChar, 500);
                cmd.Parameters["@ReturnCode"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery().ToString();
                result = (string)cmd.Parameters["@ReturnCode"].Value;
                sc.disconnect();
            }
            catch (Exception exe)
            {

            }
            return result;

        }

        public List<ObituariesModel> ObituarieGetdetails()
        {
            List<ObituariesModel> list = new List<ObituariesModel>();
            DBConnection sc = new DBConnection(_config);
            sc.connect();
            SqlCommand cmd;
            cmd = new SqlCommand("M_Obituaries_GetDeails", sc.con);
            cmd.CommandType = CommandType.StoredProcedure;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ObituariesModel OBM = new ObituariesModel();

                    if (reader["ObituaryID"].GetType().Name != "DBNull")
                        OBM.ObituaryID = Convert.ToInt32(reader["ObituaryID"].ToString());
                    else
                        OBM.ObituaryID = 0;

                    if (reader["FirstName"].GetType().Name != "DBNull")
                        OBM.FirstName = reader["FirstName"].ToString();
                    else
                        OBM.FirstName = "";

                    if (reader["LastName"].GetType().Name != "DBNull")
                        OBM.LastName = reader["LastName"].ToString();
                    else
                        OBM.LastName = "";


                    if (reader["DateOfBirth"].GetType().Name != "DBNull")
                        OBM.DateOfBirth = reader["DateOfBirth"].ToString();
                    else
                        OBM.DateOfBirth = "";

                    if (reader["DateOfBirth"].GetType().Name != "DBNull")
                        OBM.DateOfBirth = reader["DateOfBirth"].ToString();
                    else
                        OBM.DateOfBirth = "";



                    if (reader["DateOfDeath"].GetType().Name != "DBNull")
                        OBM.DateOfDeath = reader["DateOfDeath"].ToString();
                    else
                        OBM.DateOfDeath = "";


                    if (reader["Created"].GetType().Name != "DBNull")
                        OBM.Created = reader["Created"].ToString();
                    else
                        OBM.Created = "";

                    if (reader["Age"].GetType().Name != "DBNull")
                        OBM.Age = reader["Age"].ToString();
                    else
                        OBM.Age = "";


                    if (reader["ProfilePhoto"].GetType().Name != "DBNull")
                        OBM.ProfilePhoto = reader["ProfilePhoto"].ToString();
                    else
                        OBM.ProfilePhoto = "";


                    if (reader["AlbumPhoto"].GetType().Name != "DBNull")
                        OBM.Album = reader["AlbumPhoto"].ToString();
                    else
                        OBM.Album = "";

                    if (reader["Description"].GetType().Name != "DBNull")
                        OBM.Description = reader["Description"].ToString();
                    else
                        OBM.Description = "";


                    if (reader["Address"].GetType().Name != "DBNull")
                        OBM.Address = reader["Address"].ToString();
                    else
                        OBM.Address = "";


                    if (reader["StateName"].GetType().Name != "DBNull")
                        OBM.State = reader["StateName"].ToString();
                    else
                        OBM.State = "";

                    if (reader["DistrictName"].GetType().Name != "DBNull")
                        OBM.District = reader["StateName"].ToString();
                    else
                        OBM.District = "";

                    if (reader["CityName"].GetType().Name != "DBNull")
                        OBM.City = reader["CityName"].ToString();
                    else
                        OBM.City = "";


                    list.Add(OBM);


                }
            }

            sc.disconnect();
            return list;
        }

        public List<ObituariesModel> ObituarieView(int ObituaryID)
        {
            List<ObituariesModel> list = new List<ObituariesModel>();
            DBConnection sc = new DBConnection(_config);
            sc.connect();
            SqlCommand cmd;
            cmd = new SqlCommand("M_Obituaries_View", sc.con);
            cmd.Parameters.AddWithValue("@ObituaryID", ObituaryID);
            cmd.CommandType = CommandType.StoredProcedure;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ObituariesModel OBM = new ObituariesModel();                 

                    if (reader["ObituaryID"].GetType().Name != "DBNull")
                        OBM.ObituaryID = Convert.ToInt32(reader["ObituaryID"].ToString());
                    else
                        OBM.ObituaryID = 0;

                    if (reader["FirstName"].GetType().Name != "DBNull")
                        OBM.FirstName = reader["FirstName"].ToString();
                    else
                        OBM.FirstName = "";

                    if (reader["LastName"].GetType().Name != "DBNull")
                        OBM.LastName = reader["LastName"].ToString();
                    else
                        OBM.LastName = "";


                    if (reader["DateOfBirth"].GetType().Name != "DBNull")
                        OBM.DateOfBirth = reader["DateOfBirth"].ToString();
                    else
                        OBM.DateOfBirth = "";

                    if (reader["DateOfBirth"].GetType().Name != "DBNull")
                        OBM.DateOfBirth = reader["DateOfBirth"].ToString();
                    else
                        OBM.DateOfBirth = "";



                    if (reader["DateOfDeath"].GetType().Name != "DBNull")
                        OBM.DateOfDeath = reader["DateOfDeath"].ToString();
                    else
                        OBM.DateOfDeath = "";

                    
                         if (reader["Created"].GetType().Name != "DBNull")
                        OBM.Created = reader["Created"].ToString();
                    else
                        OBM.Created = "";

                    if (reader["Age"].GetType().Name != "DBNull")
                        OBM.Age= reader["Age"].ToString();
                    else
                        OBM.Age = "";


                    if (reader["ProfilePhoto"].GetType().Name != "DBNull")
                        OBM.ProfilePhoto = reader["ProfilePhoto"].ToString();
                    else
                        OBM.ProfilePhoto = "";


                    if (reader["AlbumPhoto"].GetType().Name != "DBNull")
                        OBM.Album = reader["AlbumPhoto"].ToString();
                    else
                        OBM.Album = "";

                    if (reader["Description"].GetType().Name != "DBNull")
                        OBM.Description = reader["Description"].ToString();
                    else
                        OBM.Description = "";


                    if (reader["Address"].GetType().Name != "DBNull")
                        OBM.Address = reader["Address"].ToString();
                    else
                        OBM.Address = "";


                    if (reader["StateName"].GetType().Name != "DBNull")
                        OBM.State= reader["StateName"].ToString();
                    else
                        OBM.State = "";

                    if (reader["DistrictName"].GetType().Name != "DBNull")
                        OBM.District = reader["DistrictName"].ToString();
                    else
                        OBM.District= "";

                    if (reader["CityName"].GetType().Name != "DBNull")
                        OBM.City = reader["CityName"].ToString();
                    else
                        OBM.City = "";


                    list.Add(OBM);


                }
            }

            sc.disconnect();
            return list;
        }




       


    }
}
