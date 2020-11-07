using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AssetFinancingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = File.ReadAllLines("inputs.txt");

            var root = TreeNode.BuildTreeFromTriangleMatrix(inputs);

            var result = new MaxSumPathSolver().Solve(root);

            Console.WriteLine($"Max sum: { result.Sum }");
            Console.WriteLine($"Path: { string.Join(' ', result.Path) }");
        }
    }
}