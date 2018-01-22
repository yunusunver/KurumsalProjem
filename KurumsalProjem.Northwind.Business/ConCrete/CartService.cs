using KurumsalProjem.Northwind.Business.Abstract;
using KurumsalProjem.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KurumsalProjem.Northwind.Business.ConCrete
{
    public class CartService : ICartService
    {
        //card kalıbının içini doldurduk.Ekleme çıkarma listeleme metodlarının içini doldurduk.

        public void AddToCart(Cart cart, Product product)
        {
            //ekleme işlemi yaparken o üründen eğer varsa sayısını artıracak yoksa bitane olarak tanımlanacak.
            CartLine cartLine = cart.CartLines.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
            //eğer cartLinede eklenen ürün varsa 1 artacak
            if (cartLine!=null)
            {
                //bir artır
                cartLine.Quantity++;
                return;
            }
            //eğer yoksa yeni birtane cartline classı newlenir ve miktarı 1 olarak tanımlanır.
            cart.CartLines.Add(new CartLine { Product=product,Quantity=1});
        }

        //Cart sınıfında bulunan cartlines nesnesi çağıralarak kaçtane ürün olduğu listelenir
        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        //seçilen ürünün silinmesi işlemi yapılır
        public void RemoveToCart(Cart cart, int productId)
        {
            //product id sine göre bakar ve bulunca o ürünü siler.
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(x => x.Product.ProductId==productId));
        }
    }
}
