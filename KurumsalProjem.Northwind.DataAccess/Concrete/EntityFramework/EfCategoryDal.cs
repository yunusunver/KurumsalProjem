using KurumsalProjem.Core.DataAccess.EntityFramework;
using KurumsalProjem.Northwind.DataAccess.Abstract;
using KurumsalProjem.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KurumsalProjem.Northwind.DataAccess.Concrete.EntityFramework
{
    //Repositoryden category tablosu için Crud işlemlerini çeker
    public class EfCategoryDal:EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {
    }
}
