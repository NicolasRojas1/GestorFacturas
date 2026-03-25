namespace GestorFacturas.Models;

class Agua : Factura
{
    public double ValorAcueducto { get; set; }
    public double ValorAlcantarillado { get; set; }
    public double ValorAseo { get; set; }
    public double OtroCobro { get; set; }
    public int NumeroApartamentos { get; set; }
    public List<LecturaApto> ListaAptos { get; set; }

    public Agua(double valorRecibo, int lecturaInicialRecibo, int lecturaFinalRecibo, DateTime fechaInicial, DateTime fechaFinal, double valorAcueducto, double valorAlcantarillado, double valorAseo, double otrosCobros, int numAptos, List<LecturaApto>? listaAptos)
    : base(valorRecibo, lecturaInicialRecibo, lecturaFinalRecibo, fechaInicial, fechaFinal)
    {
        ValorAcueducto = valorAcueducto;
        ValorAlcantarillado = valorAlcantarillado;
        ValorAseo = valorAseo;
        OtroCobro = otrosCobros;
        NumeroApartamentos = numAptos;
        //ListaAptos = listaAptos;

        if (listaAptos == null || listaAptos.Count == 0)
        {
            ListaAptos = new List<LecturaApto>();

            for (int i = 1; i <= NumeroApartamentos; i++)
            {
                Console.WriteLine($"\n--- Registro de Lecturas: Apto {i} ---");

                Console.Write("Lectura Inicial : ");
                int ini = int.Parse(Console.ReadLine() ?? "");

                Console.Write("Lectura Intermedia: ");
                int inter = int.Parse(Console.ReadLine() ?? "");

                Console.Write("Lectura Final: ");
                int fin = int.Parse(Console.ReadLine() ?? "");

                ListaAptos.Add(new LecturaApto
                {
                    PrimeraLectura = ini,
                    SegundaLectura = inter,
                    TerceraLectura = fin
                });
            }
        }
        else
        {
            ListaAptos = listaAptos;
        }
    }
    public double CalcularAseo()
    {
        if (NumeroApartamentos == 0) return 0;
        double VUnitarioAseo = ValorAseo / NumeroApartamentos;
        return VUnitarioAseo;

    }
    public double CalcularMetroPorConcepto(double valorDelServicio)
    {
        int totalConsumo = 0;
        foreach (var apto in ListaAptos)
        {
            totalConsumo += apto.CosumoReal;
        }

        if (totalConsumo == 0) return 0;
        return valorDelServicio / totalConsumo;
    }


    public override void ShowInfo()
    {
        double totalServicios = ValorAcueducto + ValorAlcantarillado + ValorAseo;
        //Calculo de precios unitarios
        double aseoPorApto = CalcularAseo();
        double valorUnitarioAcueducto = CalcularMetroPorConcepto(ValorAcueducto);
        double valorUnitarioAlcantarillado = CalcularMetroPorConcepto(ValorAlcantarillado);

        WriteLine($@"------ Factura de Agua para {NumeroApartamentos} Apartamentos ------
Valor Acueducto: {ValorAcueducto:C0}
Valor Alcantarillado: {ValorAlcantarillado:C0}
Valor Aseo: {ValorAseo:C0}
Otros Cobros: {OtroCobro:C0}
--------------------------------------------------
Total a Distribuir: {totalServicios:C0}
Lectura General Inicial: {LecturaInicialRecibo}
Lectura General Final: {LecturaFinalRecibo}
Total Metros Consumidos (Recibo): {LecturaFinalRecibo - LecturaInicialRecibo} m3
Valor Aseo por Apartamento: {aseoPorApto:C0}
Valor Unitario m3 Acueducto: {valorUnitarioAcueducto:C0}
Valor Unitario m3 Alcantarillado: {valorUnitarioAlcantarillado:C0}
--------------------------------------------------");

        foreach (var apto in ListaAptos)
        {
            //Calculo de consumo x precio unitario
            double subtotalAcueducto = apto.CosumoReal * valorUnitarioAcueducto;
            double subtotalAlcantarillado = apto.CosumoReal * valorUnitarioAlcantarillado;

            //Total a pagar
            double totalApto = subtotalAcueducto + subtotalAlcantarillado + aseoPorApto;
            int id = ListaAptos.IndexOf(apto) + 1;
            WriteLine($@"Apto {id}:
   Lecturas: 
   Inicial: {apto.PrimeraLectura} | Intermedia: {apto.SegundaLectura} | Final: {apto.TerceraLectura}]
   Consumo Individual: {apto.CosumoReal} m3
   - Acueducto:        {subtotalAcueducto:C0}
   - Alcantarillado:   {subtotalAlcantarillado:C0}
   - Aseo:             {aseoPorApto:C0}
   => TOTAL A PAGAR:   {totalApto:C0}
   ");
        }
        WriteLine($@"Valor a pagar por el propietario: {OtroCobro:C0}");
    }

}


class LecturaApto
{
    public int PrimeraLectura { get; set; }
    public int SegundaLectura { get; set; }
    public int TerceraLectura { get; set; }
    public int CosumoReal => TerceraLectura - PrimeraLectura;

}

