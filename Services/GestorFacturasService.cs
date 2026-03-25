namespace GestorFacturas.Services;
using GestorFacturas.Models;

public class GestorFacturasService
{
    public void EjecutarRegistroAgua()
    {
        Agua miRecibo = new(
        296080,           // Valor Total
        1978,             // Lectura Inicial Recibo
        2001,             // Lectura Final Recibo
        DateTime.Now,     // Fecha Inicial
        DateTime.Now,     // Fecha Final
        90642.10,         // Acueducto
        87139.06,         // Alcantarillado
        118200,           // Aseo
        98,               // Otros
        4,                // ¿Cuántos apartamentos son?
        null              // NULL PARA QUE PIDA LOS DATOS
    );

    // Una vez el constructor termine de pedir los datos por consola...
    miRecibo.ShowInfo();
    }

    public void EjecutarRegistroLuz()
    {
        Luz reciboLuz = new(101040, 11387, 11543, new DateTime(2026, 07, 01), new DateTime(2026, 07, 02), 7244, 7359, 740.25);
        reciboLuz.ShowInfo();
    }

    public void EjecutarRegistroGas()
    {
        Gas recibo = new(52660, 1143, 1167, new DateTime(2026, 01, 07), new DateTime(2026, 02, 07), 811, 824, 4186);
        recibo.ShowInfo();
    }
}