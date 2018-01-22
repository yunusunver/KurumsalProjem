using KurumsalProjem.Core.DataAccess;
using KurumsalProjem.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KurumsalProjem.Northwind.DataAccess.Abstract
{
    //Repositoryden product tablosu için Crud işlemlerini çeker
    public interface IProductDal:IEntityRepository<Product>
    {

        ////tek bir veriyi çekmek için kullanılan metod
        //T Get(Expression<Func<T, bool>> filter = null);

        ////istenilen tablodan istenilen verileri listeler
        //List<T> GetList(Expression<Func<T, bool>> filter = null);

        ////istenilen tabloya veri eklemek için kullanılan metod
        //void Add(T entity);

        ////istenilen tablodaki bir veriyi güncellemimize yarayan metod
        //void Update(T entity);

        ////istenilen bir tablodan veriyi silmemizi sağlayan metod
        //void Delete(T entity);
    }
}
