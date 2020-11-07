using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AssetFinancingTask
{
    public class TreeNode
    {
        public TreeNode Left;
        public TreeNode Right;

        public int Data
        {
            get
            {
                if (DataSource == null)
                {
                    throw new InvalidOperationException("DataSource is not set.");
                }

                return DataSource[DataRow][DataColumn];
            }
        }

        public int DataRow = -1;

        public int DataColumn = -1;

        public List<int>[] DataSource { get; set; }

        public override string ToString()
        {
            return Data.ToString();
        }


        public static TreeNode BuildTreeFromTriangleMatrix(string[] inputs)
        {
            var dataSourceMatrix = inputs
                .Select(level =>
                    level.Split(' ')
                    .Where(item => !string.IsNullOrWhiteSpace(item))
                    .Select(Int32.Parse)
                    .ToList())
                .ToArray();

            var root = new TreeNode();
            root.DataSource = dataSourceMatrix;
            root.DataColumn = 0;
            root.DataRow = 0;

            var levelNodes = new List<TreeNode>();
            levelNodes.Add(root);

            while (levelNodes.Count > 0)
            {
                var nextLevelNodes = new List<TreeNode>();
                foreach (var levelItem in levelNodes)
                {
                    levelItem.Left = new TreeNode()
                    {
                        DataColumn = levelItem.DataColumn,
                        DataRow = levelItem.DataRow + 1,
                        DataSource = dataSourceMatrix
                    };

                    levelItem.Right = new TreeNode()
                    {
                        DataColumn = levelItem.DataColumn + 1,
                        DataRow = levelItem.DataRow + 1,
                        DataSource = dataSourceMatrix
                    };

                    if (levelItem.DataRow < dataSourceMatrix.Length - 2)
                    {
                        nextLevelNodes.Add(levelItem.Left);
                        nextLevelNodes.Add(levelItem.Right);
                    }
                }

                levelNodes = nextLevelNodes;
            }

            return root;
        }
    }
}