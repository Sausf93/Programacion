using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;
using System.Net.Http.Headers;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("introducir nombre del jugador: ");
            string jugador = Console.ReadLine();
            jugador = jugador.ToUpper();
            Console.Write("Recuerda que si dejas dos naves una sobre otra, pierdes. Pulse cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(3, 28);
            Console.Write(jugador, "\t");
            Console.Write("\t puntuacion: ");
            Juego juego1 = new Juego(25, 25, '*', '|', ConsoleColor.Red);
            juego1.Inicia();
        }
    }
    }

