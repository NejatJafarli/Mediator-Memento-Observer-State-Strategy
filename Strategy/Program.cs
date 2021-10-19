using System;

namespace Strategy
{

    interface IStrategy
    {
        int DoOperation(int num1, int num2);
    }

    class OperationAdd : IStrategy
    {
        public int DoOperation(int num1, int num2) => num1 + num2;
    }

    class OperationSubstract : IStrategy
    {
        public int DoOperation(int num1, int num2) => num1 - num2;
    }

    class OperationMultiply : IStrategy
    {
        public int DoOperation(int num1, int num2) => num1 * num2;
    }
    class Context
    {
        public IStrategy Strategy { get; set; }
        public Context(IStrategy strategy)
        {
            Strategy = strategy;
        }
        public int DoOperation(int num1, int num2) => Strategy.DoOperation(num1, num2);
    }

    public class Program
    {
        static void Main(string[] args)
        {
            OperationAdd operationAdd = new OperationAdd();

            OperationMultiply operationMultiply = new OperationMultiply();

            OperationSubstract operationSubstract = new OperationSubstract();

            Context context = new Context(operationAdd);

            Console.WriteLine(context.DoOperation(5, 5).ToString()); //toplama

            context.Strategy = operationSubstract;

            Console.WriteLine(context.DoOperation(5, 5));//cixma

            context.Strategy = operationMultiply;

            Console.WriteLine(context.DoOperation(5, 5));//Vurma

        }
    }
}
