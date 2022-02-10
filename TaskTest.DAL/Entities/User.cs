using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TaskTest.DAL.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<UserTest> UserTests { get; set; } = new List<UserTest>();
    }
}