using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp.Service;

namespace TestApp.UnitTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestAllPlus()
        {
            var expression = "10+100+1000+10000";
            var actual = new CalculatorService().Calculate(expression);
            Assert.AreEqual(11110, actual.Value, 0, "TestAllPlus passed");
        }

        [TestMethod]
        public void TestAllMinus()
        {
            var expression = "11110- 1000 - 100- 10";
            var actual = new CalculatorService().Calculate(expression);
            Assert.AreEqual(10000, actual.Value, 0, "TestAllMinus passed");
        }

        [TestMethod]
        public void TestAllMultiply()
        {
            var expression = "10* 100 * 1000";
            var actual = new CalculatorService().Calculate(expression);
            Assert.AreEqual(1000000, actual.Value, 0, "TestAllMultiply passed");
        }

        [TestMethod]
        public void TestAllDivide()
        {
            var expression = "10/ 100 / 1000";
            var actual = new CalculatorService().Calculate(expression);
            Assert.AreEqual(0.0001, actual.Value, 0.0001, "TestAllDivide passed");
        }

        [TestMethod]
        public void TestDivideBy0()
        {
            var expression = "10/ 0";
            var actual = new CalculatorService().Calculate(expression);
            Assert.AreEqual(false, actual.HasValue, "TestDivideBy0 passed");
        }

        [TestMethod]
        public void TestMix1()
        {
            var expression = "10 / 2 * 3 + 4 + 5 - 80";
            var actual = new CalculatorService().Calculate(expression);
            Assert.AreEqual(-56, actual.Value,0.0001, "TestMix1 passed");
        }

        [TestMethod]
        public void TestMix2()
        {
            var expression = "45-20*5*12+34/13";
            var actual = new CalculatorService().Calculate(expression);
            Assert.AreEqual(-1152.38461538, actual.Value, 0.0001, "TestMix2 passed");
        }
        [TestMethod]
        public void TestMix3()
        {
            var expression = "-45-20*5*12+34/13";
            var actual = new CalculatorService().Calculate(expression);
            Assert.AreEqual(-1242.38461538, actual.Value, 0.0001, "TestMix3 passed");
        }

        [TestMethod]
        public void TaskTest1()
        {
            var expression = "4+5*2";
            var actual = new CalculatorService().Calculate(expression);
            Assert.AreEqual(14, actual.Value, 0.0001, "TaskTest1 passed");
        }

        [TestMethod]
        public void TaskTest2()
        {
            var expression = "4+5/2";
            var actual = new CalculatorService().Calculate(expression);
            Assert.AreEqual(6.5, actual.Value, 0.0001, "TaskTest2 passed");
        }

        [TestMethod]
        public void TaskTest3()
        {
            var expression = "4+5/2-1";
            var actual = new CalculatorService().Calculate(expression);
            Assert.AreEqual(5.5, actual.Value, 0.0001, "TaskTest3 passed");
        }
    }
}
