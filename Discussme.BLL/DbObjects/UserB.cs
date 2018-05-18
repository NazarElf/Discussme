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
    class UserB
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nickname { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Lastname { get; set; }
        [DataMember]
        public DateTime? DateOfBirth { get; set; }
        [DataMember]
        public string Info { get; set; }
        [DataMember]
        public bool IsBanned { get; set; }
        [DataMember]
        public string UserRole { get; set; } // Enum? "User" or "Admin"
        [DataMember]
        public string UserPrivacy { get; set; } // Enum? "Public", "Protected", "Private"
        [DataMember]
        public DateTime RegistrationTime { get; set; }
        [DataMember]
        public DateTime LastSeenTime { get; set; }
    }
}
