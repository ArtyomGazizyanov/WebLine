using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WebTravel.Models
{
    public class RoomDto
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int AdultBeds { get; set; }
        public int ChildrenBeds { get; set; }
        public int State { get; set; }

        public RoomDto()
        {
        }

        public RoomDto( Room donorRoom )
        {
            RoomId = donorRoom.RoomId;
            HotelId = donorRoom.HotelId;
            Name = donorRoom.Name;
            AdultBeds = donorRoom.AdultBeds;
            ChildrenBeds = donorRoom.ChildrenBeds;
            State = donorRoom.State;
        }
        
    }

}