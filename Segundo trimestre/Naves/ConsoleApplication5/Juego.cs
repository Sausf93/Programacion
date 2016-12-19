using System;
using System.Collections.Generic;
using System.Threading;
using Nave;

namespace ConsoleApplication5
{
    internal class Juego
    {
        public nave Nave1;
        private List<nave2> Lista;
        public int Puntos;



        public Juego(int x, int y, char car1, char disparo1, ConsoleColor color1)
        {
            Nave1 = new nave(x, y, car1, disparo1, color1);
            Lista = new List<nave2>();
            CreaLista();
        }

        public void Inicia()
        {
             
            int acaba = 0;
            bool morir = false;
            ConsoleKeyInfo car;
           
            do
            {

                car = Console.ReadKey(true);
                switch (car.Key)
                {
                    case ConsoleKey.LeftArrow:
                        Nave1.mover(-2, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        Nave1.mover(2, 0);
                        break;
                    case ConsoleKey.Spacebar:
                        Dispara();
                        break;
                }
                for (int index = Lista.Count - 1; index >= 0; index--)
                {
                    // nave2 enemigosNave2 = Lista[index];
                    if(Lista[index].y == Nave1.y)  //if (enemigosNave2.y==Nave1.y)     
                    {
                        morir = true;

                    }
                    }
               
                Puntos=Disparoenemigo(Puntos);
                MoverLista();
                Console.SetCursorPosition(28, 28);
                Console.Write(Puntos);
                Muerte(morir);
                if (acaba == -1)
                {
                    return;
                }
                if (Puntos == 1600)
                {   
                    Console.Clear();
                    Console.SetCursorPosition(1,1);
                    Console.WriteLine(" _      _ _______  _     _      _     _  ________ _       ");
                    Thread.Sleep(50);
                    Console.WriteLine("| )    ( |( ___  )| )   ( |    | )   ( |)__   __(| (    /|");
                    Thread.Sleep(50);
                    Console.WriteLine("( )   / )| (   ) || )   ( |    | )   ( |   ) (   |  )  ( |");
                    Thread.Sleep(50);
                    Console.WriteLine(" ( (_) ) | |   | || |   | |    | | _ | |   | |   |   ) | |");
                    Thread.Sleep(50);
                    Console.WriteLine("  (   )  | |   | || |   | |    | |( )| |   | |   | ( | | |");
                    Thread.Sleep(50);
                    Console.WriteLine("   ) (   | |   | || |   | |    | || || |   | |   | | ()  |");
                    Thread.Sleep(50);
                    Console.WriteLine("   | |   | (___) || (___) |    | () () |___) (___| )  (  |");
                    Thread.Sleep(50);
                    Console.WriteLine("   (_)   (_______)(_______)    (_______)(_______)|/    )_)");
                    Thread.Sleep(200);
                    Console.Clear();
                    Console.WriteLine("Tu puntuación ha sido: "+Puntos);
                    Console.Write("Pulse Enter Para Salir...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            } while (car.Key != ConsoleKey.Escape);
        }


        public void CreaLista()
        {

            for (int i = 1; i <= 2; i++)
                for (int j = 1; j <= 8; j++)
                {
                    nave2 n = new nave2(j * 5, i * 5, 'o', '|', ConsoleColor.Yellow);
                    Lista.Add(n);
                }
        }

        public void MoverLista()
        {
            foreach (nave2 nave in Lista)
            {
                nave.borrar();
                nave.mover(1, 0);
            }
        }


        public void Dispara()
        {
            for (int i = 23; i > 0; i--)
            {
                Console.SetCursorPosition(Nave1.x, i);
                Console.Write(Nave1.disparo);
                Thread.Sleep(10);
            }
            Console.Beep(1500, 100);




            for (int j = 23; j > 0; j--)
            {
                Console.SetCursorPosition(Nave1.x, j);
                Console.WriteLine(" ");
            }
            
            CompruebaDisparo();
        }

        public void CompruebaDisparo()
        {
            for (int index = Lista.Count - 1; index >= 0; index--)
            {
                nave2 enemigosNave2 = Lista[index];
                if (Nave1.x == enemigosNave2.x + 1)
                {
                    enemigosNave2.borrar();
                    Lista[index].borrar();
                    Lista.RemoveAt(index);
                    Lista.Remove(enemigosNave2);
                    enemigosNave2.borrar();
                    Puntos=Puntos +100;
                    break;
                }
            }
        }

        protected int Disparoenemigo(int puntos)
        {
            int w;
            bool hecho = false;
            Random valor = new Random();
            
            while (hecho == false)
            {
                nave2 enemigosNave2 = Lista[valor.Next(0, Lista.Count-1)];
                if (enemigosNave2.y > 6)
                {
                    w = 15;
                }
                else
                {
                    w = 20;
                }
                for (int i = 1; i < w; i++)
                {
                    Console.SetCursorPosition(enemigosNave2.x + 1, enemigosNave2.y + 1 + i);
                    Console.Write(enemigosNave2.disparo);
                    Thread.Sleep(10);
                }
                for (int j = 1; j < w; j++)
                {
                    Console.SetCursorPosition(enemigosNave2.x + 1, enemigosNave2.y + 1 + j);
                    Console.WriteLine(" ");
                }
                hecho = true;
               Console.Beep(1000, 200);
              

                if (Nave1.x == enemigosNave2.x + 1)
                {
                    Muerte(true);
                }
                else if (Nave1.y == enemigosNave2.y + 2)
                {
                  
                    Muerte(true);
                }
            }
            return (puntos);
    
        }

        public void Muerte(bool muerto)
        {
           
            if (muerto)
            {
                Nave1.borrar();
                Console.SetCursorPosition(Nave1.x - 2, Nave1.y);
                Console.WriteLine("*");
                Console.SetCursorPosition(Nave1.x - 1, Nave1.y - 1);
                Console.WriteLine("*");
                Console.SetCursorPosition(Nave1.x + 1, Nave1.y - 1);
                Console.WriteLine("*");
                Console.SetCursorPosition(Nave1.x + 2, Nave1.y);
                Console.WriteLine("*");
                Console.SetCursorPosition(Nave1.x + 1, Nave1.y + 1);
                Console.WriteLine("*");
                Console.SetCursorPosition(Nave1.x - 1, Nave1.y + 1);
                Console.WriteLine("*");
                Console.SetCursorPosition(Nave1.x, Nave1.y + 2);
                Console.WriteLine("*");
                Thread.Sleep(100);
                Console.Beep(300,200);
                Console.Beep(200,200);
                Console.Clear();
                Console.WriteLine(" _______  _______  _______  _______    _______           _______  _______");
                Thread.Sleep(100);
                Console.WriteLine("(  ____| (  ___  )(       )(  ____ )  (  ___  )|)     /|(  ____ )(  ____ )");
                Thread.Sleep(100);
                Console.WriteLine("| (      | (   ) || () () || (    (/  | (   ) || )   ( || (    (/| (    )|");
                Thread.Sleep(100);
                Console.WriteLine("| |      | (___) || || || || (__      | |   | || |   | || (__    | (____)|");
                Thread.Sleep(100);
                Console.WriteLine("| | ____ |  ___  || |(_)| ||  __)     | |   | |( (   ) )|  __)   |     __)");
                Thread.Sleep(100);
                Console.WriteLine("| | |_  )| (   ) || |   | || (        | |   | | ( )_( / | (      | () (   ");
                Thread.Sleep(100);
                Console.WriteLine("| (___) || )   ( || )   ( || (____/)  | (___) |  (   /  | (____/)| ) ) (__");
                Thread.Sleep(100);
                Console.WriteLine("(_______)|(     )||/     )|(_______/  (_______)   (_/   (_______/|/   )__( ");

                Console.WriteLine("Tu puntuación ha sido: " + Puntos);
                Console.Write("Pulse Enter Para Salir...");
                Console.ReadLine();
                Environment.Exit(0); 
            }
        }
    }
}
