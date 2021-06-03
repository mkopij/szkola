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
using _6938_sieci_neuronowe_lab1_rozpoznawanie_pojazdów.siecNeuronowa;

namespace _6938_sieci_neuronowe_lab1_rozpoznawanie_pojazdów
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Image<Gray, byte> EmguImg = null;

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                string file = op.FileName;
                imgPhotoBefore.Source = new BitmapImage(new Uri(op.FileName));
                EmguImg = PrzetwarzaczObrazow.kowertujImageNaEmgu(imgPhotoBefore);
            }

        }

        private void btnLoadImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                string file = op.FileName;
                imgLoadedPhoto.Source = new BitmapImage(new Uri(op.FileName));
                EmguImg = PrzetwarzaczObrazow.kowertujImageNaEmgu(imgLoadedPhoto);
            }

        }

        private void btnCompress_Click(object sender, RoutedEventArgs e)
        {
            var imgKontrolka = imgPhotoBefore;
            var imgEmgu = PrzetwarzaczObrazow.kowertujImageNaEmgu(imgKontrolka);

            imgEmgu = PrzetwarzaczObrazow.kompresujObraz(imgEmgu);

            PrzetwarzaczObrazow.umiescObrazEmguWKontrolceImage(imgEmgu, imgPhotoAfter);

            PrzetwarzaczObrazow.podzielNaPiksele(imgEmgu);

        }

        private void btnZaladujDane_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult folder;

            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                folder = dialog.ShowDialog();
                string[] pliki = Directory.GetFiles(dialog.SelectedPath);

                TrenerSieci.zaladujObrazy(pliki, listaObrazow_trening);
            }

        }

   
    }
}
