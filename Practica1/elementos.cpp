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
    if(primero == NULL){
        fprintf(archivo,"No existen nodos en la lsita de personas");
    }else{
        fprintf(archivo,"digraph Aviones{\n");
        fprintf(archivo,"rankdir=LR;\n");
        fprintf(archivo,"fontname = \"Bitstream Vera Sans\"\n");
        fprintf(archivo,"node[shape=record,style=filled,fillcolor=seashell2,fontname = \"Bitstream Vera Sans\"];\n");
        //lista de datos de la lista
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

 //************************************************  E S C R I T O R I O S  **********************************************
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

        //Doblemente ordenada
        //Lista de escritorios ordenada
        fprintf(archivo,"nodo%s[label=\"%s \\n Estado:%d \\l Documentos:%d\"];\n",aux->id, aux->id, aux->estado, aux->documentos);
        if(aux->siguiente == NULL){

        }else{
            aux = aux->siguiente;
            while(aux != NULL){
                fprintf(archivo,"nodo%s[label=\"%s \\n Estado:%d \\l Documentos:%d\"];\n",aux->id, aux->id, aux->estado, aux->documentos);
                aux = aux->siguiente;
            }
        }
        fprintf(archivo,"};\n");
        aux = primero;
        //punteros doblemente enlazada
        fprintf(archivo,"nodo%s",aux->id);
        if(aux->siguiente == NULL){
            //Si solo hay un nodo en la lista
        }else{
            aux = aux->siguiente;
            while (aux != NULL) {
                 fprintf(archivo,"->nodo%s",aux->id);
                 aux = aux->siguiente;
            }

            fprintf(archivo,";\n");

            while (aux2 != primero){
               fprintf(archivo,"nodo%s->",aux2->id);
               aux2 = aux2->anterior;
            }
            fprintf(archivo,"nodo%s",aux2->id);

            fprintf(archivo,";\n");
        }
        //fin de punteros de doblemente enlazada

        //lista de eventos
        aux = primero;
        while( aux != NULL){
            Pasajero *persona_aux = aux->cola_pasajeros->primero;
            if(persona_aux != NULL){
                while(persona_aux != NULL){
                    fprintf(archivo,"nodo%d[label=\"Pasajero:%d \\l Maletas:%d \\l Documentos:%d \\n Duración: %s \"];\n",);
                    persona_aux = persona_aux->siguiente;
                }
            }
            aux = aux->siguiente;
        }


        //enlazando eventos con día.
        do{
            Node<Evento> *evento_aux = aux->valor.listEventos->primero;
            fprintf(archivo,"nodo%d%d%d",aux->valor.dia,aux->valor.mes,aux->valor.anio);
            while (evento_aux != NULL){
                fprintf(archivo,"->nodo%d%d%d%d",aux->valor.dia,aux->valor.mes,aux->valor.anio,evento_aux->valor.horaInicio);
                evento_aux = evento_aux->siguiente;
            }
            fprintf(archivo, ";\n");
            aux = aux->siguiente;
        }while(aux != listDias->primero);

        fprintf(archivo,"}\n");
        fclose(archivo);

        system("dot -Tpng escritorios.txt -o Escritorios.png");
    }

}


























