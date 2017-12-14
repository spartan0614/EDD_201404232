#include "aereopuerto.h"
#include "ui_aereopuerto.h"
#include <time.h>
#include <stdlib.h>

int identificadorAvion = 0;

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
            pasajeros = rand()%11+5;
            t_desabordaje = 1;
            t_mantenimiento = rand()%3+1;
        }else if(tipo == 2){
            pasajeros = rand()%26+15;
            t_desabordaje = 2;
            t_mantenimiento = rand()%5+2;
        }else if(tipo == 3){
            pasajeros = rand()%41+30;
            t_desabordaje = 3;
            t_mantenimiento = rand()%7+3;
        }

        listaAviones->Insertar(identificadorAvion,tipo,pasajeros,t_desabordaje,t_mantenimiento);
        identificadorAvion++;
    }
    listaAviones->Graficar();
    QPixmap a("Aviones.png");
    ui->lblAviones->setPixmap(a);

    //Inicio de la lista de escritorios


}

void aereopuerto::on_btnSiguiente_clicked()
{

}
