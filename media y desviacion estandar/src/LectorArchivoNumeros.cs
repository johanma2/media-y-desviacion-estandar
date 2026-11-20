using System;
using System.Globalization;
using System.IO;

public class LectorArchivoNumeros
{
    public string RutaArchivo { get; private set; } = string.Empty;

    public ListaEnlazada Leer(string ruta)
    {
        RutaArchivo = ruta ?? string.Empty;

        if (string.IsNullOrWhiteSpace(RutaArchivo))
        {
            throw new ArgumentException("No se indicó ninguna ruta.");
        }

        if (!File.Exists(RutaArchivo))
        {
            throw new FileNotFoundException($"El archivo no existe: {RutaArchivo}");
        }

        ListaEnlazada lista = new ListaEnlazada();
        int numeroDeLinea = 0;

        try
        {
            using StreamReader lector = new StreamReader(RutaArchivo);
            string? linea;

            while ((linea = lector.ReadLine()) != null)
            {
                numeroDeLinea++;
                string textoLimpio = linea.Trim();

                if (string.IsNullOrEmpty(textoLimpio))
                {
                    continue;
                }

                if (textoLimpio.Contains(',') ||
                    !double.TryParse(
                        textoLimpio,
                        NumberStyles.Float,
                        CultureInfo.InvariantCulture,
                        out double valor) ||
                    double.IsNaN(valor) ||
                    double.IsInfinity(valor))
                {
                    throw new FormatException($"Dato inválido en la línea {numeroDeLinea}: {textoLimpio}");
                }

                lista.Agregar(valor);
            }
        }
        catch (IOException)
        {
            throw;
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new IOException($"No se pudo acceder al archivo: {ex.Message}", ex);
        }

        if (lista.Cantidad == 0)
        {
            throw new InvalidOperationException("El archivo no contiene datos numéricos.");
        }

        return lista;
    }
}