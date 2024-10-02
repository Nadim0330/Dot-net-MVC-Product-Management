using BestStoreMVC.Models;
using BestStoreMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO.Pipelines;

namespace BestStoreMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public  ProductController(ApplicationDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var producttable = context.products.OrderByDescending(p=>p.Id).ToList();
            return View(producttable);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductDto productdto)
        {
            if (productdto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile","Image file is required");
            }
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("Form hi invalid hai");
                return View(productdto);
            }
          
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //to get the file extention
            newFileName += Path.GetExtension(productdto.ImageFile!.FileName);

            string imageFullPath = webHostEnvironment.WebRootPath + "/product/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                productdto.ImageFile.CopyTo(stream);
            }

            //saving the data in database
            Product product = new Product()
            {
                NroductName = productdto.NroductName,
                Description = productdto.Description,
                Brand = productdto.Brand,
                Category = productdto.Category,
                Price = productdto.Price,
                ImageFileName = newFileName,
                CreatedOn = DateTime.Now

            };
            context.products.Add(product);
            context.SaveChanges();
            
            return RedirectToAction("Index","Product");

        }

        public IActionResult Edit(int id)
        {
            var product = context.products.Find(id);
            if (product == null) {
                return RedirectToAction("Index", "Product");
            }

            var productDto = new ProductDto()
            {
                NroductName=product.NroductName,
                Brand=product.Brand,
                Category=product.Category,
                Price=product.Price,
                Description=product.Description
            };

            ViewData["ProductId"] = product.Id;
            ViewData["ImageFileName"] = product.ImageFileName;
            ViewData["CreatedOn"] = product.CreatedOn.ToString("MM/dd/yyyy");
            return View(productDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProductDto productdto) 
        {
            var product = context.products.Find(id);

            if (product == null)
            {
                return RedirectToAction("Index", "Product");
            }

            if (!ModelState.IsValid)
            {
                ViewData["ProductId"] = product.Id;
                ViewData["ImageFileName"] = product.ImageFileName;
                ViewData["CreatedOn"] = product.CreatedOn.ToString("MM/dd/yyyy");

                return View(productdto);
            }
            //update the image file
            string newFileName = product.ImageFileName;
            if (productdto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHssfff");
                newFileName += Path.GetExtension(productdto.ImageFile.FileName);

                string imageFullpath = webHostEnvironment.WebRootPath + "/product/" + newFileName;
                using(var stream = System.IO.File.Create(imageFullpath))
                {
                    productdto.ImageFile.CopyTo(stream);
                }

                //delete the old image
                string oldImageFullPath = webHostEnvironment.WebRootPath + "/product" + product.ImageFileName;
                System.IO.File.Delete(oldImageFullPath);
            }

            product.NroductName = productdto.NroductName;
            product.Description = productdto.Description;
            product.Brand = productdto.Brand;
            product.Category = productdto.Category;
            product.Price = productdto.Price;
            product.ImageFileName = newFileName;


            context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Delete(int Id) {
            var product = context.products.Find(Id);
            if (product == null)
            {
                return RedirectToAction("Index", "Product");
            }

            string imageFullPath = webHostEnvironment.WebRootPath + "/product/" + product.ImageFileName;
            System.IO.File.Delete(imageFullPath);

            context.products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index", "Product");


        }

    }
}
