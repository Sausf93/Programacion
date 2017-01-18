using System;
using System.Collections.Generic;
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
        public int N = 3;
       
        char[,] TCasillas;
        public Juego()
        {
            
        }

        public void inicia()
        {
            int filas = 3;
            int columnas = 3;
            TCasillas = new char[N, N];
            for (int i = 0; i <= N - 1; i++)
            {
                for (int j = 0; j < N - 1; j++)
                {
                    TCasillas[i, j] = '-';
                }
            }
        }
        public void  MovimientoMaquina(bool turno)
        {
            if (turno)
            {
                TCasillas[1, 1] = 'O';
            }
        }

        public _devolv devolucion()
        {
            Random tirada = new Random();
            _devolv dev = new _devolv();
            dev.fila = tirada.Next(0,2);
            dev.columna = tirada.Next(0,2);
            return (dev);
        }
    }
}
