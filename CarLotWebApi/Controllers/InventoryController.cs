using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using AutoMapper;
namespace CarLotWebApi.Controllers
{
    [Route("api/Inventory/{id?}")]
    public class InventoryController : ApiController
    {
        [HttpGet, Route("")]
        public IEnumerable<string> Get() => new string[] { "value1", "value2" };
        [HttpGet, Route("{id}")]
        public string Get(int id) => id.ToString();
    }
}
