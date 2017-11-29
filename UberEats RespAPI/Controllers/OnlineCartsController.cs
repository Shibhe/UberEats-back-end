using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UberEats_RespAPI.Models;

namespace UberEats_RespAPI.Controllers
{
    public class OnlineCartsController : ApiController
    {
        private UberEatsEntities7 db = new UberEatsEntities7();

        // GET: api/OnlineCarts
        public IQueryable<OnlineCart> GetOnlineCarts()
        {
            return db.OnlineCarts;
        }

        // GET: api/OnlineCarts/5
        [ResponseType(typeof(OnlineCart))]
        public IHttpActionResult GetOnlineCart(int id)
        {
            OnlineCart onlineCart = db.OnlineCarts.Find(id);
            if (onlineCart == null)
            {
                return NotFound();
            }

            return Ok(onlineCart);
        }

        // PUT: api/OnlineCarts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOnlineCart(int id, OnlineCart onlineCart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != onlineCart.Id)
            {
                return BadRequest();
            }

            db.Entry(onlineCart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OnlineCartExists(id))
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

        // POST: api/OnlineCarts
        [ResponseType(typeof(OnlineCart))]
        public IHttpActionResult PostOnlineCart(OnlineCart onlineCart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Console.WriteLine("Data: {0}", onlineCart);
            db.OnlineCarts.Add(onlineCart);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = onlineCart.Id }, onlineCart);
        }

        // DELETE: api/OnlineCarts/5
        [ResponseType(typeof(OnlineCart))]
        public IHttpActionResult DeleteOnlineCart(int id)
        {
            OnlineCart onlineCart = db.OnlineCarts.Find(id);
            if (onlineCart == null)
            {
                return NotFound();
            }

            db.OnlineCarts.Remove(onlineCart);
            db.SaveChanges();

            return Ok(onlineCart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OnlineCartExists(int id)
        {
            return db.OnlineCarts.Count(e => e.Id == id) > 0;
        }
    }
}