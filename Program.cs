using Clase13_EjerBilletera.Modelo;

Billetera billet1 = new Billetera();
Billetera billet2 = new Billetera();
Billetera billet3 = new Billetera();
Tools tools = new Tools();  // Métodos auxiliares para impresiones y control de errores

// Carga BILLETERA 1
billet1.LlenarBilletera(billet1, tools,"1(UNO)");
// Carga BILLETERA 2
billet2.LlenarBilletera(billet2, tools,"2(DOS)");

// Prepara pantalla
Console.Clear();
Console.WriteLine(tools.PresentationPoster("Billetera Virtual"));

// Muestra contenido billetera 1 y 2 luego de cargas iniciales
Console.WriteLine($"Billetera 1(UNO) cuenta con: $ {billet1.Total(billet1)}\n");
Console.WriteLine($"Billetera 2(DOS) cuenta con: $ {billet2.Total(billet2)}\n");

// Comienza proceso de COMBINACION 
Console.WriteLine("Presione una tecla para sumar el contenido de Billetera 1(UNO) a Billetera 2(DOS)...");
Console.ReadKey();
billet2.Combinar(billet1, billet2); // Combina
int left = Console.CursorLeft;
int top = Console.CursorTop;
tools.BarraAvance(30);              
tools.BorrarBarra(0,left,top-1);
Console.SetCursorPosition(left, top);
Console.WriteLine("Billetera 1(UNO)"); //Muestra contenido billetera 1 luego de combinación
billet1.ImprimirBilletera(billet1);
Console.WriteLine("Billetera 2(DOS)");  //Muestra contenido billetera 2 luego de combinación
billet2.ImprimirBilletera(billet2);
Console.WriteLine("Operación terminada. Presione una tecla para continuar...");
Console.ReadKey();
// Prepara pantalla
Console.Clear();
Console.WriteLine(tools.PresentationPoster("Billetera Virtual"));

// Comienza extraccion de billeteras 1 y 2 y acreditación en billetera 3
Console.WriteLine("Presione una tecla para extraer el contenido ed Billetera 1 y Billetera 2 y acreditarlo en Billetera 3(TRES)...");
Console.ReadKey();
// Acreditación de billeteras 1 y 2 en billetera 3
billet3.Combinar(billet1, (billet3.Combinar(billet2, billet3)));

//Extraccion de billeteras 1 y 2
billet1.Extraccion(billet1);
billet2.Extraccion(billet2);

Console.WriteLine("Extracción de Billetera 1(UNO) ...");
tools.BarraRetroceso();
Console.WriteLine("Extracción de Billetera 2(DOS) ...");
tools.BarraRetroceso();
Console.WriteLine("Acreditación en Billetera 3(TRES)");
tools.BarraAvance(50);
// Prepara pantalla
Console.Clear();
Console.WriteLine(tools.PresentationPoster("Billetera Virtual"));
Console.SetWindowSize(100, 50);

// Muestra contenidos de Billeteras 1, 2 y 3
Console.WriteLine("Resumen de Cuentas:");
Console.WriteLine("Billetera 1(UNO)");
billet1.ImprimirBilletera(billet1);
Console.WriteLine("Billetera 2(DOS)");
billet2.ImprimirBilletera(billet2);
Console.WriteLine("Billetera 3(TRES)");
billet3.ImprimirBilletera(billet3);
Console.WriteLine("Presione una tecla para finalizar...");
Console.ReadKey();