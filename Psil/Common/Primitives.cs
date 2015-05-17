
namespace Psil.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    // CLass for Primitive Operations required in a Lanuage
    public static class Primitives
    {
        public static dynamic Add(dynamic a, dynamic b) { return a + b; }
        public static dynamic Subtract(dynamic a, dynamic b) { return a - b; }
        public static dynamic Multiply(dynamic a, dynamic b) { return a * b; }
        public static dynamic Divide(dynamic a, dynamic b) { return a / b; }
        public static dynamic Modulo(dynamic a, dynamic b) { return a % b; }
        public static dynamic Negative(dynamic a) { return -a; }
        public static dynamic ShiftLeft(dynamic a, dynamic b) { return a << b; }
        public static dynamic ShiftRight(dynamic a, dynamic b) { return a >> b; }
        public static dynamic Gt(dynamic a, dynamic b) { return a > b; }
        public static dynamic Lt(dynamic a, dynamic b) { return a < b; }
        public static dynamic GtEq(dynamic a, dynamic b) { return a >= b; }
        public static dynamic LtEQ(dynamic a, dynamic b) { return a <= b; }
        public static dynamic Eq(dynamic a, dynamic b) { return a.Equals(b); }
        public static dynamic Hash(dynamic a) { return a.GetHashCode(); }
        public static dynamic NEq(dynamic a, dynamic b) { return a != b; }
        public static dynamic Not(dynamic a) { return !a; }
        public static dynamic Or(dynamic a, dynamic b) { return a || b; }
        public static dynamic And(dynamic a, dynamic b) { return a && b; }
        public static dynamic Xor(dynamic a, dynamic b) { return a ^ b; }
        public static dynamic BitOr(dynamic a, dynamic b) { return a | b; }
        public static dynamic BitAnd(dynamic a, dynamic b) { return a & b; }
        public static dynamic Complement(dynamic a) { return ~a; }

        public static dynamic Succ(dynamic a) { return a + 1; }
        public static dynamic Pred(dynamic a) { return a - 1; }

        public static dynamic GetType(dynamic a) { return a.GetType(); }
        public static dynamic ToString(dynamic a) { return a.ToString(); }

        public static MethodInfo GetMethod(string s)
        {
            return typeof(Primitives).GetMethod(s);
        }
        
        /// <summary>
        /// Get the Operator label from Symbol
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetOperatorName(string s)
        {
            switch (s)
            {
                case "+": return "add";
                case "-": return "subtract";
                case "*": return "multiply";
                case "/": return "divide";
                case "bind": return "bind";
                case "(": return "openParenthesis";
                case ")": return "closeParenthesis";
                case "%": return "modulo";
                case ">>": return "shl";
                case "<<": return "shr";
                case ">": return "gt";
                case "<": return "lt";
                case ">=": return "gteq";
                case "<=": return "lteq";
                case "==": return "eq";
                case "!=": return "neq";
                case "||": return "or";
                case "&&": return "and";
                case "^": return "xor";
                case "|": return "bitOr";
                case "&": return "bitNand";
                default: throw new Exception("Not a recognized operator");
            }
        }

    }
}
