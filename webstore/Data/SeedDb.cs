using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using webstore.Data.Entities;
using webstore.Helpers;
using webstore.Models;

namespace webstore.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;
        public SeedDb(DataContext context,IImageHelper imageHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCategoriesAsync();
            await CheckCompaniesAsync();           
        }
       
        private async Task CheckCompaniesAsync()
        {
            if (!_context.Companies.Any())
            {
                AddCompany("handmade");
                AddCompany("autoservice");
                AddCompany("vevashop");
                await _context.SaveChangesAsync();
            }
        }

        private void AddCompany(string name)
        {
            _context.Companies.Add(new Company { Name = name, LogoPath = $"~/images/Companies/{name}.png" });
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                 AddCategory("Ropa");
                 AddCategory("Tecnología");
                 AddCategory("Mascotas");
                 await _context.SaveChangesAsync();
            }
        }

        private void AddCategory(string name)
        {
            _context.Categories.Add(new Category { Name = name, LogoPath = $"~/images/Categories/{name}.png" });
        }

        private async Task CheckCountriesAsync()
        {
            if(!_context.Countries.Any())
            {
                AddCountry("Honduras");
                AddCountry("Costa Rica");
                AddCountry("Guatemala");
                AddCountry("El Salvador");
                AddCountry("Nicaragua");
                AddCountry("Mexico");
                AddCountry("Estados Unidos");
                await _context.SaveChangesAsync();
            }
        }

        private void AddCountry(string name)
        {
            _context.Countries.Add(new Country { Name = name });
        }
    }
}
