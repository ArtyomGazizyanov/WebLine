using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Core.Models
{
    public class Tariff
    {
        public int TariffId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int HotelId { get; set; }

        public Tariff()
        {
        }

        public void SetData( SqlDataReader reader)
        {
            TariffId = reader.GetInt32( reader.GetOrdinal( "tariffId"));
            Price = reader.GetInt32( reader.GetOrdinal( "price"));
            Name = reader["name"].ToString();
            HotelId = reader.GetInt32( reader.GetOrdinal( "hotelId"));
        }
    }
}
