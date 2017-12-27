using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameService
{
    public class Encabezado
    {
        public int id;   //coordenada del encabezado x
        public Encabezado siguiente;
        public Encabezado anterior;
        public Nodo acceso;
        public Encabezado(int id)
        {
            this.id = id;
            this.siguiente = null;
            this.anterior = null;
            this.acceso = null;
        }
    }
}