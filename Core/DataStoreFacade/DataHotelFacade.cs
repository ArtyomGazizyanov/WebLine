using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Net.Http;

namespace Core.DataStoreFacade
{
    public class DataHotelFacade
    {
        public static Models.Hotel GetInstance( int id )
        {
            Models.Hotel hotel = new Models.Hotel();

            using (SqlConnection connection = DBConfiguration.GetConnection())
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = ( "SELECT * " +
                                   "FROM Hotels " +
                                   "WHERE id=" + id );
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hotel.SetData(reader);
                    }
                }
            }
            return hotel;
        }

        public static List<string> GetAllHotels()
        {
            Models.Hotel hotel = new Models.Hotel();
            List<string> hotelList = new List<string>();
            using (SqlConnection connection = DBConfiguration.GetConnection())
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = ("SELECT * " +
                                   "FROM Hotels");
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hotel.SetData(reader);
                        var jsonData = new JavaScriptSerializer().Serialize(hotel);
                        hotelList.Add(jsonData);
                    }
                }
            }
            return hotelList;
        }

        public static void Save(Models.Hotel hotel)
        {
            using (SqlConnection connection = DBConfiguration.GetConnection())
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = ( "UPDATE Hotels " +
                                   "SET name =" + hotel.Name + " " +                                   
                                   "WHERE id = " + hotel.HotelId );
                cmd.ExecuteReader();                
            }
        }

        public static void Delete(int id)
        {
            Core.Models.Hotel.Delete(id);
           /* try
            {
                using (SqlConnection connection = DBConfiguration.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("DELETE FROM Hotels WHERE id =" + id, connection))
                    {
                        command.ExecuteNonQuery();
                    }                 
                }
            }
            catch (ConfigurationErrorsException)
            {
            }*/
        }
    }
}
