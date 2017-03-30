using System.Linq;
using System.Web.Http;

namespace WeatherAppAPI.Controllers
{
    public class LocationsController : ApiController
    {

        public IHttpActionResult Get(string country)
        {
            WeatherApp.GlobalWeatherServiceRef.GlobalWeatherSoapClient weatherAppClient = new WeatherApp.GlobalWeatherServiceRef.GlobalWeatherSoapClient();
            string cities = weatherAppClient.GetCitiesByCountry(country);
            return Ok(cities);
        }

        //// GET: api/Orders/5
        //[ResponseType(typeof(Order))]
        //public async Task<IHttpActionResult> GetOrder(int id, bool includeOrderItems = false)
        //{
        //    var orderQuery = includeOrderItems ? db.Orders.Include(o => o.OrderItems) : db.Orders;
        //    Order order = await orderQuery.FirstOrDefaultAsync(o => o.Id == id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(order);
        //}

        //// PUT: api/Orders/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutOrder(int id, Order order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != order.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(order).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Orders
        //[ResponseType(typeof(Order))]
        //public async Task<IHttpActionResult> PostOrder(Order order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Orders.Add(order);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        //}

        //// DELETE: api/Orders/5
        //[ResponseType(typeof(Order))]
        //public async Task<IHttpActionResult> DeleteOrder(int id)
        //{
        //    Order order = await db.Orders.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Orders.Remove(order);
        //    await db.SaveChangesAsync();

        //    return Ok(order);
        //}

    }
}