using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.WebService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IItemsService _itemService;

        public ProductsController(IItemsService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult Get()  //GET - pobierz
        {
            return Ok(_itemService.Get());
        }

        [HttpGet("{id}", Name = "LinkToProduct")]
        public IActionResult Get(int id)  //GET - pobierz konkretny item
        {
            return Ok(_itemService.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product item) //POST - dodaj nowy item
        {
            _itemService.Add(item);

            return CreatedAtRoute("LinkToProduct", new { id = item.Id }, item);
        }
    }
}