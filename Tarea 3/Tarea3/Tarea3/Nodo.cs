using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3
{
    class Nodo
    {
        public string caracter;
        public Nodo derecha;
        public Nodo izquierda;

        public Nodo(string caracter)
        {
            this.caracter = caracter;
            this.derecha = null;
            this.izquierda = null;
        }
    }
}
