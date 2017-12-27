using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameService
{
    public class Juego
    {
        public string oponente;
        public int UniDesplegadas;
        public int UniSobrevivientes;
        public int UniDestruidas;
        public int resultado;         //ganó: 1 , perdió: 0
        public Juego siguiente;
        public Juego anterior;

        public Juego(string oponente, int UniDesplegadas, int UniSobrevivientes, int UniDestruidas, int resultado)
        {
            this.oponente = oponente;
            this.UniDesplegadas = UniDesplegadas;
            this.UniSobrevivientes = UniSobrevivientes;
            this.UniDestruidas = UniDestruidas;
            this.resultado = resultado;
            this.siguiente = null;
            this.anterior = null;
        }
    }
}