using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace GameService
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

        public Usuario ValidarUsuario(string nickname, string password)
        {
            return ValidarUsuario(this.raiz, nickname, password);
        }

        Usuario ValidarUsuario(Usuario actual, string nickname, string password)
        {
            if (actual == null)
            {
                return null;
            }

            int EqualNick = string.Compare(nickname, actual.nickname);
            int EqualPass = string.Compare(password, actual.password);

            if ((EqualNick == 0) && (EqualPass == 0))
            {
                return actual;
            }
            else if (EqualNick < 0)
            {
                return ValidarUsuario(actual.izquierda, nickname, password);
            }
            else if (EqualPass > 0)
            {
                return ValidarUsuario(actual.derecha, nickname, password);
            }

            return null;
        }


        public Usuario Buscar(string nickname)
        {
            return Buscar(this.raiz, nickname);
        }

        Usuario Buscar(Usuario actual, string nickname)
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

        public void CargaUsuarios(string path)
        {
            List<string[]> datos = takeData(path);
            for (int n = 1; n < datos.Count; n++)
            {
                string[] row = datos[n];
                Insertar(row[0], row[1], row[2], Int32.Parse(row[3]));
            }

        }

        public void CargaJuegos(string path)
        {
            List<string[]> datos = takeData(path);
            for (int n = 1; n < datos.Count; n++)
            {
                string[] row = datos[n];
                Usuario nodeBase = Buscar(row[0]);
                Usuario nodeOponente = Buscar(row[1]);
                if ((nodeBase != null) && (nodeOponente != null))
                {
                    nodeBase.juegos.Insertar(new Juego(row[1], Int32.Parse(row[2]), Int32.Parse(row[3]), Int32.Parse(row[4]), Int32.Parse(row[5])));
                }
            }
        }

        List<string[]> takeData(string path)
        {
            List<string[]> parsedData = new List<string[]>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                string[] row;
                while ((line = reader.ReadLine()) != null)
                {
                    row = line.Split(',');
                    parsedData.Add(row);
                }
            }
            return parsedData;
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


        void Insertar(Usuario actual, Usuario nuevo)
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

        public void LeerUsuarios()
        {

        }

        public string ProcessGraphic()
        {
            if (this.raiz != null) {
                var fileName = "C:\\Users\\Dinora\\Documents\\Dinora\\Diciembre\\EDD_201404232\\Proyecto_fase1\\GameService\\GameService\\images\\Usuarios.txt";
                SaveToFile(fileName);
                string path = Directory.GetCurrentDirectory();
                GenerarGrafo(fileName, path);

                string elArbol = "C:\\Users\\Dinora\\Documents\\Dinora\\Diciembre\\EDD_201404232\\Proyecto_fase1\\GameService\\GameService\\images\\Usuarios.png";
                return elArbol;
            }
            return ""; 
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
            b.Append(ToDot(this.raiz));
            b.Append("}");
            return b.ToString();
        }

        string ToDot(Usuario actual)
        {
            StringBuilder b = new StringBuilder();
            if ((actual.izquierda == null) && (actual.derecha == null))
            {
                b.AppendFormat("nodo{0}[label=\"Nickname:{1} \\l Contraseña:{2} \\l Correo:{3}\"];\n", actual.nickname, actual.nickname, actual.password, actual.email, Environment.NewLine);
            }
            else if ((actual.izquierda == null) && (actual.derecha != null))
            {
                b.AppendFormat("nodo{0}[label=\"Nickname:{1} \\l Contraseña:{2} \\l Correo:{3}|<C1>\"];\n", actual.nickname, actual.nickname, actual.password, actual.email, Environment.NewLine);
            }
            else if ((actual.izquierda != null) && (actual.derecha == null))
            {
                b.AppendFormat("nodo{0}[label=\"<C0>|Nickname:{1} \\l Contraseña:{2} \\l Correo:{3}\"];\n", actual.nickname, actual.nickname, actual.password, actual.email, Environment.NewLine);
            }
            else
            {
                b.AppendFormat("nodo{0}[label=\"<C0>|Nickname:{1} \\l Contraseña:{2} \\l Correo:{3}|<C1>\"];\n", actual.nickname, actual.nickname, actual.password, actual.email, Environment.NewLine);
            }

            if (actual.izquierda != null)
            {
                b.Append(ToDot(actual.izquierda));
                b.AppendFormat("nodo{0}:C0->nodo{1}\n", actual.nickname, actual.izquierda.nickname, Environment.NewLine);
            }
            if (actual.derecha != null)
            {
                b.Append(ToDot(actual.derecha));
                b.AppendFormat("nodo{0}:C1->nodo{1}\n", actual.nickname, actual.derecha.nickname, Environment.NewLine);
            }

            return b.ToString();
        }



    }
}