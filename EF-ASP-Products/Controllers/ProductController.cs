using EF_ASP_Products.Data;
using EF_ASP_Products.Models;
using EF_ASP_Products.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_ASP_Products.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult GetAll(int? categoryId)
        {
            var products = _context.Products.Include(p => p.Category).ToList();

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var category= _context.Categorys.ToList();
            ViewData["Categorys"]=category;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel products)
        {
            if(ModelState.IsValid)
            {

                _context.Products.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetAll");
            }
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id) 
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetAll");
        }

        
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); 
            }

            var viewModel = new ProductUpdateViewModel
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl
            };

            return View(viewModel);

        }


        [HttpPost]
        public async Task<IActionResult> Update(int id, ProductUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            product.Title = model.Title;
            product.Description = model.Description;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;

            await _context.SaveChangesAsync();

            return RedirectToAction("GetAll");

        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            var categories = _context.Categorys.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryViewModel Categorys)
        {
            if (ModelState.IsValid)
            {

                _context.Categorys.Add(Categorys);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetCategory");
            }
            return View(Categorys);
        }




    }
}
