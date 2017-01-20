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
        private DialogResult res;
        Juego enraya;
        
        private bool turno;
        
        private Button[,] Tboton;
        private int N;

        private void button1_Click(object sender, EventArgs e)
        {
            enraya=new Juego();

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
                turno = true;
            }
            else
            {
                turno = false;
            }
            panel1.Enabled = true;

        }

        public Form1()
        {
            InitializeComponent();
            Crea(); //Crea la tabla debotones de dos dimensiones
            panel1.Enabled = false;

        }

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

        private void button_Click(object sender, EventArgs e)
        {
            if (!turno)
            {
                Button clickedButton = (Button)sender;
                clickedButton.Text = "X";
                clickedButton.Enabled = false;
                turno = true;
                enraya.recoger(clickedButton.Name[1].ToString(), clickedButton.Name[2].ToString());
                enraya.GanaJugador();
            }
            if (enraya.dev.ganajugador)
            {
                MessageBox.Show("Has ganado", "¡¡Felicidades!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Movimientomaquina(object sender, EventArgs e)
        {//obtener estructura a partir de la clase juego//
            _devolv _dev = enraya.devolucion();
            _dev.sigue = true;
            while (_dev.sigue)
            {
                _dev = enraya.devolucion();
                Tboton[_dev.fila, _dev.columna].Text = "O";
                Tboton[_dev.fila, _dev.columna].Enabled = false;
                turno = false;
                enraya.compruebamaquina();
                _dev.sigue = false;
               
            }
            if (_dev.ganamaquina)
            {
                MessageBox.Show("Has perdido", "Eres un batata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
    }
}


