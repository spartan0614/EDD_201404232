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
                        {                                                           //   |    |-1.1.1: No hay Nada atrás
                            aux.atras = nuevo;                                      //   |    |
                            nuevo.adelante = aux;                                   //   |    |      |Cambiar conexiones de los lados para 1
                            CambiarConexiones(aux, nuevo);                          //   |    |   
                        }
                        else if ((aux.atras.z == 2) || (aux.atras.z == 3))
                        {                                                           //   |    |-1.1.2: Atrás es un 2
                            Nodo cambio = aux.atras;                                //   |    |-1.1.3: Atrás es un 3
                            aux.atras = nuevo;                                      //   |
                            cambio.adelante = nuevo;                                //   |
                            nuevo.adelante = aux;                                   //   |
                            nuevo.atras = cambio;                                   //   |
                            CambiarConexiones(aux, nuevo);                          //   |           |Cambiar conexiones de los lados para 1
                        }                                                           //   |
                        eje_x.getEncabezado(nuevo.x).nivel1++;
                        eje_y.getEncabezado(nuevo.y).nivel1++;
                    }                                                               //   |
                    else if (nuevo.z == 2)                                          //   |-1.2: Nuevo es un 2
                    {                                                               //   |    |
                        if (aux.atras == null)
                        {                                                           //   |    |-1.2.1: No hay nada atrás
                            aux.atras = nuevo;                                      //   |    |
                            nuevo.adelante = aux;                                   //   |    |                   
                        }
                        else if (aux.atras.z == 3)
                        {                                                           //   |    |-1.2.2: Atrás es un 3
                            Nodo cambio = aux.atras;                                //   | 
                            aux.atras = nuevo;                                      //   |                                
                            cambio.adelante = nuevo;                                //   |                                
                            nuevo.adelante = aux;                                   //   |                       
                            nuevo.atras = cambio;                                   //   | 
                        }                                                           //   | 
                        eje_x.getEncabezado(nuevo.x).nivel2++;
                        eje_y.getEncabezado(nuevo.y).nivel2++;

                    }
                    else if (nuevo.z == 3)                                          //   |-1.3: Nuevo es un 3
                    {                                                               //   |    |
                        if (aux.atras == null)
                        {                                                           //   |    |-1.3.1: No hay nada atrás
                            aux.atras = nuevo;                                      //   |    |
                            nuevo.adelante = aux;                                   //   |    |
                        }
                        else if (aux.atras.z == 2)
                        {                                                           //   |    |-1.3.2: Atrás es un 2
                            aux.atras.atras = nuevo;                                //   |    
                            nuevo.adelante = aux.atras;                             //   | 
                        }                                                           //   |
                        eje_x.getEncabezado(nuevo.x).nivel3++;
                        eje_y.getEncabezado(nuevo.y).nivel3++;

                    }                                                               //   |
                }                                                                   //   |
                else if (aux.z == 1)                                                //--2: Nivel 1 como base
                {                                                                   //   |
                    if (nuevo.z == 0)                                               //   |-2.1: Nuevo es un 0
                    {                                                               //   |
                        aux.adelante = nuevo;                                       //   |
                        nuevo.atras = aux;                                          //   |
                        eje_x.getEncabezado(nuevo.x).nivel0++;
                        eje_y.getEncabezado(nuevo.y).nivel0++;
                    }                                                               //   |
                    else if (nuevo.z == 2)
                    {                                                               //   |-2.2: Nuevo es un 2
                        if (aux.atras == null)
                        {                                                           //   |    |-2.2.1: No hay nada atrás
                            aux.atras = nuevo;                                      //   |    |
                            nuevo.adelante = aux;                                   //   |    |
                        }
                        else if (aux.atras.z == 3)
                        {                                                           //   |    |-2.2.2: Atrás es un 3
                            Nodo cambio = aux.atras;                                //   |
                            aux.atras = nuevo;                                      //   |    
                            cambio.adelante = nuevo;                                //   |
                            nuevo.adelante = aux;                                   //   |
                            nuevo.atras = cambio;                                   //   |
                        }                                                           //   |    
                        eje_x.getEncabezado(nuevo.x).nivel2++;
                        eje_y.getEncabezado(nuevo.y).nivel2++;

                    }
                    else if (nuevo.z == 3)
                    {                                                               //   |-2.3: Nuevo es un 3
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
                        eje_x.getEncabezado(nuevo.x).nivel3++;
                        eje_y.getEncabezado(nuevo.y).nivel3++;
                    }                                                               //   |    
                }                                                                   //   |    
                else if (aux.z == 2)                                                //--3: Nivel 2 como base
                {                                                                   //   |
                    if ((nuevo.z == 0) || (nuevo.z == 1))                           //   |-3.1: Nuevo es un 0
                    {                                                               //   |-3.2: Nuevo es un 1
                        aux.adelante = nuevo;                                       //   |
                        nuevo.atras = aux;                                          //   |
                        CambiarConexiones(aux, nuevo);                              //   |
                        if (nuevo.z == 0)
                        {
                            eje_x.getEncabezado(nuevo.x).nivel0++;
                            eje_y.getEncabezado(nuevo.y).nivel0++;
                        }
                        else if (nuevo.z == 1)
                        {
                            eje_x.getEncabezado(nuevo.x).nivel1++;
                            eje_y.getEncabezado(nuevo.y).nivel1++;
                        }
                    }                                                               //   |
                    else if (nuevo.z == 3)                                          //   |
                    {                                                               //   |-3.3: Nuevo es un 3
                        aux.atras = nuevo;                                          //   |
                        nuevo.adelante = aux;                                       //   |
                        eje_x.getEncabezado(nuevo.x).nivel3++;
                        eje_y.getEncabezado(nuevo.y).nivel3++;
                    }                                                               //   |
                }                                                                   //   |
                else if (aux.z == 3)                                                //--4: Nivel 2 como base
                {                                                                   //   |
                    if ((nuevo.z == 0) || (nuevo.z == 1) || (nuevo.z == 2))         //   |
                    {
                        aux.adelante = nuevo;
                        nuevo.atras = aux;
                        CambiarConexiones(aux, nuevo);
                        if (nuevo.z == 0)
                        {
                            eje_x.getEncabezado(nuevo.x).nivel0++;
                            eje_y.getEncabezado(nuevo.y).nivel0++;
                        }
                        else if (nuevo.z == 1)
                        {
                            eje_x.getEncabezado(nuevo.x).nivel1++;
                            eje_y.getEncabezado(nuevo.y).nivel1++;
                        }
                        else if (nuevo.z == 2)
                        {
                            eje_x.getEncabezado(nuevo.x).nivel2++;
                            eje_y.getEncabezado(nuevo.y).nivel2++;
                        }
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
                if (nuevo.z == 0)
                {
                    encabezado_x.nivel0++;
                }
                else if (nuevo.z == 1)
                {
                    encabezado_x.nivel1++;
                }
                else if (nuevo.z == 2)
                {
                    encabezado_x.nivel2++;
                }
                else if (nuevo.z == 3)
                {
                    encabezado_x.nivel3++;
                }
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

                if (nuevo.z == 0)
                {
                    encabezado_x.nivel0++;
                }
                else if (nuevo.z == 1)
                {
                    encabezado_x.nivel1++;
                }
                else if (nuevo.z == 2)
                {
                    encabezado_x.nivel2++;
                }
                else if (nuevo.z == 3)
                {
                    encabezado_x.nivel3++;
                }
            }
            //FIN DE LA INSERCIÓN DE FILAS

            //INSERCIÓN COLUMNAS
            Encabezado encabezado_y = eje_y.getEncabezado(nuevo.y);
            if (encabezado_y == null)      //Si no existe se crea un nuevo encabezado.
            {
                encabezado_y = new Encabezado(nuevo.y);
                this.eje_y.Insertar(encabezado_y);
                encabezado_y.acceso = nuevo;

                if (nuevo.z == 0)
                {
                    encabezado_y.nivel0++;
                }
                else if (nuevo.z == 1)
                {
                    encabezado_y.nivel1++;
                }
                else if (nuevo.z == 2)
                {
                    encabezado_y.nivel2++;
                }
                else if (nuevo.z == 3)
                {
                    encabezado_y.nivel3++;
                }
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

                if (nuevo.z == 0)
                {
                    encabezado_y.nivel0++;
                }
                else if (nuevo.z == 1)
                {
                    encabezado_y.nivel1++;
                }
                else if (nuevo.z == 2)
                {
                    encabezado_y.nivel2++;
                }
                else if (nuevo.z == 3)
                {
                    encabezado_y.nivel3++;
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
            tw.WriteLine(GraficarBarcos());  //ToDoGraph 
            tw.Close();
        }

        string GraficarBarcos()
        {
            StringBuilder b = new StringBuilder();
            //----------------    INICIO DE ESCRITURA    ---------------
            b.Append("digraph Barcos{" + Environment.NewLine);
            b.Append("   node[\n");
            b.Append("      fontname = \"Bitstream Vera Sans\"\n");
            b.Append("      fontsize = 8\n");
            b.Append("      fillcolor=seashell2\n");
            b.Append("      style = filled\n");
            b.Append("      shape = box\n");
            b.Append("   ];\n");
            b.Append("   edge[\n");
            b.Append("       fontname = \"Bitstream Vera Sans\"\n");
            b.Append("       fontsize = 10\n");
            b.Append("   ];\n");
            b.Append("rankdir=UD;\n" + Environment.NewLine);

            b.Append("{\n" + Environment.NewLine);
            b.Append("rank=min;\n" + Environment.NewLine);
            b.Append("m[label=\"matriz\"];\n" + Environment.NewLine);
            //---------------- LISTADO DE ENCABEZADOS DE Y---------------
            Encabezado encabezado_y = eje_y.primero;
            while (encabezado_y != null)
            {
                if (encabezado_y.nivel1 > 0)
                {   //Si existe un nivel 1 para ese encabezado entonces si se grafica
                    b.AppendFormat("nodey{0}[label=\"{1}\"];\n", getColumnName(encabezado_y.id), getColumnName(encabezado_y.id), Environment.NewLine);
                }
                encabezado_y = encabezado_y.siguiente;
            }
            b.Append("};\n" + Environment.NewLine);
            //------ LISTADO DE ENCABEZADOS DE X Y NODOS INTERNOS --------
            Encabezado encabezado_x = eje_x.primero;
            while (encabezado_x != null)
            {
                if (encabezado_x.nivel1 > 0)
                {  //Si existe un nivel 1 para el encabezado entonces si se grafica
                    b.Append("{\n" + Environment.NewLine);
                    b.Append("rank=same;\n" + Environment.NewLine);
                    b.AppendFormat("nodex{0}[label=\"{1}\"];\n", encabezado_x.id, encabezado_x.id, Environment.NewLine);
                    Nodo casilla = encabezado_x.acceso;

                    while (casilla != null)
                    {
                        if (casilla.z == 1)
                        {
                            b.AppendFormat("nodel{0}{1}[label=\"x:{2} y:{3} z:{4} \\l tipo:{5} \\l unidad:{6} \\l alcance:{7} \\l movimiento:{8} \\l daño:{9} \\l vida:{10}\"];\n",
                            casilla.x, casilla.y, casilla.x, casilla.y, casilla.z, casilla.tipo, casilla.unidad, casilla.alcance, casilla.movimiento, casilla.damage, casilla.vida, Environment.NewLine);
                        }
                        casilla = casilla.derecha;
                    }
                    b.Append("}\n" + Environment.NewLine);
                }
                encabezado_x = encabezado_x.siguiente;
            }
            //-------------------- ENLACES INTERNOS DE Y -----------------
            Nodo first = null;
            bool puedeEnlazar = false;

            Encabezado tempy = eje_y.primero;
            while (tempy != null)
            {
                if (tempy.nivel1 > 0)
                {
                    Nodo auxColum = tempy.acceso;
                    while (auxColum != null)
                    {
                        if (auxColum.z == 1)
                        {
                            if (puedeEnlazar == false)
                            {
                                first = auxColum;
                                puedeEnlazar = true;
                            }
                            else
                            {
                                b.AppendFormat("nodel{0}{1}->nodel{2}{3}\n", first.x, first.y, auxColum.x, auxColum.y, Environment.NewLine);
                                b.AppendFormat("nodel{0}{1}->nodel{2}{3}\n", auxColum.x, auxColum.y, first.x, first.y, Environment.NewLine);
                                first = auxColum;
                            }
                        }
                        auxColum = auxColum.abajo;
                    }
                    first = null;
                    puedeEnlazar = false;
                }
                tempy = tempy.siguiente;
            }
            //------------ UNIENDO CABECERAS DE Y CON ACCESO --------------
            Encabezado auxy = eje_y.primero;
            while (auxy != null)
            {
                if (auxy.nivel1 > 0)
                {
                    Nodo auxColumn = auxy.acceso;
                    while (auxColumn != null)
                    {
                        if (auxColumn.z == 1)
                        {
                            b.AppendFormat("nodey{0}->nodel{1}{2};\n", getColumnName(auxy.id), auxColumn.x, auxColumn.y, Environment.NewLine);
                            break;
                        }
                        auxColumn = auxColumn.abajo;
                    }
                }
                auxy = auxy.siguiente;
            }
            //------------------ ENLACES INTERNOS DE X --------------------
            first = null;
            puedeEnlazar = false;

            Encabezado tempx = eje_x.primero;
            while (tempx != null)
            {
                if (tempx.nivel1 > 0)
                {
                    Nodo auxfil = tempx.acceso;
                    while (auxfil != null)
                    {
                        if (auxfil.z == 1)
                        {
                            if (puedeEnlazar == false)
                            {
                                first = auxfil;
                                puedeEnlazar = true;
                            }
                            else
                            {
                                b.AppendFormat("nodel{0}{1}->nodel{2}{3}\n", first.x, first.y, auxfil.x, auxfil.y, Environment.NewLine);
                                b.AppendFormat("nodel{0}{1}->nodel{2}{3}\n", auxfil.x, auxfil.y, first.x, first.y, Environment.NewLine);
                                first = auxfil;
                            }
                        }
                        auxfil = auxfil.derecha;
                    }
                    first = null;
                    puedeEnlazar = false;
                }
                tempx = tempx.siguiente;
            }
            //----------------- UNIENDO CABECERAS DE X CON ACCESO-----------
            Encabezado auxx = eje_x.primero;
            while (auxx != null)
            {
                if (auxx.nivel1 > 0)
                {
                    Nodo auxfil = auxx.acceso;
                    while (auxfil != null)
                    {
                        if (auxfil.z == 1)
                        {
                            b.AppendFormat("nodex{0}->nodel{1}{2};\n", auxx.id, auxfil.x, auxfil.y, Environment.NewLine);
                            break;
                        }
                        auxfil = auxfil.derecha;
                    }
                }
                auxx = auxx.siguiente;
            }
            //------------------------  ENCABEZADOS ------------------------
            Encabezado temporal_x = eje_x.primero;
            Encabezado temporal_y = eje_y.primero;
            b.Append("m");
            while (temporal_y != null)
            {
                if (temporal_y.nivel1 > 0)
                {
                    b.AppendFormat("->nodey{0}", getColumnName(temporal_y.id), Environment.NewLine);
                }
                temporal_y = temporal_y.siguiente;
            }
            b.Append(";\n");

            b.Append("m");
            while (temporal_x != null)
            {
                if (temporal_x.nivel1 > 0)
                {
                    b.AppendFormat("->nodex{0}", temporal_x.id);
                }
                temporal_x = temporal_x.siguiente;
            }
            b.Append(";\n");

            b.Append("}");
            return b.ToString();
        }
    }
}