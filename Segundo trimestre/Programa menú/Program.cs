using System;


namespace Programa_menú
{
    class Program
    {

        struct alumno
        {
            public int Num;
            public string Nombre;
            public int Nota;
        }



        static void Main(string[] args)
        {

            int opcion = 0, N;
            Console.Write("introducir el numero de registros que quiere que tenga la tabla1: ");
            N = Numerotabla();
            int J=5;
            alumno[] tabla = new alumno[N];
            alumno[] tabla2 = new alumno[J];
            alumno[] tabla3 = new alumno[N + J];


            Inicializar(tabla, N); // Función para poner todo a cero, antes del do while, para no perder todo cada vez que mostremos menú
            tabla2[0].Num = 4;
            tabla2[0].Nombre = "Saulo";
            tabla2[0].Nota = 10;
            tabla2[1].Num = 6;
            tabla2[1].Nombre = "Manuel";
            tabla2[1].Nota = 10;
            tabla2[2].Num = 8;
            tabla2[2].Nombre = "Christian";
            tabla2[2].Nota = 10;
            tabla2[3].Num = 12;
            tabla2[3].Nombre = "Yasiel";
            tabla2[3].Nota = 10;
            tabla2[4].Num = 14;
            tabla2[4].Nombre = "Luis";
            tabla2[4].Nota = 10;

            do
            {
                opcion = Menu(opcion);//Llamada a la funcion menu que visualiza y devuelve la opcion elegida para meterla en el switch
                switch (opcion)
                {
                    case 1:
                        Altas(tabla, N);
                        break;
                    case 2:
                        Bajas(tabla, N);
                        break;
                    case 3:
                        Modificaciones(tabla, N);
                        break;
                    case 4:
                        Console.Clear();
                        Consultas(tabla, N);
                        Console.Write("\nPresione cualquier tecla para volver");
                        Console.ReadKey();
                        break;
                    case 5:
                        Listado(tabla,tabla2, tabla3, N, J);
                        break;
                   case 6:
                      Ordenar(tabla, N);
                      break;
                    case 7:
                        busquedabi(tabla, N);
                        break;
                    case 8:
                     mezclar(tabla, tabla2, tabla3, N, J);
                      break;
                    case 0:
                        break;
                }

            } while (opcion != 0 && opcion<=8);
        }

        //------------------------------------------------------------------------------------------//
        static void Inicializar(alumno[] tabla, int N)     
        {
            for (int i = 0; i < N; i++)
            {
                tabla[i].Num = 0;
                tabla[i].Nombre = "";
                tabla[i].Nota = 0;
            }
        }
        //------------------------------------------------------------------------------------------//
        static int Busca(alumno[] tabla, int numero, int N)    
        {
            for (int i = 0; i < N; i++)
            {
                if (tabla[i].Num == numero)
                    return (i);
            }
            return (-1);
        }
        //------------------------------------------------------------------------------------------//
        static int Consultas(alumno[] tabla, int N)    
        {

            int posi, numero;
            Console.Write("Introduzca el número que quiera consultar: ");
            numero = Numero();
            posi = Busca(tabla, numero, N);
            if (posi >= 0)
                Console.Write("Los datos son: {0}. {1}. {2}", tabla[posi].Num, tabla[posi].Nombre, tabla[posi].Nota);
            else
                Console.Write("Dato no encontrado.");
            return (posi);
        }
        //------------------------------------------------------------------------------------------//
        static void Altas(alumno[] tabla, int N)      
        {
            //-----------------Definir más variables para controlar que no haya error de introducción----------------//IMPORTANTE//
            int numero = 0, posi, posi2;
            int cont = 1;
            Console.Clear();

            while (cont == 1 && cont != 0)    //Bucle para salir de Altas.
            {
                Console.Write("\nIntroduzca número de lista del alumno: ");
                numero = Numerotabla();  //Recogemos número y mandamos a la función Busca para que compare.
                posi = Busca(tabla, numero, N); //Con BuscaAltas buscamos un número repetido, y devolverá -1 en la variable posi si el número NO está repetido.
                posi2 = Busca(tabla, 0, N);
                if (posi >= 0)
                {
                    Console.Write("\nEl alumno ya esta registrado");
                    Console.Write("\n Desea probar a dar de alta a otro alumno introduzca 1, si no 0: ");
                    cont = Numero();



                }

                if (posi2 == -1)
                {
                    Console.Write("\nLa tabla esta llena, pulse cualquier tecla para volver al menu");
                    Console.ReadKey();
                    break;
                }


                //Mensajes Write aquí, y usar un solo busca.

                if (posi == -1 && posi2 >= 0)   //Si posi es -1 es que no hay repetición de número, y si posi2 es mayor o igual que cero es que tenemos posición para escribir.
                {
                    tabla[posi2].Num = numero;  //Guardamos en el espacio de la tabla que está dentro de posi2 el número que está en la variable numero.
                    Console.Write("Introduzca el nombre del alumno: ");
                    tabla[posi2].Nombre = comprobarstring();
                    Console.Write("Introduzca la nota del alumno: ");
                    tabla[posi2].Nota = Numeronota();



                    //Si no quiere seguir introduciendo va a cambiar cont a No, y va a salir del for y por lo tanto salir de la función.
                    Console.Write("Si quiere seguir dando de alta a más alumnos escriba 1, en caso contrario escriba 0: ");
                    cont = Numero();

                }

            }
        }
        //------------------------------------------------------------------------------------------//
        static void Bajas(alumno[] tabla, int N)       
        {
            int posi;
            int cont = 1, cont2 = 1;

            Console.Clear();    //Colocamos aquí para que solo se borre una vez, no cada vez que entre al bucle.
            while (cont2 == 1 || cont2 == 1)    //Mientras cont2 sea B, nos mantenemos, si es M, saldrá al Menú principal
            {
                posi = Consultas(tabla, N);        //Desde la función busca, viene la posición de la coincidencia en la variable posi.
                if (posi >= 0)                  //Si posi es una posición entra
                {
                    Console.Write("\nSi desea eliminar este registro pulse 1, en caso contrario pulse 0: ");
                    cont = Numero();
                    if (cont == 1 || cont == 1)    //Ejecutamos la baja
                    {
                        tabla[posi].Num = 0;
                        tabla[posi].Nombre = "";
                        tabla[posi].Nota = 0;
                        Console.Write("\nBaja realidaza correctamente.");

                        Console.Write("\nSi desea volver al Menú Principal, pulse 0, en caso de querer seguir dando de Baja, pulse 1: ");
                        cont2 = Convert.ToChar(Console.ReadLine());
                        if (cont2 == 0 || cont2 == 0)
                            break;
                    }
                    else if (cont == 0 || cont == 0)
                    {
                        Console.Write("\nSi desea volver al Menú Principal, pulse 0, en caso de querer seguir dando de Baja, pulse 1: ");
                        cont2 = Convert.ToChar(Console.ReadLine());
                        if (cont2 == 0 || cont2 == 0)
                            break;
                    }

                }
            }
        }
        //------------------------------------------------------------------------------------------//
        static void Modificaciones(alumno[] tabla, int N) 
        {
            int posi;
            int cont = 1, cont2 = 1;   //La variable cont, maneja el bucle principal de modificación de registros, y la variable cont2 maneja el bucle interno de repetición de modificación de los campos.
            Console.Clear();
            while (cont == 1)     // Mientras cont, sea yes...
            {
                cont2 = 1;    //Esto es una asignación para que cuando se ejecute el bucle por segunda vez cont2 vuelva a ser Y, ya que antes se habrá cambiado a N.
                posi = Consultas(tabla, N);
                Console.Write("Introduzca el nombre modificado: ");
                tabla[posi].Nombre = comprobarstring();
                Console.Write("\nIntroduzca la nota modificada: ");
                tabla[posi].Nota = Numeronota();

                while (cont2 == 1)    //Segundo bucle para repetición de campos
                {
                    Console.Write("\nSi desea volver a modificar otro dato de este registro, pulse 1, en caso contrario pulse 0: ");
                    cont2 = Numero();
                    if (cont2 == 0)
                        break;          //Este break sale del while interno, no del externo.
                    else if (cont2 == 1)
                    {
                        Console.Write("\nIntroduzca el nombre modificado: ");
                        tabla[posi].Nombre = comprobarstring();
                        Console.Write("\nIntroduzca la nota modificada: ");
                        tabla[posi].Nota = Numeronota();
                    }
                }

                Console.Write("\nSi desea modificar otro registro, pulse 1, en caso contrario pulse 0: ");
                cont = Numero();
            }
        }
        //------------------------------------------------------------------------------------------//
        static void Listado(alumno[] tabla,alumno[]tabla2, alumno[]tabla3, int N, int J)      
        {
            Console.Clear();
            Console.WriteLine("\tabla1:");
            for (int i = 0; i < N; i++)
            {
                if (tabla[i].Num != 0)
                    Console.WriteLine("{0}. \t{1}. \t{2}", tabla[i].Num, tabla[i].Nombre, tabla[i].Nota);
            }
            Console.ReadKey();
        }
        //------------------------------------------------------------------------------------------//
        static int Numero()
        {
            int resu = -1;
            bool convert = false;
            while (convert == false || resu < 0)
            {
                convert = Int32.TryParse(Console.ReadLine(), out resu);
                if (convert == false || resu < 0)
                    Console.Write("\nValor no correcto. Introduce otro: ");
            }
            return (resu);
        }
        //------------------------------------------------------------------------------------------------------//
        static string comprobarstring()
        {
            int index = 0;
            string str = "";
            string[] tofind = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            while (index >= 0)
            {
                str = Console.ReadLine();
                for (int i = 0; i < 10; i++)
                {
                    index = str.IndexOf(tofind[i]);
                    if (index != -1)
                    {
                        Console.Write("el valor introducido es incorrecto, introduzca nombre sin datos numericos: ");
                        break;
                    }
                }
            }
            return (str);

        }
        //----------------------------------------------------------------------------------------------------//
        static int Menu(int opcion)
        {
            Console.Clear();
            Console.WriteLine("\t|─────────MENÚ──────────|");
            Console.WriteLine("\t─────────────────────────");
            Console.WriteLine("\t|1.- Altas\t\t|");
            Console.WriteLine("\t|2.- Bajas\t\t|");
            Console.WriteLine("\t|3.- Modificaciones\t|");
            Console.WriteLine("\t|4.- Consultas\t\t|");
            Console.WriteLine("\t|5.- Listado\t\t|");
            Console.WriteLine("\t|6.- Ordenar\t\t|");
            Console.WriteLine("\t|7.- Busqueda binaria\t|");
            Console.WriteLine("\t|8.- Mezclar\t\t|");
            Console.WriteLine("\t|0.- Salir\t\t|");
            Console.WriteLine("\t─────────────────────────");
            Console.Write("\nElija una opción: ");
            opcion = Numero();
            return (opcion);
        }
        //----------------------------------------------------------------------------------------------------//
        static int Numerotabla()
        {
            int resu = -1;
            bool convert = false;
            while (convert == false || resu <= 0)
            {
                convert = Int32.TryParse(Console.ReadLine(), out resu);
                if (convert == false || resu <= 0)
                    Console.Write("\nValor no correcto. Introduce otro: ");
            }
            return (resu);
        }
        //----------------------------------------------------------------------------------------------------------//
        static int Numeronota()
        {
            int resu = -1;
            bool convert = false;
            while (convert == false ||( resu < 0 || resu > 10))
            {
                convert = Int32.TryParse(Console.ReadLine(), out resu);
                if (convert == false || (resu < 0 || resu > 10))
                    Console.Write("\nValor no correcto. Introduce otro: ");
            }
            return (resu);
        }
        //------------------------------------------------------------------------------------------------------------//
        static void Ordenar(alumno[] tabla, int N)
        {
            alumno temp;
        for (int i = 0; i < N; i++)
       {
          for (int j = 0; j < N-1; j++)
               {
                    if (tabla[i].Num< tabla[j].Num)
                    {
                        temp.Num=tabla[i].Num;
                        temp.Nota = tabla[i].Nota;
                        temp.Nombre = tabla[i].Nombre;
                        tabla[i].Num = tabla[j].Num;
                        tabla[i].Nombre = tabla[j].Nombre;
                        tabla[i].Nota = tabla[j].Nota;
                        tabla[j].Num=temp.Num;
                        tabla[j].Nombre = temp.Nombre;
                        tabla[j].Nota = temp.Nota;

                    }

               }
          }

        }
        //-------------------------------------------------------------------------------------------------------------//
        static void busquedabi(alumno[] tabla, int N)
        {
            int inicio = 0;
            int fin = N-1;
            int medio = (fin+inicio)/2;
            int Num;
            Console.Write("introducir el numero que se desea buscar: ");
            Num = Numero();
            while(tabla[medio].Num!=Num && inicio<fin)
            {
                if (tabla[medio].Num<Num)
                {
                    inicio = medio + 1;
                     medio = (fin + inicio) / 2;
                }
                else
                {
                    fin = medio - 1;
                    medio = (fin + inicio) / 2;
                }
            }
            if (tabla[medio].Num == Num)
            {
                Console.Write("Los datos son: {0}. {1}. {2}", tabla[medio].Num, tabla[medio].Nombre, tabla[medio].Nota);
                Console.ReadKey();
                
            }
            else
            {
                Console.Write("El numero no esta en la tabla. pulse cualquier tecla para volver");
                Console.ReadKey();
            }

        }
        //--------------------------------------------------------------------------------------------------------------//
        static void mezclar(alumno[]tabla, alumno[]tabla2, alumno[]tabla3, int N, int J)
        {
            Ordenar(tabla, N);
            int P = 0, i = 0, T = 0;
            while (i < N && T < J)
            {
                if(tabla[i].Num<tabla2[T].Num)
                {

                    tabla3[P].Num = tabla[i].Num;
                    tabla3[P].Nombre = tabla[i].Nombre;
                    tabla3[P].Nota = tabla[i].Nota;
                    P++;
                    i++;
                }
                else
                {
                    tabla3[P].Num = tabla2[T].Num;
                    tabla3[P].Nombre = tabla2[T].Nombre;
                    tabla3[P].Nota = tabla2[T].Nota;
                    P++;
                    T++;
                }
            }
            if(i==N)
            {
                for (; T < J; T++)
                {
                    tabla3[P].Num = tabla2[T].Num;
                    tabla3[P].Nombre = tabla2[T].Nombre;
                    tabla3[P].Nota = tabla2[T].Nota;
                    P++;
                }
            }
            else
                {
                for (;  i< N; i++)
                {
                    tabla3[P].Num = tabla[i].Num;
                    tabla3[P].Nombre = tabla[i].Nombre;
                    tabla3[P].Nota = tabla[i].Nota;
                    P++;
                }
            }
            Console.Clear();
            Console.WriteLine("\ttabla3:");
            for (int w = 0; w < tabla3.Length; w++)
            {
                
                    Console.WriteLine("{0}---. {1}---. {2}", tabla3[w].Num, tabla3[w].Nombre, tabla3[w].Nota);
            }
            Console.ReadKey();
        }
        }
    }

