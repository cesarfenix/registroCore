using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace registroCore.Models
{
    public class Persona
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string nombre { get; set; }


        [Required(ErrorMessage = "El email es obligatorio")]
        [DataType(DataType.EmailAddress)]

        public string correo { get; set; }


        [Required(ErrorMessage = "La fecha es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime fechaNacimiento { get; set; }
        
        

    }
}
