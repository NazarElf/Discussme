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
                fdsc.AddSection(3, null, null);
                var sections = fdsc.GetSections();
                foreach (var item in sections)
                {
                    Console.WriteLine("--------Sections-------");
                    Console.WriteLine($"{item.Id}: \"{item.Title}\" \n{item.Description}");
                }
            }
            Console.ReadLine();
        }
    }
}
