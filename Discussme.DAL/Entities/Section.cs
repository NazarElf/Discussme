using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discussme.DAL.Entities
{
    public class Section
    {
        //Uniq identificator of section
        public int Id { get; set; }
        //Name(or title) of section
        [Required]
        public string Title { get; set; }
        //Description of section (Header)
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        //Collection of topics that located in this section
        public virtual ICollection<Topic> Topics { get; set; }

        public Section()
        {
            Topics = new List<Topic>();
        }
    }
}
