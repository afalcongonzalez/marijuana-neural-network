using SimpleMarijuanaNeuralNetwork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMarijuanaNeuralNetwork.Functions
{
    public class RectifiedActivationFuncion : IActivationFunction
    {
        public double CalculateOutput(double input)
        {
            return Math.Max(0, input);
        }
    }
}
