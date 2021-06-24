﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libros.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El Título es obligatorio")]
        [StringLength(50, ErrorMessage ="El {0} debe ser almenos {2} y máximo {1} Carácteres", MinimumLength = 3)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La Descripción es obligatoria")]
        [StringLength(50, ErrorMessage = "El {0} debe ser almenos {2} y máximo {1} Carácteres", MinimumLength = 3)]
        [Display(Name = "Descripción")]
        public string Descripción { get; set; }

        [Required(ErrorMessage = "El Fecha es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }

        [Required(ErrorMessage = "El Autor es obligatorio")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "El Precio es obligatorio")]
        public int Precio { get; set; }
    }
}
