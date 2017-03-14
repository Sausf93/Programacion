using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows3Raya
{
    public partial class Form1 : Form
    {

        private DialogResult res, again, empat, empat2;
        Juego enraya;
        private Button[,] Tboton;
        private int N, win = 0, draw = 0, lose = 0;
        


        /// <summary>
        /// La función button1_click es el evento que se produce cuando clickamos en el boton de inicia. Establece la tabla de botones y muestra un mensaje para dar el turno a el jugador o a la maquina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button1_Click(object sender, EventArgs e)
        {
            //Está crea un objeto del tipo juego para poder llamar a funciones de la clase juego y mete en la tabla de botones uno a uno en su propiedad .text guiones
            // para inicializarlos todos en guion.
            
            enraya = new Juego();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Tboton[i, j].Text = "-";
                    Tboton[i, j].Enabled = true;
                }
            }
            //Este boton hace que se muestre una ventana emergente en la que da la opción a que inicie tirando ficha el usuario o la maquina. El resultado que se pulse se almacena en la variable res. Si el resultado es si entonces pone turno a uno que quiere decir que empieza jugando la maquina y si se pulsa no pone turno a dos y empieza jugando el usuario. Y por ultimo pone el panel que contiene los botones a verdadero ya que se inicializa como falso para que no se pueda empezar sin elegir el turno.
            res = MessageBox.Show("Pulsa si para que empiece la maquina y pulsa no para empezar tu", "¡¡Importante!!",
            MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {

                enraya.dev.turno = 1;
            }
            else
            {
                enraya.dev.turno = 2;

            }
            panel1.Enabled = true;

        }
        /// <summary>
        /// Form1 es cuando la función que inicializa todos los botones del diseño. En esta funcion también añadimos una funcion crea y que el panel que contiene los botones lo inicie como falso. 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Crea(); //Crea la tabla debotones de dos dimensiones
            panel1.Enabled = false;

        }
        /// <summary>
        /// Funcion Crea. Es la que llamamos despues de inicializar el diseño. Esta consiste en crear una tabla de botones de dos dimensiones siendo de 3x3 y metiendo los botones ordenados en tal caso de que los mete en este orden: B00, B01, B02, B10, B11, B12, B20, B21, B22. Esto se hace para cuando vayamos a escribir en los botones coincida su posición tanto en esta tabla como en la que crearemos posteriormente en la clase juego.
        /// </summary>
        private void Crea()
        {
            N = 3;
            Tboton = new Button[N, N];
            int k = panel1.Controls.Count - 1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Tboton[i, j] = (Button)panel1.Controls[k];
                    k--;
                }
            }
        }
        /// <summary>
        /// Función button_click. Esta es la funcion que se se ejecuta con el evento click de todos los botones dentro del panel. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            //Lo primero de todo es poner una variable empatar a 0 
            int empatar = 0;
            // controlar todo el contenido de este boton con un if que solo entre en el cuando el turno sea par
            if (enraya.dev.turno % 2 == 0)
            {

                //Se hace un click general para todos con el sender que es el boton pulsado y metiendolo en clickedbutton. En este boton pulsado se va a escribir una X que es la ficha del usuario en la propiedad .Text del boton y seguido se pone el enable a false para que no se pueda volver a pulsar se suma uno a turno y se manda a la funcion recoger que es de la clase juego con el objeto creado anteriormente de esta clase y se le manda la segunda letra del nombre del boton y la tercera que como antes los habiamos metido en una tabla de botones de dos dimensiones y con sus nombres coincidentes con su posicion en el tablero pues le estamos mandando a la clase juego la posicion en donde se esta escribiendo esa X del usuario.
                Button clickedButton = (Button)sender;
                clickedButton.Text = "X";
                clickedButton.Enabled = false;
                enraya.dev.turno++;
                enraya.Recoger(clickedButton.Name[1].ToString(), clickedButton.Name[2].ToString());
                enraya.Ganar();
            }
            // Despues de esto hacemos una llama a la funcion ganar, si esta funcion devuelve la variable ganajugador a true entra por un if y muestra un mensaje en una ventana emergente de has ganado despues seguido muestra otro de quieres volver a jugar con si y no.
            if (enraya.dev.ganajugador)
            {
                MessageBox.Show("Has ganado", "¡¡Felicidades!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                again = MessageBox.Show("¿Quieres volver a jugar?", "Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                win++;
                textBox1.Text = (Convert.ToString(win));
                // Si se le da a no el formulario se cierra y si se le da a si se llama a el evento button1_click que es el que incia el juego y empezaria de nuevo metiendo guiones en los botones...
                if (again == DialogResult.Yes)
                {
                    button1_Click(sender, e);

                }
                else
                {
                    Close();
                }
            }
            //Por ultimo esta funcion llama a la funcion empate que es otra que esta creada en la clase juego y esta devuelve la variable empate a 0 o a 1 de este depende si el juego ha acabado porque el panel esta lleno y no ha ganado ninguno de los dos jugadores o si es 0 es que el juego no ha acabado aun hay casillas en blanco. Y se vuelve a preguntar si se quiere jugar de nuevo.
            empatar = enraya.Empate();
            if (empatar == 1)
            {
                empat = MessageBox.Show("Han quedado empate, Pulsa iniciar si quieres volver a jugar.", "Empate",
                MessageBoxButtons.YesNo);
                draw++;
                textBox2.Text = (Convert.ToString(draw));
                if (empat == DialogResult.Yes)
                {
                    button1_Click(sender, e);
                }
                else
                {
                    Close();
                }

            }

        }

        /// <summary>
        /// Funcion movimientomaquina. Es el evento que se ejecuta cuando le damos click al boton de maquina del formulario.   
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Movimientomaquina(object sender, EventArgs e)
        {
            // Esta función comienza también declarando una variable empate entera y un check booleano a false.
            int empatar;
            bool check = false;
            //obtener estructura a partir de la clase juego//

            //Mientras check sea falso entra dentro de esta condición 
            while (!check)
            {
                //lo primero que hay es un if para controlar la tirada que consiste en que si turno es par y si sin querer le das al boton de la maquina y no le toca a ella pues que muestre un mensaje de le toca al usuario para recordarlo y pone check a true para que pueda salir de este mientras si este fuera el caso y con return sale de la función.
                if (enraya.dev.turno % 2 == 0)
                {
                    MessageBox.Show("Te toca a ti y no a la maquina", "Cuidado");
                    check = true;
                    return;
                }
                //mientras  que el turno no sea par y que check sea false si esto es verdadero entra.
                while (enraya.dev.turno % 2 != 0 && check == false)
                {
                    //dentro de este otro mientras lo primero llama a la funcion tiradagana de la clase juego.
                    enraya.tiradagana();
                    //Despues de llamar a esta función hace una ultima comprobación con una condición if que es que si en el boton en el que va a escribir la propiedad .Text sea un guión para que entre y pueda escribir.
                    if (Tboton[enraya.dev.fila, enraya.dev.columna].Text == "-")
                    {

                        // Si es verdadera entra y escribe en la posicion que nos devolvio la clase juego en la estructura dev, pone ese boton escrito a false con la propiedad enable, suma uno a turno y pone check a true para que salga del primer mientras.
                        Tboton[enraya.dev.fila, enraya.dev.columna].Text = "O";
                        Tboton[enraya.dev.fila, enraya.dev.columna].Enabled = false;
                        enraya.dev.turno++;
                        check = true;
                    }

                }
            }
            // Despues de esto llamamos a la función gana igual que cuando tiraba el usuario para comprobar si la maquina ha ganado y que si es asi muestre la opcion de jugar de nuevo y si no que se cierre el formulario.
            enraya.Ganar();
            if (enraya.dev.ganamaquina)
            {
                MessageBox.Show("Has perdido", "Eres un batata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lose++;
                textBox3.Text = (Convert.ToString(lose));
                again = MessageBox.Show("¿Quieres volver a jugar?", "Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (again == DialogResult.Yes)
                {
                    button1_Click(sender, e);
                    //Aqui poner para que se reinicie el juego//
                }
                else
                {
                    Close();
                }

            }
            //Y para terminar tambien hace lo mismo con la función empate.
            empatar = enraya.Empate();
            if (empatar == 1)
            {
                empat2 = MessageBox.Show("Han quedado empate, Pulsa iniciar si quieres volver a jugar.", "Empate",
                MessageBoxButtons.YesNo);
                draw++;
                textBox2.Text = (Convert.ToString(draw));
                if (empat2 == DialogResult.Yes)
                {
                    button1_Click(sender, e);
                }
                else
                {
                    Close();
                }

            }
        }
    }
}


