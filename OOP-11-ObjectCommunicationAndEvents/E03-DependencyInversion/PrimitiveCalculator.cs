namespace E03_DependencyInversion
{
    using E03_DependencyInversion.Strategies;

    public class PrimitiveCalculator
    {
        private IStrategy strategy;

        public PrimitiveCalculator()
            :this(new AdditionStrategy())
        {
        }

        public PrimitiveCalculator(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ChangeStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public double PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}