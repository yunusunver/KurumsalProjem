using KurumsalProjem.Northwind.Business.Abstract;
using KurumsalProjem.Northwind.DataAccess.Abstract;
using KurumsalProjem.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KurumsalProjem.Northwind.Business.ConCrete
{
    public class CategoryManager : ICategoryService
    {
        //Dataaccess katmanına ulaşmak için depencendies injection oluşturduk.
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        /*ekleme yapmak için dataaccess katmanındaki ekleme işlemini yaptık.Ui katmanında 
        business layerden çağıracağız.Business layerda dataaccess.Dataaccess de core katmanından veriyi getirecek.*/
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(int categoryId)
        {
            _categoryDal.Delete(new Category { CategoryId=categoryId});
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }


        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
