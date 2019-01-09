using System;
using ExpressionTreeCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressionTreeCalculator.Tests
{
    [TestClass]
    public class BuildAndCalculateTests
    {
        TreeBuilder _treeBuilder = new TreeBuilder();
        TreeCalculator _treeCalculator = new TreeCalculator();

        [TestMethod]
        public void SimpleAddition()
        {
            string expression = "3 + 4";
            var root = _treeBuilder.BuildTreeFromString(expression);
            double result = _treeCalculator.CalculateExpression(root);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void SimpleMultiplication()
        {
            string expression = "3 * 4";
            var root = _treeBuilder.BuildTreeFromString(expression);
            double result = _treeCalculator.CalculateExpression(root);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void SimpleDivision()
        {
            string expression = "3 / 4";
            var root = _treeBuilder.BuildTreeFromString(expression);
            double result = _treeCalculator.CalculateExpression(root);
            Assert.AreEqual(3/4.0, result);
        }

        [TestMethod]
        public void SimpleSubtraction()
        {
            string expression = "3 - 4";
            var root = _treeBuilder.BuildTreeFromString(expression);
            double result = _treeCalculator.CalculateExpression(root);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void DecimalMultiplication()
        {
            string expression = "3.1345 * 4.29385";
            var root = _treeBuilder.BuildTreeFromString(expression);
            double result = _treeCalculator.CalculateExpression(root);
            Assert.AreEqual(3.1345 * 4.29385, result);
        }

        [TestMethod]
        public void Brackets()
        {
            string expression = "(1 / 2) * (3 + 4)";
            var root = _treeBuilder.BuildTreeFromString(expression);
            double result = _treeCalculator.CalculateExpression(root);
            Assert.AreEqual(3.5, result);
        }

        [TestMethod]
        public void MultipleBrackets()
        {
            string expression = "(1 + 2) * (2 + 3) * (3 * (2 + 4))";
            var root = _treeBuilder.BuildTreeFromString(expression);
            double result = _treeCalculator.CalculateExpression(root);
            Assert.AreEqual(270, result);
        }

        [TestMethod]
        public void DeepBrackets()
        {
            string expression = "1 + (2 * (3 + (4 * 5)))";
            var root = _treeBuilder.BuildTreeFromString(expression);
            double result = _treeCalculator.CalculateExpression(root);
            Assert.AreEqual(47, result);
        }
    }
}
