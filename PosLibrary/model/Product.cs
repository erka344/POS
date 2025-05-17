using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary.model
{
    public class Product
    {
        public int BarCode { get; set; }
        public string Name { get; set; }
        public int price { get; set; }
        public int CategoryId { get; set; }
        public int Discount { get; set; }
        public int resource {  get; set; }
    }
}
