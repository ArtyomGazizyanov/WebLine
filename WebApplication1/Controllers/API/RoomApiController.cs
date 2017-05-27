using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebTravel.Models;
using Core.Models;
using Core.DataStoreFacade;
using System.Web.Script.Serialization;

namespace WebTravel.Controllers
{
    public class RoomApiController : ApiController
    {
        // GET: api/RoomApi
        [Route( "api/RoomApi/{hotelId}/{roomId}" )]
        public string Get( int hotelId, int roomId )
        {
            Room donorRoom = DataRoomFacade.GetInstance( roomId );
            RoomDto room = new RoomDto( donorRoom );

            var json = new JavaScriptSerializer( ).Serialize( room );
            return json;
        }

        // GET: api/RoomApi/5
        public string Get( int id )
        {
            int hotelId = id;
            List<Room> roomsList = new List<Room>( );
            roomsList= DataRoomFacade.GetAllRooms( hotelId );
            
            var json = new JavaScriptSerializer( ).Serialize( roomsList );
            return json;
        }

        // POST: api/RoomApi
        public void Post( [FromBody]Room room )
        {
            DataRoomFacade.Add( room );
        }

        // PUT: api/RoomApi
        public void Put( [FromBody]Room room )
        {
            DataRoomFacade.Save( room );
        }

        // DELETE: api/RoomApi/5
        public void Delete( int id )
        {
            DataRoomFacade.Delete( id );
        }
    }
}
