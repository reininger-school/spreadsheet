// Reid Reininger
// 11512839
namespace ExpressionTreeApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cpts321;

    /// <summary>
    /// Console application for ExpressionTree app.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Console app start point.
        /// </summary>
        public static void Main()
        {
            bool status = true;
            string input1, input2;
            ExpressionTree tree = new ExpressionTree("1+11");
            while (status)
            {
                PrintMenu(Console.Out, tree.Expression);
                input1 = Console.ReadLine();
                switch (input1)
                {
                    case "1":
                        Console.Write("Enter new expression: ");
                        tree.Expression = Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Enter variable name: ");
                        input1 = Console.ReadLine();
                        Console.Write("Enter variable value: ");
                        input2 = Console.ReadLine();
                        tree.SetVariable(input1, double.Parse(input2));
                        break;
                    case "3":
                        Console.WriteLine(tree.Evaluate().ToString());
                        break;
                    case "4":
                        status = false;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Print expression tree menu.
        /// </summary>
        /// <param name="writer">Stream to write to.</param>
        /// <param name="expression">Current expression.</param>
        public static void PrintMenu(TextWriter writer, string expression)
        {
            writer.WriteLine($"Menu (current expression=\"{expression}\")");
            writer.WriteLine("  1 = Enter a new expression");
            writer.WriteLine("  2 = Set a variable value");
            writer.WriteLine("  3 = Evaluate tree");
            writer.WriteLine("  4 = Quit");
            writer.Flush();
        }
    }
}
