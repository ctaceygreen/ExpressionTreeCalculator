using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeCalculator
{
    public class TreeBuilder
    {

        Dictionary<char, Func<double, double, double>> _operators = new Dictionary<char, Func<double, double, double>>
        {
            { '*', (a,b) => a * b },
            { '/', (a,b) => a / b },
            { '+', (a,b) => a + b },
            { '-', (a,b) => a - b }
        };


        public TreeNode BuildTreeFromString(string expression)
        {
            //Remove whitespace
            expression = expression.Replace(" ", string.Empty);

            TreeNode currentNode = null;
            int characterIndex = 0;

            //Loop through characters of expression.
            while(characterIndex < expression.Length)
            {
                char character = expression[characterIndex];
                if (_operators.ContainsKey(character))
                {
                    //Then we have an operator
                    var operatorFunc = _operators[character];
                    currentNode = InsertOperator(currentNode, operatorFunc);
                    characterIndex++;
                }
                else if(char.IsDigit(character))
                {
                    //Then we have a digit. 
                    //This could be a single digit number or a double or a really long number, 
                    //so continue looping until we reach a non "." or non digit character
                    string number = character.ToString();
                    characterIndex++;
                    while(characterIndex < expression.Length && (char.IsDigit(expression[characterIndex]) || expression[characterIndex] == '.'))
                    {
                        number += expression[characterIndex];
                        characterIndex++;
                    }
                    double value = double.Parse(number);
                    currentNode = InsertOperand(value, currentNode);
                }
                else if(expression[characterIndex] == ')')
                {
                    //If we reach a close bracket then we need to jump our pointer to our parent
                    currentNode = currentNode.Parent;
                    characterIndex++;
                }
                else
                {
                    //Any other char just ignore
                    characterIndex++;
                }
                
            }
            // Return the root node
            TreeNode root = currentNode;
            while(root.Parent != null)
            {
                root = root.Parent;
            }
            return root;
        }

        public void InsertParent(TreeNode child, TreeNode newParent)
        {
            TreeNode existingParent = child.Parent;
            child.Parent = newParent;
            if(existingParent != null)
            {
                newParent.Parent = existingParent;
            }
        }

        public TreeNode InsertOperator(TreeNode currentNode, Func<double, double, double> operatorFunc)
        {
            //Inserting an operator at the current point makes a new node as the parent of the currentNode
            TreeNode newParent = new TreeNode
            {
                Operator = operatorFunc,
                LeftChild = currentNode,
                Parent = currentNode.Parent
            };
            if (newParent.Parent != null)
            {
                newParent.Parent.RightChild = newParent;
            }
            currentNode.Parent = newParent;
            return newParent;
        }

        public TreeNode InsertOperand(double value, TreeNode currentNode = null)
        {
            //currentNode can be null in the first element of the expression
            TreeNode operandNode = new TreeNode
            {
                Operand = value
            };
            if(currentNode != null)
            {
                operandNode.Parent = currentNode;
                // Should always be adding this in as the right child
                currentNode.RightChild = operandNode;
            }
            return operandNode;
        }

    }
}
