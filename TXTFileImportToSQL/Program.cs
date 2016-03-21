using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXTFileImportToSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataParser.ParseLambdaCNAB();

            DataParser.Parse();
            Console.WriteLine();
            DataParser.ParseLambdaCNAB();
            Console.WriteLine();
            DataParser.ParseLambdaCSV();
            Console.ReadKey();
            //create a breakpoint, grab sqlScript and run sql like....
            // INSERT INTO [dbo].[TXT_Import]
            // SELECT '00001', 'AAA' UNION ALL
            // SELECT '00002', 'BBB' UNION ALL
            // By - Alexandre Miranda
        }
    }
}
