using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameService
{
    public class ListaEncabezados
    {
        public Encabezado primero;
        public Encabezado ultimo;

        public ListaEncabezados()
        {
            primero = ultimo = null;
        }

        public void Insertar(Encabezado nuevo)
        {
            if (primero == null)
            {
                primero = ultimo = nuevo;
            }
            else
            {
                if (nuevo.id < primero.id)//Inserción al inicio de la lista
                {
                    primero.anterior = nuevo;
                    nuevo.siguiente = primero;
                    primero = nuevo;
                }
                else if (nuevo.id > ultimo.id)   //Inserción al final
                {
                    ultimo.siguiente = nuevo;
                    nuevo.anterior = ultimo;
                    ultimo = nuevo;
                }
                else
                {
                    Encabezado aux = primero;
                    while (aux.siguiente != null)
                    {
                        if (nuevo.id < aux.siguiente.id)
                        {
                            nuevo.siguiente = aux.siguiente;
                            aux.siguiente.anterior = nuevo;
                            nuevo.anterior = aux;
                            aux.siguiente = nuevo;
                            break;
                        }
                        aux = aux.siguiente;
                    }
                }
            }
        }

        public Encabezado getEncabezado(int id)
        {
            Encabezado aux = primero;
            while (aux != null)
            {
                if (aux.id == id)
                {
                    return aux;
                }
                aux = aux.siguiente;
            }
            return null;
        }

        public string getColumnName(int columnNumber)
        {               //NÚMERO ----> COLUMNA             
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }
            return columnName;
        }

        public int getColumnNumber(string columnName)
        {              //COLUMNA -----> NÚMERO
            int result = 0;
            for (int i = 0; i < columnName.Length; i++)
            {
                result *= 26;
                char letter = columnName[i];
                if (letter < 'A') letter = 'A';
                if (letter > 'Z') letter = 'Z';
                result += (int)letter - (int)'A' + 1;
            }
            return result;
        }
    }
}