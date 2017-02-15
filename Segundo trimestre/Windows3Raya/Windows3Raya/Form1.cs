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
        //-----------estructura------------//

        //public int _fila;
        //public int _columna;
        //public bool _ganajugador;
        //public bool _ganamaquina;
        //public bool _fin;
        //public bool _sigue;


        //-----------estructura------------//
        private DialogResult res, again, empat, empat2;
        Juego enraya;
        private Button[,] Tboton;
        private int N, win = 0, draw = 0, lose = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button1_Click(object sender, EventArgs e)
        {
            enraya = new Juego();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Tboton[i, j].Text = "-";
                    Tboton[i, j].Enabled = true;
                }
            }
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
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Crea(); //Crea la tabla debotones de dos dimensiones
            panel1.Enabled = false;

        }
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            int empatar = 0;
            if (enraya.dev.turno % 2 == 0)
            {
                Button clickedButton = (Button)sender;
                clickedButton.Text = "X";
                clickedButton.Enabled = false;
                enraya.dev.turno++;
                enraya.Recoger(clickedButton.Name[1].ToString(), clickedButton.Name[2].ToString());
                enraya.Ganar();
            }
            if (enraya.dev.ganajugador)
            {
                MessageBox.Show("Has ganado", "¡¡Felicidades!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                again = MessageBox.Show("¿Quieres volver a jugar?", "Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                win++;
                textBox1.Text = (Convert.ToString(win));
                if (again == DialogResult.Yes)
                {
                    button1_Click(sender, e);

                }
                else
                {
                    Close();
                }
            }

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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Movimientomaquina(object sender, EventArgs e)
        {
            int empatar;
            bool check = false;
            //obtener estructura a partir de la clase juego//

            while (!check)
            {
                if (enraya.dev.turno % 2 == 0)
                {
                    MessageBox.Show("Te toca a ti y no a la maquina", "Cuidado");
                    check = true;
                    return;
                }
                while (enraya.dev.turno % 2 != 0 && check == false)
                {
                    enraya.tiradagana();
                    if (Tboton[enraya.dev.fila, enraya.dev.columna].Text == "-")
                    {
                        Tboton[enraya.dev.fila, enraya.dev.columna].Text = "O";
                        Tboton[enraya.dev.fila, enraya.dev.columna].Enabled = false;
                        enraya.dev.turno++;
                        check = true;
                    }

                }
            }
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


