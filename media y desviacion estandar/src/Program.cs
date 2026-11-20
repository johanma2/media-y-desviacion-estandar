using System;
using System.IO;

public class Program
{
    public static int Main(string[] args)
    {
        ConsolaUI consola = new ConsolaUI();

        try
        {
            string ruta = (args != null && args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
                ? args[0].Trim()
                : consola.PedirRutaArchivo().Trim();

            if (string.IsNullOrWhiteSpace(ruta))
            {
                throw new ArgumentException("No se indicó ninguna ruta de archivo.");
            }

            LectorArchivoNumeros lector = new LectorArchivoNumeros();
            CalculadoraEstadistica calculadora = new CalculadoraEstadistica();

            ListaEnlazada lista = lector.Leer(ruta);

            if (lista.Cantidad < 2)
            {
                throw new InvalidOperationException(
                    "Se necesitan al menos dos datos para calcular la media y la desviación estándar muestral.");
            }

            double media = calculadora.CalcularMedia(lista);
            double desviacionEstandar = calculadora.CalcularDesviacionEstandar(lista, media);

            ResultadoEstadistico resultado = new ResultadoEstadistico(lista.Cantidad, media, desviacionEstandar);
            consola.MostrarResultado(resultado);

            return 0;
        }
        catch (ArgumentException ex)
        {
            consola.MostrarError(ex.Message);
            return 1;
        }
        catch (FileNotFoundException ex)
        {
            consola.MostrarError(ex.Message);
            return 1;
        }
        catch (FormatException ex)
        {
            consola.MostrarError(ex.Message);
            return 1;
        }
        catch (InvalidOperationException ex)
        {
            consola.MostrarError(ex.Message);
            return 1;
        }
        catch (IOException ex)
        {
            consola.MostrarError(ex.Message);
            return 1;
        }
    }
}