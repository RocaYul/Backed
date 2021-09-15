using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vehiculos.Data.Entities
{
    public class TypeDocument
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de documento")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}
