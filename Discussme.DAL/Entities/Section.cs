using System.Collections.Generic;

namespace Discussme.DAL.Entities
{
    public class Section
    {
        //Uniq identificator of section
        public int Id { get; set; }
        //Name(or title) of section
        public string Title { get; set; }
        //Description of section (Header)
        public string Description { get; set; }

        //Collection of topics that located in this section
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
