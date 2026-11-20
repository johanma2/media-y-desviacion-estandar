using System;
using System.Globalization;

public class ConsolaUI
{
    public string PedirRutaArchivo()
    {
        Console.Write("Escribe la ruta del archivo: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public void MostrarError(string mensaje)
    {
        Console.WriteLine(mensaje);
    }

    public void MostrarResultado(ResultadoEstadistico resultado)
    {
        Console.WriteLine($"Cantidad de datos: {resultado.Cantidad}");
        Console.WriteLine($"Media: {resultado.Media.ToString("F2", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Desviación estándar: {resultado.DesviacionEstandar.ToString("F2", CultureInfo.InvariantCulture)}");
    }
}