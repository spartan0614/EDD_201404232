#include <cstring>
#include <string>
#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include "elementos.h"

using namespace std;
//Contructores______________________________
Avion::Avion(int id, int tipo, int pasajeros, int tiempo_desbordaje, int tiempo_mantnimento){
    this->id = id;
    this->tipo = tipo;
    this->pasajeros = pasajeros;
    this->tiempo_desbordaje = tiempo_desbordaje;
    this->tiempo_mantnimento = tiempo_mantnimento;
    this->siguiente = NULL;
    this->anterior = NULL;
}

Pasajero::Pasajero(int equipaje, int documentos, int tiempo_registro){
    this->equipaje = equipaje;
    this->documentos = documentos;
    this->tiempo_registro = tiempo_registro;
    this->siguiente = NULL;
}

Escritorio::Escritorio(char id, int estado, int documentos, int faltante){
    this->id = id;
    this->estado = estado;
    this->documentos = documentos;
    this->faltante = faltante;
    this->siguiente = NULL;
    this->anterior = NULL;
}

//*****************************************     A V I O N E S     **********************************************
void ColaDoble::Insertar(int id,int tipo, int pasajeros, int tiempo_desbordaje, int tiempo_mantnimento){
    Avion *nuevo = new Avion(id,tipo, pasajeros, tiempo_desbordaje,tiempo_mantnimento);
    if(primero == NULL){
        primero = ultimo = nuevo;
    }else{
        ultimo->siguiente = nuevo;
        nuevo->anterior = ultimo;
        ultimo = nuevo;
    }
}

 Avion *ColaDoble::Eliminar(){

 }

void ColaDoble::Graficar(){
    FILE *archivo;
    archivo = fopen("aviones.txt", "w");
    if(archivo == NULL){
        exit(-1);
    }
    Avion *aux = primero;
    Avion *temporal = ultimo;
    Avion *aux2 = primero;
    if(listContactos->primero == NULL){
        fprintf(archivo,"No existen nodos en la lsita de personas");
    }else{
        fprintf(archivo,"digraph Aviones{\n");
        fprintf(archivo,"rankdir=LR;\n");
        fprintf(archivo,"fontname = \"Bitstream Vera Sans\"\n");
        fprintf(archivo,"node[shape=record,style=filled,fillcolor=seashell2,fontname = \"Bitstream Vera Sans\"];\n");

        fprintf(archivo,"nodo%d[label=\"Tipo:%s \\l Pasajeros:%d \\l Turnos \\l desabordaje:%d \\l\"];\n",aux->id,aux->tipo,aux->pasajeros,aux->tiempo_desbordaje);
        if(aux->siguiente == NULL){

        }else{
            aux = aux->siguiente;
            while(aux != NULL){
                fprintf(archivo,"nodo%d[label=\"Tipo:%s \\l Pasajeros:%d \\l Turnos \\l desabordaje:%d \\l\"];\n",aux->id,aux->tipo,aux->pasajeros,aux->tiempo_desbordaje);
                aux = aux->siguiente;
            }
        }

        fprintf(archivo,"nodo%s",ConvertChar(aux2->valor.nickname));
        if(aux2->siguiente == NULL){

        }else{
            aux2 = aux2->siguiente;
            while (aux2 != NULL) {
                 fprintf(archivo,"->nodo%s",ConvertChar(aux2->valor.nickname));
                 aux2 = aux2->siguiente;
            }
        }
         fprintf(archivo,";\n");

         while (temporal != listContactos->primero){
            fprintf(archivo,"nodo%s->",ConvertChar(temporal->valor.nickname));
            temporal = temporal->anterior;
         }
          fprintf(archivo,"nodo%s",ConvertChar(listContactos->primero->valor.nickname));

          fprintf(archivo,";\n");
          fprintf(archivo,"}\n");
          fclose(archivo);

          system("dot -Tpng aviones.txt -o Aviones.png");

    }

}


 //Pasajeros________________________________
 void ColaPasajeros::Insertar(int equipaje, int documentos, int tiempo_registro){
    Pasajero *nuevo = new Pasajero(equipaje,documentos,tiempo_registro);
    if(primero == NULL){
        primero = nuevo;
    }else{
        Pasajero *tmp = primero;
        while (tmp->siguiente != NULL) {
            tmp = tmp->siguiente;
        }
        tmp->siguiente = nuevo;
    }
 }

 Pasajero *ColaPasajeros::Eliminar(){

 }

 //Escritorios________________________________
 void DobleOrdenada::Insertar(char id, int estado, int documentos, int faltante){
    Escritorio *nuevo = new Escritorio(id, estado, documentos, faltante);

 }

