using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace GameOnAPIs.Controllers
{
    public class UserDetailsController : ApiController
    {
        private enigma_gameonEntities db = new enigma_gameonEntities();

        //// GET: api/UserDetails
        //public IQueryable<UserDetail> GetUserDetails()
        //{
        //    return db.UserDetails;
        //}

        // GET: api/UserDetails/5
        [ResponseType(typeof(UserDetail))]
        public dynamic GetUserDetail(string user_id)
        {
            return new { user = db.sp_user_get_by_id(user_id) };
        }

        //// PUT: api/UserDetails/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutUserDetail(string id, UserDetail userDetail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != userDetail.UserID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(userDetail).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserDetailExists(id))
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

        // POST: api/UserDetails
        [ResponseType(typeof(UserDetail))]
        [ActionName("Login")]
        public dynamic PostUserDetail(UserDetail userDetail)
        {

            return new { user = db.sp_user_find_by_username_password(userDetail.UserID, userDetail.UserPassword) };
        }

        // POST: api/UserDetails/
        [ResponseType(typeof(UserDetail))]
        [ActionName("Register")]
        public dynamic RegisterUserDetail(UserDetail userDetail)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                db.UserDetails.Add(userDetail);
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }
            return new { user = db.sp_user_get_by_id(userDetail.UserID) };
        }

        //// DELETE: api/UserDetails/5
        //[ResponseType(typeof(UserDetail))]
        //public IHttpActionResult DeleteUserDetail(string id)
        //{
        //    UserDetail userDetail = db.UserDetails.Find(id);
        //    if (userDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    db.UserDetails.Remove(userDetail);
        //    db.SaveChanges();

        //    return Ok(userDetail);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserDetailExists(string id)
        {
            return db.UserDetails.Count(e => e.UserID == id) > 0;
        }
    }
}