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
        private readonly IMapper mapper;
        private readonly InventoryRepo _repo = new InventoryRepo();

        public InventoryController()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Inventory, Inventory>()
                .ForMember(x => x.Orders, opt => opt.Ignore());
            });
            mapper = config.CreateMapper();

        }
        [HttpGet, Route("")]
        public IEnumerable<Inventory> GetInventory()
        {
            var inventories = _repo.GetAll();
            return mapper.Map<List<Inventory>, List<Inventory>>(inventories);
        }
        [HttpGet, Route("{id}", Name = "DisplayRoute")]
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> GetInventory(int id)
        {
            Inventory inventory = _repo.GetOne(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Inventory, Inventory>(inventory));
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
