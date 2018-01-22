using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KurumsalProjem.Northwind.Entities.Concrete;
using Microsoft.Extensions.Primitives;

namespace KurumsalProjem.Northwind.MvcWebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; internal set; }
        public int CurrentCategory { get; internal set; }
    }
}
