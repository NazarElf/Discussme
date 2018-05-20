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
            using (BLL_Service.ForumDataServiceClient fdsc = new BLL_Service.ForumDataServiceClient())
            {
                Console.WriteLine("In 1st section:");
                var _1top = fdsc.GetTopicsInSection(1);
                foreach (var item in _1top)
                {
                    Console.WriteLine(item.Title);
                }
                Console.WriteLine("All Topics:");
                var _all = fdsc.GetAllTopics();
                foreach (var item in _all)
                {
                    Console.WriteLine($"{item.Title} from section {item.SectionId}");
                }
            }
            Console.WriteLine("Connection ended, it seems that everything ok");
            Console.ReadLine();
        }
    }
}
