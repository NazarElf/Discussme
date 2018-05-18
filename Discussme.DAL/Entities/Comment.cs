using System;

namespace Discussme.DAL.Entities
{
    public class Comment
    {
        //Uniq identificator
        public int Id { get; set; }
        //Body of comment
        public string Description { get; set; }
        //DateTime of comment, list of comments will be 
        //sorted by this field
        public DateTime CreationTime { get; set; }
        
        //Id of Creator of comment and ref for creator
        public int CreatorId { get; set; }
        public User Creator { get; set; }

        //Id of Topic where comment was left and ref for this topic
        public int TopicId { get; set; }
        public Topic ParrentTopic { get; set; }
    }
}
