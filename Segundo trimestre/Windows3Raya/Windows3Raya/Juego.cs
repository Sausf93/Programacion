using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows3Raya
{
    /// <summary>
    /// 
    /// </summary>

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

    /// <Juego>
    /// La clase Juego, coge todas las variables, las organiza buenamente, y le presentan a Manu a Claudia.
    /// </Juego>

    internal class Juego
    {

        private int verticales, horizontales, diagonales, diagonales2, conta, conta2;
        public _devolv dev;
        public int N = 3;
        private char[,] TCasillas;


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

        /// <summary>
        /// Hecha//
        /// </summary>
        public void Ganar()
        {
            //Horizontales//
            for (int i = 0; i < 3; i++)
            {
                conta = 0;
                conta2 = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (TCasillas[i, j] == 'X')
                    {
                        conta++;
                    }
                    if (TCasillas[i, j] == 'O')
                    {
                        conta2++;
                    }
                    if (conta == 3)
                    {
                        dev.ganajugador = true;
                        break;
                    }
                    if (conta2 == 3)
                    {
                        dev.ganamaquina = true;
                        break;
                    }
                }
            }

            //Verticales//
            for (int j = 0; j < 3; j++)
            {
                conta2 = 0;
                conta = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (TCasillas[i, j] == 'X')
                    {
                        conta++;
                    }
                    if (TCasillas[i, j] == 'O')
                    {
                        conta2++;
                    }
                    if (conta == 3)
                    {
                        dev.ganajugador = true;
                        break;
                    }
                    if (conta2 == 3)
                    {
                        dev.ganamaquina = true;
                        break;
                    }

                }
            }

            //Diagonales//
            if (TCasillas[0, 0] == 'X' && TCasillas[1, 1] == 'X' && TCasillas[2, 2] == 'X')
            {
                dev.ganajugador = true;
                return;
            }
            if (TCasillas[0, 2] == 'X' && TCasillas[1, 1] == 'X' && TCasillas[2, 0] == 'X')
            {
                dev.ganajugador = true;
            }
            if (TCasillas[0, 0] == 'O' && TCasillas[1, 1] == 'O' && TCasillas[2, 2] == 'O')
            {
                dev.ganamaquina = true;
                return;
            }
            if (TCasillas[0, 2] == 'O' && TCasillas[1, 1] == 'O' && TCasillas[2, 0] == 'O')
            {
                dev.ganamaquina = true;
            }
        }

        public void Recoger(string recogidax, string recogiday)
        {
            // X y Y son las filas y columnas de la jugada mia  //
            int x = Convert.ToInt32(recogidax);
            int y = Convert.ToInt32(recogiday);
            TCasillas[x, y] = 'X';
        }

        public int Empate()
        {
            int empatar = 0;
            int contador = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (TCasillas[i, j] == 'X' || TCasillas[i, j] == 'O')
                    {
                        contador++;
                    }
                    if (contador == 9)
                    {
                        empatar = 1;
                        dev.sigue = false;
                        return (empatar);
                    }
                }
            }
            return (empatar);
        }

        //Tiradas de la maquina: primero tirara a ganar despues comprobara si el medio esta ocupado, despues me ira a tapar a mi si no tiene donde tirar y es la segunda tirada que tire en una esquina y si no que tire aleatorio//
        public _devolv Movimientomaquina()
        {

            //Cambiar todo el chorro de if por for para hacer la maquina inteligentes
            //Horizontales//

            if (dev.turno >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    dev.columna = 1;
                    dev.fila = 1;
                    horizontales = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (TCasillas[i, j] != 'X')
                        {
                            dev.fila = i;
                            dev.columna = j;
                        }
                        if (TCasillas[i, j] == 'X')
                        {
                            horizontales++;
                        }
                    }
                    if (TCasillas[dev.fila, dev.columna] != 'X' && TCasillas[dev.fila, dev.columna] != 'O' &&
                        horizontales == 2)
                    {
                        TCasillas[dev.fila, dev.columna] = 'O';
                        return dev;
                    }
                }

                //Verticales//
                for (int j = 0; j < 3; j++)
                {
                    verticales = 0;
                    dev.columna = 1;
                    dev.fila = 1;
                    for (int i = 0; i < 3; i++)
                    {
                        if (TCasillas[i, j] == '-')
                        {
                            dev.fila = i;
                            dev.columna = j;
                        }
                        if (TCasillas[i, j] == 'X')
                        {
                            verticales++;
                        }
                    }
                    if (TCasillas[dev.fila, dev.columna] != 'X' && TCasillas[dev.fila, dev.columna] != 'O' &&
                        verticales == 2)
                    {
                        TCasillas[dev.fila, dev.columna] = 'O';
                        return dev;
                    }
                }

                //Primera Diagonal//
                diagonales = 0;
                for (int j = 0, i = 0; j < 3 && i < 3; j++, i++)
                {

                    if (TCasillas[i, j] == '-')
                    {
                        dev.fila = i;
                        dev.columna = j;
                    }
                    if (TCasillas[i, j] == 'X')
                    {
                        diagonales++;
                    }
                }
                if (TCasillas[dev.fila, dev.columna] != 'X' && TCasillas[dev.fila, dev.columna] != 'O' &&
                    diagonales == 2)
                {
                    TCasillas[dev.fila, dev.columna] = 'O';
                    return dev;
                }
                //Segunda Diagonal//
                diagonales2 = 0;
                for (int j = 2, i = 0; j >= 0 && i <= 3; j--, i++)
                {

                    if (TCasillas[i, j] == '-')
                    {
                        dev.fila = i;
                        dev.columna = j;
                    }
                    if (TCasillas[i, j] == 'X')
                    {
                        diagonales2++;
                    }
                }
                if (TCasillas[dev.fila, dev.columna] != 'X' && TCasillas[dev.fila, dev.columna] != 'O' &&
                    diagonales2 == 2)
                {
                    TCasillas[dev.fila, dev.columna] = 'O';
                    return dev;
                }

            }


            return tiraresquina() ;
        }

        public _devolv tiradarandom()
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
            return dev;
        }

        // public _devolv tiradaGanar()
        // {
        //Funcion para que cuando hayan dos circulos la maquina tire a ganar antes que a defender//
        // }
        public _devolv tiradagana()  
        {
            if (dev.turno == 1 || (TCasillas[1, 1] == '-' && dev.turno >= 3))
            {
                dev.fila = 1;
                dev.columna = 1;
                TCasillas[dev.fila, dev.columna] = 'O';
                return dev;
            }
            if (dev.turno >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    dev.fila = 1;
                    dev.columna = 1;
                    horizontales = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (TCasillas[i, j] == '-')
                        {
                            dev.fila = i;
                            dev.columna = j;
                        }
                        if (TCasillas[i, j] == 'O')
                        {
                            horizontales++;
                        }
                    }
                    if (TCasillas[dev.fila, dev.columna] != 'O' && TCasillas[dev.fila, dev.columna] != 'X' &&
                        horizontales == 2)
                    {
                        TCasillas[dev.fila, dev.columna] = 'O';
                        return dev;
                    }
                }

                //Verticales//
                for (int j = 0; j < 3; j++)
                {
                    dev.fila = 1;
                    dev.columna = 1;
                    verticales = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        if (TCasillas[i, j] == '-' )
                        {
                            dev.fila = i;
                            dev.columna = j;
                        }
                        if (TCasillas[i, j] == 'O')
                        {
                            verticales++;
                        }
                    }
                    if (TCasillas[dev.fila, dev.columna] != 'X' && TCasillas[dev.fila, dev.columna] != 'O' &&
                        verticales == 2)
                    {
                        TCasillas[dev.fila, dev.columna] = 'O';
                        return dev;
                    }
                }

                //Primera Diagonal//
                diagonales = 0;
                dev.fila = 1;
                dev.columna = 1;
                for (int j = 0, i = 0; j < 3 && i < 3; j++, i++)
                {

                    if (TCasillas[i, j] == '-')
                    {
                        dev.fila = i;
                        dev.columna = j;
                    }
                    if (TCasillas[i, j] == 'O')
                    {
                        diagonales++;
                    }
                }
                if (TCasillas[dev.fila, dev.columna] != 'X' && TCasillas[dev.fila, dev.columna] != 'O' &&
                    diagonales == 2)
                {
                    TCasillas[dev.fila, dev.columna] = 'O';
                    return dev;
                }
                //Segunda Diagonal//
                diagonales2 = 0;
                dev.fila = 1;
                dev.columna = 1;
                for (int j = 2, i = 0; j >= 0 && i <= 3; j--, i++)
                {

                    if (TCasillas[i, j] == '-')
                    {
                        dev.fila = i;
                        dev.columna = j;
                    }
                    if (TCasillas[i, j] == 'O')
                    {
                        diagonales2++;
                    }
                }
                if (TCasillas[dev.fila, dev.columna] != 'X' && TCasillas[dev.fila, dev.columna] != 'O' &&
                    diagonales2 == 2)
                {
                    TCasillas[dev.fila, dev.columna] = 'O';
                    return dev;
                }

            }

            return Movimientomaquina();
        }

        public _devolv tiraresquina()
        {
            int tirada = 0;
            if (dev.turno>=3)
            {
                Random esquina=new Random();
                tirada = esquina.Next(1, 5);
                if (tirada==1 && TCasillas[0,0]=='-')
                {
                    TCasillas[0, 0] = 'O';
                    dev.fila = 0;
                    dev.columna = 0;
                    return dev;
                }
                if (tirada == 2 && TCasillas[0, 2] == '-')
                {
                    TCasillas[0, 2] = 'O';
                    dev.fila = 0;
                    dev.columna = 2;
                    return dev;
                }
                if (tirada == 3 && TCasillas[2, 0] == '-')
                {
                    TCasillas[2, 0] = 'O';
                    dev.fila = 2;
                    dev.columna = 0;
                    return dev;
                }
                if (tirada == 4 && TCasillas[2, 2] == '-')
                {
                    TCasillas[2, 2] = 'O';
                    dev.fila = 2;
                    dev.columna = 2;
                    return dev;
                }
            }
            return tiradarandom();
        }
    }
}







