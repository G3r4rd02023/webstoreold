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
        private readonly IUserHelper _userHelper;
        public SeedDb(DataContext context,IImageHelper imageHelper,IUserHelper userHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync("0801-1990-13256", "Gerardo", "Lanza", "glanza007@gmail.com", "3307-7964", "Calle 36 24 51", "Manager");
            var owner = await CheckUserAsync("0714-1991-22020", "Maria Celeste", "Valle", "celeste@yopmail.com", "3634-2747", "Calle Luna Calle Sol", "Owner");
            var customer = await CheckUserAsync("0801-1992-42020", "Carlos Antonio", "Montoya", "carlos@yopmail.com", "3342-3747", "Calle Luna Calle Sol", "Customer");
            await CheckManagerAsync(manager);
            await CheckOwnersAsync(owner);
            await CheckCustomersAsync(customer);
            await CheckCountriesAsync();
            await CheckCategoriesAsync();
            await CheckCompaniesAsync();           
        }

        private async Task CheckOwnersAsync(User user)
        {
            if (!_context.Owners.Any())
            {
                _context.Owners.Add(new Owner { User = user });
                await _context.SaveChangesAsync();
            }

        }

        private async Task CheckManagerAsync(User user)
        {
            if (!_context.Managers.Any())
            {
                _context.Managers.Add(new Manager { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task<User>CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
            }

            return user;
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Manager");
            await _userHelper.CheckRoleAsync("Owner");
            await _userHelper.CheckRoleAsync("Customer");
        }

        private async Task CheckCustomersAsync(User user)
        {
            if (!_context.Customers.Any())
            {
                _context.Customers.Add(new Customer { User = user });
                await _context.SaveChangesAsync();
            }

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
