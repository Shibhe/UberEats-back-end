using AutoMapper;
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
        // private Product prod = new Product();
        private IMapper _mapper;
        

        public byte[] convertToByte(ProductDTO pr)
        {
            byte[] bytes = new byte[pr.itemImage.Length * sizeof(char)];
            System.Buffer.BlockCopy(pr.itemImage.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
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
        public IHttpActionResult PostProduct(ProductDTO produ)
        {
           var prod = _mapper.Map<Product>(produ);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            prod = new Product
            {
                Id=produ.Id,
                itemImage = convertToByte(produ),
                itemName = produ.itemName,
                itemPrice = produ.itemPrice,
                itemType = produ.itemType,
                description = produ.description
            };

            db.Products.Add(prod);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prod.Id }, prod);
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