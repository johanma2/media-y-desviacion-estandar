using System;

public class CalculadoraEstadistica
{
    public double CalcularMedia(ListaEnlazada lista)
    {
        if (lista == null || lista.Cantidad == 0)
        {
            throw new ArgumentException("La lista debe contener al menos un dato.");
        }

        double suma = 0.0;
        Nodo? actual = lista.Cabeza;

        while (actual != null)
        {
            suma += actual.Valor;
            actual = actual.Siguiente;
        }

        return suma / lista.Cantidad;
    }

    public double CalcularDesviacionEstandar(ListaEnlazada lista, double media)
    {
        if (lista == null || lista.Cantidad < 2)
        {
            throw new ArgumentException("Se necesitan al menos dos datos para calcular la desviación estándar.");
        }

        double sumaCuadrados = 0.0;
        Nodo? actual = lista.Cabeza;

        while (actual != null)
        {
            double diferencia = actual.Valor - media;
            sumaCuadrados += diferencia * diferencia;
            actual = actual.Siguiente;
        }

        double varianza = sumaCuadrados / (lista.Cantidad - 1);
        return Math.Sqrt(varianza);
    }
}