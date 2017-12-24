using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinario ab = new ArbolBinario();
            ab.Insertar("/");
            ab.Insertar("&");
            ab.Insertar("a");
            ab.Insertar("b");
            ab.Insertar("z");
            ab.Insertar("$");
            ab.Insertar("y");
            ab.Insertar("1");
            ab.Insertar("o");
            ab.Insertar("k");
            ab.Insertar("(");

        System.Diagnostics.Debug.WriteLine("PREORDEN: ");
        ab.Preorden(ab.getRaiz());
        System.Diagnostics.Debug.WriteLine("");

        System.Diagnostics.Debug.WriteLine("ENORDEN: ");
        ab.Enorden(ab.getRaiz());
        System.Diagnostics.Debug.WriteLine("");

        System.Diagnostics.Debug.WriteLine("POSTORDEN: ");
        ab.Postorden(ab.getRaiz());


        }
    }
}
