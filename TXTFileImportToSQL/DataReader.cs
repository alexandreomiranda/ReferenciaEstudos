using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXTFileImportToSQL
{
    public class DataReader
    {
        public static string GetDataCNAB()
        {
            return @"
00001  AAA
00002  BBB
00003  CCC
00004  DDD
00005  EEE
00006  FFF
00007  GGG
00008  HHH
";
        }
        public static string GetDataCSV()
        {
            return @"
00001,KKK
00002,LLL
00003,MMM
00004,NNN
00005,OOO
00006,PPP
00007,QQQ
00008,RRR
";
        }
    }
}
