using KurumsalProjem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace KurumsalProjem.Core.DataAccess.EntityFramework
{
    //IEntityRepository de kalıplarını oluşturduğumuz metodları burada implement ediyoruz
    //EfEntityRepositoryBase 2 tane parametre alıyor. TEntity=hani tablo olduğu. TContext=Hangi framework kullandığımız.Entityframework,hibernate vs.
    //TEntity class olmak zorunda IEntity den miras alıyorve newlenebilir.
    //TContext DbContexten miras alıyor ve newlenebilir.
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        //tabloya ekleme işleminin yapıldığı yer
        public void Add(TEntity entity)
        {
            using (var context=new TContext())
            {
                var addedEntity=context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        //tablodan silme işleminin yapıldığı yer
        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        //tablodan tek bir kayıt çekmemize yarar
        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        //tablodan istenilen tablodan istenilen veriyi çekmemize yarar
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ?
                    context.Set<TEntity>().ToList() 
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        //tablodaki veriyi güncellememizi sağlar
        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var UpdatedEntity = context.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
