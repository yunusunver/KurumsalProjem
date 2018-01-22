using KurumsalProjem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace KurumsalProjem.Core.DataAccess
{
    //DataAccess repositoryde kullanılacak metodların kalıplarnı buraya oluşturduk.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //tek bir veriyi çekmek için kullanılan metod
        T Get(Expression<Func<T, bool>> filter=null);

        //istenilen tablodan istenilen verileri listeler
        List<T> GetList(Expression<Func<T,bool>> filter=null);

        //istenilen tabloya veri eklemek için kullanılan metod
        void Add(T entity);

        //istenilen tablodaki bir veriyi güncellemimize yarayan metod
        void Update(T entity);

        //istenilen bir tablodan veriyi silmemizi sağlayan metod
        void Delete(T entity);
    }
}
