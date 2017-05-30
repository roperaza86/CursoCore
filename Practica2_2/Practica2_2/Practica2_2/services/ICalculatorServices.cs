using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica2_2.services
{
    public interface ICalculatorServices
    {

        int Calculate(int a, int b, string operation);
    }

    public class CalculatorServices : ICalculatorServices
    {

        private readonly ICalculationEngine _iCalculatorEngine;


        public CalculatorServices(ICalculationEngine iCalculatorServices)
        {
            _iCalculatorEngine = iCalculatorServices;
        }
        public int Calculate(int a, int b, string operation)
        {
            switch (operation)
            {
                case "+":
                    return _iCalculatorEngine.Add(a, b);
                case "-":
                    return _iCalculatorEngine.Substract(a, b);
                case "*":
                    return _iCalculatorEngine.Multiply(a, b);
                case "/":
                    return _iCalculatorEngine.Divide(a, b);
                default:
                    var message = $"Operation '{operation}' not supported";
                    throw new ArgumentOutOfRangeException(nameof(operation), message);
            }
        }
    }


    public interface ICalculationEngine
    {

        int Add(int a, int b);
        int Substract(int a, int b);
        int Multiply(int a, int b);
        int Divide(int a, int b);

    }

    public class CalculationEngine : ICalculationEngine
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Divide(int a, int b)
        {
            return a / b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Substract(int a, int b)
        {
            return a - b;
        }
    }
}
