using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discussme.DAL.Enums;

namespace Discussme.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Info { get; set; }
        public bool IsBanned { get; set; }
        public Role UserRole { get; set; }
        public Privacy UserPrivacy { get; set; }
        public DateTime RegistrationTime { get; set; }
        public DateTime LastSeenTime { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
