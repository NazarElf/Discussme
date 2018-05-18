using System;
using System.Collections.Generic;
using Discussme.DAL.Enums;

namespace Discussme.DAL.Entities
{
    public class User
    {
        //Uniq identificator of user
        public int Id { get; set; }
        //User's nickname
        public string Nickname { get; set; }
        //User's Email that connected with concreate user
        public string Email { get; set; }
        //User's password
        public string Password { get; set; }
        //User's Firstname. Can be private or null
        public string Firstname { get; set; }
        //User's Lastname. Can be private or null
        public string Lastname { get; set; }
        //User's Date of birth. Can be private or null
        public DateTime? DateOfBirth { get; set; }
        //User's info aka quote, or some description for user's choice
        public string Info { get; set; }
        //Field that can to not allow user to some actions
        public bool IsBanned { get; set; }
        //User's role
        public Role UserRole { get; set; }
        //User's Privacy
        public Privacy UserPrivacy { get; set; }
        //User's Registration date (don't even know, where am i need it)
        public DateTime RegistrationTime { get; set; }
        //Time when user was last seen (will uses to identify online of user)
        public DateTime LastSeenTime { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
