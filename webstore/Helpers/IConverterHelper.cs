using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webstore.Data.Entities;
using webstore.Models;

namespace webstore.Helpers
{
    public interface IConverterHelper
    {
        Company ToCompany(CompanyViewModel model, string path, bool isNew);

        CompanyViewModel ToCompanyViewModel(Company company);

        Category ToCategory(CategoryViewModel model, string path, bool isNew);

        CategoryViewModel ToCategoryViewModel(Category category);
    }
}
