public class Nodo
{
    public double Valor { get; }
    public Nodo? Siguiente { get; set; }

    public Nodo(double valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}