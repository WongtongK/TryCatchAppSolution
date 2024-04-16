using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchApp.DataAccess
{
    public class CSVfile
    {
        public CSVfile()
        {
       
        }
        public string[] Get()
        {
            string filepath = "c:\\csv\\TopratedRelations.csv";
            return File.ReadAllLines(filepath);
        }
    }
}
