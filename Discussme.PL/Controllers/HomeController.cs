using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Discussme.PL.Models;
using System.Threading.Tasks;
using Discussme.BLL.ServiceClasses;
using Discussme.BLL.ServiceInterfaces;
using Microsoft.AspNet.Identity.Owin;

namespace Discussme.PL.Controllers
{
    public class HomeController : Controller
    {
        private IForumService ForumService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IForumService>();
            }
        }

        public ActionResult Index()
        {
            var listOfSections = ForumService.GetAllSections();
            List<SectionsModel> list = new List<SectionsModel>();
            foreach (var item in listOfSections)
            {
                list.Add(new SectionsModel { SectionName = item.Title, SectionDescription = item.Description, Id = item.Id });
            }
            return View(list);
        }

        public ActionResult Details(SectionsModel model)
        { 
            //
            var listOfTopicsInSection = ForumService.GetTopicsInSection(model.Id);
            List<TopicModel> list = new List<TopicModel>();
            foreach (var item in listOfTopicsInSection)
            {
                list.Add(new TopicModel { CreationTime = item.CreationTime, Description = item.Description, Title = item.Title });
            }
            return View(list);
        }
    }
}