using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace GameOnAPIs.Controllers
{
    public class SizesController : ApiController
    {
        private enigma_gameonEntities db = new enigma_gameonEntities();

        //// GET: api/Sizes
        //public IQueryable<Size> GetSizes()
        //{
        //    return db.Sizes;
        //}

        //// GET: api/Sizes/5
        //[ResponseType(typeof(Size))]
        //public IHttpActionResult GetSize(int id)
        //{
        //    Size size = db.Sizes.Find(id);
        //    if (size == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(size);
        //}

        // GET: api/Sizes/product/5
        /// <summary>
        /// Get the list of available sizes for a particular product
        /// </summary>
        [ResponseType(typeof(Size))]
        [ActionName("product")]
        public dynamic GetSizesByProductID(int id)
        {

            return new { size = db.sp_get_sizes_by_product_id(id) };
        }

        //// PUT: api/Sizes/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutSize(int id, Size size)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != size.SizeID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(size).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SizeExists(id))
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

        //// POST: api/Sizes
        //[ResponseType(typeof(Size))]
        //public IHttpActionResult PostSize(Size size)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Sizes.Add(size);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (SizeExists(size.SizeID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = size.SizeID }, size);
        //}

        //// DELETE: api/Sizes/5
        //[ResponseType(typeof(Size))]
        //public IHttpActionResult DeleteSize(int id)
        //{
        //    Size size = db.Sizes.Find(id);
        //    if (size == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Sizes.Remove(size);
        //    db.SaveChanges();

        //    return Ok(size);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SizeExists(int id)
        {
            return db.Sizes.Count(e => e.SizeID == id) > 0;
        }
    }
}