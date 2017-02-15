using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace liga_de_futbol
{
    public partial class Form1 : Form
    {
        Fichero f1, f2;
        List<string> l1;
        List<tipo> l2;
        List<string> cajas;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (f1.abre())
                {
                    f1.fin();
                    carga(cajas);
                    f1.escribe(cajas);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                f1.cierra();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            l1 = new List<string>();
            l2 = new List<tipo>();
            cajas = new List<string>();
            l1.Add("numero");
            l1.Add("nombre");
            l1.Add("victorias");
            l1.Add("empate");
            l1.Add("derrotas");

            l2.Add(tipo.entero);
            l2.Add(tipo.cadena);
            l2.Add(tipo.entero);
            l2.Add(tipo.entero);
            l2.Add(tipo.entero);
            try
            {
                f1 = new Fichero("Ingeniero en organizacion.dat", l1, l2);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                return;
            }
            l1.Clear();
            l2.Clear();

            l1.Add("numero");
            l1.Add("nombre");
            l1.Add("victorias");
            l1.Add("empate");
            l1.Add("derrotas");
            l1.Add("puntos");

            l2.Add(tipo.entero);
            l2.Add(tipo.cadena);
            l2.Add(tipo.entero);
            l2.Add(tipo.entero);
            l2.Add(tipo.entero);
            l2.Add(tipo.entero);
            try
            {
                f2 = new Fichero("partidos.dat", l1, l2);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> caja2;
            f1.abre();
            f2.trunca();
            f2.abre();
            cajas.Clear();
            caja2 = new List<string>();
            int victorias, empates, puntos;
            for (int i = 0; i < f1.numRegistros; i++)
            {
                try
                {
                    cajas = f1.lee();
                    victorias = Convert.ToInt32(cajas[2]);
                    empates = Convert.ToInt32(cajas[3]);
                    puntos = (victorias*3) + empates;
                    caja2.Add(cajas[0]);
                    caja2.Add(cajas[1]);
                    caja2.Add(cajas[2]);
                    caja2.Add(cajas[3]);
                    caja2.Add(cajas[4]);
                    caja2.Add(cajas[5]);
                    caja2.Add(puntos.ToString());
                    try
                    {
                        f2.escribe(caja2);
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show(e1.Message + "\n" + e1.Source);
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            f1.cierra();
            f2.cierra();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            int i = 0;
            List<string> caja3;
            caja3 = new List<string>();
            f2.abre();
            dataGridView1.Rows.Clear();
            for (i = 0; i < f1.numRegistros; i++)
            {
                caja3.Clear();
                try
                {
                    caja3 = f2.lee();
                    dataGridView1.Rows.Add(caja3[0], caja3[1], caja3[2], caja3[3], caja3[4], caja3[5]);
                    
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            f1.numRegistros++;
            f2.cierra();
        }

        public Form1()
        {
            InitializeComponent();
        }
        void carga(List<string> cajas)
        {
            cajas.Clear();
            cajas.Add(textBox1.Text);
            cajas.Add(textBox2.Text);
            cajas.Add(textBox3.Text);
            cajas.Add(textBox4.Text);
        }

    }
}
