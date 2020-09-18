using Cinema.Server.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Cinema.Server.Controllers
{
    public class OrdersController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post([FromBody] Order order)
        {
            using var db = new DatabaseContext();
            order.Time = DateTime.UtcNow;
            db.Orders.Add(order);
            db.SaveChanges();

            return Created($"api/Orders/{order.Id}", order);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            using var db = new DatabaseContext();
            var order = db.Orders.FirstOrDefault(o => o.Id == id);
            if (order is null)
            {
                return BadRequest();
            }

            return Ok(order);
        }
    }
}
