using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discussme.BLL.ServiceClasses;
using System.Data.Entity.Validation;

namespace ProgramDebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            ForumService fs = new ForumService();
            var sections = fs.GetAllSections();
            foreach (var item in sections)
            {
                Console.WriteLine(item.Id);
            }



            var res = fs.GetTopicsInSection(2);

            foreach (var item in res)
            {
                Console.WriteLine(item.Title);
            }


            Console.WriteLine("Connection ended, it seems that everything ok");
            Console.ReadLine();
        }
    }
}
