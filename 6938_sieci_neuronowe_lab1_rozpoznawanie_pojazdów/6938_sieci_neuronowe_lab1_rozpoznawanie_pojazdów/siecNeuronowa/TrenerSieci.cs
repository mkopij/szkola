using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace _6938_sieci_neuronowe_lab1_rozpoznawanie_pojazdów.siecNeuronowa
{
    public static class TrenerSieci
    {
        private static List<Image<Gray, Byte>> zbiorObrazowEmgu { get; set; }

        static List<Obraz> zbiorObrazow { get; set; }

 
      //  private static List<System.Drawing.Image> zbiorObrazowImg { get; set; }

        public static void zaladujObrazy(string[] pliki, System.Windows.Controls.ListBox lista)
        {

            //TODO dodac radioButtonList do okna, ktore bedzie pozwalac na wybor klasyfikacj, oraz usunac linijke dodaja klasyfikacje samochod
            string[] dozwoloneRozszerzenia = new string[]
            {
                ".jpg", ".jpeg", ".png"
            };

            zbiorObrazowEmgu = new List<Image<Gray, byte>>();
            zbiorObrazow = new List<Obraz>();

            Image<Gray, Byte> obrazEmgu;
            Klasyfikacja klasyfikacjaObrazu;

            foreach (string sciezka in pliki)
            {
                if(dozwoloneRozszerzenia.Contains(System.IO.Path.GetExtension(sciezka)))
                {
                    obrazEmgu = new Image<Gray, byte>((Bitmap)System.Drawing.Image.FromFile(sciezka));
                    klasyfikacjaObrazu = Klasyfikacja.Samochod;

                    Obraz test = new Obraz(obrazEmgu, klasyfikacjaObrazu);
                    zbiorObrazow.Add(test);
                }

                lista.Items.Add(sciezka);
            }

            zbiorObrazowEmgu = PrzetwarzaczObrazow.kompresujListeObrazow(zbiorObrazowEmgu);



          //  Obraz test = new Obraz(zbiorObrazowEmgu[0], Klasyfikacja.Samochod);

        }
    }
}
