// Parser And Evaluator

namespace Psil.Parsing
{
    using Psil.Common;
    using Psil.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;


    /// <summary>
    /// Parse and Evaluate PSil
    /// </summary>
    public class ParserEvaluator
    {
        PsilEnvironment Environment;
        // Stack of all the Value references
        Stack<string> ValueStack;
        // Stack of all the Operator
        Stack<string> OperatorStack;

        public ParserEvaluator(PsilEnvironment psilEnvironment)
        {
            Environment = psilEnvironment;
            ValueStack = new Stack<string>();
            OperatorStack = new Stack<string>();
        }

        public PsilResult Process(string input)
        {
            PsilResult psilResult;
            try
            {
                var processedValue = ProcessInput(input);
                psilResult = new PsilResult(processedValue, PsilResultType.Success);
            }
            catch (BaseException baseEx)
            {
                Common.Logger.Log(Logger.LogTypes.Exception, baseEx.ToString());
                psilResult = new PsilResult(PsilMessages.InvalidProgram, PsilResultType.Error);
            }
            return psilResult;
        }


        private string ProcessInput(string input)
        {
            // tempContainer for Data Retrieval
            double doubleTempContainer;

            // Collection for All the Operands in a Statement
            List<string> operands = new List<string>();
            List<string> tokens = input.Split(' ').ToList();

            foreach (var token in tokens)
            {
                // Identify all the numerics (integer,float ...)
                if (double.TryParse(token, out doubleTempContainer))
                {
                    // Push to Value Stack
                    ValueStack.Push(token);
                }
                else if (token.Equals(PsilSymbols.OpenParenthesis))
                {
                    // Push token to Operator Stuff
                    OperatorStack.Push(PsilSymbols.OpenParenthesis);

                    // Push a identifier to ValueStack to mark the Commencement of the Variables as there
                    // can be more then two operands in Psil
                    ValueStack.Push(PsilSymbols.ArgsStartDelimiter);
                }
                else if (token.Equals(PsilSymbols.CloseParenthesis))
                {
                    string currentOperatorSymbol = OperatorStack.Pop();

                    if (currentOperatorSymbol == PsilSymbols.OpenParenthesis)
                    {
                        // Not valid Operator Entry eg (45)
                        currentOperatorSymbol = PsilSymbols.OperatorLess;
                    }
                    else
                    {
                        // pop up the open parenthis in case of Operator present
                        OperatorStack.Pop();
                    }

                    // Clear the Operands
                    operands.Clear();
                    // Extract all the Operands
                    ExtractValueOperands(ref operands);
                    doubleTempContainer = EvaluateExpression(currentOperatorSymbol, operands);
                    ValueStack.Push(Convert.ToString(doubleTempContainer));
                }
                else if (PsilPrimitive.IsValidOperator(token))
                {
                    OperatorStack.Push(token);
                }
                else if (PsilPrimitive.IsValidVariableName(token))
                {
                    ValueStack.Push(token);
                }
                else
                {
                    throw new InvalidTokenException(string.Format("Invalid Token : {0}", token));
                }
            }
            return GetFinalResult();
        }

        /// <summary>
        /// Get the Final Result
        /// </summary>
        /// <returns></returns>
        private string GetFinalResult()
        {
            string eval = ValueStack.Pop();

            // Value & Operaor Stack should be Emtry in perfect scenarios
            if (OperatorStack.Count != 0)
            {
                throw new InvalidTokenException("Improper values in Operator and Operator Stack.");
            }
            return eval;
        }

        /// <summary>
        /// Extract Valid operands for the 
        /// </summary>
        private void ExtractValueOperands(ref List<string> operands)
        {
            // Get all the Operands
            while (ValueStack.Peek() != PsilSymbols.ArgsStartDelimiter)
            {
                operands.Add(ValueStack.Pop());
            }
            // Pop out the PsilSymbols.ArgsStartDelimiter
            ValueStack.Pop();
        }

        /// <summary>
        /// Evaluate a Expression given the Operator and List of operands
        /// </summary>
        /// <param name="operatorSymbol"></param>
        /// <param name="operands"></param>
        /// <returns></returns>
        private double EvaluateExpression(string operatorSymbol, List<string> operands)
        {
            if (operands == null || operands.Count <= 0)
            {
                throw new InvalidCommandException("Check the number of operands");
            }
            switch (operatorSymbol)
            {
                case PsilSymbols.Add:
                    return EvaluateAdd(operands);
                case PsilSymbols.Multiply:
                    return EvaluateMultiply(operands);
                case PsilSymbols.Bind:
                    return EvaluateBind(operands);
                case PsilSymbols.OperatorLess:
                    return EvaluateOperatorLess(operands);
                default:
                    throw new InvalidOperatorException(string.Format("Operator not Supported : {0}", operatorSymbol));
            }
        }

        /// <summary>
        /// Evaluate Bind statement
        /// </summary>
        /// <param name="operands"></param>
        /// <returns></returns>
        private double EvaluateBind(List<string> operands)
        {
            double result;
            // there should be just Two Operands for Bind Statements
            if (operands.Count != 2)
            {
                throw new InvalidBindStatementException("Number of Operands are more then Expected two! Check your Bind Statement");
            }
            string operand = operands[0];
            string bindVariableName = operands[1];

            if (!double.TryParse(operand, out result))
            {
                // If operand is not a number then Expectit to be allready binded variable
                result = Environment.Memory.GetBindedDataVariableValue(operand);
            }

            PsilVariable variable = new PsilVariable { Name = operands[1], Value = result };
            Environment.Memory.StoreData(variable);

            return result;
        }

        /// <summary>
        /// Evaluate Add operation
        /// </summary>
        /// <param name="operands"></param>
        /// <returns></returns>
        private double EvaluateAdd(List<String> operands)
        {
            double result = 0;
            double doubleTempContainer = 0;

            operands.ForEach(operand =>
            {
                if (double.TryParse(operand, out doubleTempContainer))
                {
                    result = Primitives.Add(result, doubleTempContainer);
                }
                else
                {
                    // Try to get from memory
                    result = Primitives.Add(result, Environment.Memory.GetBindedDataVariableValue(operand));
                }
            });

            return result;
        }

        /// <summary>
        /// Evaluate Multiply operation
        /// </summary>
        /// <param name="operands"></param>
        /// <returns></returns>
        private double EvaluateMultiply(List<String> operands)
        {
            double result = 1;
            double doubleTempContainer = 0;
            operands.ForEach(operand =>
            {
                if (double.TryParse(operand, out doubleTempContainer))
                {
                    result = Primitives.Multiply(result, doubleTempContainer);
                }
                else
                {
                    // Try to get from memory
                    result = Primitives.Multiply(result, Environment.Memory.GetBindedDataVariableValue(operand));
                }
            });

            return result;
        }


        /// <summary>
        /// Evaluate Add operation
        /// </summary>
        /// <param name="operands"></param>
        /// <returns></returns>
        private double EvaluateOperatorLess(List<String> operands)
        {
            double result = 0;
            double doubleTempContainer = 0;

            bool firstOperandVisited = false;

            operands.ForEach(operand =>
            {
                if (!double.TryParse(operand, out doubleTempContainer))
                {
                    // Try to get from memory
                    doubleTempContainer = Environment.Memory.GetBindedDataVariableValue(operand);
                }

                if (!firstOperandVisited)
                {
                    result = doubleTempContainer;
                    firstOperandVisited = true;
                }
            });
            return result;
        }
    }
}
