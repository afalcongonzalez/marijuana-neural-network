using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMarijuanaNeuralNetwork.Interfaces
{
    public interface IInputFunction
    {
        double CalculateInput(List<ISynapse> inputs);
    }
}
