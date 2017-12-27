using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameService
{
    public class ListaJuegos
    {
        public Juego primero;
        public Juego ultimo;

        public ListaJuegos()
        {
            primero = ultimo = null;
        }

        public void Insertar(Juego nuevo)
        {
            if (primero == null)
            {
                primero = ultimo = nuevo;
            }
            else
            {
                ultimo.siguiente = nuevo;
                nuevo.anterior = ultimo;
                ultimo = nuevo;
            }
        }

    }
}