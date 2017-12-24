using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3
{
    class ArbolBinario
    {
        Nodo raiz;

        public ArbolBinario()
        {
            raiz = null;
        }

        public Nodo getRaiz()
        {
            return this.raiz;
        }

        public Nodo Buscar(string caracter)
        {
            return Buscar(this.raiz, caracter);
        }

        public Nodo Buscar(Nodo actual, string caracter)
        {
            if (actual == null)
            {
                return null;
            }

            if (Ascii(caracter) == Ascii(actual.caracter))
            {
                return actual;
            }
            else if (Ascii(caracter) < Ascii(actual.caracter))
            {
                return Buscar(actual.izquierda, caracter);
            }
            else if (Ascii(caracter) > Ascii(actual.caracter))
            {
                return Buscar(actual.derecha, caracter);
            }

            return null;
        }

        int Ascii(string s)
        {
            return Encoding.ASCII.GetBytes(s)[0];
        }

        public void Insertar(string caracter)
        {
            if (Buscar(caracter) == null)
            {
                if (this.raiz == null)
                {
                    raiz = new Nodo(caracter);
                }
                else
                {
                    Insertar(raiz, new Nodo(caracter));
                }
            }
        }


        public void Insertar(Nodo actual, Nodo nuevo)
        {
            if (string.Compare(nuevo.caracter, actual.caracter) < 0)
            {
                if (actual.izquierda == null)
                {
                    actual.izquierda = nuevo;
                }
                else
                {
                    Insertar(actual.izquierda, nuevo);
                }
            }
            else
            {
                if (actual.derecha == null)
                {
                    actual.derecha = nuevo;
                }
                else
                {
                    Insertar(actual.derecha, nuevo);
                }
            }
        }

        public void Preorden(Nodo r) {
            if (r != null) {
                System.Diagnostics.Debug.Write(r.caracter.ToString() + ", ");
                Preorden(r.izquierda);
                Preorden(r.derecha);
            }
        }

        public void Enorden(Nodo r) {
            if (r != null)
            {
                Preorden(r.izquierda);
                System.Diagnostics.Debug.Write(r.caracter.ToString() + ", ");
                Preorden(r.derecha);
            }
        }

        public void Postorden(Nodo r) {
            if (r != null)
            {
                Preorden(r.izquierda);
                Preorden(r.derecha);
                System.Diagnostics.Debug.Write(r.caracter.ToString() + ", ");
            }
        }
    }
}
