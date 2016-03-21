using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtAspNet = new DataTable("AspNet");
            dtAspNet.Columns.Add("AlunoID", typeof(int));
            dtAspNet.Columns.Add("AlunoNome", typeof(string));
            dtAspNet.Rows.Add(1, "Mike");
            dtAspNet.Rows.Add(2, "Vitor");
            dtAspNet.Rows.Add(3, "Maria");
            dtAspNet.Rows.Add(4, "Pedro");
            dtAspNet.Rows.Add(5, "Cesar");

            DataTable dtJava = new DataTable("Java");
            dtJava.Columns.Add("AlunoID", typeof(int));
            dtJava.Columns.Add("AlunoNome", typeof(string));
            dtJava.Rows.Add(6, "Alex");
            dtJava.Rows.Add(2, "Vitor");
            dtJava.Rows.Add(7, "John");
            dtJava.Rows.Add(4, "Pedro");
            dtJava.Rows.Add(8, "Paulo");

            DataTable dtOnlyAspNet = dtAspNet.AsEnumerable().Except(dtJava.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
            Console.WriteLine("Estudantes matriculados somente no curso AspNet");
            foreach (DataRow dr in dtOnlyAspNet.Rows)
            {
                Console.WriteLine(string.Format("AlunoID: {0}, AlunoNome: {1}", dr[0].ToString(), dr[1].ToString()));
            }
            Console.WriteLine("");
            Console.WriteLine("Estudantes matriculados somente no curso Java");
            DataTable dtOnlyJava = dtJava.AsEnumerable().Except(dtAspNet.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
            foreach (DataRow dr in dtOnlyJava.Rows)
            {
                Console.WriteLine(string.Format("AlunoID: {0}, AlunoNome: {1}", dr[0].ToString(), dr[1].ToString()));
            }

            Console.WriteLine("");
            Console.WriteLine("Estudantes matriculados em ambos");
            DataTable dtAmbos = dtAspNet.AsEnumerable().Intersect(dtJava.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
            foreach (DataRow dr in dtAmbos.Rows)
            {
                Console.WriteLine(string.Format("AlunoID: {0}, AlunoNome: {1}", dr[0].ToString(), dr[1].ToString()));
            }

            Console.WriteLine("");
            Console.WriteLine("Lista de todos os alunos");
            DataTable dtAll = dtAspNet.AsEnumerable().Union(dtJava.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
            foreach (DataRow dr in dtAll.Rows)
            {
                Console.WriteLine(string.Format("StudentID: {0}, StudentName: {1}", dr[0].ToString(), dr[1].ToString()));
            }

            Console.ReadKey();
        }
    }
}
