using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webstore.Data.Entities
{
    public class User:IdentityUser
    {
        [Display(Name = "DNI")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Foto")]
        public string ImageUrl { get; set; }

        // TODO: Change the path when publish
        [Display(Name = "Foto")]
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
           ? $"https://localhost:44379/images/noimage.png"
            : $"https://localhost:44379{ImageUrl[1..]}";
        //? "https://soccerweb.azurewebsites.net//images/noimage.png"
        //: $"https://soccerweb.azurewebsites.net{LogoPath.Substring(1)}";

        public Country Country { get; set; }

        public ICollection<Manager> Managers { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public ICollection<Owner> Owners { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<OrderDetailTemp> OrderDetailTemps { get; set; }
    }
}
