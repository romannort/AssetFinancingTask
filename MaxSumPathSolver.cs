using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AssetFinancingTask
{
    public class MaxSumPathSolver
    {
        public class Result
        {
            public int Sum { get; set; } = 0;
            public Stack<TreeNode> Path { get; set; } = new Stack<TreeNode>();

            public Result Combine(TreeNode node)
            {
                Sum += node.Data;
                Path.Push(node);

                return this;
            }
        }

        public Result Solve(TreeNode root)
        {
            return MaxPathSumRec(root);

            static Result MaxPathSumRec(TreeNode node)
            {
                if (node.Left == null && node.Right == null)
                {
                    return new Result().Combine(node);
                }

                Result leftRes = new Result();
                if (!IsParityMathches(node.Data, node.Left.Data))
                {
                    leftRes = MaxPathSumRec(node.Left);
                }

                Result rightRes = new Result();
                if (!IsParityMathches(node.Data, node.Right.Data))
                {
                    rightRes = MaxPathSumRec(node.Right);
                }

                if (leftRes.Sum > rightRes.Sum)
                {
                    return leftRes.Combine(node);
                }

                return rightRes.Combine(node);
            }
        }

        public static bool IsParityMathches(int value1, int value2)
        {
            return value1 % 2 == value2 % 2;
        }
    }
}