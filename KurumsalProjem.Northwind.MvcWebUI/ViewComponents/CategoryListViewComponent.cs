using KurumsalProjem.Northwind.Business.Abstract;
using KurumsalProjem.Northwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurumsalProjem.Northwind.MvcWebUI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        //businestaki categoryservice katmanına ulaşmak için dependicies injection kullandık
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CategoryListViewModel
            {
                //tüm kategorileri çektik
                Categories = _categoryService.GetAll(),
                //tıklanan kategoriyi almak için currentcategory e attık
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"])
            };

        
            return View(model);
        }
        }

    }

