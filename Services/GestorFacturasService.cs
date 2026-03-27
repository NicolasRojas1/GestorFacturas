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
        //Gas recibo = new(52660, 1143, 1167, new DateTime(2026, 01, 07), new DateTime(2026, 02, 07), 811, 824, 4186);
        double valor = LeerDouble("Valor total del recibo: ");
        int ini = LeerEntero("Ingrese la lectura inicial del recibo: ");
        int fin = LeerEntero("Ingrese la lectura final del recibo: ");
        DateTime fechaInicial = new(2026, 01, 07);
        DateTime fechaFinal = new(2026, 02, 07);
        int consumoIni = LeerEntero("Consumo inicial del contador: ");
        int consumoFin = LeerEntero("Consumo final del contador: ");
        double cargoFijo = LeerDouble("Ingrese el valor del cargo fijo del recibo: ");

        //Creacion
        Gas recibo = new(valor, ini, fin, fechaInicial, fechaFinal, consumoIni, consumoFin, cargoFijo);

        //Llamado
        WriteLine("\n--- PROCESANDO CÁLCULOS ---");
        recibo.ShowInfo();
    }

    // -------------- Validadores --------------
    private int LeerEntero(string mensaje)
    {
        int resultado;
        while (true)
        {
            Write(mensaje);
            string? entrada = ReadLine();

            if (int.TryParse(entrada, out resultado))
            {
                return resultado; // Salimos del método con el número listo
            }

            WriteLine("❌ Error: Por favor, ingresa un número entero válido.");
        }
    }

    private double LeerDouble(string mensaje)
    {
        double resultado;
        while (true)
        {
            Write(mensaje);
            string? entrada = ReadLine();

            if(double.TryParse(entrada, out resultado))
            {
                return resultado;
            }
            WriteLine("❌ Error: Debe ser un número (ej: 1500,50)");
        }
    }
}