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
    public enum VariableScope
    {
        Global,
        Local
    }

    public class Variable
    {
        public VariableScope Scope;

        public string Name;
        /// <summary>
        /// It can support any type as it's dynamic
        /// </summary>
        public dynamic Value;

        public override bool Equals(Object obj)
        {
            if (obj == null || !(obj is Variable))
                return false;
            else
            {
                return Equals(obj);
            }
        }

        public bool Equals(Variable obj)
        {
            return ((Variable)obj).Value.Equals(Value);
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

    public class PsilVariable : Variable
    {
        public PsilVariable()
        {
            // Variable have Global Scope bydefault
            Scope = VariableScope.Global;
        }
    }
}
