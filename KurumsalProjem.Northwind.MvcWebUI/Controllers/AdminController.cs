using KurumsalProjem.Northwind.Business.Abstract;
using KurumsalProjem.Northwind.Entities.Concrete;
using KurumsalProjem.Northwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurumsalProjem.Northwind.MvcWebUI.Controllers
{
    [Authorize]
    public class AdminController:Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService,ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var productListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };

            return View(productListViewModel);
        }

        public ActionResult Add() {

            var productAddViewModel = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll()
            };
            return View(productAddViewModel);
        }

        [HttpPost]
        public ActionResult Add(Product product) {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("message","product wa succesfully added");
            }
            return RedirectToAction("Add");
        }

        public ActionResult Update(int productId)
        {
            var productUpdateViewModel = new ProductUpdateViewModel
            {
                Product = _productService.GetById(productId),
                Categories = _categoryService.GetAll()
            };
            return View(productUpdateViewModel);
        }

        [HttpPost]
        public ActionResult Update(Product product) {

            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message","Product was succefully updated");
            }
            return RedirectToAction("Update");
        }

        public ActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            TempData.Add("message", "Product was succefully deleted");
            return RedirectToAction("Index");
        }
    }
}
