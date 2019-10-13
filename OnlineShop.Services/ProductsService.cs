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
        #region Singleton
        public static ProductsService Instance
        {
            get
            {
                if (instance == null) instance = new ProductsService();

                return instance;
            }
        }
        private static ProductsService instance { get; set; }
        private ProductsService()
        {
        }
        #endregion


        public Product GetProduct(int ID)
        {
            using (var context = new DBContext())
            {
                return context.Products.Where(x => x.ID == ID).Include(x => x.Category).FirstOrDefault();
            }
        }

        public List<Product> GetProducts(List<int> IDs)
        {
            using (var context = new DBContext())
            {
                return context.Products.Where(product => IDs.Contains(product.ID)).ToList();
            }
        }

        public List<Product> GetProducts(int pageNo)
        {
            int pageSize = 5;

            using (var context = new DBContext())
            {
                //return context.Products.OrderBy(x=>x.ID).Skip((pageNo-1)* pageSize).Take(pageSize).Include(x => x.Category).ToList();

                return context.Products.Include(x => x.Category).ToList();
            }
        }
        public List<Product> GetProducts(int pageNo, int pageSize)
        {
            using (var context = new DBContext())
            {
                return context.Products.OrderByDescending(x => x.ID).Skip((pageNo - 1) * pageSize).Take(pageSize).Include(x => x.Category).ToList();
            }
        }


        public List<Product> GetProductsByCategory(int categoryID, int pageSize)
        {
            using (var context = new DBContext())
            {
                return context.Products.Where(x => x.Category.ID == categoryID).OrderByDescending(x => x.ID).Take(pageSize).Include(x => x.Category).ToList();
            }
        }

        public List<Product> GetLatestProducts(int numberOfProducts)
        {
            using (var context = new DBContext())
            {
                return context.Products.OrderByDescending(x => x.ID).Take(numberOfProducts).Include(x => x.Category).ToList();
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
