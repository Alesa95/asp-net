using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Tutorial_ASP_NET_MVC.Models
{
    public class Videojuego
    {
        public enum PegiType
        {
            [Display(Name = "PEGI 3")] pegi3,
            [Display(Name = "PEGI 7")] pegi7,
            [Display(Name = "PEGI 12")] pegi12,
            [Display(Name = "PEGI 16")] pegi16,
            [Display(Name = "PEGI 18")] pegi18
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(30, MinimumLength=2, ErrorMessage = "Debe tener entre 2 y 30 caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "PEGI")]
        public PegiType Pegi { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }

        public int? ConsolaId { get; set; }
        public Consola? Consola { get; set; }
    }
}
