using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SimpleMarijuanaNeuralNetwork.Componets;
using SimpleMarijuanaNeuralNetwork.Functions;

namespace SimpleMarijuanaNeuralNetworkTests.SixInputTests
{
    [TestClass]
    public class SixInputs_OneOutput_Tests
    {
        [TestMethod]
        public void Initialization_Constructor_NeuralNetworkInitialized()
        {
            var network = new SimpleNeuralNetwork(6);
            Assert.AreEqual(1, network._layers.Count);
            Assert.AreEqual(6, network._layers.First().Neurons.Count);

            Assert.AreEqual(2.95, network._learningRate);
        }

        [TestMethod]
        public void AddLayer_NeuralAddingNewLayer_LayerAdded()
        {
            var network = new SimpleNeuralNetwork(6);
            var layerFactory = new NeuralLayerFactory();
            network.PushInputValues(new double[] { 23, 565, 789, 3, 90, 23 });
            network.AddLayer(layerFactory.CreateNeuralLayer(3, new RectifiedActivationFuncion(), new WeightedSumFunction()));

            Assert.AreEqual(2, network._layers.Count);
            Console.WriteLine(JsonConvert.SerializeObject(network, Formatting.Indented));
        }

        [TestMethod]
        public void PushInputValues_ValuesSentToNetwork_ValuesSetOnInput()
        {
            var network = new SimpleNeuralNetwork(6);
            network.PushInputValues(new double[] { 23, 565, 789,3,90,23 });

            Assert.AreEqual(23, network._layers.First().Neurons.First().Inputs.First().GetOutput());
            Console.WriteLine(JsonConvert.SerializeObject(network, Formatting.Indented));
        }
        [TestMethod]
        public void TrainNetwork_6Inputs_3HiddenLayer_2Outputs()
        {
            var network = new SimpleNeuralNetwork(6,1.95); // six input nuerons
            var layerFactory = new NeuralLayerFactory();
            network.AddLayer(layerFactory.CreateNeuralLayer(3, new SigmoidActivationFunction(0.7), new WeightedSumFunction())); // three hidden layers
            network.AddLayer(layerFactory.CreateNeuralLayer(2, new LazyOutputFunction(), new WeightedSumFunction())); // two output layers
            network.PushExpectedValues(
               new double[][] {
                    new double[] { 0.25 , 0.20 },
                    new double[] { 0.10 , 0.05 },
                    new double[] { 0.16 , 0.30 },
                    new double[] { 0.30 , 0.10 },
                    new double[] { 0.25 , 0.20 },
                    new double[] { 0.10 , 0.05 },
                    new double[] { 0.16 , 0.30 },
                    new double[] { 0.30 , 0.10 },
               });
            network.Train(
               new double[][] {
                    new double[] { 150, 0, 0 ,34,35,56},
                    new double[] { 190, 23, 56 ,0,29,529},
                    new double[] { 290, 3, 108 ,24,189,20},
                    new double[] { 290, 67, 6 ,0,1,0},
                    new double[] { 150, 0, 0 ,34,35,56},
                    new double[] { 190, 23, 56 ,0,29,529},
                    new double[] { 290, 3, 108 ,24,189,20},
                    new double[] { 290, 67, 6 ,0,1,0},
               }, 10000);

            network.PushInputValues(new double[] { 150, 0, 0, 34, 35, 56 });

            var outputs = network.GetOutput();
            Console.WriteLine(outputs[0].ToString() +" "+ outputs[1].ToString() + "\n\n" +JsonConvert.SerializeObject(network, Formatting.Indented));
         
        }
    }
}
