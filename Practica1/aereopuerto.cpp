#include "aereopuerto.h"
#include "ui_aereopuerto.h"

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
