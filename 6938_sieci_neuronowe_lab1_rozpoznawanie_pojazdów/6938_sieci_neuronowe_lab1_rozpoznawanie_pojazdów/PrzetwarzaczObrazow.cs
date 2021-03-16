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

    //TODO: funkcja do augementacji obrazow

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

            return listaWyjsciowa;
        }

        //todo poprawic nazwy zmiennych
        // Konwertuje obraz typu System.Drawing na obraz typu Emgu. Dzieki temu bedziemy mogli wywolywac na nich inne funkcje z tej klasy
        public static Image<Gray, Byte> kowertujImageNaEmgu(System.Windows.Controls.Image obrazWpf)
        {
            BitmapSource bitmapaSRC = (BitmapSource)obrazWpf.Source;
            Bitmap bitmapa;
            Image<Gray, Byte> wynik;
            MemoryStream outStream = new MemoryStream();
            BitmapEncoder enc = new BmpBitmapEncoder();

            enc.Frames.Add(BitmapFrame.Create(bitmapaSRC));
            enc.Save(outStream);

            bitmapa = new Bitmap(outStream);

            wynik = new Image<Gray, byte>(bitmapa);

            return wynik;

        }

        public static void umiescObrazEmguWKontrolceImage(Image<Gray, byte> obrazEmgu, System.Windows.Controls.Image oknoImage)
        {
            Bitmap bitmapa = obrazEmgu.ToBitmap();
            BitmapImage obrazBitmapa;

            using (MemoryStream memory = new MemoryStream())
            {
                bitmapa.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                obrazBitmapa = bitmapimage;
            }

            oknoImage.Source = obrazBitmapa;


        }

        public static double[] normalizujWartosciPixeli(Image<Gray, Byte> obraz)
        {
            byte[] bajtyObrazu = obraz.Bytes;
            double[] networkFeed = new double[bajtyObrazu.Count()];

            for(int i = 0; i < bajtyObrazu.Length; i++)
            {
                networkFeed[i] = ((double)bajtyObrazu[i] / 256);
            }

            return networkFeed;
        }

    }
}
