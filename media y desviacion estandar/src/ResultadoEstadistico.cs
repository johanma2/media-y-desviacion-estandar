public class ResultadoEstadistico
{
    public int Cantidad { get; }
    public double Media { get; }
    public double DesviacionEstandar { get; }

    public ResultadoEstadistico(int cantidad, double media, double desviacionEstandar)
    {
        Cantidad = cantidad;
        Media = media;
        DesviacionEstandar = desviacionEstandar;
    }
}