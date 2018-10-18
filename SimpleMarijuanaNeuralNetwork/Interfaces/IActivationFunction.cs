using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMarijuanaNeuralNetwork.Interfaces
{
    public interface IActivationFunction
    {
        double CalculateOutput(double input);
    }
}
