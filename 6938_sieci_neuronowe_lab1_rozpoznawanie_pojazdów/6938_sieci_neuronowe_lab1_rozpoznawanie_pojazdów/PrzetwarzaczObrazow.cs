using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.IntensityTransform;

namespace _6938_sieci_neuronowe_lab1_rozpoznawanie_pojazdów
{
    // klasa odpowiada za przygotowanie obrazow do przetworzenia przez siec neuronowa
    public static class PrzetwarzaczObrazow
    {
        // funkcja zmniejsza rozmiar obrazu, i wyszarza go, aby zaoszczedzic na miejscu i pamieci
        public static Image<Gray, Byte> kompresujObraz(Image<Gray, Byte> oryginalnyObraz)
        {
            var wyjsciowyObraz = oryginalnyObraz.Convert<Gray, Byte>(); // Wyszarza obraz

            return wyjsciowyObraz.Resize(50, 50, Emgu.CV.CvEnum.Inter.Cubic, false); // Zmiejsza obraz i go zwraca
        }

        // Kompresuje cala liste obrazow
        public static List<Image<Gray, Byte>> kompresujListeObrazow(List<Image<Gray, Byte>> listaWejsciowa)
        {
            List<Image<Gray, Byte>> listaWyjsciowa = new List<Image<Gray, byte>>();

            listaWejsciowa.ForEach(o => listaWyjsciowa.Add(kompresujObraz(o)));

            return null;
        }

    }
}
