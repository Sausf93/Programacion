using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liga_de_futbol
{
  
        enum tipo
        {
            cadena = 1,
            entero = 2
        }

        class Registro
        {
            List<string> campos;
            List<tipo> tipos;
            int numCampos;

            public Registro(List<string> lista1, List<tipo> lista2)
            {
                int i = 0;
                campos = new List<string>();
                tipos = new List<tipo>();
            
                    campos.InsertRange(0, lista1);
                    tipos.InsertRange(0, lista2);

                numCampos = lista1.Count;

            }

            public void escribe(List<string> listavalores, BinaryWriter bw)
            {
                int entero = 0;

                try
                {
                    for (int i = 0; i < listavalores.Count; i++)
                    {
                        switch (tipos[i])
                        {
                            case tipo.cadena:
                                bw.Write(listavalores[i]);
                                break;
                            case tipo.entero:
                                Int32.TryParse(listavalores[i], out entero);
                                bw.Write(entero);
                                break;
                            default:
                                throw new Exception("Tipo de dato no permitido");
                        }
                    }
                }
                catch (Exception e1)
                {
                    throw new Exception(e1.Message + "\n" + e1.Source);
                }
            }


            public List<string> lee(BinaryReader br)
            {
                List<string> devol;
                devol = new List<string>();
                try
                {
                    for (int i = 0; i < numCampos; i++)
                    {
                        switch (tipos[i])
                        {
                            case tipo.cadena:
                                devol.Add(br.ReadString());
                                break;
                            case tipo.entero:
                                devol.Add(br.ReadInt32().ToString());
                                break;
                            default:
                                throw new Exception("Tipo de dato no permitido");
                        }
                    }
                }
                catch (Exception e1)
                {
                    throw new Exception(e1.Message + "\n" + e1.Source);
                }
                return (devol);
            }
        }
    }
