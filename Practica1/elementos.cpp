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

Pasajero::Pasajero(int id, int equipaje, int documentos, int tiempo_registro){
    this->id = id;
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
    this->pila_documentos = new Pila();
    this->cola_pasajeros = new ColaPasajeros();
    this->siguiente = NULL;
    this->anterior = NULL;
}

Estacion::Estacion(int id, int estado, int faltante){
    this->id = id;
    this->estado = estado;
    this->faltante = faltante;
    this->siguiente = NULL;
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
    if(primero == NULL){
        //No hay nada que eliminar
    }else if(primero == ultimo){
        Avion *tmp = primero;
        primero = ultimo = NULL;
        return tmp;
    }else{
        Avion *tmp = primero;
        primero = primero->siguiente;
        primero->anterior = NULL;
        return tmp;
    }
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
    if(primero == NULL){
        fprintf(archivo,"No existen nodos en la lsita de personas");
    }else{
        fprintf(archivo,"digraph Aviones{\n");
        fprintf(archivo,"rankdir=LR;\n");
        fprintf(archivo,"fontname = \"Bitstream Vera Sans\"\n");
        fprintf(archivo,"node[shape=record,style=filled,fillcolor=seashell2,fontname = \"Bitstream Vera Sans\"];\n");
        //datos de la lista doble
        fprintf(archivo,"nodo%d[label=\"Tipo:%s \\l Pasajeros:%d \\l Turnos \\l desabordaje:%d \\l\"];\n",aux->id,getTipo(aux->tipo),aux->pasajeros,aux->tiempo_desbordaje);
        if(aux->siguiente == NULL){

        }else{
            aux = aux->siguiente;
            while(aux != NULL){
                fprintf(archivo,"nodo%d[label=\"Tipo:%s \\l Pasajeros:%d \\l Turnos \\l desabordaje:%d \\l\"];\n",aux->id,getTipo(aux->tipo),aux->pasajeros,aux->tiempo_desbordaje);
                aux = aux->siguiente;
            }
        }
        //conexiones con punteros de los nodos
        fprintf(archivo,"nodo%d",aux2->id);
        if(aux2->siguiente == NULL){
            //Si solo hay un nodo en la lista
        }else{
            aux2 = aux2->siguiente;
            while (aux2 != NULL) {
                 fprintf(archivo,"->nodo%d",aux2->id);
                 aux2 = aux2->siguiente;
            }

            fprintf(archivo,";\n");

            while (temporal != primero){
               fprintf(archivo,"nodo%d->",temporal->id);
               temporal = temporal->anterior;
            }
            fprintf(archivo,"nodo%d",primero->id);

            fprintf(archivo,";\n");
        }

        fprintf(archivo,"}\n");
        fclose(archivo);

        system("dot -Tpng aviones.txt -o Aviones.png");
    }
}

char *ColaDoble::getTipo(int numero){
    if(numero == 1){
        return "pequeño";
    }else if(numero == 2){
        return "mediano";
    }else if(numero == 3){
        return "grande";
    }
}


//****************************************************   P A S A J E R O S   *****************************************************
void ColaPasajeros::Insertar(int id, int equipaje, int documentos, int tiempo_registro){
    Pasajero *nuevo = new Pasajero(id,equipaje,documentos,tiempo_registro);
    if(primero == NULL){
        primero = nuevo;
    }else{
        Pasajero *tmp = primero;
        while (tmp->siguiente != NULL) {
            tmp = tmp->siguiente;
        }
        tmp->siguiente = nuevo;
    }
    size++;
 }

 Pasajero *ColaPasajeros::Eliminar(){

 }

 //***************************************************  E S C R I T O R I O S  ****************************************************
 void DobleOrdenada::Insertar(char id, int estado, int documentos, int faltante){
    Escritorio *nuevo = new Escritorio(id, estado, documentos, faltante);
    if(primero == NULL){
        primero = ultimo = nuevo;
    }else{
        if(nuevo->id < primero->id){  //Inserción al inicio
            primero->anterior = nuevo;
            nuevo->siguiente = primero;
            primero = nuevo;
        }else if(nuevo->id > ultimo->id){ //Inserción al final
            ultimo->siguiente = nuevo;
            nuevo->anterior = ultimo;
            ultimo = nuevo;
        }else{ //Inserción en el medio
            Escritorio * aux = primero;
            while (aux->siguiente != NULL) {
                if(nuevo->id < aux->siguiente->id){
                    nuevo->siguiente = aux->siguiente;
                    aux->siguiente->anterior = nuevo;
                    nuevo->anterior = aux;
                    aux->siguiente = nuevo;
                    break;
                }
                aux = aux->siguiente;
            }
        }
    }
 }

void DobleOrdenada::Graficar(){
    FILE *archivo;
    archivo = fopen("escritorios.txt", "w");
    if(archivo == NULL){
        exit(-1);
    }
    Escritorio *aux = primero;
    Escritorio *aux2 = ultimo;
    if(aux == NULL){
        fprintf(archivo, "No existen nodos en la lista de días");
    }else{
        fprintf(archivo,"digraph Escritorios{\n");
        fprintf(archivo,"rankdir=TB;\n");
        fprintf(archivo,"fontname = \"Bitstream Vera Sans\"\n");
        fprintf(archivo,"node[shape = record, style = filled, fillcolor = seashell2, fontname = \"Bitstream Vera Sans\"];\n");
        fprintf(archivo,"{\n");
        fprintf(archivo,"rank=min;\n");
        //datos de la lista doble
        fprintf(archivo,"nodo%c[label=\"%c \\n Estado:%d \\l\"];\n",aux->id,aux->id,aux->estado);
        if(aux->siguiente == NULL){

        }else{
            aux = aux->siguiente;
            while(aux != NULL) {
                 fprintf(archivo,"nodo%c[label=\"%c \\n Estado:%d \\l\"];\n",aux->id,aux->id,aux->estado);
                 aux =  aux->siguiente;
            }
        }
        fprintf(archivo,"};\n");
        //conexiones con punteros de los nodos escritorio
        aux = primero;
        fprintf(archivo,"nodo%c", aux->id);
        if(aux->siguiente == NULL){

        }else{
            aux = aux->siguiente;
            while(aux != NULL) {
                fprintf(archivo,"->nodo%c",aux->id);
                aux = aux->siguiente;
            }
            fprintf(archivo,";\n");

            while(aux2 != primero) {
                fprintf(archivo,"nodo%c->",aux2->id);
                aux2 = aux2->anterior;
            }
            fprintf(archivo,"nodo%c",primero->id);
            fprintf(archivo,";\n");
        }
        //fin de conexion de los punteros de los nodos escritorio

        //personas de cada escritorio
        aux = primero;
        while(aux != NULL){
            Pasajero *tmp = aux->cola_pasajeros->primero;
            if(tmp == NULL){

            }else{
                while(tmp != NULL) {
                    fprintf(archivo,"nodo%d[label=\"Pasajero:%d \\l Maletas:%d \\l Documentos:%d\"];\n", tmp->id,tmp->id,tmp->equipaje,tmp->documentos);
                    tmp = tmp->siguiente;
                }
            }
            aux = aux->siguiente;
        }
        //fin de listado de personas de cada escritorio

        //Enlazando Escritorios con su cola de personas
        aux = primero;
        while(aux != NULL) {
            Pasajero *tmp = aux->cola_pasajeros->primero;
            fprintf(archivo,"nodo%c",aux->id);
            if(tmp == NULL){

            }else{
                while(tmp != NULL){
                    fprintf(archivo,"->nodo%d",tmp->id);
                    tmp = tmp->siguiente;
                }
            }
            fprintf(archivo, ";\n");
            aux = aux->siguiente;
        }
        //Fin de enlaces

        fprintf(archivo,"}\n");
        fclose(archivo);

        system("dot -Tpng escritorios.txt -o Escritorios.png");
    }
}

//***************************************************   E S T A C I O N E S   ****************************************************
void Simple::Insertar(int id, int estado, int faltante){
    Estacion *nuevo = new Estacion(id,estado,faltante);
    if(primero == NULL){
        primero = nuevo;
    }else{
        Estacion *tmp = primero;
        while (tmp->siguiente != NULL) {
            tmp = tmp->siguiente;
        }
        tmp->siguiente = nuevo;
    }
}

void Simple::Graficar(){
    FILE *archivo;
    archivo = fopen("estaciones.txt", "w");
    if(archivo == NULL){
        exit(-1);
    }
    Estacion *aux = primero;

    if(primero == NULL){
        fprintf(archivo,"No existen nodos en la lsita de personas");
    }else{
        fprintf(archivo,"digraph Estaciones{\n");
        fprintf(archivo,"rankdir=LR;\n");
        fprintf(archivo,"fontname = \"Bitstream Vera Sans\"\n");
        fprintf(archivo,"node[shape=record,style=filled,fillcolor=seashell2,fontname = \"Bitstream Vera Sans\"];\n");
        //datos de la lista simple
        fprintf(archivo,"nodo%d[label=\"Estado:%d \\l Turnos \\l faltantes:%d \\l\"];\n",aux->id,aux->estado,aux->faltante);
        if(aux->siguiente == NULL){

        }else{
            aux = aux->siguiente;
            while(aux != NULL){
                fprintf(archivo,"nodo%d[label=\"Estado:%d \\l Turnos \\l faltantes:%d \\l\"];\n",aux->id,aux->estado,aux->faltante);
                aux = aux->siguiente;
            }
        }
        //conexiones con punteros de los nodos
        aux = primero;
        fprintf(archivo,"nodo%d",aux->id);
        if(aux->siguiente == NULL){
            //Si solo hay un nodo en la lista
        }else{
            aux = aux->siguiente;
            while (aux != NULL) {
                 fprintf(archivo,"->nodo%d",aux->id);
                 aux = aux->siguiente;
            }
            fprintf(archivo,";\n");
        }
        fprintf(archivo,"}\n");
        fclose(archivo);

        system("dot -Tpng estaciones.txt -o Estaciones.png");
    }
}
























