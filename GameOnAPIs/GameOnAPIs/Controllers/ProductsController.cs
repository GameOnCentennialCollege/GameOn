﻿using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace GameOnAPIs.Controllers
{
    public class ProductsController : ApiController
    {
        private enigma_gameonEntities db = new enigma_gameonEntities();

        // GET: api/Products
        public dynamic GetProducts()
        {
            return new { product = db.sp_product_get_all() };            
        }


        // GET: api/Products
        [ResponseType(typeof(Product))]
        [ActionName("RecentProducts")]
        public dynamic GetRecentProducts()
        {

            return new { product = db.sp_get_recently_added_products() };
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public dynamic GetProduct(int id)
        {
            return new { product = db.sp_get_product_details_by_id(id) };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}