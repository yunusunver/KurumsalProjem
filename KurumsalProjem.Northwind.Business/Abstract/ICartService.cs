using KurumsalProjem.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KurumsalProjem.Northwind.Business.Abstract
{
    public interface ICartService
    {
        //Cart kalıbını oluşturduk.Ekleme çıkarma ve listeleme yapacağız.
        void AddToCart(Cart cart,Product product);
        void RemoveToCart(Cart cart,int productId);
        List<CartLine> List(Cart cart);
       
    }
}
