using SimpleMarijuanaNeuralNetwork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMarijuanaNeuralNetwork.Functions
{
    public class SigmoidActivationFunction : IActivationFunction
    {
        private double _coeficient;

        public SigmoidActivationFunction(double coeficient)
        {
            _coeficient = coeficient;
        }

        public double CalculateOutput(double input)
        {
            return (1 / (1 + Math.Exp(-input * _coeficient)));
        }
    }
}
