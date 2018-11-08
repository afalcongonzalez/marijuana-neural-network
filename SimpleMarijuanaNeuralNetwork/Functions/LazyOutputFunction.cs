using SimpleMarijuanaNeuralNetwork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMarijuanaNeuralNetwork.Functions
{
    public class LazyOutputFunction : IActivationFunction
    {
        public double CalculateOutput(double input)
        {
            return input;
        }
    }
}
