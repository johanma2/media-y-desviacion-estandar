public class ListaEnlazada
{
    public Nodo? Cabeza { get; private set; }
    public Nodo? Cola { get; private set; }
    public int Cantidad { get; private set; }

    public ListaEnlazada()
    {
        Cabeza = null;
        Cola = null;
        Cantidad = 0;
    }

    public void Agregar(double valor)
    {
        Nodo nuevo = new Nodo(valor);

        if (Cabeza == null)
        {
            Cabeza = nuevo;
            Cola = nuevo;
        }
        else
        {
            Cola!.Siguiente = nuevo;
            Cola = nuevo;
        }

        Cantidad++;
    }
}