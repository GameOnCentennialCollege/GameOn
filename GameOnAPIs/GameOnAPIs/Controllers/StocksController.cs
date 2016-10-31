using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace GameOnAPIs.Controllers
{
    public class StocksController : ApiController
    {
        private enigma_gameonEntities db = new enigma_gameonEntities();

        //// GET: api/Stocks
        //public IQueryable<Stock> GetStocks()
        //{
        //    return db.Stocks;
        //}

        // GET: api/Stocks/5
        /// <summary>
        /// check if the particular product is available in specific color and size
        /// </summary>
        [ResponseType(typeof(Stock))]

        public dynamic GetStock(int product_id, int color_id, int size_id)
        {
            return new { stock = db.sp_get_stock_by_product_id_color_id_size_id(product_id,color_id,size_id) };            
        }

        //// PUT: api/Stocks/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutStock(int id, Stock stock)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != stock.StockID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(stock).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StockExists(id))
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

        //// POST: api/Stocks
        //[ResponseType(typeof(Stock))]
        //public IHttpActionResult PostStock(Stock stock)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Stocks.Add(stock);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (StockExists(stock.StockID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = stock.StockID }, stock);
        //}

        //// DELETE: api/Stocks/5
        //[ResponseType(typeof(Stock))]
        //public IHttpActionResult DeleteStock(int id)
        //{
        //    Stock stock = db.Stocks.Find(id);
        //    if (stock == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Stocks.Remove(stock);
        //    db.SaveChanges();

        //    return Ok(stock);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StockExists(int id)
        {
            return db.Stocks.Count(e => e.StockID == id) > 0;
        }
    }
}