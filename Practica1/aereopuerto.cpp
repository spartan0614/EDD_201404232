#include "aereopuerto.h"
#include "ui_aereopuerto.h"
#include <time.h>
#include <stdlib.h>

int identificadorAvion = 0;
int identificadorEstacion = 0;
int identificacionPasajero = 0;
int identificacionMaletas = 0;

aereopuerto::aereopuerto(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::aereopuerto)
{
    ui->setupUi(this);
}

aereopuerto::~aereopuerto()
{
    delete ui;
}

void aereopuerto::on_btnIniciar_clicked()
{
    //Inicio de la cola de aviones
    int noAviones = ui->lineAviones->text().toInt();
    srand(time(NULL));
    for(int i = 0; i < noAviones; i++){
        int tipo = 0;
        int pasajeros = 0;
        int t_desabordaje = 0;
        int t_mantenimiento = 0;
        tipo = rand()%3+1;
        if(tipo == 1){
            pasajeros = rand()%6+5;
            t_desabordaje = 1;
            t_mantenimiento = rand()%3+1;
        }else if(tipo == 2){
            pasajeros = rand()%11+15;
            t_desabordaje = 2;
            t_mantenimiento = rand()%3+2;
        }else if(tipo == 3){
            pasajeros = rand()%11+30;
            t_desabordaje = 3;
            t_mantenimiento = rand()%4+3;
        }
        listaAviones->Insertar(identificadorAvion,tipo,pasajeros,t_desabordaje,t_mantenimiento);
        identificadorAvion++;
    }
    listaAviones->Graficar();
    QPixmap a("Aviones.png");
    ui->lblAviones->setPixmap(a);

    //Inicio de la lista de escritorios
    int noEscritorios = ui->lineEscritorios->text().toInt();
    for(int j = 0; j < noEscritorios; j++){
        char letra = BuscarLetra();
        listaEscritorios->Insertar(letra,0,0,0);

    }
    listaEscritorios->Graficar();
    QPixmap b("Escritorios.png");
    ui->lblEscritorios->setPixmap(b);

    //Inicio de la lista de estaciones
    int noEstaciones = ui->lineEstaciones->text().toInt();
    for(int k = 0; k < noEstaciones; k++){
        listaEstaciones->Insertar(identificadorEstacion,0,0);
        identificadorEstacion++;
    }
    listaEstaciones->Graficar();
    QPixmap c("Estaciones.png");
    ui->lblEstaciones->setPixmap(c);

}

char aereopuerto::BuscarLetra(){
     char letra = rand()%26+65;
     Escritorio *tmp = listaEscritorios->primero;
     if(tmp == NULL){
        return letra;
     }else{
         while(tmp != NULL) {
            if(tmp->id == letra){
                return BuscarLetra();
            }
            tmp = tmp->siguiente;
         }
         //Si llego hasta aquí es porque la letra no se encuentra en la lista
         return letra;
     }
}

void aereopuerto::on_btnSiguiente_clicked()
{
    //>>>>>>>Pasajeros en cola de Escritorios
    AtenderPasajeros();

    //>>>>>>Pasajeros en cola de espera
    EncolarEnEspera();

    //>>>>>>>Aviones en mantenimiento
    AtenderAviones();

    //>>>>>Aviones
    //verificar que la lista de aviones no esté vacia
    Avion *tmp_plane = listaAviones->primero;
    if(tmp_plane == NULL){
        //ya no quedan aviones para desabordar
    }else{
        //preguntar si el tiempo de sabordaje no ha terminado
       if(tmp_plane->tiempo_desbordaje == 0){
           //se debe eliminar el avion de la lista y enviarlo a mantenimiento
           Avion *listo = listaAviones->Eliminar();
           LlevarMantenimiento(listo);

       }else{
            //preguntar si los pasajeros aún están arriba
           int noPasajeros = tmp_plane->pasajeros;
           if(noPasajeros > 0){
                //sacar pasajeros de la lista y repartirnos en los escritorios
                DesabordarPasajeros(noPasajeros);
                tmp_plane->pasajeros = 0;
                tmp_plane->tiempo_desbordaje--;
           }else{
               //simplemente se le resta un turno al avión
               tmp_plane->tiempo_desbordaje--;
           }
       }
    }

    listaAviones->Graficar();
    QPixmap a("Aviones.png");
    ui->lblAviones->setPixmap(a);

    listaEscritorios->Graficar();
    QPixmap b("Escritorios.png");
    ui->lblEscritorios->setPixmap(b);

    listaEstaciones->Graficar();
    QPixmap c("Estaciones.png");
    ui->lblEstaciones->setPixmap(c);

    //Si se llenó la cola de pasajeros debe mostrarse
    if(listaPasajeros->primero != NULL){
        listaPasajeros->Graficar();
        QPixmap e("Pasajeros.png");
        ui->lblPasajeros->setPixmap(e);
    }

    if(listaEsperaMantenimiento->primero != NULL){
        listaEsperaMantenimiento->GraficarEspera();
        QPixmap f("Mantenimiento.png");
        ui->lblMantenimiento->setPixmap(f);
    }

    if(listaMaletas->primero != NULL){
        listaMaletas->Graficar();
        QPixmap h("Equipaje.png");
        ui->lblMaletas->setPixmap(h);
    }
}

void aereopuerto::DesabordarPasajeros(int numero){
    Escritorio *tmp = listaEscritorios->primero;
    //preguntar si la lista de escritorios no esta vacía.
    if(tmp == NULL){
        //No pasa nada porque no puede hacer nada
    }else{
        srand(time(NULL));
        while(tmp != NULL) {
            if(numero == 0){
                break;
            }
            if(tmp->cola_pasajeros->size < 10){
                for(int i = tmp->cola_pasajeros->size; i < 10; i++){
                    int maletas = 0;
                    int documentos = 0;
                    int turnos_registro = 0;

                    maletas = rand()%4+1;
                    documentos = rand()%10+1;
                    turnos_registro = rand()%3+1;

                    tmp->cola_pasajeros->Insertar(identificacionPasajero,maletas,documentos,turnos_registro);
                    for(int w = 0; w < maletas; w++){
                        listaMaletas->Insertar(identificacionMaletas);
                        identificacionMaletas++;
                    }
                    identificacionPasajero++;
                    numero--;
                    if(numero == 0){
                        break;
                    }
                }
            }
            tmp = tmp->siguiente;
        }

        if(numero > 0){  //Si ya no caben las personas en los escritorios entonces se debe llenar la cola de espera.
            for(int i = 0; i < numero; i++){
                int maletas = 0;
                int documentos = 0;
                int turnos_registro = 0;

                maletas = rand()%4+1;
                documentos = rand()%10+1;
                turnos_registro = rand()%3+1;

                listaPasajeros->Insertar(identificacionPasajero,maletas,documentos,turnos_registro);
                identificacionPasajero++;
            }
        }
        numero = 0;
    }
}

void aereopuerto::AtenderPasajeros(){
    Escritorio *tmp = listaEscritorios->primero;
    if(tmp == NULL){
        //No hay escritorios en la lista
    }else{
        while(tmp != NULL){
            Pasajero *actual = tmp->cola_pasajeros->primero;
            if(actual != NULL){
                int time_actual = actual->tiempo_registro;
                if(time_actual == 0){
                    //Quitar la cantidad de maletas del pasajero en la lista circular
                    for(int i = 0; i < actual->equipaje; i++){
                        listaMaletas->Eliminar();
                    }
                    //Si el turno del pasajero llega a cero entonces debe eliminarse
                    tmp->cola_pasajeros->Eliminar();

                }else{
                    //restar el tiempo para registro en la cola
                    actual->tiempo_registro--;
                }
            }
            tmp = tmp->siguiente;
        }
    }
}

void aereopuerto::EncolarEnEspera(){
    Escritorio *tmp = listaEscritorios->primero;
    if(tmp == NULL){
            //No hay escritorios en la lista entonce no se puede hacer nada
    }else{
         while(tmp != NULL) {
            if(listaPasajeros->primero == NULL){
                break;
            }
            if(tmp->cola_pasajeros->size < 10){
                for(int i = tmp->cola_pasajeros->size;i<10;i++){
                    Pasajero *nuevo = listaPasajeros->getPasajero();
                    tmp->cola_pasajeros->Insertar(nuevo->id,nuevo->equipaje,nuevo->documentos,nuevo->tiempo_registro);
                    if(listaPasajeros->primero == NULL){
                        break;
                    }
                }
            }
            tmp = tmp->siguiente;
        }
    }
}

void aereopuerto::LlevarMantenimiento(Avion *plane){
    bool hayEspacio = false;
    if(listaEstaciones->primero == NULL){
        //No pasa nada porque no hay estaciones de mantenimietno
    }else{
        Estacion *tmp = listaEstaciones->primero;
        while(tmp != NULL) {
            if(tmp->acceso == NULL){
                tmp->acceso = plane;
                hayEspacio = true;
                break;
            }
            tmp = tmp->siguiente;
        }
        //Si llego hasta acá es porque todas las estaciones están ocupadas
        //Entonces se debe empezar a llenar otra lista de espera
        if(hayEspacio == false){
            listaEsperaMantenimiento->Insertar(plane->id,plane->tipo,plane->pasajeros,plane->tiempo_desbordaje,plane->tiempo_mantnimento);
        }
        hayEspacio = false;
    }
}

void aereopuerto::AtenderAviones(){
    Estacion *tmp = listaEstaciones->primero;
    if(tmp == NULL){
        //No hay estacione en la lista
    }else{
        while(tmp != NULL) {
            Avion *actual = tmp->acceso;
            if(actual != NULL){
                int time_actual = actual->tiempo_mantnimento;
                if(time_actual == 0){
                    //Si el turno del avión llega a cero entonces debe eliminarse
                    tmp->acceso = NULL;
                }else{
                    //restar el tiempo de mantenimiento de avión en la estación
                    actual->tiempo_mantnimento--;
                }
            }
            tmp = tmp->siguiente;
        }
    }
}




















