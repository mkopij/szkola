using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6938_sieci_neuronowe_lab1_rozpoznawanie_pojazdów.siecNeuronowa
{
    class Neuron
    {
        int indeks;
        double wartosc;
        double bias;

        List<Neuron> polaczeniaPrzod;
    }
}
