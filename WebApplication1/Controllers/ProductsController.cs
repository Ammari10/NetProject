using EStore.Data;
using EStore.Data.Enums;
using EStore.Data.Services;
using EStore.Data.Static;
using EStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync(n => n.Company);
            return View(allProducts);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _service.GetAllAsync(n => n.Company);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allProducts.Where(n => n.ProductName.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                return View("Index", filteredResult);
            }

            return View("Index", allProducts);
        }
        public async Task<IActionResult> GetByCompany(int CompanyId)
        {
            var allProducts = await _service.GetAllAsync(n => n.Company);

   
                var filteredResult = allProducts.Where(n => n.CompanyId.Equals(CompanyId)).ToList();

                return View("Index", filteredResult);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetByCategory(ProductCategory category )
        {
            var allProducts = await _service.GetAllAsync(n => n.Company);


            var filteredResult = allProducts.Where(n => n.Category.Equals(category)).ToList();

            return View("Index", filteredResult);
        }
  

        //GET: Products/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var ProductDetail = await _service.GetProductByIdAsync(id);
            return View(ProductDetail);
        }

        //GET: Products/Create
        public async Task<IActionResult> Create()
        {
            var ProductDropdownsData = await _service.GetNewProductDropdownsValues();

            ViewBag.Companies = new SelectList(ProductDropdownsData.Companies, "Id", "CompanyName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM Product)
        {
            if (!ModelState.IsValid)
            {
                var ProductDropdownsData = await _service.GetNewProductDropdownsValues();


                ViewBag.Companies = new SelectList(ProductDropdownsData.Companies, "Id", "CompanyName");

                return View(Product);
            }

            await _service.AddNewProductAsync(Product);
            return RedirectToAction(nameof(Index));
        }


        //GET: Products/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var ProductDetails = await _service.GetProductByIdAsync(id);
            if (ProductDetails == null) return View("NotFound");

            var response = new NewProductVM()
            {
                Id = ProductDetails.Id,
                ProductName = ProductDetails.ProductName,
                Description = ProductDetails.Description,
                ImageURL = ProductDetails.ImageURL,
                Price = ProductDetails.Price,
                Company = ProductDetails.Company,
                ReleaseDate = ProductDetails.ReleaseDate,
                Category = ProductDetails.Category,
                
            };

            var ProductDropdownsData = await _service.GetNewProductDropdownsValues();
            ViewBag.Companies = new SelectList(ProductDropdownsData.Companies, "Id", "CompanyName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM Product)
        {
            if (id != Product.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var ProductDropdownsData = await _service.GetNewProductDropdownsValues();

                ViewBag.Companies = new SelectList(ProductDropdownsData.Companies, "Id", "CompanyName");

                return View(Product);
            }

            await _service.UpdateProductAsync(Product);
            return RedirectToAction(nameof(Index));
        }
    }
}