namespace E03_DependencyInversion
{
    using System;
    using E03_DependencyInversion.Strategies;

    public class Engine
    {
        private readonly PrimitiveCalculator calculator;

        public Engine(PrimitiveCalculator calculator)
        {
            this.calculator = calculator;
        }
        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                else if (input.StartsWith("mode"))
                {
                    var operation = input.Split()[1];

                    switch (operation)
                    {
                        case"+":
                            this.calculator.ChangeStrategy(new AdditionStrategy());
                            break;
                        case "-":
                            this.calculator.ChangeStrategy(new SubtractionStrategy());
                            break;
                        case "*":
                            this.calculator.ChangeStrategy(new MultiplicationStrategy());
                            break;
                        case "/":
                            this.calculator.ChangeStrategy(new DivideStrategy());
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    var operands = input.Split();
                    var firstOperand = int.Parse(operands[0]);
                    var secondOperand = int.Parse(operands[1]);
                    Console.WriteLine(this.calculator.PerformCalculation(firstOperand, secondOperand));
                }
            }
        }
    }
}