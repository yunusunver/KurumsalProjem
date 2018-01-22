using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KurumsalProjem.Northwind.Entities.Concrete
{
    //Sepetimizin tutulduğu class
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }
        //ürünleri listele
        public List<CartLine> CartLines { get; set; }

        //sepet toplam fiyatı
        public decimal Total
        {
            get { return CartLines.Sum(x => x.Product.UnitPrice * x.Quantity); }
        }
    }
}
