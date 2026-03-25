namespace GestorFacturas.Models;

class Gas : Factura
{
    public int ConsumoInicial { get; set; }
    public int ConsumoFinal { get; set; }
    public double CargoFijo { get; set; }
    int ConsumoTotal => LecturaFinalRecibo - LecturaInicialRecibo;

    public Gas(double valorRecibo, int lecturaInicialRecibo, int lecturaFinalRecibo, DateTime fechaInicial, DateTime fechaFinal, int consumoInicial, int consumoFinal, double cargoFijo)
    : base(valorRecibo, lecturaInicialRecibo, lecturaFinalRecibo, fechaInicial, fechaFinal)
    {
        ConsumoInicial = consumoInicial;
        ConsumoFinal = consumoFinal;
        CargoFijo = cargoFijo;
    }

    public (int c1, int c2) CalcularConsumos()
    {
        int consumo1 = ConsumoFinal - ConsumoInicial;
        int consumo2 = ConsumoTotal - consumo1;
        return (consumo1, consumo2);
    }

    public (double v1, double v2) CalcularPorcentajes()
    {
        if (ConsumoTotal == 0)
        {
            return (50, 50);
        }
        var consumos = CalcularConsumos();
        double consumo1 = consumos.c1;
        double consumo2 = consumos.c2;
        double porcentaje1 = consumo1 / ConsumoTotal * 100;
        double porcentaje2 = consumo2 / ConsumoTotal * 100;
        return (porcentaje1, porcentaje2);
    }

    public (double total1, double total2) CalcularPagos()
    {
        if (CalcularPorcentajes() == (0, 0))
        {
            var porcentajes = CalcularPorcentajes();
            double valorApto1 = porcentajes.v1 / 100 * CargoFijo;
            double valorApto2 = porcentajes.v2 / 100 * CargoFijo;
            return (valorApto1, valorApto2);
        }
        else
        {
            var porcentajes = CalcularPorcentajes();
            double valorApto1 = porcentajes.v1 / 100 * ValorRecibo;
            double valorApto2 = porcentajes.v2 / 100 * ValorRecibo;
            return (Math.Round(valorApto1, 0), Math.Round(valorApto2, 0));
        }
    }
    public override void ShowInfo()
    {
        var (c1, c2) = CalcularConsumos();
        var (p1, p2) = CalcularPorcentajes();
        var (total1, total2) = CalcularPagos();

        WriteLine($@"
==================================================
      🔥 REPORTE DE CONSUMO DE GAS 🔥
==================================================
[ DATOS DEL RECIBO ]
--------------------------------------------------
Periodo:        {FechaInicial:d} al {FechaFinal:d}
Valor Total:    {ValorRecibo:C0}
Cargo Fijo:     {CargoFijo:C0}

Lectura Recibo: {LecturaInicialRecibo} m3 - {LecturaFinalRecibo} m3
Lectura Medidor:{ConsumoInicial} m3 - {ConsumoFinal} m3
--------------------------------------------------

[ DISTRIBUCIÓN POR APARTAMENTO ]
--------------------------------------------------
APTO 1:
   Consumo:      {c1} m3 ({p1:F1}%)
   VALOR A PAGAR: {total1:C0}

APTO 2:
   Consumo:      {c2} m3 ({p2:F1}%)
   VALOR A PAGAR: {total2:C0}
--------------------------------------------------
    *Cálculos basados en el consumo real del medidor*
==================================================");
    }
}

