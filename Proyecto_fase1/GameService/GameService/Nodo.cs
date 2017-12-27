using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameService
{
    public class Nodo
    {
        public int x;              //eje en x
        public int y;              //eje en y
        public int z;              //eje en z
        public int tipo;           //satélite, avión, barco, submarino
        public int unidad;         //Neosatelite, bombardero, caza, helicoptero, fragata, crucero, submarino
        public int movimiento;     //forma en la que puede moverse la unidad
        public int alcance;        //alcance que tiene al atacar
        public int damage;         //daño que causa la unidad al atacar
        public int vida;           //cantidad de vida que contiene la unidad
        //punteros                  //            arriba   atras
        public Nodo derecha;        //           ___|____ /
        public Nodo izquierda;      //          |        |
        public Nodo arriba;         //    izq<--|        |-->der
        public Nodo abajo;          //          |________|
        public Nodo adelante;       //         /    |
        public Nodo atras;          //  adelante  abajo
        public Nodo(int x, int y, int z, int tipo, int unidad, int movimiento, int alcance, int damage, int vida)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.tipo = tipo;
            this.unidad = unidad;
            this.movimiento = movimiento;
            this.alcance = alcance;
            this.damage = damage;
            this.vida = vida;
            this.derecha = null;
            this.izquierda = null;
            this.arriba = null;
            this.abajo = null;
            this.adelante = null;
            this.atras = null;
        }
    }
}