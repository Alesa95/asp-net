using Microsoft.AspNetCore.Mvc;

namespace Tutorial_ASP_NET_MVC.Controllers
{
    public class HolaMundoController : Controller
    {
        public IActionResult Index()
        {
            ViewData["mensaje"] = "Este es el mensaje";

            return View();
        }

        public IActionResult Adios(string frase, int veces)
        {
            ViewData["frase"] = frase;
            ViewData["veces"] = veces;

            return View();
        }

        /*public string Index()
        {
            return "Hola mundo";
        }

        public string Adios(string nombre, int edad)
        {
            return "Nombre: " + nombre + "\n" + "Edad: " + edad;
        }

        public string HastaLuego(string frase, int ID)
        {
            return frase + "\n" + ID;
        }*/
    }
}
