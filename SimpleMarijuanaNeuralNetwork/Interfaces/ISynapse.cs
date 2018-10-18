using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMarijuanaNeuralNetwork.Interfaces
{
    public interface ISynapse
    {
        double Weight { get; set; }
        double PreviousWeight { get; set; }
        double GetOutput();

        bool IsFromNeuron(Guid fromNeuronId);
        void UpdateWeight(double learningRate, double delta);
    }
}
