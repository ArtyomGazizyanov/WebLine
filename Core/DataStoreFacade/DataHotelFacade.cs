using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Net.Http;
using Core.Models;
using System.Data;

namespace Core.DataStoreFacade
{
    public class DataHotelFacade
    {
        public static Hotel GetInstance( int id  )
        {
            Hotel hotel = null;

            using ( SqlConnection connection = DBConfiguration.GetConnection() )
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = id;
                cmd.CommandText = ( @"SELECT * 
                                   FROM Hotels
                                   WHERE hotelId=@id" );

                using ( SqlDataReader reader = cmd.ExecuteReader() )
                {
                    if ( reader.Read() )
                    {
                        hotel = new Hotel( reader );
                    }
                }
            }
            return hotel;
        }

        public static List<Hotel> GetAllHotels()
        {            
            List<Hotel> hotelList = new List<Hotel>();
            using ( SqlConnection connection = DBConfiguration.GetConnection() )
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = ( @"SELECT * 
                                   FROM Hotels" );
                using ( SqlDataReader reader = cmd.ExecuteReader() )
                {
                    while ( reader.Read() )
                    {
                        Hotel hotel = new Hotel( reader );
                        hotelList.Add( hotel );
                    }
                }
            }
            return hotelList;
        }
         

        public static void Save( Hotel hotel )
        {
            hotel.Save();
        }

        public static void Delete( int id )
        {
            Hotel.Delete( id ); 
        }
    }
}
