using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Psil.Common
{
    public static class PsilPrimitive
    {
        /// <summary>
        /// Container for all the supported operators
        /// </summary>
        public static List<Operator> SupportedOperators;

        /// <summary>
        /// Static constructor initializes  field.
        /// </summary>
        static PsilPrimitive()
        {
            SupportedOperators = new List<Operator>();
            SupportedOperators.Add(OperatorFactory.Get(PsilSymbols.Add));
            SupportedOperators.Add(OperatorFactory.Get(PsilSymbols.Multiply));
            SupportedOperators.Add(OperatorFactory.Get(PsilSymbols.Bind));
        }

        /// <summary>
        /// CHeck for Valid Psil Operator
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static bool IsValidOperator(string symbol)
        {
            return SupportedOperators.Any(item => item.Symbol.Equals(symbol));
        }

        /// <summary>
        /// CHeck for Valid Mathematical Operator
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static bool IsValidMathematicalOperator(string symbol)
        {
            if (symbol.Equals(PsilSymbols.Add) || symbol.Equals(PsilSymbols.Multiply))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get the Operator
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static Operator GetOperator(string symbol)
        {
            return SupportedOperators.Find(item => item.Symbol.Equals(symbol));
        }

        /// <summary>
        /// CHeck for Valid Psil VariableName
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static bool IsValidVariableName(string symbol)
        {
            // Variable should just have Characters
            string invalidPattern = "[^A-Za-z]";

            if (Regex.IsMatch(symbol, invalidPattern))
            {
                return false;
            }
            return true;
        }

    }
}
