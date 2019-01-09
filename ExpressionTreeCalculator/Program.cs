using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = "";
            if(args.Length > 0)
            {
                expression = args[0];
            }
            else
            {
                //Take input from console instead
                Console.WriteLine("Please input your expression..");
                expression = Console.ReadLine();
            }
            Console.WriteLine($"Calculating your expression: {expression}");
            
            TreeBuilder treeBuilder = new TreeBuilder();
            var root = treeBuilder.BuildTreeFromString(expression);
            TreeCalculator treeCalculator = new TreeCalculator();
            double result = treeCalculator.CalculateExpression(root);

            Console.WriteLine($"{expression} = {result}");
            Console.ReadLine();
        }
    }
}
