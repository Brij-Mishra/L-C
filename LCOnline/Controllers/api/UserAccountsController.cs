using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LCOnline.DataLayer;
using LCOnline.Model;
using WebGrease.Css.Extensions;

namespace LCOnline.Controllers.api
{
    public class UserAccountsController : ApiController
    {
        private LCModelDBContext db = new LCModelDBContext();

        // GET: api/UserAccounts
        public IQueryable<UserAccount> GetUserAccounts()
        {
            return db.UserAccounts;
        }

        // GET: api/UserAccounts/5
        [ResponseType(typeof(UserAccount))]
        public async Task<IHttpActionResult> GetUserAccount(int id)
        {
            UserAccount userAccount = await db.UserAccounts.FindAsync(id);
            IList<Address> addresses = db.Addresses.Where(a => a.UserAccountId == id).ToList();
            if (userAccount == null)
            {
                return NotFound();
            }
            addresses.ForEach( a => userAccount.Addresses.Add(a));
            return Ok(userAccount);
        }

        // PUT: api/UserAccounts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserAccount(int id, UserAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAccount.UserAccountId)
            {
                return BadRequest();
            }

            db.Entry(userAccount).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserAccounts
        [ResponseType(typeof(UserAccount))]
        public async Task<IHttpActionResult> PostUserAccount(UserAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserAccounts.Add(userAccount);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userAccount.UserAccountId }, userAccount);
        }

        // DELETE: api/UserAccounts/5
        [ResponseType(typeof(UserAccount))]
        public async Task<IHttpActionResult> DeleteUserAccount(int id)
        {
            UserAccount userAccount = await db.UserAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            db.UserAccounts.Remove(userAccount);
            await db.SaveChangesAsync();

            return Ok(userAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserAccountExists(int id)
        {
            return db.UserAccounts.Count(e => e.UserAccountId == id) > 0;
        }
    }
}