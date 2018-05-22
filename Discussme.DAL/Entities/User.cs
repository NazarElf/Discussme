using System;
using System.Collections.Generic;
using Discussme.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Discussme.DAL.Entities
{
    public class User
    {
        //Uniq identificator of user
        [Key]
        [ForeignKey("IdentityForumUser")]
        public string Id { get; set; }

        //User's nickname
        //[Required]
        //public string Nickname { get; set; }

        //Don't need this anymore, because Identity already have it
        //[Required]
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }

        //User's password
        //[Required]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        //User's Firstname. Can be private or null
        public string Firstname { get; set; }

        //User's Lastname. Can be private or null
        public string Lastname { get; set; }

        //User's Date of birth. Can be private or null
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        //User's info aka quote, or some description for user's choice
        public string Info { get; set; }

        //Field that can to not allow user to some actions
        [Required]
        public bool IsBanned { get; set; }

        //User's role
        //public MyRoles UserRole { get; set; }

        //User's Privacy
        public Privacy UserPrivacy { get; set; }

        //User's Registration date (don't even know, where am i need it)
        [Required]
        public DateTime RegistrationTime { get; set; }

        //Time when user was last seen (will uses to identify online of user)
        [Required]
        public DateTime LastSeenTime { get; set; }

        public virtual IdentityForumUser IdentityForumUser { get; set; }
        
        public virtual ICollection<Topic> Topics { get; set; }
        
        public virtual ICollection<Comment> Comments { get; set; }

        public User()
        {
            Topics = new List<Topic>();
            Comments = new List<Comment>();
        }
    }
}
