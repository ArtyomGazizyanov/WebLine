using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Search;
using Core.Models;
using System.Web.Script.Serialization;
using System.Web.Http;

namespace WebTravel.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        //POST: search/Send   
        public string Send( [FromBody] SearchRequest searchParams )
        {
            List<SearchResult> searchResults = SearchHelper.FindTariff( searchParams );
            List<SearchResultDto> tariffsList = new List<SearchResultDto>();
            foreach ( var result in searchResults )
            {
                tariffsList.Add( new SearchResultDto( result ) );
            }
            var json = new JavaScriptSerializer().Serialize( tariffsList );
            return json;
        } 
    }         
}
