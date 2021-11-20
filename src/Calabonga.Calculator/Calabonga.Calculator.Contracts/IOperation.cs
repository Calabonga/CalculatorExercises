namespace Calabonga.Calculator.Contracts
{
    public interface IOperation
    {
        string Name { get; }

        string ShortName { get; }

        string Description { get; }

        float Execute(float number1, float number2);
    }
}
