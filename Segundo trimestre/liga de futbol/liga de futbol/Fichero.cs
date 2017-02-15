using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liga_de_futbol
{
    class Fichero
    {
        string ficNombre;
        public int numRegistros;
        FileStream fs;
        public BinaryReader br;
        public BinaryWriter bw;
        List<string> campos;
        List<tipo> tipos;
        public Registro reg;
        public List<string> devol;

        public Fichero(string fnom, List<string> lista1, List<tipo> lista2)
        {
            ficNombre = fnom;
            numRegistros = 0;
            fs = null;
            br = null;
            bw = null;
            if (!File.Exists(ficNombre))
            {
                try
                {
                    fs = new FileStream(ficNombre, FileMode.Create, FileAccess.Write);
                    fs.Close();
                }
                catch (Exception e1)
                {
                    throw new Exception(e1.Message);
                }
            }

            campos = new List<string>();
            tipos = new List<tipo>();
            {
                campos.InsertRange(0, lista1);
                tipos.InsertRange(0, lista2);

            }

            try
            {
                reg = new Registro(lista1, lista2);
            }
            catch (Exception e1)
            {
                throw new Exception(e1.Message);
            }
            numRegistros = calculaRegistros();
        }

        int calculaRegistros()
        {
            int cuenta = 0;
            bool fin = false;
            if (abre())
            {
                do
                {
                    try
                    {
                        reg.lee(br);
                        cuenta++;
                    }
                    catch (Exception)
                    {
                        fin = true;
                    }
                } while (fin == false);
                cierra();
            }
            return (cuenta);
        }

        public void escribe(List<string> listavalores)
        {
            try
            {
                reg.escribe(listavalores, bw);
                numRegistros++;
            }
            catch (Exception e1)
            {
                throw new Exception(e1.Message);
            }
        }

        public List<string> lee()
        {
            try
            {
                devol = reg.lee(br);
            }
            catch (Exception e1)
            {
                throw new Exception(e1.Message);
            }
            return (devol);
        }

        public void trunca()
        {
            fs = new FileStream(ficNombre, FileMode.Truncate);
            fs.Close();
            numRegistros = 0;
        }

        public bool abre()
        {
            try
            {
                fs = new FileStream(ficNombre, FileMode.Open, FileAccess.ReadWrite);
            }
            catch (Exception e1)
            {
                cierra();
                throw new Exception(e1.Message + "\n" + e1.Source);
            }
            try
            {
                br = new BinaryReader(fs);
            }
            catch (Exception e1)
            {
                cierra();
                throw new Exception(e1.Message + "\n" + e1.Source);
            }
            try
            {
                bw = new BinaryWriter(fs);
            }
            catch (Exception e1)
            {
                cierra();
                throw new Exception(e1.Message + "\n" + e1.Source);
            }
            return (true);
        }

        public void cierra()
        {
            if (br != null)
                br.Close();
            if (bw != null)
                bw.Close();
            if (fs != null)
                fs.Close();
            br = null;
            bw = null;
            fs = null;
        }

        public void inicio()
        {
            fs.Seek(0, SeekOrigin.Begin);
        }

        public void fin()
        {
            fs.Seek(0, SeekOrigin.End);
        }

    }
}

