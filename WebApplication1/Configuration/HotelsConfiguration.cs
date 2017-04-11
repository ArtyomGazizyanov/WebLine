using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace WebTravel
{
    public class HotelsConfiguration
    {
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["HotelBD"].ConnectionString;

        }

    }

   
}