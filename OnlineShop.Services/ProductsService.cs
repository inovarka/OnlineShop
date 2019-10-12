using OnlineShop.Database;
using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OnlineShop.Services
{
    public class ProductsService
    {
        public Product GetProduct(int ID)
        {
            using (var context = new DBContext())
            {
                return context.Products.Find(ID);
                // return
            }
        }

        public List<Product> GetProducts()
        {
            using (var context = new DBContext())
            {
                return context.Products.Include(x=>x.Category).ToList();
            }
        }

        public void SaveProduct(Product product)
        {
            

            using (var context = new DBContext())
            {
                //preventing category double
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;

                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public void UpdateProduct(Product product)
        {
            using (var context = new DBContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int ID)
        {
            using (var context = new DBContext())
            {
                var product = context.Products.Find(ID);

                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
