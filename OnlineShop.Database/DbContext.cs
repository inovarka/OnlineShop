using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OnlineShop.Entities;

namespace OnlineShop.Database
{
    public class DBContext :DbContext
    {
        public DBContext() : base("OnlineShopConnection")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
