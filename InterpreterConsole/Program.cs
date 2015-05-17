using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psil;
namespace InterpreterConsole
{
    class Program
    {
        static void Main(string[] args)
        {

        //   List<string> commands = new List<string>({( bind x 42 )"
        
        //});

            PsilUnitTest.Scenarios scenario = new PsilUnitTest.Scenarios();

            scenario.SimpleAdd();


            string input = "( + 2 3 5 )";

            input = "( bind x 42 ) ( + x 10 )";

            input = "( bind foo ( + 1 2 3 ) )";

            input = "( bind length 10 ) ( bind breadth 10 ) ( + length breadth )";
            PsilEnvironment myPsil = new PsilEnvironment(input);
            var res = myPsil.Eval();
          //  rule.Parse(input);

            input = "( + 1 15 ( * 2 3 ) ( * 4 2 ) )";
        //    rule.Parse(input);

           
            input = "( + 2 3 5 10 )";
        //    rule.Parse(input);


            input = "( + 2 3 5 10 ( + 1 1 ) )";
           // rule.Parse(input);


            input = "( + 2 3 5 )";
           // rule.Parse(input);
        }
    }
}
