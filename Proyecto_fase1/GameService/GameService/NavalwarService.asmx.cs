using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace GameService
{
    /// <summary>
    /// Summary description for NavalwarService
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    [WebService(Namespace = "http://localhost/NavalWar", Name = "Proyecto EDD")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NavalwarService : System.Web.Services.WebService
    {
        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}
        public static ArbolBinario tree = new ArbolBinario();

        [WebMethod]
        public bool Administrador(string nickname, string password) {
            if ((nickname == "Dinora") && (password == "admin"))
            {
                return true;
            }
            else {
                return false;
            }
        }

        [WebMethod]
        public void UpFileUsers(string path) {
            tree.CargaUsuarios(path);
        }

        [WebMethod]
        public void UpFileGames(string path) {
            tree.CargaJuegos(path);
        }

        [WebMethod]
        public string ViewTree()
        {
            return tree.ProcessGraphic();
        }

        [WebMethod]
        public void AddNewUser(string nickname, string password, string email, int conectado) {
            tree.Insertar(nickname, password, email, conectado);
        }

        [WebMethod]
        public void DeleteUser(string nickname) {
            tree.Eliminar(nickname);
        }

        [WebMethod]
        public int getHeigth() {     //altura
            return tree.Altura(tree.raizArbol());
        }

        [WebMethod]
        public int getLevels() {     //niveles
            return tree.Niveles();
        }

        [WebMethod]
        public int getLeaves() {       //Hojas
            return tree.CantidadNodosHoja();
        }

        [WebMethod]
        public int getBranches() {      //Rama
            return tree.CantidadNodosRama();
        }

        //[WebMethod]
        //public void graphTree()
        //{
        //    tree.ProcessGraphic();
        //}

        [WebMethod]
        public bool IngresoUsuario(string nickname, string password) {
            Usuario jugador = tree.ValidarUsuario(nickname, password);
            if (jugador != null)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
