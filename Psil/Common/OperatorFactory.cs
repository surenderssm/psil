using Psil.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psil.Common
{
    /// <summary>
    /// Operator
    /// </summary>
    public abstract class Operator
    {
        protected string label;
        public abstract string Label { get; }
        public abstract string Symbol { get; }

        public override string ToString()
        {
            return Symbol;
        }
    }

    /// <summary>
    /// Add Operator
    /// </summary>
    public class AddOperator : Operator
    {
        public override string Symbol
        {
            get { return PsilSymbols.Add; }
        }

        public override string Label
        {
            get { return label; }
        }

        public AddOperator()
        {
            label = Primitives.GetOperatorName(PsilSymbols.Add);
        }
    }

    /// <summary>
    /// Multiply Operator
    /// </summary>
    public class MultiplyOperator : Operator
    {
        public override string Symbol
        {
            get { return PsilSymbols.Multiply; }
        }

        public override string Label
        {
            get { return label; }
        }

        public MultiplyOperator()
        {
            label = Primitives.GetOperatorName(PsilSymbols.Multiply);
        }
    }

    /// <summary>
    /// Multiply Operator
    /// </summary>
    public class BindOperator : Operator
    {
        public override string Symbol
        {
            get { return PsilSymbols.Bind; }
        }

        public override string Label
        {
            get { return label; }
        }

        public BindOperator()
        {
            label = Primitives.GetOperatorName(PsilSymbols.Bind);
        }
    }

    /// <summary>
    /// OpenParenthesis Operator
    /// </summary>
    public class OpenParenthesisOperator : Operator
    {
        public override string Symbol
        {
            get { return PsilSymbols.OpenParenthesis; }
        }

        public override string Label
        {
            get { return label; }
        }

        public OpenParenthesisOperator()
        {
            label = Primitives.GetOperatorName(PsilSymbols.OpenParenthesis);
        }
    }
    /// <summary>
    /// OpenParenthesis Operator
    /// </summary>
    public class CloseParenthesisOperator : Operator
    {
        public override string Symbol
        {
            get { return PsilSymbols.CloseParenthesis; }
        }

        public override string Label
        {
            get { return label; }
        }

        public CloseParenthesisOperator()
        {
            label = Primitives.GetOperatorName(PsilSymbols.CloseParenthesis);
        }
    }

    /// <summary>
    /// Factory to Return Operators
    /// </summary>
    public static class OperatorFactory
    {
        /// <summary>
        /// Get the Operator
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static Operator Get(string symbol)
        {
            switch (symbol)
            {
                case PsilSymbols.Add:
                    return new AddOperator();
                case PsilSymbols.Multiply:
                    return new MultiplyOperator();
                case PsilSymbols.OpenParenthesis:
                    return new OpenParenthesisOperator();
                case PsilSymbols.CloseParenthesis:
                    return new CloseParenthesisOperator();
                case PsilSymbols.Bind:
                    return new BindOperator();
                default:
                    throw new InvalidOperatorException(symbol);
            }
        }
    }
}
