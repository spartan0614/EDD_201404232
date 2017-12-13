#include "aereopuerto.h"
#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    aereopuerto w;
    w.show();

    return a.exec();
}
