using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BLL_Service.ForumServiceClient fdsc = new BLL_Service.ForumServiceClient())
            {
                var res = fdsc.GetTopicsInSection(2);

                foreach (var item in res)
                {
                    Console.WriteLine(item.Title);
                }
            }
            Console.WriteLine("Connection ended, it seems that everything ok");
            Console.ReadLine();
        }
    }
}
