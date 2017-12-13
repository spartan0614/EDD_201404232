#ifndef AEREOPUERTO_H
#define AEREOPUERTO_H

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

private:
    Ui::aereopuerto *ui;
};

#endif // AEREOPUERTO_H
