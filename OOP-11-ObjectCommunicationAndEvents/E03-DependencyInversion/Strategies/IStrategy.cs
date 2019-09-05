namespace E03_DependencyInversion.Strategies
{
    public interface IStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}