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
                fdsc.AddSection(0, "My First Section", "This is first section");
            }
        }
    }
}
