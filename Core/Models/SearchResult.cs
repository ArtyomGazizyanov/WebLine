using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class SearchResult
    {

        public int TariffId { get; set; }
        public int RoomId { get; set; }
        public string Date { get; set; }
        public string TariffName { get; set; }
        public int Price { get; set; }

        public void SetData( SqlDataReader reader)
        {
            TariffId = reader.GetInt32( reader.GetOrdinal( "tariffId"));
            RoomId = reader.GetInt32( reader.GetOrdinal( "roomId"));
            Price = reader.GetInt32( reader.GetOrdinal( "price"));
            TariffName = reader["name"].ToString();
            Date = reader["datePrice"].ToString(); 
        }
    }
}
