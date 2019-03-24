using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsilWebview.PSilRepository
{
    /// <summary>
    /// Execute the PSIL via some ENgine
    /// </summary>
    public static class PSilEngine
    {
        public static string Execute(string commands)
        {
            Psil.PsilEnvironment environment = new Psil.PsilEnvironment(commands);
            Psil.PsilResult result = environment.Eval();
            return result.Value;
        }
    }
}