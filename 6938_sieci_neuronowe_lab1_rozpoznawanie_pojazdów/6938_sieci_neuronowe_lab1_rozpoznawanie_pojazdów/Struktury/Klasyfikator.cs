using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6938_sieci_neuronowe_lab1_rozpoznawanie_pojazdów.siecNeuronowa;

namespace _6938_sieci_neuronowe_lab1_rozpoznawanie_pojazdów.Struktury
{
    public static class Klasyfikator
    {
        class Kotwica
        {
            public static Random losowy = new Random();
            public double X { get; set; }
            public double Y { get; set; }
            public double Szerokosc { get; set; }
            public double Wysokosc { get; set; }


            public static Kotwica generujNowa()
            {
                double x = (losowy.NextDouble()) / (double)1.1;
                double y = (losowy.NextDouble()) / (double)1.1;

                double mniejszy = x > y ? x : y;
                double szerokosc = losowy.Next(100000, (int)(((double)1 - mniejszy) * 10000000)) / (double)10000000;
                double wysokosc = szerokosc;

                return new Kotwica()
                {
                    X = x,
                    Y = y,
                    Szerokosc = szerokosc,
                    Wysokosc = wysokosc
                };            
            }

            public static List<Kotwica> generujLosoweKotwice()
            {
                var listaKotwic = new List<Kotwica>()
                {
                    new Kotwica()
                    {
                        Wysokosc = 1,
                        Szerokosc = 1,
                        X = 0,
                        Y = 0
                    }
                };

                foreach(int i in Enumerable.Range(0, 1000))
                {
                    listaKotwic.Add(Kotwica.generujNowa());
                }

                return listaKotwic;
            }

            public static System.Drawing.Rectangle zwrocZakotwiczonyProstokat(List<System.Drawing.Rectangle> wykryteProstokaty)
            {
                System.Drawing.Rectangle wydzielonyProstokat = new System.Drawing.Rectangle();

                foreach(var prostokat in wykryteProstokaty)
                {
                    wydzielonyProstokat = System.Drawing.Rectangle.Union(wydzielonyProstokat, prostokat);
                }

                return wydzielonyProstokat;
            }
                            
        }

        private static Klasyfikacja? klasyfikuj(SiecNeuronowa siecNeuronowa, Image<Gray, Byte> obraz)
        {
            double[] bajtyObrazu = PrzetwarzaczObrazow.podzielNaPiksele(obraz);
            

            return null;
        }
        


    }
}
