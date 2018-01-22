using KurumsalProjem.Northwind.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KurumsalProjem.Northwind.DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext:DbContext
    {
        //veritabanına bağlanma işlemini yaptık.Northwind veritabanına bağlandık.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-9P1JTP9\SQLEXPRESS;Database=NORTHWND;Trusted_Connection=True");
        }
        //Product ve Category classlarının veritabanı tablosu olduğunu tanıttık
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
    }
}
