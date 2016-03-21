using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXTFileImportToSQL
{
    public class DataParser
    {

        //Option 1 - reading CNAB with Lambda
        public static void ParseLambdaCNAB()
        {
            string dados = string.Join("", DataReader.GetDataCNAB()
                .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(item => new {codigo = item.Substring(0,7).Trim(), descricao=item.Substring(7)})
                .Select(item => string.Format("SELECT '{0}', '{1}' UNION ALL\r\n", item.codigo, item.descricao)));

            Console.WriteLine(dados);

        }

        //Option 2 - reading CNAB with foreach
        public static void Parse()
        {
            var dados = DataReader.GetDataCNAB();
            StringBuilder sqlScriptBuilder = new StringBuilder();

            var rows = dados.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (rows.Length > 0)
            {
                foreach (var item in rows)
                {
                    var codigo = item.Substring(0, 7).Trim();
                    var descricao = item.Substring(7).Trim();

                    sqlScriptBuilder.AppendLine(string.Format("SELECT '{0}', '{1}' UNION ALL", codigo, descricao));
                }
                var sqlScript = sqlScriptBuilder.ToString();
            }
            Console.WriteLine(sqlScriptBuilder);
        }

        //Option 1 - reading CSV with Lambda
        public static void ParseLambdaCSV()
        {
            string dados = string.Join("", DataReader.GetDataCSV()
                .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Split(new[] { ',' }))
                .Select(item => new { codigo = item[0], descricao = item[1] })
                .Select(item => string.Format("SELECT '{0}', '{1}' UNION ALL\r\n", item.codigo, item.descricao)));
            Console.WriteLine(dados);
        }
    }
}

// sample 1
/*
List<User> ReadCSV(string filename)
{
  return File.ReadLines(filename)
    .Skip(1)
    .Where(s => s != "")
    .Select(s => s.Split(new[] { ',' }))
    .Select(a => new User
    {
      RecordId = a[0],
      Email = a[1],
      FirstName = a[2],
      LastName = a[3],
      IsMember = a[4],
      IsFullSubscriber = a[5],
      MailingList = a[6],
      Activated = a[7],
      Source = a[8],
      CreatedAt = a[9]
    })
    .ToList();
}
*/
// sample 2
/*
string delimiter = ",;";
List<string> logs = (File.ReadAllLines(@"C:\Data.txt")
    // leave blank lines
    .Where(line => !string.IsNullOrEmpty(line))
    // split line seperated by delimiter
    .Select(line => line.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
    // compare the third column to find all records from CityA
    .Where(values => values[2].Equals("CityA", StringComparison.CurrentCultureIgnoreCase))
    // compare the second column to find all records with age more than or equal to 30
    .Where(values => int.Parse(values[1]) >= 30)
    // join back the splitted values by underscore
    .Select(values => string.Join("_", values))
    // find all unique values
    .Distinct()
    .ToList<string>());// convert to list
*/