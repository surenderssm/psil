using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace PsilUnitTest
{
    /// <summary>
    /// only to test highlevel Scenarios
    /// </summary>
    [TestClass]
    public class Scenarios
    {
        private const string InvalidProgramMessage = Psil.PsilMessages.InvalidProgram;

        [TestMethod]
        public void SimpleTest()
        {

            string input = "45";
            string output = "45";
            var expression = new TestExpression(input, output);
            expression.Test();

            input = "( bind x 42 ) ( + x 10 )";
             output = "52";
            expression = new TestExpression(input, output);
            expression.Test();
        }

        [TestMethod]
        public void NoOperatorNumberTest()
        {

            string input = "45";
            string output = "45";
            var expression = new TestExpression(input, output);
            expression.Test();

            input = "( bind x 42 ) ( + x 10 )";
            output = "52";
            expression = new TestExpression(input, output);
            expression.Test();
        }

        [TestMethod]
        public void UnformatedINput()
        {
            string input = "(bind x 42)( + x 10 )  ";
            string output = "52";
            var expression = new TestExpression(input, output);
            expression.Test();
        }

        [TestMethod]
        public void SimpleBind()
        {
            string input = "( bind x 42 ) ( + x 10 )";
            string output = "52";
            var expression = new TestExpression(input, output);
            expression.Test();
        }


        [TestMethod]
        public void SimpleAdd()
        {
            string input = "( + 2 3 5 )";
            string output = "10";
            var expression = new TestExpression(input, output);
            expression.Test();
        }

        [TestMethod]
        public void UnbindedToken()
        {
            string input = "( + 3 2 unbindedVariableA )";
            string output = InvalidProgramMessage;
            var expression = new TestExpression(input, output);
            expression.Test();
        }

        [TestMethod]
        public void SequenceOfStatements()
        {
            string input = @"(bind a 10)  (bind b a)
            (bind a 11)
            (+ a b) ";
            string output = "21";
            var expression = new TestExpression(input, output);
            expression.Test();

            input = @"(bind a 10)  (bind b a)
            (bind a 11)
            (* a b) ";
            output = "110";
            expression = new TestExpression(input, output);
            expression.Test();
        }

        [TestMethod]
        public void MultipleBind()
        {
            string input = @"
                (bind length 10)
                (bind breadth (+ length 1))

                (bind length 11) (* length breadth)";

            string output = "121";
            var expression = new TestExpression(input, output);
            expression.Test();
        }


        [TestMethod]
        public void InvalidProgram()
        {
            List<string> lstInvalidInputs = new List<string> { "(", "()", "A", "_A", "(+ x 1 2 3)","+ c v b" };
            string output = InvalidProgramMessage;
            lstInvalidInputs.ForEach(input =>
            {
                TestExpression testExpression = new TestExpression(input, output);
                testExpression.Test();
            });
        }
    }
}
