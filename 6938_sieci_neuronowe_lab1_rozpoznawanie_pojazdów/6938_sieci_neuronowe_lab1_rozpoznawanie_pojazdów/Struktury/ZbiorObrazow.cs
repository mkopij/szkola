using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6938_sieci_neuronowe_lab1_rozpoznawanie_pojazdów.Struktury
{
    class ZbiorObrazow
    {
        public List<Obraz> obrazy { get; set; }
        public Klasyfikacja klasyfikacja { get; set; }


        public void dodaj(Obraz obraz)
        {
            obrazy.Add(obraz);
        }
    }
}
