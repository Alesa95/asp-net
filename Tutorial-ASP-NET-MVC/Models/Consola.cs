using System.ComponentModel.DataAnnotations;

namespace Tutorial_ASP_NET_MVC.Models
{
    public class Consola
    {
        public enum IvaType
        {
            SUPERREDUCIDO,
            REDUCIDO,
            GENERAL
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Tiene que tener entre 2 y 50 caracteres")]
        [Display(Name = "Consola")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0,10000)]
        [Display(Name = "Precio sin IVA")]
        public float PrecioBruto { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Tipo de IVA")]
        public IvaType TipoIva { get; set; }

        public ICollection<Videojuego>? Videojuegos { get; set; }
    }
}
