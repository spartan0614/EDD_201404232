using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameService
{
    public class Usuario
    {
        public string nickname;
        public string password;
        public string email;
        public int conectado;
        public ListaJuegos juegos;
        public Usuario derecha;
        public Usuario izquierda;

        public Usuario(string nickname, string password, string email, int conectado)
        {
            this.nickname = nickname;
            this.password = password;
            this.email = email;
            this.conectado = conectado;
            this.juegos = new ListaJuegos();
            this.derecha = null;
            this.izquierda = null;
        }
    }
}