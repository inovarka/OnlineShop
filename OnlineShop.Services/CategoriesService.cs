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
    public class CategoriesService
    {
        #region Singleton
        public static CategoriesService Instance
        {
            get
            {
                if (instance == null) instance = new CategoriesService();

                return instance;
            }
        }
        private static CategoriesService instance { get; set; }
        private CategoriesService()
        {
        }
        #endregion

        public Category GetCategory(int ID)
        {
            using (var context = new DBContext())
            {
                return context.Categories.Find(ID);
            }
        }

        public List<Category> GetCategories()
        {
            using (var context = new DBContext())
            {
                return context.Categories.Include(x => x.Products).ToList();
            }
        }

        public List<Category> GetFeaturedCategories()
        {
            using (var context = new DBContext())
            {
                //return null;
                return context.Categories.Where(x => x.isFeatured && x.ImageURL != null).ToList();
            }
        }

        public void SaveCategory(Category category)
        {
            using(var context = new DBContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
        public void UpdateCategory(Category category)
        {
            using (var context = new DBContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int ID)
        {
            using (var context = new DBContext())
            {
                var category = context.Categories.Find(ID);

                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }
    }
}
