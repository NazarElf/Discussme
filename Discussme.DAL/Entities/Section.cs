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

        // ForeignKey used to create foreign key column "SectionId"
        // in Topics table in the database
        [ForeignKey("SectionId")]
        //Collection of topics that located in this section
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
