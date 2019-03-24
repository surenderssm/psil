using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psil
{
    /// <summary>
    /// Defince the scope of Variable
    /// </summary>
    public enum PsilResultType
    {
        Success,
        Error,
        Warning
    }

    public class PsilResult
    {
        /// <summary>
        /// Container for the Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Container for all the messages
        /// </summary>
        public List<string> Messages;

        /// <summary>
        /// Type 
        /// </summary>
        public PsilResultType Type { get; set; }

        // Avoid creation of the object withour value and type
        public PsilResult(string value, PsilResultType type)
        {
            Value = value;
            Type = type;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || !(obj is PsilResult))
                return false;
            else
            {
                return Equals(obj);
            }
        }

        public bool Equals(PsilResult obj)
        {
            return ((PsilResult)obj).Value.Equals(Value);
        }

        public override string ToString()
        {
            try
            {
                return Value.ToString();
            }
            catch (Exception ex)
            {
                return String.Format("ToString can not be Called.{0}", ex.ToString());
            }
        }
    }
    public static class PsilMessages
    {
        public const string InvalidProgram = "Invalid program";
        public const string Sucess = "Sucess";
    }
}
