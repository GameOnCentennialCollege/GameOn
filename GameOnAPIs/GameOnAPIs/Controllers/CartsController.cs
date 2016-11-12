using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace GameOnAPIs.Controllers
{
    public class CartsController : ApiController
    {
        private enigma_gameonEntities db = new enigma_gameonEntities();

        // GET: api/Carts/5
        /// <summary>
        /// Get cart details using user id
        /// </summary>
        [ResponseType(typeof(Cart))]
        public dynamic GetCart(string user_id)
        {
            return new { cart = db.sp_get_cart_details_by_user_id(user_id) };
        }

        // POST: api/Carts
        /// <summary>
        /// insert new item to the cart (stock id, quantity, unit cost, user id).
        /// </summary>
        [ResponseType(typeof(Cart))]
        public dynamic PostCart(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carts.Add(cart);
            db.SaveChanges();

            return new { cart = db.sp_get_cart_details_by_user_id(cart.CartClientID) };
        }

        //// DELETE: api/Carts/5
        //[ResponseType(typeof(Cart))]
        //public IHttpActionResult DeleteCart(int id)
        //{
        //    Cart cart = db.Carts.Find(id);
        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Carts.Remove(cart);
        //    db.SaveChanges();

        //    return Ok(cart);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartExists(int id)
        {
            return db.Carts.Count(e => e.CartID == id) > 0;
        }
    }
}