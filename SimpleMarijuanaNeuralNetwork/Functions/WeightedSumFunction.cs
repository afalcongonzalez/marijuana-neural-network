using SimpleMarijuanaNeuralNetwork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMarijuanaNeuralNetwork.Functions
{
    public class WeightedSumFunction : IInputFunction
    {
        public double CalculateInput(List<ISynapse> inputs)
        {
            return inputs.Select(x => x.Weight * x.GetOutput()).Sum();
        }
    }
}
