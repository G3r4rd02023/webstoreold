﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webstore.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Producto")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Stock { get; set; }

        [DisplayName("Activo")]
        public bool IsActive { get; set; }

        [DisplayName("Disponible")]
        public bool IsStarred { get; set; }

        public Category Category { get; set; }

        public Company Company { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }

        public ICollection<OrderDetail> Items { get; set; }

        [DisplayName("#Imagenes")]
        public int ProductImagesNumber => ProductImages == null ? 0 : ProductImages.Count;

        [Display(Name = "Foto")]
        public string ImageFullPath => ProductImages == null || ProductImages.Count == 0
            ? $"https://localhost:44379/images/noimage.png"
            : ProductImages.FirstOrDefault().ImageFullPath;
    }
}
