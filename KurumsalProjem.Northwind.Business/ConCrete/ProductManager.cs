using KurumsalProjem.Northwind.Business.Abstract;
using KurumsalProjem.Northwind.DataAccess.Abstract;
using KurumsalProjem.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KurumsalProjem.Northwind.Business.ConCrete
{
    public class ProductManager : IProductService
    {
        //Dataaccess katmanına ulaşmak için depencendies injection oluşturduk.

        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        /*ekleme yapmak için dataaccess katmanındaki ekleme işlemini yaptık.Ui katmanında 
       business layerden çağıracağız.Business layerda dataaccess.Dataaccess de core katmanından veriyi getirecek.*/
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

       

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { ProductId=productId});
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(x=>x.CategoryId==categoryId || categoryId==0);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public Product GetById(int productId) {
            return _productDal.Get(x=>x.ProductId==productId);
        }
    }
}
