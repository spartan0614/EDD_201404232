using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace GameService
{
    public class Matriz
    {
        ListaEncabezados eje_x;
        ListaEncabezados eje_y;

        public Matriz()
        {
            this.eje_x = new ListaEncabezados();
            this.eje_y = new ListaEncabezados();
        }

        public void AgregarNodo(int x, int y, int z, int tipo, int unidad, int movimiento, int alcance, int damage, int vida)
        {
            Nodo nuevo = new Nodo(x, y, z, tipo, unidad, movimiento, alcance, damage, vida);

            Nodo aux = ExistePunto(x, y);        //Verificar si existe un nodo en ese punto
            if (aux == null)                    //Si no existe  entonces hay que crearlo
            {
                InsertarNuevo(nuevo);
            }
            else
            {                                                                  //Si ya existe entonces hay que verificar en que nivel (en z) se encuentra ese nodo
                if (aux.z == 0)                                                     //--1: Nivel 0 como base
                {                                                                   //   |            
                    if (nuevo.z == 1)                                               //   |-1.1: Nuevo es un 1
                    {                                                               //   |    |
                        if (aux.atras == null)
                        {                                    //   |    |-1.1.1: No hay Nada atrás
                            aux.atras = nuevo;                                      //   |    |
                            nuevo.adelante = aux;                                   //   |    |      |Cambiar conexiones de los lados para 1
                            CambiarConexiones(aux, nuevo);                           //   |    |   
                        }
                        else if ((aux.atras.z == 2) || (aux.atras.z == 3))
                        {        //   |    |-1.1.2: Atrás es un 2
                            Nodo cambio = aux.atras;                                //   |    |-1.1.3: Atrás es un 3
                            aux.atras = nuevo;                                      //   |
                            cambio.adelante = nuevo;                                //   |
                            nuevo.adelante = aux;                                   //   |
                            nuevo.atras = cambio;                                   //   |
                            CambiarConexiones(aux, nuevo);                           //   |           |Cambiar conexiones de los lados para 1
                        }                                                           //   |
                    }                                                               //   |
                    else if (nuevo.z == 2)                                          //   |-1.2: Nuevo es un 2
                    {                                                               //   |    |
                        if (aux.atras == null)
                        {                                    //   |    |-1.2.1: No hay nada atrás
                            aux.atras = nuevo;                                      //   |    |
                            nuevo.adelante = aux;                                   //   |    |                   
                        }
                        else if (aux.atras.z == 3)
                        {                              //   |    |-1.2.2: Atrás es un 3
                            Nodo cambio = aux.atras;                                //   | 
                            aux.atras = nuevo;                                      //   |                                
                            cambio.adelante = nuevo;                                //   |                                
                            nuevo.adelante = aux;                                   //   |                       
                            nuevo.atras = cambio;                                   //   | 
                        }                                                           //   | 
                    }
                    else if (nuevo.z == 3)                                         //   |-1.3: Nuevo es un 3
                    {                                                               //   |    |
                        if (aux.atras == null)
                        {                                    //   |    |-1.3.1: No hay nada atrás
                            aux.atras = nuevo;                                      //   |    |
                            nuevo.adelante = aux;                                   //   |    |
                        }
                        else if (aux.atras.z == 2)
                        {                                //   |    |-1.3.2: Atrás es un 2
                            aux.atras.atras = nuevo;                                //   |    
                            nuevo.adelante = aux.atras;                             //   | 
                        }                                                           //   |
                    }                                                               //   |
                }                                                                   //   |
                else if (aux.z == 1)                                                //--2: Nivel 1 como base
                {                                                                   //   |
                    if (nuevo.z == 0)                                               //   |-2.1: Nuevo es un 0
                    {                                                               //   |
                        aux.adelante = nuevo;                                       //   |
                        nuevo.atras = aux;                                          //   |
                    }                                                               //   |
                    else if (nuevo.z == 2)
                    {                                        //   |-2.2: Nuevo es un 2
                        if (aux.atras == null)
                        {                                    //   |    |-2.2.1: No hay nada atrás
                            aux.atras = nuevo;                                      //   |    |
                            nuevo.adelante = aux;                                   //   |    |
                        }
                        else if (aux.atras.z == 3)
                        {                              //   |    |-2.2.2: Atrás es un 3
                            Nodo cambio = aux.atras;                                //   |
                            aux.atras = nuevo;                                      //   |    
                            cambio.adelante = nuevo;                                //   |
                            nuevo.adelante = aux;                                   //   |
                            nuevo.atras = cambio;                                   //   |
                        }                                                           //   |    
                    }
                    else if (nuevo.z == 3)
                    {                                      //   |-2.3: Nuevo es un 3
                        if (aux.atras == null)                                      //   |    |
                        {                                                           //   |    |-2.3.1: No hay nada atrás
                            aux.atras = nuevo;                                      //   |    |
                            nuevo.adelante = aux;                                   //   |    |
                        }                                                           //   |    |
                        else if (aux.atras.z == 2)                                  //   |    |-2.3.2: Atrás es un 2
                        {                                                           //   |    
                            aux.atras.atras = nuevo;                                //   |    
                            nuevo.adelante = aux.atras;                             //   |    
                        }                                                           //   |    
                    }                                                               //   |    
                }                                                                   //   |    
                else if (aux.z == 2)                                                //--3: Nivel 2 como base
                {                                                                   //   |
                    if ((nuevo.z == 0) || (nuevo.z == 1))                           //   |-3.1: Nuevo es un 0
                    {                                                               //   |-3.2: Nuevo es un 1
                        aux.adelante = nuevo;                                       //   |
                        nuevo.atras = aux;                                          //   |
                        CambiarConexiones(aux, nuevo);                                        //   |
                    }                                                               //   |
                    else if (nuevo.z == 3)                                          //   |
                    {                                                               //   |-3.3: Nuevo es un 3
                        aux.atras = nuevo;                                          //   |
                        nuevo.adelante = aux;                                       //   |
                    }                                                               //   |
                }                                                                   //   |
                else if (aux.z == 3)                                                //--4: Nivel 2 como base
                {                                                                   //   |
                    if ((nuevo.z == 0) || (nuevo.z == 1) || (nuevo.z == 2))         //   |
                    {
                        aux.adelante = nuevo;
                        nuevo.atras = aux;
                        CambiarConexiones(aux, nuevo);
                    }
                }
            }
        }

        void CambiarConexiones(Nodo aux, Nodo nuevo)
        {
            //--------------  DERECHA  ----------------
            if (aux.derecha != null)
            {
                aux.derecha.izquierda = nuevo;
                nuevo.derecha = aux.derecha;
                aux.derecha = null;
            }
            //-------------  IZQUIERDA  ---------------
            if (aux.izquierda != null)
            {
                aux.izquierda.derecha = nuevo;
                nuevo.izquierda = aux.izquierda;
                aux.izquierda = null;
            }
            else
            { //es el acceso de un encabezado en x
                Encabezado encabezado_x = eje_x.getEncabezado(aux.x);
                encabezado_x.acceso = nuevo;
            }
            //---------------  ARRIBA  ----------------
            if (aux.arriba != null)
            {
                aux.arriba.abajo = nuevo;
                nuevo.arriba = aux.arriba;
                aux.arriba = null;
            }
            else
            { //es el acceso de un encabezado en y
                Encabezado encabezado_y = eje_y.getEncabezado(aux.y);
                encabezado_y.acceso = nuevo;
            }
            //---------------  ABAJO  -----------------
            if (aux.abajo != null)
            {
                aux.abajo.arriba = nuevo;
                nuevo.abajo = aux.abajo;
                aux.abajo = null;
            }
        }

        void InsertarNuevo(Nodo nuevo)
        {  //
            //INSERCIÓN FILAS
            Encabezado encabezado_x = eje_x.getEncabezado(nuevo.x);
            if (encabezado_x == null)
            {  //Si no existe el encabezado hay que crearlo
                encabezado_x = new Encabezado(nuevo.x);
                this.eje_x.Insertar(encabezado_x);
                encabezado_x.acceso = nuevo;
            }
            else if (encabezado_x.acceso == null)
            {  //No es necesario, pero ahí que quede
                encabezado_x.acceso = nuevo;
            }
            else
            {
                if (nuevo.y < encabezado_x.acceso.y)
                {  //Inserción al inicio
                    nuevo.derecha = encabezado_x.acceso;
                    encabezado_x.acceso.izquierda = nuevo;
                    encabezado_x.acceso = nuevo;
                }
                else
                {
                    Nodo actual = encabezado_x.acceso;  //Inserción en el medio
                    while (actual.derecha != null)
                    {
                        if (nuevo.y < actual.derecha.y)
                        {
                            nuevo.derecha = actual.derecha;
                            actual.derecha.izquierda = nuevo;
                            nuevo.izquierda = actual;
                            actual.derecha = nuevo;
                            break;
                        }
                        actual = actual.derecha;
                    }
                    if (actual.derecha == null)
                    {  //Inserción al final
                        actual.derecha = nuevo;
                        nuevo.izquierda = actual;
                    }
                }
            }
            //FIN DE LA INSERCIÓN DE FILAS

            //INSERCIÓN COLUMNAS
            Encabezado encabezado_y = eje_y.getEncabezado(nuevo.y);
            if (encabezado_y == null)
            {//Si no existe se crea un nuevo encabezado.
                encabezado_y = new Encabezado(nuevo.y);
                this.eje_y.Insertar(encabezado_y);
                encabezado_y.acceso = nuevo;
            }
            else if (encabezado_y.acceso == null)
            {  //No es necesario
                encabezado_y.acceso = nuevo;
            }
            else
            {
                if (nuevo.x < encabezado_y.acceso.x)
                {  //Inserción al inicio
                    nuevo.abajo = encabezado_y.acceso;
                    encabezado_y.acceso.arriba = nuevo;
                    encabezado_y.acceso = nuevo;
                }
                else
                {
                    Nodo actual = encabezado_y.acceso;
                    while (actual.abajo != null)
                    {
                        if (nuevo.x < actual.abajo.x)
                        {
                            nuevo.abajo = actual.abajo;
                            actual.abajo.arriba = nuevo;
                            nuevo.arriba = actual;
                            actual.abajo = nuevo;
                            break;
                        }
                        actual = actual.abajo;
                    }
                    if (actual.abajo == null)
                    {
                        actual.abajo = nuevo;
                        nuevo.arriba = actual;
                    }
                }
            }
            //FIN DE INSERCIÓN COLUMNAS
        }

        Nodo ExistePunto(int x, int y)
        {
            Encabezado aux = eje_x.primero;
            if (aux == null)
            {
                return null;
            }
            else
            {
                while (aux != null)
                {
                    Nodo actual = aux.acceso;
                    while (actual != null)
                    {
                        if ((x == actual.x) && (y == actual.y))
                        {
                            return actual;
                        }
                        actual = actual.derecha;
                    }
                    aux = aux.siguiente;
                }
            }
            return null;
        }


        public void ProcessGraphic()
        {
            var fileName = "Barcos.txt";
            SaveToFile(fileName);
            string path = Directory.GetCurrentDirectory();
            GenerarGrafo(fileName, path);
        }


        void GenerarGrafo(string filename, string path)
        {
            try
            {
                var command = string.Format("dot -Tpng {0} -o {1}", Path.Combine(path, filename), Path.Combine(path, filename.Replace(".txt", ".png")));
                var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + command);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception x)
            {

            }
        }

        void SaveToFile(string fileName)
        {
            TextWriter tw = new StreamWriter(fileName);
            tw.WriteLine(Graficar());  //ToDoGraph 
            tw.Close();
        }

        string Graficar()
        {
            StringBuilder b = new StringBuilder();
            b.Append("digraph Usuarios{" + Environment.NewLine);
            b.Append("rankdir=TB;" + Environment.NewLine);
            b.Append("node [shape = record, style= filled, fillcolor=seashell2];\n" + Environment.NewLine);
            //b.Append(ToDot(this.raiz));
            b.Append("}");
            return b.ToString();
        }

    }
}