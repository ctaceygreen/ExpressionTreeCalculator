using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionTreeCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeCalculator.Tests
{
    [TestClass()]
    public class TreeCalculatorTests
    {
        TreeCalculator _sut = new TreeCalculator();

        [TestInitialize()]
        public void Setup()
        {

        }

        [TestMethod()]
        public void CalculateExpression_SimpleAddition()
        {
            TreeNode node = new TreeNode
            {
                Operator = (a, b) => a + b,
                LeftChild = new TreeNode
                {
                    Operand = 1
                },
                RightChild = new TreeNode
                {
                    Operand = 2
                }
            };
            double result = _sut.CalculateExpression(node);
            Assert.AreEqual(3, result);
        }
        [TestMethod()]
        public void CalculateExpression_MultipleBranches()
        {
            TreeNode node = new TreeNode
            {
                Operator = (a, b) => a * b,
                LeftChild = new TreeNode
                {
                    Operator = (a, b) => a + b,
                    LeftChild = new TreeNode
                    {
                        Operand = 1
                    },
                    RightChild = new TreeNode
                    {
                        Operand = 2
                    }
                },
                RightChild = new TreeNode
                {
                    Operator = (a, b) => a / b,
                    LeftChild = new TreeNode
                    {
                        Operand = 3
                    },
                    RightChild = new TreeNode
                    {
                        Operand = 4
                    }
                }
            };
            double result = _sut.CalculateExpression(node);
            Assert.AreEqual(9/4.0, result);
        }

        [TestMethod()]
        public void CalculateExpression_SingleNodeReturnsOperand()
        {
            TreeNode root = new TreeNode
            {
                Operand = 1
            };
            double result = _sut.CalculateExpression(root);
            Assert.AreEqual(1, result);
        }
    }
}