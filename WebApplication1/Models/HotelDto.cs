using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Models;
using System.Web.Script.Serialization;

namespace WebTravel.Models
{
    public class HotelDto
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int State { get; set; }
        public HotelDto()
        {
        }

        public HotelDto( Hotel donorHotel )
        {
            HotelId = donorHotel.HotelId;
            Name = donorHotel.Name;
            Address = donorHotel.Address;
            Phone = donorHotel.Phone;
            Email = donorHotel.Email;
            State = donorHotel.State;
        }  
    }
}