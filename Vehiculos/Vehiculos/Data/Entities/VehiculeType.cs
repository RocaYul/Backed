﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vehiculos.Data.Entities
{
    public class VehiculeType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Vehiculo")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
