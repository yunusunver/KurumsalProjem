using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KurumsalProjem.Northwind.Entities.Concrete;

namespace KurumsalProjem.Northwind.MvcWebUI.Models
{
    public class CartSummaryViewModel
    {
        public Cart Cart { get; internal set; }
    }
}
