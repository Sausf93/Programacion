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
    /// Estructura _devolv. Es la estructura de datos que se va a intercambiar entre la clase juego y el form1.cs para compartir información. Contiene un turno, fila, columna, ganajugador, ganamaquina, sigue.
    /// </summary>

    public struct _devolv //Como pasar la estructura a el form//
    {
        /// <summary>
        /// variable de turno entera
        /// </summary>
        public int turno;
        /// <summary>
        /// variable de fila entera
        /// </summary>
        public int fila;
        /// <summary>
        /// variable de columna entera
        /// </summary>
        public int columna;
        /// <summary>
        /// variable de ganajugador booleana
        /// </summary>
        public bool ganajugador;
        /// <summary>
        /// variable de ganamaquina booleana
        /// </summary>
        public bool ganamaquina;
        /// <summary>
        /// variable sigue booleana
        /// </summary>
        public bool sigue;
    };

    /// <Juego>
    /// Clase Juego. Es la que se encarga del funcionamiento de la maquina las comprobaciones .
    /// </Juego>

    internal class Juego
    {
        //Comienza declarando varias variables de tipo entero crea verticales, horizontales, diagonales, diagonales2, conta, conta2
        private int verticales, horizontales, diagonales, diagonales2, conta, conta2;
        public _devolv dev;
        public int N = 3;
        private char[,] TCasillas;

        //En el constructor de la clase juego inizializa la estructura y la llama dev, también crea una variable N, le da valor 3 y inicializa un array de dos dimensiones de tipo char.
        public Juego()
        {
            TCasillas = new char[N, N];

            //Se crea la tabla de dos dimensiones de NXN, es decir 3x3 y en ella se escriben guiones al igual que en la tabla de dos dimensiones de botones del formulario
            for (int i = 0; i <= N - 1; i++)
            {
                for (int j = 0; j <= N - 1; j++)
                {
                    TCasillas[i, j] = '-';
                }
            }
        }

        /// <summary>
        /// Función de la clase juego Ganar, devuelve a la funcion que la llama ganamaquina o ganajugador a true o falso. Esto lo hace comprobando con varios bucles si hay tres fichas iguales en linea.
        /// </summary>
        public void Ganar()
        {
            // Esta función hace un doble bucle for para contar filas y columnas de la tabla de char de dos dimensiones.

            //Horizontales//
            for (int i = 0; i < 3; i++)
            {
                // Dentro del primer bucle pone a 0 las variables conta y conta2.
                conta = 0;
                conta2 = 0;
                for (int j = 0; j < 3; j++)
                {
                    // Despues de esto va comprobando las horizontales si encuentra una X suma uno a conta, si encuentra una O suma uno a conta2.
                    if (TCasillas[i, j] == 'X')
                    {
                        conta++;
                    }
                    if (TCasillas[i, j] == 'O')
                    {
                        conta2++;
                    }

                    //Si conta uno es igual a 3 entonces quiere decir que ha ganado la X porque ha encontrado tres X en la misma fila y si ha conta2 es 3 pues ha encontrado tres O por lo que pondría ganajugador o ganamaquina a true y haría un break para volver a la función que la llamo
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

           // Después de comprobar las horizontales hacemos lo mismo con las verticales cambiando el bucle siendo el primer for el de la j y el segundo el de la i para hacer que vaya leyendo por columnas.Funciona con las mismas variables.

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

            //Y por ultimo hacemos las dos diagonales con 4 if dos para las X y dos para las O.

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
        /// <summary>
        /// Funcion recoger. Es la que llamamos al escribir la jugada del usuario. Esta funcion lo que hace es recoger en donde ha escrito esa X el usuario para meterla en la tabla de dos dimensiones de la clase juego para posteriormente poder hacer las comprobaciones y demás.
        /// </summary>
        /// <param name="recogidax"></param>
        /// <param name="recogiday"></param>
        public void Recoger(string recogidax, string recogiday)
        {
            // X y Y son las filas y columnas de la jugada mia  //
            int x = Convert.ToInt32(recogidax);
            int y = Convert.ToInt32(recogiday);
            TCasillas[x, y] = 'X';
        }
        /// <summary>
        /// Funcion empate. Es la funcion que llamamos desde la jugada del usuario o de la maquina para ver si el tablero de char de dos dimensiones esta lleno por lo que quiere decir que el juego ha terminado. Esta función es de tipo int por lo que devuelve 1 en caso de que se haya rellenado el tablero o 0 en caso de que aun no este lleno.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Función de tipo _devolv Movimiento maquina. Es la segunda que se llamara para que juegue la maquina despues de la de gana. Esta se encarga de comprobar si el usuario esta a punto de ganar porque tiene dos de sus fichas en linea y va a colocar la ficha de la maquina en esa posicion para tapar la jugada del usuario.
        /// </summary>
        /// <returns></returns>
        public _devolv Movimientomaquina()
        {
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
                dev.columna = 1;
                dev.fila = 1;
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
                dev.columna = 1;
                dev.fila = 1;
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
            return jugadatriangulo();
        }
        /// <summary>
        /// Funcion de tipo _devolv tiradaramdon. Esta función es la ultima que llamaremos para la jugada de la maquina. Se encarga de tirar en cualquier posicion que este vacia aleatoriamente. solo se utiliza si todos los pasos que son llamados antes no tienen que cubrir o hacer alguna jugada.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Función de tipo _devolv tiradagana. Esta función se encarga de la primera tirada de la maquina. Su función primero es comprobar si el centro del tablero esta ocupado y si no tirar ahi. Despues ver si tiene dos fichas en linea para ir a ganar colocando la tercera.
        /// </summary>
        /// <returns></returns>
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
                        if (TCasillas[i, j] == '-')
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
        /// <summary>
        /// Función de tipo _devolv tiradaesquina. Esta es la función que se puede llamar en dos casos en la que se haga la jugadaTriangulo. Si esta no se hace se llama despues de la función jugadaSaulo. La tirada esquina se encarga de tirar en las esquinas aleatoriamente como su nombre indica.
        /// </summary>
        /// <returns></returns>
        public _devolv tiraresquina()
        {
            int tirada = 0;
            if (dev.turno >= 3)
            {
                Random esquina = new Random();
                tirada = esquina.Next(1, 5);
                if (tirada == 1 && TCasillas[0, 0] == '-')
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
        /// <summary>
        /// Funcion de tipo _devolv jugadatriangulo. Esta función se encarga de controlar la jugada en la que la x este escrita en una esquina y en el medio. hay una opción si no se controla bien de que el jugador pulse otra esquina y si en ese caso en el turno de la maquina que tiraria aleatorio no tira a esquina, el usuario tendria la opción de ganar. Asi que si este fuera el caso se llama a tiradaEsquina.
        /// </summary>
        /// <returns></returns>
        public _devolv jugadatriangulo()
        {
            //Controlar la jugada triangulo//
            if (TCasillas[0, 0] == 'X' && TCasillas[1, 1] == 'X')
            {
                return tiraresquina();
            }
            else if (TCasillas[2, 0] == 'X' && TCasillas[1, 1] == 'X')
            {
                return tiraresquina();
            }
            else if (TCasillas[0, 2] == 'X' && TCasillas[1, 1] == 'X')
            {
                return tiraresquina();
            }
            else if (TCasillas[2, 2] == 'X' && TCasillas[1, 1] == 'X')
            {
                return tiraresquina();
            }
            return jugadaSaulo();
        }
        /// <summary>
        /// Función tipo _devolv JugadaSaulo. Esta función es la que se llama despues de la jugadatriangulo siempre que esta otra no entre por algun if. Esta función controla otra jugada especifica en la que la maquina no ve peligro de perder y tira aleatorio. Pero con esta función la controlamos haciendo todas las opciones posibles que la maquina cubra ese lado.
        /// </summary>
        /// <returns></returns>
        public _devolv jugadaSaulo()
        {
            if (dev.turno == 5)
            {
                if (TCasillas[1, 0] == 'X' && TCasillas[0, 2] == 'X')
                {
                    dev.fila = 0;
                    dev.columna = 1;
                    return dev;
                }
                else if (TCasillas[1, 0] == 'X' && TCasillas[2, 2] == 'X')
                {
                    dev.fila = 2;
                    dev.columna = 1;
                    return dev;
                }
                else if (TCasillas[0, 1] == 'X' && TCasillas[2, 2] == 'X')
                {
                    dev.fila = 1;
                    dev.columna = 2;
                    return dev;
                }
                else if (TCasillas[0, 1] == 'X' && TCasillas[2, 0] == 'X')
                {
                    dev.fila = 1;
                    dev.columna = 0;
                    return dev;
                }
                else if (TCasillas[1, 2] == 'X' && TCasillas[0, 0] == 'X')
                {
                    dev.fila = 0;
                    dev.columna = 1;
                    return dev;
                }
                else if (TCasillas[2, 0] == 'X' && TCasillas[1, 2] == 'X')
                {
                    dev.fila = 2;
                    dev.columna = 1;
                    return dev;
                }
                else if (TCasillas[2, 1] == 'X' && TCasillas[0, 0] == 'X')
                {
                    dev.fila = 1;
                    dev.columna = 0;
                    return dev;
                }
                else if ((TCasillas[2, 1] == 'X' && TCasillas[0, 2] == 'X'))
                {
                    dev.fila = 1;
                    dev.columna = 2;
                    return dev;
                }
            }
            return jugadaEsquina();
        }
        /// <summary>
        /// Función jugadaEsquina. Es en el caso en el que el usuario escriba en dos esquinas la maquina no tenia controlada esta jugada y escribia en otra esquina por lo que dejaba la opcion de la 4 esquina libre por no tener amenaza de perdida del usuario que al escribir esa cuarta esquina tenia dos opciones de vencer. La maquina taparia una de las dos y jaquemate chaval.
        /// </summary>
        /// <returns></returns>
        public _devolv jugadaEsquina()
        {
            if ((TCasillas[0, 0] == 'X' && TCasillas[2, 2] == 'X'))
            {
                tiradarandom();
                return dev;
            }

            else if ((TCasillas[2, 0] == 'X' && TCasillas[0, 2] == 'X'))
            {
                tiradarandom();
                return dev;
            }
            return tiraresquina();
        }
    }
}







