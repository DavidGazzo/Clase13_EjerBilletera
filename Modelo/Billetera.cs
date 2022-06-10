using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Clase13_EjerBilletera.Modelo
{
    internal class Billetera
    {
        public int _billetesDe10;
        public int _billetesDe20;
        public int _billetesDe50;
        public int _billetesDe100;
        public int _billetesDe200;
        public int _billetesDe500;
        public int _billetesDe1000;

        public void SetBilletera(Billetera billet, int item, int cantidad)
        {
            // Guarda en cada campo (item) la cantidad de billetes ingresados en CargarBilletera
            // en la billetera recibida por parámetro
            switch (item)
            {
                case 10:
                    billet._billetesDe10 = cantidad;
                    break;
                case 20:
                    billet._billetesDe20 = cantidad;
                    break;
                case 50:
                    billet._billetesDe50 = cantidad;
                    break;
                case 100:
                    billet._billetesDe100 = cantidad;
                    break;
                case 200:
                    billet._billetesDe200 = cantidad;
                    break;
                case 500:
                    billet._billetesDe500 = cantidad;
                    break;
                case 1000:
                    billet._billetesDe1000 = cantidad;
                    break;
            }
        }// Fin SetBilletera

        public void CargarBilletera(Billetera billet, string nombreBilletera)
        {
            Tools tools = new Tools();
            // Carga la cantidad de billetes en campos "_billetesDe..."
            // en la billetera recibida por parámetro
            Console.SetCursorPosition(0, 5);
            Console.WriteLine($"Cargando Billetera {nombreBilletera}\n");
            int[] denominacion = new int[] { 10, 20, 50, 100, 200, 500, 1000 };
            
            foreach (var item in denominacion)
            {
                int left = Console.CursorLeft;
                int top = Console.CursorTop;
                Console.SetCursorPosition(0, 6);
                Console.WriteLine("Ingrese cantidad de billetes de:");
                Console.ForegroundColor = ConsoleColor.Yellow;                
                Console.Write($"  $ {item} :           ");
                Console.ResetColor();
                Console.SetCursorPosition(11, 7);
                bool esNumero = false;
                int cantidad = 0;
                do

                {   // Control de error de ingreso, sólo permite nros enteros                    
                    Console.SetCursorPosition(11, 7);                    
                    var ingreso = Console.ReadLine();
                    esNumero = tools.ctrlNumber(ingreso);
                    if (!esNumero)
                    {
                        Console.SetCursorPosition(15, 7);
                        Console.WriteLine("Solo puede ungresar números enteros...");
                    }
                    else
                    {
                        Console.SetCursorPosition(15, 7);
                        Console.WriteLine("                                      ");
                        cantidad = int.Parse(ingreso);
                    }
                } while (esNumero==false);
                tools.BarraAvance(cantidad);
                tools.BorrarBarra(0, left, top);
                SetBilletera(billet, item, cantidad);   // Asigan el valor ingresado en cada campo
            }
        }// Fin CargarBilletera

        public decimal Total(Billetera billet)
        {   // Suma los valores nominales de los billetes por la cantidad de cada uno
            // obtiene el total en $$$ de la billetera recibida por parámetro
            decimal total = billet._billetesDe10 * 10 +
                    billet._billetesDe20 * 20 +
                    billet._billetesDe50 * 50 +
                    billet._billetesDe100 * 100 +
                    billet._billetesDe200 * 200 +
                    billet._billetesDe500 * 500 +
                    billet._billetesDe1000 * 1000;
            return total;
        }// Fin Total

        public Billetera Combinar(Billetera billet1, Billetera billet2)
        {   // Combinación de billeteras recibidas por parámetro
            // el segundo parámetro recibe el dinero
            billet2._billetesDe10 += billet1._billetesDe10;
            billet2._billetesDe20 += billet1._billetesDe20;
            billet2._billetesDe50 += billet1._billetesDe50;
            billet2._billetesDe100 += billet1._billetesDe100;
            billet2._billetesDe200 += billet1._billetesDe200;
            billet2._billetesDe500 += billet1._billetesDe500;
            billet2._billetesDe1000 += billet1._billetesDe1000;

            return billet2;
        }// Fin Combinar

        public Billetera Extraccion(Billetera billet)
        {    // Pone a 0(cero) la billetera que recibe por parámetro
            billet._billetesDe10 = 0;
            billet._billetesDe20 = 0;
            billet._billetesDe50 = 0;
            billet._billetesDe100 = 0;
            billet._billetesDe200 = 0;
            billet._billetesDe500 = 0;
            billet._billetesDe1000 = 0;

            return billet;
        }// Fin Extraccion

        public int[] CantidadesVector(Billetera billet)
        {   // Obtiene las cantidades de cada denominación
            // de la billetera recibida por parámetro
            int[] cantidades = new int[7];
            cantidades[0] = billet._billetesDe10;
            cantidades[1] = billet._billetesDe20;
            cantidades[2] = billet._billetesDe50;
            cantidades[3] = billet._billetesDe100;
            cantidades[4] = billet._billetesDe200;
            cantidades[5] = billet._billetesDe500;
            cantidades[6] = billet._billetesDe1000;

            return cantidades;
        }

        public void LlenarBilletera(Billetera billet, Tools tools, string idBillet)
        {   // Ingreso de cantidades de billetes de cada denominacion
            // en la billetera recibida por parámetro 
            do
            {
                Console.Clear();
                Console.WriteLine(tools.PresentationPoster("Billetera Virtual"));
                billet.CargarBilletera(billet, idBillet);
                billet.ImprimirBilletera(billet);//, billet.Total(billet));
                                                 //Muestra contenido de billeteras 1 y 2 iniciales
                Console.WriteLine($"Billetera {idBillet} cuenta con: $ {billet.Total(billet)}\n");
                //if (ContinuarSiNo()) break;
            } while (tools.ContinuarSiNo());
        }// Fin LlenarBilletera

        public void ImprimirBilletera(Billetera billet)
        {   // Imprime en pantalla  la billetera recibida por parámetro
            int[] denominacion = new int[] { 10, 20, 50, 100, 200, 500, 1000 };

            Console.WriteLine("┌───────────────────┬────────────┬────────────┐");
            Console.WriteLine("│    Denominación   │CantBilletes│ Subtotal $ │");
            Console.WriteLine("├───────────────────┼────────────┼────────────┤");

            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            for (int i = 0; i < 7; i++)
            {
                int[] cantidades = CantidadesVector(billet);

                Console.SetCursorPosition(left, top + i);
                Console.Write($"│ Denominacion ${denominacion[i]}");
                Console.SetCursorPosition(left + 20, top + i);
                Console.Write($"│ {cantidades[i]}");
                Console.SetCursorPosition(left + 33, top + i);
                Console.Write($"│ ${cantidades[i] * denominacion[i]}");
                Console.SetCursorPosition(left + 46, top + i);
                Console.Write("│\n");
            }
            Console.SetCursorPosition(0, top + 7);
            Console.WriteLine("├───────────────────┴────────────┼────────────┤");
            Console.Write($"│           Total en Billetera   │ ${Total(billet)}");
            Console.SetCursorPosition(left + 46, top + 8);
            Console.Write("│\n");
            Console.WriteLine("└────────────────────────────────┴────────────┘");
        }// Fin ImprimirBilletera

    }// Fin class
}
// Fin namespace
