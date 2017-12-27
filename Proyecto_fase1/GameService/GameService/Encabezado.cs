using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameService
{
    public class Encabezado
    {
        public int id;   //coordenada del encabezado x
        public int nivel0;   //etiquetas que serán de ayuda para graficar los niveles de la matriz
        public int nivel1;
        public int nivel2;
        public int nivel3;
        public Encabezado siguiente;
        public Encabezado anterior;
        public Nodo acceso;
        public Encabezado(int id)
        {
            this.id = id;
            this.nivel0 = 0;
            this.nivel1 = 0;
            this.nivel2 = 0;
            this.nivel3 = 0;
            this.acceso = null;
            this.siguiente = null;
            this.anterior = null;
        }
    }
}