using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Discussme.BLL.DbObjects
{
    // B means Business logic's object
    [DataContract]
    class CommentB
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime CreationTime { get; set; }
        [DataMember]
        public int CreatorId { get; set; } //Can be wrong
        [DataMember]
        public int TopicId { get; set; } // Can be wrong
    }
}
