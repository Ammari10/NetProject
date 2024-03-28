using EStore.Data.Base;
using EStore.Data.ViewModels;
using EStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                ProductName = data.ProductName,
                //ProductURL = data.ProductURL,
                Description = data.Description,
                ImageURL = data.ImageURL,
                Price = data.Price,
                Company = data.Company,
                ReleaseDate = data.ReleaseDate,
                Category = data.Category,
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var ProductDetails = await _context.Products
                .Include(p => p.Company)
                .FirstOrDefaultAsync(n => n.Id == id);

            return ProductDetails;
        }

        public async Task<NewProductDropdownsVM> GetNewProductDropdownsValues()
        {
            var response = new NewProductDropdownsVM()
            {
                Companies = await _context.Companies.OrderBy(n => n.CompanyName).ToListAsync(),
               
            };

            return response;
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbProduct != null)
            {
                dbProduct.ProductName = data.ProductName;
                dbProduct.Description = data.Description;
                dbProduct.Price = data.Price;
                dbProduct.ImageURL = data.ImageURL;
                dbProduct.CompanyId = data.CompanyId;
                dbProduct.ReleaseDate = data.ReleaseDate;
                dbProduct.Category = data.Category;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            /*var existingActorsDb = _context.Actors_Products.Where(n => n.ProductId == data.Id).ToList();
            _context.Actors_Products.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();*/
        }
    }
}
