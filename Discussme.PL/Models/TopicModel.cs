using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Discussme.PL.Models
{
    public class TopicModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public string AuthorName { get; set; }
    }
}