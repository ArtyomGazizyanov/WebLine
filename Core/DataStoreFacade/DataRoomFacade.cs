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
    public class DataRoomFacade
    {
        public static Room GetInstance( int id)
        {
            Room room = null;

            using ( SqlConnection connection = DBConfiguration.GetConnection())
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add( "@id", SqlDbType.Int).Value = id;
                cmd.CommandText = ( @"SELECT * 
                                   FROM Rooms 
                                   WHERE roomId=@id");

                using ( SqlDataReader reader = cmd.ExecuteReader())
                {
                    if ( reader.Read())
                    {
                        room = new Room( reader);
                    }
                }
            }
            return room;
        }

        public static List<Room> GetAllRooms( int HotelId)
        {
            List<Room> roomList = new List<Room>();
            using ( SqlConnection connection = DBConfiguration.GetConnection())
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add( "@HotelId", SqlDbType.Int).Value = HotelId;
                cmd.CommandText = ( @"SELECT * 
                                   FROM Rooms
                                   WHERE hotelId = @HotelId");
                using ( SqlDataReader reader = cmd.ExecuteReader())
                {
                    while ( reader.Read())
                    {
                        Room room = new Room( reader);
                        roomList.Add( room);
                    }
                }
            }
            return roomList;
        }

        public static void Add( Room room)
        {
            room.Add();
        }

        public static void Save( Room room)
        {
            room.Save(); 
        }

        public static void Delete( int id)
        {
            Room.Delete( id);
        }
    }
}
