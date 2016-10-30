using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace GameOnAPIs.Controllers
{
    public class SubCategoriesController : ApiController
    {
        private enigma_gameonEntities db = new enigma_gameonEntities();

        // GET: api/SubCategories
        public dynamic GetSubCategories()
        {
            return new { SubCategory = db.sp_sub_category_get_all() };
        }

        // GET: api/SubCategories/5
        [ResponseType(typeof(SubCategory))]
        [ActionName("subcategory")]
        public dynamic GetSubCategory(int id)
        {
            return new { SubCategory = db.sp_sub_category_get_by_id(id) };
        }

        // GET: api/SubCategories/5
        [ResponseType(typeof(SubCategory))]
        [ActionName("category")]
        public dynamic GetSubCategoryByCategory(int id)
        {

            return new { SubCategory = db.sp_sub_category_get_all_by_category_id(id) };
        }

        //// PUT: api/SubCategories/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutSubCategory(int id, SubCategory subCategory)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != subCategory.SubCategoryID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(subCategory).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SubCategoryExists(id))
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

        //// POST: api/SubCategories
        //[ResponseType(typeof(SubCategory))]
        //public IHttpActionResult PostSubCategory(SubCategory subCategory)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.SubCategories.Add(subCategory);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = subCategory.SubCategoryID }, subCategory);
        //}

        //// DELETE: api/SubCategories/5
        //[ResponseType(typeof(SubCategory))]
        //public IHttpActionResult DeleteSubCategory(int id)
        //{
        //    SubCategory subCategory = db.SubCategories.Find(id);
        //    if (subCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    db.SubCategories.Remove(subCategory);
        //    db.SaveChanges();

        //    return Ok(subCategory);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubCategoryExists(int id)
        {
            return db.SubCategories.Count(e => e.SubCategoryID == id) > 0;
        }
    }
}