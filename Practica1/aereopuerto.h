#ifndef AEREOPUERTO_H
#define AEREOPUERTO_H
#include "elementos.h"
#include <QMainWindow>

namespace Ui {
class aereopuerto;
}

class aereopuerto : public QMainWindow
{
    Q_OBJECT

public:
    explicit aereopuerto(QWidget *parent = 0);
    ~aereopuerto();

    ColaDoble *listaAviones = new ColaDoble();
    DobleOrdenada *listaEscritorios = new DobleOrdenada();
    Simple *listaEstaciones = new Simple();
    ColaPasajeros *listaPasajeros = new ColaPasajeros();

    char BuscarLetra();
    void DesabordarPasajeros(int numero);

private slots:
    void on_btnIniciar_clicked();

    void on_btnSiguiente_clicked();

private:
    Ui::aereopuerto *ui;
};

#endif // AEREOPUERTO_H
