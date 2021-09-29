using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webstore.Data;
using webstore.Data.Entities;
using webstore.Models;

namespace webstore.Helpers
{
    public class ConverterHelper:IConverterHelper
    {
        private readonly DataContext _context;

        public ConverterHelper(DataContext context)
        {
            _context = context;
            
        }

        public Category ToCategory(CategoryViewModel model, string path, bool isNew)
        {
            return new Category
            {
                Id = isNew ? 0 : model.Id,
                LogoPath = path,
                Name = model.Name
            };
        }

        public CategoryViewModel ToCategoryViewModel(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                LogoPath = category.LogoPath,
                Name = category.Name
            };
        }

        public Company ToCompany(CompanyViewModel model, string path, bool isNew)
        {
            return new Company
            {
                Id = isNew ? 0 : model.Id,
                LogoPath = path,
                Name = model.Name
            };
        }

        public CompanyViewModel ToCompanyViewModel(Company company)
        {
            return new CompanyViewModel
            {
                Id = company.Id,
                LogoPath = company.LogoPath,
                Name = company.Name
            };
        }
    }
}
