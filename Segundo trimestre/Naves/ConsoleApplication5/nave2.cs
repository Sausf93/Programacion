using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class nave2
    {
        public int x, y;
        public char caracter;
        public char disparo;
        public int finx, finy;
        public bool vivo = true;
        public ConsoleColor colorActivo;


        public nave2(int x1, int y1, char car1, char disparo0, ConsoleColor color0)
        {
            x = x1;
            y = y1;
            caracter = car1;
            disparo = disparo0;
            colorActivo = color0;
            finx = 70;
            finy = 50;
            visualizar();

        }

        public void visualizar()
        {

            Console.ForegroundColor = colorActivo;
            Console.SetCursorPosition(x, y);
            Console.Write(caracter);
            Console.Write(caracter);
            Console.Write(caracter);
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write(caracter);

        }


        public void mover(int incx, int incy)
        {

            x = x + incx;

            if (x < 0 || y < 0 || x > finx || y > finy)
            {
                x = x - incx;

                

            }
            if (x > 68)
            {
                x = 1;
                y+=3;
                for (int i = 25; i > 0; i--)
                {
                    Console.SetCursorPosition(70, i);
                    Console.WriteLine(" ");
                }

            }
            
            visualizar();
        }
        public void borrar()
        {
            Console.SetCursorPosition(x - 1, y);
            Console.Write("    ");
            Console.SetCursorPosition(x+1, y + 1);
            Console.Write(" ");
        }


    }

}