using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace GameOnAPIs.Controllers
{
    public class ColorsController : ApiController
    {
        private enigma_gameonEntities db = new enigma_gameonEntities();

        //// GET: api/Colors
        //public IQueryable<Color> GetColors()
        //{
        //    return db.Colors;
        //}

        //// GET: api/Colors/5
        //[ResponseType(typeof(Color))]
        //public IHttpActionResult GetColor(int id)
        //{
        //    Color color = db.Colors.Find(id);
        //    if (color == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(color);
        //}

        // GET: api/Colors/product/5
        [ResponseType(typeof(Color))]
        [ActionName("product")]
        public dynamic GetColorsByProductID(int id)
        {

            return new { color = db.sp_get_colours_by_product_id(id) };
        }

        //// PUT: api/Colors/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutColor(int id, Color color)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != color.ColorID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(color).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ColorExists(id))
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

        //// POST: api/Colors
        //[ResponseType(typeof(Color))]
        //public IHttpActionResult PostColor(Color color)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Colors.Add(color);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ColorExists(color.ColorID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = color.ColorID }, color);
        //}

        //// DELETE: api/Colors/5
        //[ResponseType(typeof(Color))]
        //public IHttpActionResult DeleteColor(int id)
        //{
        //    Color color = db.Colors.Find(id);
        //    if (color == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Colors.Remove(color);
        //    db.SaveChanges();

        //    return Ok(color);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColorExists(int id)
        {
            return db.Colors.Count(e => e.ColorID == id) > 0;
        }
    }
}