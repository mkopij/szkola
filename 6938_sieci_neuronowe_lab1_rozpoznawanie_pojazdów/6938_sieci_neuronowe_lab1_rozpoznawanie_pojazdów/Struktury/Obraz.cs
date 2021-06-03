using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;

namespace _6938_sieci_neuronowe_lab1_rozpoznawanie_pojazdów
{
     enum Klasyfikacja
    {
        Nieznana = 0,
        Samochod = 1,
        Ciezarowka = 2,
        Rower = 3,
        Lodz = 4,
        Samolot = 5,
        Helikopter = 6

    };
    class Obraz
    {
        public Klasyfikacja klasyfikacja { get; set; }
        public Image<Gray, Byte> obraz { get; set; }

        public Obraz(Image<Gray, Byte> obraz, Klasyfikacja klasyfikacja)
        {
            this.obraz = obraz;
            this.klasyfikacja = klasyfikacja;
        }
    }

}
