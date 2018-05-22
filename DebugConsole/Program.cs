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

            Thread t = new Thread(SetInitData);
            t.Start();
            t.Join();



            Console.WriteLine("Connection ended, it seems that everything ok");
            Console.ReadLine();
        }
        static void SetInitData()
        {
            ForumService fs = new ForumService();
            fs.SetInitData(new UserB
            {
                Email = "nnn43@ukr.net",
                Nickname = "Rover_Go",
                Password = "Somebody4_4Someone",
                Firstname = "Nazar",
                Lastname = "Yurchenko",
                UserRole = "admin",
                UserPrivacy = "public",
                LastSeenTime = DateTime.Now,
                RegistrationTime = DateTime.Now,
            }, new List<string>
            {
                "admin", "user"
            }
            );
        }
    }
}
