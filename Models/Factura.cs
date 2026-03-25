namespace GestorFacturas.Models;
public class Factura
{
    public double ValorRecibo { get; set; }
    public int LecturaInicialRecibo { get; set; }
    public int LecturaFinalRecibo { get; set; }
    public DateTime FechaInicial { get; set; }
    public DateTime FechaFinal { get; set; }

    public Factura(double valorRecibo, int lecturaInicialRecibo, int lecturaFinalRecibo, DateTime fechaInicial, DateTime fechaFinal)
    {
        ValorRecibo = valorRecibo;
        LecturaInicialRecibo = lecturaInicialRecibo;
        LecturaFinalRecibo = lecturaFinalRecibo;
        FechaInicial = fechaInicial;
        FechaFinal = fechaFinal;
    }

    public virtual void ShowInfo(){}
}