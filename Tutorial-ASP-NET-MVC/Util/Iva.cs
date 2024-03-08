namespace Tutorial_ASP_NET_MVC.Util
{
    public abstract class Iva
    {
        public static double precioConIva (double precio, string tipoIva)
        {
            double precioConIva = 0;

            if (tipoIva == "SUPERREDUCIDO") precioConIva = precio * 1.04;
            else if (tipoIva == "REDUCIDO") precioConIva = precio * 1.12;
            else if (tipoIva == "GENERAL") precioConIva = precio * 1.21;

            return precioConIva;
        }
    }
}
