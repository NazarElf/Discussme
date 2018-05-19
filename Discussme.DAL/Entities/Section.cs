using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public  ICollection<Topic> Topics { get; set; }

        public Section()
        {
            Topics = new List<Topic>();
        }
    }
}
