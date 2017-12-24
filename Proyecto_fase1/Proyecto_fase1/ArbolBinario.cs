using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_fase1
{
    public class ArbolBinario
    {
        Usuario raiz;
        int hojas = 0;
        int nodos = 0;

        public ArbolBinario()
        {
            raiz = null;
        }

        public Usuario raizArbol()
        {
            return raiz;
        }

        public bool esVacio()
        {
            return raiz == null;
        }

        public Usuario Buscar(string nickname)
        {
            return Buscar(this.raiz, nickname);
        }

        public Usuario Buscar(Usuario actual, string nickname)
        {
            if (actual == null)
            {
                return null;
            }

            int comparacion = string.Compare(nickname, actual.nickname);

            if (comparacion == 0)
            {
                return actual;
            }
            else if (comparacion < 0)
            {
                return Buscar(actual.izquierda, nickname);
            }
            else if (comparacion > 0)
            {
                return Buscar(actual.derecha, nickname);
            }

            return null;
        }

        public void Insertar(string nickname, string password, string email, int conectado)
        {
            if (Buscar(nickname) == null)
            {
                if (this.raiz == null)
                {
                    raiz = new Usuario(nickname, password, email, conectado);
                }
                else
                {
                    Insertar(raiz, new Usuario(nickname, password, email, conectado));
                }
            }
        }


        public void Insertar(Usuario actual, Usuario nuevo)
        {
            if (string.Compare(nuevo.nickname, actual.nickname) < 0)
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

        public Usuario Espejo()
        {
            Usuario mirror = Espejo(this.raiz);
            return mirror;
        }

        public Usuario Espejo(Usuario actual)
        {
            if (actual == null)
            {
                return null;
            }
            Usuario tmp = actual.izquierda;
            actual.izquierda = Espejo(actual.derecha);
            actual.derecha = Espejo(tmp);
            return actual;
        }

        public int Altura(Usuario actual)
        {
            if (actual == null)
            {
                return 0;
            }
            else
            {
                int hi = Altura(actual.izquierda);
                int hd = Altura(actual.derecha);
                return (hi > hd ? hi : hd) + 1;
            }
        }

        public int Niveles()
        {
            if (this.raiz == null)
            {
                return -1;
            }
            else
            {
                return Altura(this.raiz) - 1;
            }
        }

        void NodosHojas(Usuario actual)
        {
            if (actual != null)
            {
                if (actual.izquierda == null && actual.derecha == null)
                {
                    hojas++;
                }
                NodosHojas(actual.izquierda);
                NodosHojas(actual.derecha);
            }
        }

        public int CantidadNodosHoja()
        {
            hojas = 0;
            NodosHojas(this.raiz);
            return hojas;
        }

        void Nodos(Usuario actual)
        {
            if (actual != null)
            {
                nodos++;
                Nodos(actual.izquierda);
                Nodos(actual.derecha);
            }
        }

        public int CantidadNodos()
        {
            nodos = 0;
            Nodos(this.raiz);
            return nodos;
        }

        public int CantidadNodosRama()
        {
            return (CantidadNodos() - CantidadNodosHoja());
        }

        public void Eliminar(string nickname)
        {
            raiz = Eliminar(raiz, nickname);
        }

        public Usuario Eliminar(Usuario raiz, string nickname)
        {
            if (raiz == null)
            {
                return raiz;
            }

            if (string.Compare(nickname, raiz.nickname) < 0)
            {
                raiz.izquierda = Eliminar(raiz.izquierda, nickname);
            }
            else if (string.Compare(nickname, raiz.nickname) > 0)
            {
                raiz.derecha = Eliminar(raiz.derecha, nickname);
            }
            else
            {
                if (raiz.izquierda == null)
                {
                    Usuario temp = raiz.derecha;
                    return temp;
                }
                else if (raiz.derecha == null)
                {
                    Usuario temp = raiz.izquierda;
                    return temp;
                }
                Usuario tmp = minValueNode(raiz.derecha);
                raiz.nickname = tmp.nickname;
                raiz.derecha = Eliminar(raiz.derecha, tmp.nickname);
            }
            return raiz;
        }

        Usuario minValueNode(Usuario nodo)
        {
            Usuario current = nodo;
            while (current.izquierda != null)
            {
                current = current.izquierda;
            }
            return current;
        }
    }
}