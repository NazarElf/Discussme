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
                fdsc.GetTopicsInSection(2);

            }
            Console.WriteLine("Connection ended, it seems that everything ok");
            Console.ReadLine();
        }
    }
}
