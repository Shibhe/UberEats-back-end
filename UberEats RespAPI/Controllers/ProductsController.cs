using AutoMapper;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using UberEats_RespAPI.Models;

namespace UberEats_RespAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private UberEatsEntities7 db = new UberEatsEntities7();
        private IMapper _mapper;
        
        // GET: api/Products
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(ProductDTO proDto)
        {
         
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
           // Product prod = new Product();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductDTO, Product>()
                .ForMember(img => img.itemImage, opt =>
               // opt.ResolveUsing(s => s.itemImage != null ? Convert.FromBase64String(s.itemImage) : null));
               opt.MapFrom(s => s.itemImage != null ? Convert.FromBase64String(s.itemImage) : null));
            });

            _mapper = config.CreateMapper();
           
            var userDto = _mapper.Map<Product>(proDto);    
            
            db.Products.Add(userDto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userDto.Id }, userDto);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
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
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}