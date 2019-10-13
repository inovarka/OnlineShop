using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Entities
{
    public class Product :BaseEntity
    {
        public virtual Category Category { get; set; }

        //public int CategoryID { get; set; }
        [Range(1, 100000)]
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
    }
}
