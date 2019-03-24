// Added to Manage Memory of Psil

namespace Psil
{
    using Psil.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Mange the  Memory for Data(Variables) or Code(lambda) Storage
    /// </summary>
    public class PsilMemory
    {
        private Dictionary<string, PsilVariable> dataMemory;

        // Future for anonymous/lambda functions or closures
        private Dictionary<string, dynamic> codeMemory;

        public PsilMemory()
        {
            dataMemory = new Dictionary<string, PsilVariable>();
            codeMemory = new Dictionary<string, dynamic>();
        }

        public void StoreData(string key, dynamic value)
        {
            // TODO: Poll for the duplicate check in different Scope
            dataMemory[key] = new PsilVariable { Value = key, Name = value };
        }

        public void StoreData(PsilVariable variable)
        {
            // TODO: Poll for the duplicate check in different Scope
            dataMemory[variable.Name] = variable;
        }
        public PsilVariable GetData(string key)
        {
            return dataMemory[key];
        }

        public List<string> GetAllDataVariableNames()
        {
            return dataMemory.Keys.ToList();
        }

        public bool DataExist(string key)
        {
            return GetAllDataVariableNames().Any(item => item.Equals(key));
        }

        /// <summary>
        /// Try Get the DataValue.Return True and Data in out variable if found sucessfuly
        /// </summary>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool TryGetData(string key, out PsilVariable result)
        {
            if (DataExist(key))
            {
                result = dataMemory[key];
                return true;
            }
            result = null;
            return false;
        }


        /// <summary>
        /// Get the Binded Data variable
        /// </summary>
        /// <param name="variableName"></param>
        /// <returns></returns>
        public PsilVariable GetBindedDataVariable(string variableName)
        {
            PsilVariable variable;
            // It might be a variable
            // Environment.Memory.
            if (!TryGetData(variableName, out variable))
            {
                throw new UnBindedVariableException(String.Format("Unbinded variable used {0}", variableName));
            }
            return variable;
        }


        /// <summary>
        /// Get the Binded Data variable Value
        /// </summary>
        /// <param name="variableName"></param>
        /// <returns></returns>
        public double GetBindedDataVariableValue(string variableName)
        {
            double result;
            var variable = GetBindedDataVariable(variableName);
            if (!double.TryParse(Convert.ToString(variable.Value), out result))
            {
                throw new InvalidDataVariableException(string.Format("Variable Name : {0}, Value : {1}", variableName, Convert.ToString(variable.Value)));
            }
            return result;
        }
    }
}