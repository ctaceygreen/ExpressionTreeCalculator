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
    public class TreeBuilderTests
    {
        TreeBuilder _sut = new TreeBuilder();

        [TestMethod()]
        public void BuildTreeFromString_SingleOperand()
        {
            var node = _sut.BuildTreeFromString("3");
            Assert.AreEqual(3, node.Operand);
        }

        [TestMethod()]
        public void BuildTreeFromString_SingleOperandDecimal()
        {
            var node = _sut.BuildTreeFromString("3.14");
            Assert.AreEqual(3.14, node.Operand);
        }

        [TestMethod()]
        public void BuildTreeFromString_SimpleAddition()
        {
            var node = _sut.BuildTreeFromString("3 + 4");
            Assert.AreEqual(3, node.LeftChild.Operand);
            Assert.AreEqual(4, node.RightChild.Operand);
            Assert.AreEqual(5, node.Operator(2, 3));
        }

        [TestMethod()]
        public void BuildTreeFromString_Brackets()
        {
            var node = _sut.BuildTreeFromString("(1 + 2) * (3 + 4)");
            Assert.AreEqual(3, node.LeftChild.Operator(1, 2));
            Assert.AreEqual(1, node.LeftChild.LeftChild.Operand);
            Assert.AreEqual(2, node.LeftChild.RightChild.Operand);
            Assert.AreEqual(7, node.RightChild.Operator(3, 4));
            Assert.AreEqual(3, node.RightChild.LeftChild.Operand);
            Assert.AreEqual(4, node.RightChild.RightChild.Operand);
            Assert.AreEqual(21, node.Operator(3, 7));
        }
    }
}