using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase13_EjerBilletera.Modelo
{
    public class Tools
    {
        public string PresentationPoster(string legend)
        {
            // Genera cartel adaptandose al texto recibido
            int longer = legend.Length;
            string tittle = "";
            string space = " ";
            string horizBar = new string('─', longer + 8);
            string vertBar = "│";
            string supIzq = "┌";
            string supDer = "┐";
            string infIzq = "└";
            string infDer = "┘";
            string margenSpace = new string(' ', 4);
            string prefix = vertBar + margenSpace;
            string suffix = margenSpace + vertBar;

            tittle = supIzq + horizBar + supDer + "\n";
            tittle += prefix + legend + suffix + "\n";
            tittle += infIzq + horizBar + infDer + "\n";

            return tittle;
        }   //  End PresentationPoster        

        public bool ctrlNumber(string fact)
        {   // Controla que el valor recibido por parámetro sea numérico
            bool inNumber = Int32.TryParse(fact, out _);
            return inNumber;
        }   // End CtrlNumber


        public bool ContinuarSiNo()
        {   // devuelve verdadero o falso para continuar  (o no ) un proceso
            bool seguir = false;
            // Ubicar cursor para sobreimprimir los mensajes y luego borrarlos
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            string resp = "";
            
            Console.SetCursorPosition(left, top);
            Console.Write("¿Cantidades correctas? 'M'para (M)odificar, otra tecla para aceptar: ");
            resp = Console.ReadLine().ToUpper();
            if (resp == "M")
            {
                seguir = true;
            }
            
            return seguir;
        }// Fin ContinuarSiNo


        public void BarraAvance(int cantidad)
        {   // Simula avance de proceso, parámetro 'cantidad' indica el tiempo de espera en cada bucle
            var contador = 0;
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            Console.SetCursorPosition(left, top);
            for (int i = 0; i < 50; i++)
            {
                Console.SetCursorPosition(left++, top);
                Console.Write("│");
                Console.SetCursorPosition(0, top+1);
                contador+=2;
                Console.WriteLine($"Acreditando {contador}%");
                Thread.Sleep(cantidad/4);
            }
        }// Fin BarraAvance


        public void BarraRetroceso()
        {   // Simula Avance en reversa
            var contador = 100;
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            Console.SetCursorPosition(left, top);
            for (int i = 0; i < 50; i++)
            {
                Console.SetCursorPosition(left++, top);
                Console.Write("║");
                Console.SetCursorPosition(0, top + 1);                
                Console.WriteLine($"Extracción{contador}%");
            }
            BorrarBarra(30,left,top);
        }// Fin BarraRetroceso

        public void BorrarBarra(int cantidad, int left, int top)
        {   // Borra barra de avance
            int contador = 100;
            top = Console.CursorTop;
            left = 50;
            for (int i = 50; i >= 0; i--)
            {
                Console.SetCursorPosition(left--, top - 2);
                Console.Write(" ");
                Console.SetCursorPosition(0, top - 1);
                contador -= 2;
                Console.WriteLine($"Completado {contador}%  ");
                Thread.Sleep(cantidad);
            }
            Console.SetCursorPosition(0, top-1 );
            Console.WriteLine("               ");
        }// Fin BorraBarra
    }
}
