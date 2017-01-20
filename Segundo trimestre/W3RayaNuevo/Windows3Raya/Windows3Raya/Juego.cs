using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows3Raya
{
    public struct _devolv //Como pasar la estructura a el form//
    {
        public int turno;
        public int fila;
        public int columna;
        public bool ganajugador;
        public bool ganamaquina;
        public bool fin;
        public bool sigue;
    };


    class Juego
    {
        public _devolv dev = new _devolv();
        public int N = 3;
        char[,] TCasillas;
        
        


        public Juego()
        {
            TCasillas = new char[N, N];
            for (int i = 0; i <= N - 1; i++)
            {
                for (int j = 0; j <= N - 1; j++)
                {
                    TCasillas[i, j] = '-';
                }
            }
        }

        public void  MovimientoMaquina(bool turno)
        {
           
        }

        public _devolv devolucion()
        {
          
            Random tirada = new Random();
            bool check = false;
            dev.fila = tirada.Next(0, 3);
            dev.columna = tirada.Next(0, 3);
            while (!check)
            {
                if (TCasillas[dev.fila, dev.columna] == '-')
                {
                    TCasillas[dev.fila, dev.columna] = 'O';
                    check = true;
                }
                else
                {
                    dev.fila = tirada.Next(0, 3);
                    dev.columna = tirada.Next(0, 3);
                } 
            }
           
            return (dev);

        }

        public void compruebamaquina()
        {
            //Horizontal//
            
            for (int i = 0; i < 3; i++)
            {
                int conta = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (TCasillas[i, j] == 'O')
                    {
                        conta++;
                    }
                    if (conta == 3)
                    {
                        dev.ganamaquina = true;
                        return;
                    } 
                }
            }

            //Verticales//
            
            for (int j = 0; j < 3; j++)
                {
                int conta2 = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (TCasillas[i, j] == 'O')
                    {
                        conta2++;
                    }
                    if (conta2 == 3)
                    {
                        dev.ganamaquina = true;
                    } 
                }
             }
                //Diagonales//
                  if ((TCasillas[0, 0] =='O'&& TCasillas[1, 1]=='O') && (TCasillas[1, 1] =='O' && TCasillas[2, 2]=='O'))
            {
                dev.ganamaquina = true;
            }
            if ((TCasillas[0, 2] =='O' && TCasillas[1, 1]== 'O') && (TCasillas[1, 1] =='O' && TCasillas[2, 0]=='O'))
            {
                dev.ganamaquina = true;
            }
        }

        public void GanaJugador()
        {
            //Horizontales//
            for (int i = 0; i < 3; i++)
            {
                int conta = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (TCasillas[i, j] == 'X')
                    {
                        conta++;
                    }
                    if (conta == 3)
                    {
                        dev.ganajugador = true;
                        break;
                    }
                }
            }
            //Verticales//
            for (int j = 0; j < 3; j++)
            {
                int conta2 = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (TCasillas[i, j] == 'X')
                    {
                        conta2++;
                    }
                    if (conta2 == 3)
                    {
                        dev.ganajugador = true;
                        return;
                    }
                }
            }
            //Diagonales//
            if (TCasillas[0,0]=='X' && TCasillas[1,1]=='X' && TCasillas[2,2]=='X')
            {
                dev.ganajugador = true;
                return;
            }
            if (TCasillas[0, 2] == 'X' && TCasillas[1, 1] == 'X' && TCasillas[2, 0] == 'X')
            {
                dev.ganajugador = true;
            }
        }
        public void recoger(string recogidax, string recogiday)
        {
            int x = 0;
            int y = 0;
            //X y Y son las filas y columnas de la jugada mia//.
            x=Convert.ToInt32(recogidax);
            y = Convert.ToInt32(recogiday);
            TCasillas[x, y] = 'X';
        }
    }
}
