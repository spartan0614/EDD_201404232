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
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_aereopuerto
{
public:
    QWidget *centralWidget;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *aereopuerto)
    {
        if (aereopuerto->objectName().isEmpty())
            aereopuerto->setObjectName(QStringLiteral("aereopuerto"));
        aereopuerto->resize(1729, 912);
        centralWidget = new QWidget(aereopuerto);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
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
    } // retranslateUi

};

namespace Ui {
    class aereopuerto: public Ui_aereopuerto {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_AEREOPUERTO_H
