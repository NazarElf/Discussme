using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discussme.BLL.ServiceClasses;
using System.Data.Entity.Validation;
using Discussme.BLL.DbObjects;
using System.Threading;

namespace ProgramDebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ForumService fs = new ForumService();
            var t = fs.GetTopicsInSection(2);
            foreach (var item in t)
            {
                Console.WriteLine(item.Title);
            }
            Console.ReadLine();
        }
        
    }
}
