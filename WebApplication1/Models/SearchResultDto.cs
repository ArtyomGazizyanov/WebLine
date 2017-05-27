using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class SearchResultDto
    {

        public int TariffId { get; set; }
        public int RoomId { get; set; }
        public string Date { get; set; }
        public string TariffName { get; set; }
        public int Price { get; set; } 

        public SearchResultDto( SearchResult donorResult )
        {
            TariffId = donorResult.TariffId;
            RoomId = donorResult.RoomId;
            Date = donorResult.Date;
            TariffName = donorResult.TariffName;
            Price = donorResult.Price;
        }

    }
}
