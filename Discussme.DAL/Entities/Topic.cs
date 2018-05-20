using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discussme.DAL.Entities
{
    public class Topic
    {
        //Uniq dentificator of Topic
        public int Id { get; set; }
        //Title (or name) of topic
        [Required]
        public string Title { get; set; }
        //Body of topic (have all text)
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        //Time of creation of topic (will be sorted by this field)
        public DateTime CreationTime { get; set; }
        
        //List of comment to topic
        public ICollection<Comment> Comments { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public int SectionId { get; set; }
        public virtual Section Section { get; set; }

        public Topic()
        {
            Comments = new List<Comment>();
        }
    }
}
