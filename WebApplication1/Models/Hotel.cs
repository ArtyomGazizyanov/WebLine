using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTravel.Models
{
    public class Hotel : Core.Models.Hotel
    {
        public void SetData(Core.Models.Hotel donorHotel)
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