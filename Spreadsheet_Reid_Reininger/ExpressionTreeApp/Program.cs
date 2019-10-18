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
            while (status)
            {
                PrintMenu(Console.Out, null);
                var tree = new ExpressionTree("40 / 5 /      2");
                Console.WriteLine(tree.Evaluate());
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
