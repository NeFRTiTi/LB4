using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INIDLL;

namespace Lab4_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            INIManager manager = new INIManager("C:\\my.ini");

            string name = manager.GetPrivateString("main", "name");

            Console.WriteLine(name);

            manager.WritePrivateString("Василий", "возраст", "21");

        }
    }
}
