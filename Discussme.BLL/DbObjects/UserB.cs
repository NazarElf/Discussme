using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Discussme.BLL.DbObjects
{
    // B means Business logic's object
    public class UserB
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Info { get; set; }
        public bool IsBanned { get; set; }
        public string UserRole { get; set; } // Enum? "User" or "Admin"
        public string UserPrivacy { get; set; } // Enum? "Public", "Protected", "Private"
        public DateTime RegistrationTime { get; set; }
        public DateTime LastSeenTime { get; set; }
    }
}
