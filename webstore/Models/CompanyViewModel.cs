using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using webstore.Data.Entities;

namespace webstore.Models
{
    public class CompanyViewModel : Company
    {
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
