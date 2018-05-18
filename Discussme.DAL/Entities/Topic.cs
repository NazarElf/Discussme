using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussme.DAL.Entities
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public int SectionId { get; set; }
        public Section ParentSection { get; set; }
    }
}
