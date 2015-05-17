using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psil.Exceptions;
using System.Text.RegularExpressions;
using Psil.Common;
namespace Psil
{
    /// <summary>
    /// Responsible to manage instance of PsilEnvironment Execution
    /// </summary>
    public class PsilEnvironment
    {
        private string RawInputCommand { get; set; }
        public string PsilInput { get; private set; }

        public PsilMemory Memory;
        public PsilEnvironment(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Trim().Length <= 0)
            {
                throw new InvalidCommandException(String.Format("Null or Empty: {0}", input));
            }
            RawInputCommand = input;
            PsilInput = FormatInputForPsilCommands(input);
            Memory = new PsilMemory();
        }

        public PsilResult Eval()
        {
            var result = (new Psil.Parsing.ParserEvaluator(this)).Process(PsilInput);
            return result;
        }
        /// <summary>
        /// Cleaning Up the Input for Processing
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string FormatInputForPsilCommands(string text)
        {
            // Cases Insensitive
            text = text.Trim().ToLower();

            if (text.ElementAt(0).ToString() != PsilSymbols.OpenParenthesis)
            {
                text = string.Format("{0}{1}{2}", PsilSymbols.OpenParenthesis, text, PsilSymbols.CloseParenthesis);
            }
            //clear extra spaces
            string cleanedString = Regex.Replace(text, "[a-zA-Z]+|[0-9]+|[()]", "$0 ").Trim();


            // Multiple spaces to one space spaces for token
            cleanedString = Regex.Replace(cleanedString, @"\s+", " ");


            return cleanedString;
        }
    }


}
