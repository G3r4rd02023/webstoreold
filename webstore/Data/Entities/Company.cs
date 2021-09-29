using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webstore.Data.Entities
{
    public class Company
    {
        public int Id { get; set; }

        [Display(Name = "Empresa")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Logo")]
        public string LogoPath { get; set; }

        [Display(Name = "Logo")]
        public string LogoFullPath => string.IsNullOrEmpty(LogoPath)
            ? $"https://localhost:44379/images/noimage.png"
            : $"https://localhost:44379{LogoPath[1..]}";
       //? "https://soccerweb.azurewebsites.net//images/noimage.png"
       //: $"https://soccerweb.azurewebsites.net{LogoPath.Substring(1)}";


    }
}
