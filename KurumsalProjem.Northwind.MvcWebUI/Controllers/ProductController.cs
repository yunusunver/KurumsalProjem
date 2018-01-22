using KurumsalProjem.Northwind.Business.Abstract;
using KurumsalProjem.Northwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurumsalProjem.Northwind.MvcWebUI.Controllers
{
    public class ProductController:Controller
    {

        //depencieny injection oluşturarak business katmanındaki productlara ulaşıyoruz
        private IProductService _productServise;

        public ProductController(IProductService productServise)
        {
            _productServise = productServise;
        }

        public ActionResult Index(int page=1,int category=0)
        {
            //category idsine göre ürünleri çekiyoruz
            var product = _productServise.GetByCategory(category);
            int pageSize = 10;

            //product viewmodel oluşturduk ve içine gerekli özellikleri yazdık.
            //products'a verileri çekiyoruz
            ProductListViewModel model = new ProductListViewModel
            {
                Products = product.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount=(int)Math.Ceiling(product.Count/(double)pageSize),
                PageSize=pageSize,
                CurrentCategory=category,
                CurrentPage=page
              
            };

            return View(model);
        }

    }
}
