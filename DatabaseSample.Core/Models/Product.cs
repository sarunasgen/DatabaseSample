using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSample.Core.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public ProductCategory Category { get; set; }

        public Product()
        {

        }

        public override string ToString()
        {
            return $"{ProductId} | {ProductName} | {ProductPrice.ToString("F2")}EUR | {Category.ToString()}";
        }
    }
}
