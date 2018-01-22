using KurumsalProjem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KurumsalProjem.Northwind.Entities.Concrete
{
    //category tablosunu burada tanımladık
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
