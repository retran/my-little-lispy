﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLittleLispy.Hosting;

namespace MyLittleLispy.Tests
{
    [TestClass]
    public class Arithmetics
    {
        private ScriptEngine _engine;

        [TestInitialize]
        public void SetUp()
        {
            _engine = new ScriptEngine();
        }

        [TestMethod]
        public void IntegerConstShouldEvaluateToItsValue()
        {
            Assert.AreEqual(2, _engine.Execute("2").To<int>());
            Assert.AreEqual(-200, _engine.Execute("-200").To<int>());
            Assert.AreEqual(0, _engine.Execute("0").To<int>());
        }

        [TestMethod]
        public void AddOperationShouldAddIntegersProperly()
        {
            Assert.AreEqual(4, _engine.Execute("(+ 2 2)").To<int>());
            Assert.AreEqual(0, _engine.Execute("(+ -2 2)").To<int>());
        }

        [TestMethod]
        public void SubstractOperationShouldSubstractIntegersProperly()
        {
            Assert.AreEqual(4, _engine.Execute("(- 10 6)").To<int>());
            Assert.AreEqual(16, _engine.Execute("(- 10 -6)").To<int>());
            Assert.AreEqual(-16, _engine.Execute("(- -10 6)").To<int>());
        }

        [TestMethod]
        public void MultipleOperationShouldMultipleIntegersProperly()
        {
            Assert.AreEqual(50, _engine.Execute("(* 10 5)").To<int>());
            Assert.AreEqual(-50, _engine.Execute("(* -10 5)").To<int>());
            Assert.AreEqual(0, _engine.Execute("(* 0 5)").To<int>());
        }

        [TestMethod]
        public void DivideOperationShouldDivideIntegersProperly()
        {
            Assert.AreEqual(5, _engine.Execute("(/ 10 2)").To<int>());
            Assert.AreEqual(5, _engine.Execute("(/ 11 2)").To<int>());
            Assert.AreEqual(0, _engine.Execute("(/ 0 2)").To<int>());

            // TODO find way to assert exceptions 
//            Assert.AreEqual(5, _engine.Execute("(/ 10 0)").To<int>());
//            Assert.AreEqual(5, _engine.Execute("(/ 0 0)").To<int>());
        }

        [TestMethod]
        public void ComplexExpressionWithIntegersShouldEvaluateProperly()
        {
            Assert.AreEqual(6, _engine.Execute("(+ 2 (* 2 2))").To<int>());
            Assert.AreEqual(94, _engine.Execute("(- (* 10 10) 6)").To<int>());
            Assert.AreEqual(50, _engine.Execute("(* (/ 10  5) (* 5 5))").To<int>());
            Assert.AreEqual(37, _engine.Execute("(+ (+ (* 10 3) 2) (- 10 (- 20 15)))").To<int>());
        }
    }
}