using KurumsalProjem.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KurumsalProjem.Northwind.Business.Abstract
{
    public interface ICategoryService
    {
        //istediğimizin metodların kalıplarını yazdık.
        List<Category> GetAll();
        void Add(Category category);
        void Update(Category category);
        void Delete(int categoryId);
    }
}
