﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.Common.Enums;

namespace Vehiculos.Data.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Segundo nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }

        [Display(Name = "Tipo de documento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string DocumentType { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Display(Name = "Direccion")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Address { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }
        [Display(Name = "Foto")]
        //Backed information of imagen
        public string ImageFullPath => ImageId == Guid.Empty
             ? $"https://localhost:44300/Images/noimage.png"
            : $"https://vehiclessalazar.blob.core.windows.net/users/{ImageId}";

        [Display(Name = "Tipo de documento")]
        public UserType UserType { get; set; }

        [Display(Name = "Tipo de documento")]
        public string Fullname => $"{FirstName} {LastName}";

    }
}