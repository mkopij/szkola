using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.MachineLearning;
using Accord.Neuro;
using Accord.Neuro.ActivationFunctions;
using Accord.Neuro.Learning;
using Accord.Neuro.Networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6938_sieci_neuronowe_lab1_rozpoznawanie_pojazdów.siecNeuronowa
{
    class SiecNeuronowa
    {
        readonly private int rozmiarWarstwyWejscia = 10000;
        readonly private int rozmiarWarstwyWyjscia = 7;

        private int rozmiarUkrytychWarstw;

        DeepBeliefNetwork siec;
        DeepBeliefNetworkLearning nienadzorowanyTrener;
        ResilientBackpropagationLearning nadzorowanyTrener;

        public SiecNeuronowa()
        {
            siec = new DeepBeliefNetwork(new BernoulliFunction(), rozmiarWarstwyWejscia, 5000, 2500, 7);
            new NguyenWidrow(siec).Randomize();
            siec.UpdateVisibleWeights();
            nienadzorowanyTrener = GetUnsupervisedTeacherForNetwork(siec);
            nadzorowanyTrener = GetSupervisedTeacherForNetwork(siec);
        }


        private DeepBeliefNetworkLearning GetUnsupervisedTeacherForNetwork(DeepBeliefNetwork deepNetwork)
        {
            var teacher = new DeepBeliefNetworkLearning(deepNetwork)
            {
                Algorithm = (hiddenLayer, visibleLayer, i) => new ContrastiveDivergenceLearning(hiddenLayer, visibleLayer)
                {
                    LearningRate = 0.1,
                    Momentum = 0.5
                }
            };
            return teacher;
        }

        private ResilientBackpropagationLearning GetSupervisedTeacherForNetwork(DeepBeliefNetwork deepNetwork)
        {
            var teacher = new ResilientBackpropagationLearning(deepNetwork)
            {
                LearningRate = 0.1
                //Momentum = 0.5
            };
            return teacher;
        }
    }
}
