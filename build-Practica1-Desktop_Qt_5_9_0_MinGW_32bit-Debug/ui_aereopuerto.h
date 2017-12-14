/********************************************************************************
** Form generated from reading UI file 'aereopuerto.ui'
**
** Created by: Qt User Interface Compiler version 5.9.0
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_AEREOPUERTO_H
#define UI_AEREOPUERTO_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_aereopuerto
{
public:
    QWidget *centralWidget;
    QLabel *lblAviones;
    QLabel *lblPasajeros;
    QLabel *lblEscritorios;
    QGroupBox *groupBox;
    QPushButton *btnSiguiente;
    QPushButton *btnIniciar;
    QLineEdit *lineAviones;
    QLineEdit *lineEstaciones;
    QLineEdit *lineEscritorios;
    QLineEdit *lineTurnos;
    QLabel *label;
    QLabel *label_2;
    QLabel *label_3;
    QLabel *label_4;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *aereopuerto)
    {
        if (aereopuerto->objectName().isEmpty())
            aereopuerto->setObjectName(QStringLiteral("aereopuerto"));
        aereopuerto->resize(1729, 912);
        centralWidget = new QWidget(aereopuerto);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        lblAviones = new QLabel(centralWidget);
        lblAviones->setObjectName(QStringLiteral("lblAviones"));
        lblAviones->setGeometry(QRect(20, 20, 1211, 121));
        lblAviones->setScaledContents(true);
        lblPasajeros = new QLabel(centralWidget);
        lblPasajeros->setObjectName(QStringLiteral("lblPasajeros"));
        lblPasajeros->setGeometry(QRect(20, 160, 111, 731));
        lblEscritorios = new QLabel(centralWidget);
        lblEscritorios->setObjectName(QStringLiteral("lblEscritorios"));
        lblEscritorios->setGeometry(QRect(154, 160, 721, 731));
        lblEscritorios->setScaledContents(true);
        groupBox = new QGroupBox(centralWidget);
        groupBox->setObjectName(QStringLiteral("groupBox"));
        groupBox->setGeometry(QRect(1250, 0, 451, 161));
        QFont font;
        font.setFamily(QStringLiteral("Yu Gothic UI Semibold"));
        font.setBold(true);
        font.setWeight(75);
        groupBox->setFont(font);
        btnSiguiente = new QPushButton(groupBox);
        btnSiguiente->setObjectName(QStringLiteral("btnSiguiente"));
        btnSiguiente->setGeometry(QRect(310, 100, 131, 51));
        QFont font1;
        font1.setFamily(QStringLiteral("Yu Gothic UI Semibold"));
        font1.setPointSize(9);
        font1.setBold(true);
        font1.setWeight(75);
        btnSiguiente->setFont(font1);
        btnIniciar = new QPushButton(groupBox);
        btnIniciar->setObjectName(QStringLiteral("btnIniciar"));
        btnIniciar->setGeometry(QRect(310, 30, 131, 51));
        btnIniciar->setFont(font1);
        lineAviones = new QLineEdit(groupBox);
        lineAviones->setObjectName(QStringLiteral("lineAviones"));
        lineAviones->setGeometry(QRect(20, 50, 113, 31));
        lineEstaciones = new QLineEdit(groupBox);
        lineEstaciones->setObjectName(QStringLiteral("lineEstaciones"));
        lineEstaciones->setGeometry(QRect(170, 50, 111, 31));
        lineEscritorios = new QLineEdit(groupBox);
        lineEscritorios->setObjectName(QStringLiteral("lineEscritorios"));
        lineEscritorios->setGeometry(QRect(20, 120, 111, 31));
        lineTurnos = new QLineEdit(groupBox);
        lineTurnos->setObjectName(QStringLiteral("lineTurnos"));
        lineTurnos->setGeometry(QRect(170, 120, 113, 31));
        label = new QLabel(groupBox);
        label->setObjectName(QStringLiteral("label"));
        label->setGeometry(QRect(20, 30, 55, 16));
        label_2 = new QLabel(groupBox);
        label_2->setObjectName(QStringLiteral("label_2"));
        label_2->setGeometry(QRect(20, 100, 71, 16));
        label_3 = new QLabel(groupBox);
        label_3->setObjectName(QStringLiteral("label_3"));
        label_3->setGeometry(QRect(170, 30, 71, 16));
        label_4 = new QLabel(groupBox);
        label_4->setObjectName(QStringLiteral("label_4"));
        label_4->setGeometry(QRect(170, 100, 55, 16));
        aereopuerto->setCentralWidget(centralWidget);
        statusBar = new QStatusBar(aereopuerto);
        statusBar->setObjectName(QStringLiteral("statusBar"));
        aereopuerto->setStatusBar(statusBar);

        retranslateUi(aereopuerto);

        QMetaObject::connectSlotsByName(aereopuerto);
    } // setupUi

    void retranslateUi(QMainWindow *aereopuerto)
    {
        aereopuerto->setWindowTitle(QApplication::translate("aereopuerto", "aereopuerto", Q_NULLPTR));
        lblAviones->setText(QString());
        lblPasajeros->setText(QString());
        lblEscritorios->setText(QString());
        groupBox->setTitle(QApplication::translate("aereopuerto", "Datos Iniciales", Q_NULLPTR));
        btnSiguiente->setText(QApplication::translate("aereopuerto", " Siguiente Turno", Q_NULLPTR));
        btnIniciar->setText(QApplication::translate("aereopuerto", "Iniciar", Q_NULLPTR));
        label->setText(QApplication::translate("aereopuerto", "Aviones:", Q_NULLPTR));
        label_2->setText(QApplication::translate("aereopuerto", "Escritorios:", Q_NULLPTR));
        label_3->setText(QApplication::translate("aereopuerto", "Estaciones:", Q_NULLPTR));
        label_4->setText(QApplication::translate("aereopuerto", "Turnos:", Q_NULLPTR));
    } // retranslateUi

};

namespace Ui {
    class aereopuerto: public Ui_aereopuerto {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_AEREOPUERTO_H
