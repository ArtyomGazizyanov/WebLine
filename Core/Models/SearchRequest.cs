using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class SearchRequest
    {
        public string HotelName { get; set; }
        public string RoomName { get; set; }
        public string Date { get; set; }

        public SearchRequest()
        {
        }
    }
}
