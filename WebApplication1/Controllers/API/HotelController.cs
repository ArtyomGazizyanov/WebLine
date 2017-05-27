using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebTravel.Models;
using Core.Models;
using Core.DataStoreFacade;
using Newtonsoft.Json.Linq;

namespace WebTravel.Controllers
{ 
    public class HotelController : ApiController
    {
        // GET: api/Hotel
        public string Get()
        {
            List<Hotel> hotelNames = new List<Hotel>();
            hotelNames = DataHotelFacade.GetAllHotels();            
            var json = new JavaScriptSerializer().Serialize(hotelNames);
            return json;
        }

        // GET: api/Hotel/5
        public string Get(int id)
        {
            Hotel donorHotel =  DataHotelFacade.GetInstance(id);         
            var json = new JavaScriptSerializer().Serialize(donorHotel);
            return json;
        }
        
        // POST: api/Hotel
        public void Post([FromBody]Hotel hotel)
        {
            DataHotelFacade.Save(hotel);

        }

        // PUT: api/Hotel/5
        public void Put([FromBody]Hotel hotel)
        {
            DataHotelFacade.Save(hotel);   
        }

        // DELETE: api/Hotel/5
        public void Delete(int id)
        {
            DataHotelFacade.Delete(id);
        }

    }
}
