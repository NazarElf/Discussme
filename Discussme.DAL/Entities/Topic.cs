﻿using System;

namespace Discussme.DAL.Entities
{
    public class Topic
    {
        //Uniq dentificator of Topic
        public int Id { get; set; }
        //Title (or name) of topic
        public string Title { get; set; }
        //Body of topic (have all text)
        public string Description { get; set; }
        //Time of creation of topic (will be sorted by this field)
        public DateTime CreationTime { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public int SectionId { get; set; }
        public Section ParentSection { get; set; }
    }
}
