namespace GestorFacturas.Models;
class Luz : Factura
{
    int ConsumoInicial { get; set; }
    int ConsumoFinal { get; set; }
    double ValorKw { get; set; }
    int ConsumoTotal => LecturaFinalRecibo - LecturaInicialRecibo;


    public Luz(double valorRecibo, int lecturaInicialRecibo, int lecturaFinalRecibo, DateTime fechaInicial, DateTime fechaFinal, int consumoInicial, int consumoFinal, double valorKw) : base(valorRecibo, lecturaInicialRecibo, lecturaFinalRecibo, fechaInicial, fechaFinal)
    {
        ConsumoInicial = consumoInicial;
        ConsumoFinal = consumoFinal;
        ValorKw = valorKw;
    }

    public (int c1, int c2) CalcularConsumos()
    {
        int consumo1 = ConsumoFinal - ConsumoInicial;
        int consumo2 = ConsumoTotal - consumo1;
        return (consumo1, consumo2);
    }

    public (double v1, double v2) CalcularPorcentajes()
    {
        double total = ConsumoTotal;
        var consumos = CalcularConsumos();
        double valor1 = consumos.c1;
        double valor2 = consumos.c2;
        double porcentaje1 = valor1 / total * 100;
        double porcentaje2 = valor2 / total * 100;
        return (porcentaje1, porcentaje2);
    }

    public (double total1, double total2) CalcularPagos()
    {
        var porcentajes = CalcularPorcentajes();
        double valorApto1 = (porcentajes.v1 / 100) * ValorRecibo;
        double valorApto2 = (porcentajes.v2 / 100) * ValorRecibo;
        return (Math.Round(valorApto1, 0), Math.Round(valorApto2, 0));
    }

    public (double total1, double total2) MetodoPago()
    {
        if (ConsumoTotal == 0) return (0, 0);
        
        else
        {
            return CalcularPagos();
        }
    }


    public override string ObtenerReporte()
    {
        var (c1, c2) = CalcularConsumos();
        var (p1, p2) = CalcularPorcentajes();
        var (total1, total2) = MetodoPago();

        return $@"------ Esta es la informacion de tu recibo de la luz: ------
Valor Total del Recibo: {ValorRecibo:C}

Lectura Anterior del Contador: {ConsumoInicial}
Lectura Actual del Contador: {ConsumoFinal}
Valor Kw del Recibo: {ValorKw:C0}
Total Kw Consumidos Durante el Mes: {ConsumoTotal}

Apto 1 Consumo: {c1} kw | Porcentaje: {p1:F2}%
Apto 2 Consumo: {c2} kw | Porcentaje: {p2:F2}%

Apto 1 Pago: {total1:C0}
Apto 2 Pago: {total2:C0}";
    }
}
