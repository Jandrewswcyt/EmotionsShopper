using EmotionsShopper.DataTypes.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmotionsShopper.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository; 

        public ProductController(IProductRepository repo)
        {
            repository = repo; 
        }

        public ViewResult List() => View(repository.Products); 

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
