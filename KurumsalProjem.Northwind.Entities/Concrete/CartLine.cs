using System;
using System.Collections.Generic;
using System.Text;

namespace KurumsalProjem.Northwind.Entities.Concrete
{
    public class CartLine
    {
        //ürün
        public Product Product { get; set; }
        //miktarı
        public int Quantity { get; set; }
    }
}
