using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebTravel.Controllers
{
    public class HotelController : ApiController
    {
        //здесь будет обращение к hotelфасаду и получение всех отелей
        // GET: api/Hotel
        public IEnumerable<string> Get()
        {
            List<string> hotelNames = new List<string>();
            hotelNames = Core.DataStoreFacade.DataHotelFacade.GetAllHotels();

            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(hotelNames);
            return hotelNames;
        }

        // GET: api/Hotel/5
        public IEnumerable<string> Get(int id)
        {
            List<string> hotelNames = new List<string>();
            Core.Models.Hotel donorHotel =  Core.DataStoreFacade.DataHotelFacade.GetInstance(id);

            WebTravel.Models.Hotel hotel = new WebTravel.Models.Hotel();
            hotel.SetData(donorHotel);

            var json = new JavaScriptSerializer().Serialize(hotel);
                        
            hotelNames.Add(json);

            return hotelNames;
        }
        
        // POST: api/Hotel
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Hotel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Hotel/5
        public void Delete(int id)
        {
            Core.DataStoreFacade.DataHotelFacade.Delete(id);
        }

        private SqlConnection GetConnection()
        {
            var sqlConnection = new SqlConnection( HotelsConfiguration.GetConnectionString() );
            sqlConnection.Open();
            return sqlConnection;
        }
        
    }
}
