﻿using EmotionsShopper.DataTypes.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq; 

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmotionsShopper.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int ProductsPerPage = 4; 

        public ProductController(IProductRepository repo)
        {
            repository = repo; 
        }

        public ViewResult List( int page = 1) => View(repository.Products
            .OrderBy
            (p => p.ProductID) // order by id
            .Skip((page - 1) * ProductsPerPage) // skip all products before
            .Take(ProductsPerPage)); //take the number of products needed. 

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
