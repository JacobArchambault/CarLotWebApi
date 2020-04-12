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
        public InventoryController()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Inventory, Inventory>()
                .ForMember(x => x.Orders, opt => opt.Ignore());
            });
        }
        [HttpGet, Route("")]
        public IEnumerable<string> Get() => new string[] { "value1", "value2" };
        [HttpGet, Route("{id}")]
        public string Get(int id) => id.ToString();
    }
}
