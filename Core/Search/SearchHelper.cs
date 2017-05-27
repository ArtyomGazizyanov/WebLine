using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using System.Data;
using System.Data.SqlClient;

namespace Core.Search
{
    public class SearchHelper
    {
        static public List<SearchResult> FindTariff( SearchRequest searchParams)
        { 
            List<SearchResult> searchResultList = new List<SearchResult>(); 

            using ( SqlConnection connection = DBConfiguration.GetConnection())
            {
                int foundHotelId = -1;
                int foundRoomlId = -1;
                SqlCommand findHotelId = connection.CreateCommand();
                findHotelId.Parameters.Add( "@hotelName", SqlDbType.VarChar).Value = searchParams.HotelName;
                findHotelId.CommandText = ( @"SELECT [Hotels].[hotelId] FROM [dbo].[Hotels] WHERE  [Hotels].[name]=@hotelName");
                using ( SqlDataReader reader = findHotelId.ExecuteReader())
                {
                    while ( reader.Read())
                    { 
                        foundHotelId = reader.GetInt32( reader.GetOrdinal( "hotelId"));
                    }
                }

                if( foundHotelId == -1)
                {
                    return new List<SearchResult>();
                }

                SqlCommand findRoomId = connection.CreateCommand();
                findRoomId.Parameters.Add( "@roomName", SqlDbType.VarChar).Value = searchParams.RoomName;
                findRoomId.Parameters.Add( "@hotelId", SqlDbType.Int).Value = foundHotelId;
                findRoomId.CommandText = ( @"SELECT [Rooms].[roomId] FROM [dbo].[Rooms] WHERE [Rooms].[name]=@roomName AND [Rooms].[hotelId]=@hotelId"); 
                using ( SqlDataReader reader = findRoomId.ExecuteReader())
                {
                    while ( reader.Read())
                    {
                        foundRoomlId = reader.GetInt32( reader.GetOrdinal( "roomId"));
                    }
                }

                if ( foundRoomlId == -1)
                {
                    return new List<SearchResult>();
                }

                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add( "@hotelId", SqlDbType.Int).Value = foundHotelId;
                cmd.Parameters.Add( "@roomId", SqlDbType.VarChar).Value = foundRoomlId;    
                cmd.Parameters.Add( "@date", SqlDbType.Date).Value = searchParams.Date;
                cmd.CommandText = ( @"SELECT  
                                    [Price].[tariffId]
                                    ,[Tariff].[name]
                                    ,[Price].[price]
                                    ,[Price].[datePrice] 
                                    ,[Price].[roomId]
                                    FROM [dbo].[Price]  
                                    LEFT JOIN [Tariff] ON [Price].[tariffId] = [Tariff].[tariffId]
                                    WHERE [Tariff].[hotelId] = @hotelId
                                    AND [Price].[roomId] = @roomId
                                    AND [Price].[datePrice]  = @date");

                using ( SqlDataReader reader = cmd.ExecuteReader())
                {
                    while ( reader.Read())
                    {
                        SearchResult result = new SearchResult();
                        result.SetData( reader);
                        searchResultList.Add( result);
                    }
                }
            }
            return searchResultList;
        }
    }
}
