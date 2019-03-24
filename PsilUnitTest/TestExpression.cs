namespace PsilUnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Testing the PsilExpressions
    /// </summary>
    class TestExpression
    {
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }

        public override string ToString()
        {
            return string.Format("Input : {0} | ExpectedOutput : {1} ", Input, ExpectedOutput);
        }

        public TestExpression(string input, string expectedResult)
        {
            Input = input;
            ExpectedOutput = expectedResult;
        }

        /// <summary>
        /// Test the Expression after Evaluating 
        /// </summary>
        /// <returns></returns>
        public void Test()
        {
            Psil.PsilEnvironment environment = new Psil.PsilEnvironment(Input);
            Psil.PsilResult result = environment.Eval();

            if (!string.Equals(result.Value, ExpectedOutput))
            {
                Assert.Fail(String.Format("Expression : {0}, EvaluatedOutput {1}", this.ToString(), ExpectedOutput));
            }
        }
    }
}
