#ifndef ELEMENTOS_H
#define ELEMENTOS_H

//Nodos
typedef struct Avion Avion;
typedef struct Pasajero Pasajero;
typedef struct Escritorio Escritorio;
typedef struct Documento Documento;
typedef struct Equipaje Equipaje;
typedef struct Estacion Estacion;
//Estructuras
typedef struct ColaDoble ColaDoble;
typedef struct ColaPasajeros ColaPasajeros;
typedef struct DobleOrdenada DobleOrdenada;
typedef struct Circular Circular;
typedef struct Pila Pila;
typedef struct Simple Simple;

//------------------------------------------------  COLA DOBLEMENTE ENLAZADA
struct Avion{
    int id;
    int tipo;  //grande, mediano, pequeño
    int pasajeros;
    int tiempo_desbordaje;
    int tiempo_mantnimento;
    Avion *siguiente;
    Avion *anterior;
    Avion(int id, int tipo, int pasajeros, int tiempo_desbordaje, int tiempo_mantnimento);
};

struct ColaDoble{
    Avion *primero;
    Avion *ultimo;
    void Insertar(int id, int tipo, int pasajeros, int tiempo_desbordaje, int tiempo_mantnimento);
    Avion *Eliminar();
    void Graficar();
    char * getTipo(int numero);
};

//-------------------------------------------------  COLA SIMPLE
struct Pasajero{
    int id;
    int equipaje;
    int documentos;
    int tiempo_registro;
    Pasajero *siguiente;
    Pasajero(int id, int equipaje, int documentos, int tiempo_registro);
};

struct ColaPasajeros{
    int size = 0;
    Pasajero *primero;
    Pasajero *ultimo;
    void Insertar(int id, int equipaje, int documentos, int tiempo_registro);
    Pasajero *Eliminar();
};

//------------------------------------------------  DOBLEMENTE ORDENADA
struct Escritorio{
    char id;
    int estado;                          //ocupado o libre
    int documentos;                      //cantidad de documentos a revisar
    int faltante;                        //tiempo restante de pasajero atendido
    ColaPasajeros *cola_pasajeros;       //Cola simple de pasajeros
    Pila *pila_documentos;               //Pila de documentos de pasajero atendido
    Escritorio *siguiente;
    Escritorio *anterior;
    Escritorio(char id, int estado, int documentos, int faltante);
};

struct DobleOrdenada{
    Escritorio *primero;
    Escritorio *ultimo;
    void Insertar(char id, int estado, int documentos, int faltante);
    void Graficar();
};


//-------------------------------------------------   CIRCULAR
struct Equipaje{
    int maletas;
    Equipaje *siguiente;
    Equipaje *anterior;
    Equipaje(int maletas);
};

struct Circular{
    Equipaje *primero;
    Equipaje *ultimo;
    void Insertar(int maletas);
    void Eliminar(int maletas);
};

//--------------------------------------------------  PILA
struct Documento{ //Pila
    int id;
    Documento *siguiente;
    Documento(int id);
};

struct Pila{
    Documento *cima;
    void Push(int id);
    void Pop();
};

//----------------------------------------------------- SIMPLE
struct Estacion{
    int id;
    int estado; //ocupado o libre
    int faltante; //tiempo restante del avion actual atendido
    Estacion *siguiente;
    Estacion(int id, int estado, int faltante);
};

struct Simple{
    Estacion *primero;
    void Insertar(int id, int estado, int faltante);
    void Graficar();
};


#endif // ELEMENTOS_H
