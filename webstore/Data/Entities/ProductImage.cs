using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webstore.Data.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Product Product { get; set; }

        [Display(Name = "Foto")]
        public string ImageUrl { get; set; }

        // TODO: Change the path when publish
        [Display(Name = "Foto")]
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
           ? $"https://localhost:44379/images/noimage.png"
            : $"https://localhost:44379{ImageUrl[1..]}";
        //? "https://soccerweb.azurewebsites.net//images/noimage.png"
        //: $"https://soccerweb.azurewebsites.net{LogoPath.Substring(1)}";
    }
}
