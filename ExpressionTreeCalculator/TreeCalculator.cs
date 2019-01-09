using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeCalculator
{
    public class TreeCalculator
    {
        public double CalculateExpression(TreeNode node)
        {
            if(node == null)
            {
                throw new NullReferenceException("Node cannot be null");
            }
            //If we are an operand then no more calculations to do, just return our value here
            if(node.Operand.HasValue)
            {
                return node.Operand.Value;
            }

            //Calculate expression of left child and right child and then the current operator of the two
            double left = CalculateExpression(node.LeftChild);
            double right = CalculateExpression(node.RightChild);

            return node.Operator(left, right);
        }
    }
}
