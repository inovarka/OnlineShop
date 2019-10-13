using OnlineShop.Database;
using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    public class ConfigurationsService
    {
        public Config GetConfig(string Key)
        {
            using (var context = new DBContext())
            {
                return context.Configurations.Find(Key);
            }
        }
    }
}
