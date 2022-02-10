using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTest.DAL.Entities
{
    public class UserTest
    {
        public UserTest()
        {
            
        }
        public UserTest( User user, Test test)
        {
            UserTestId = Guid.NewGuid();
            User = user;
            Test = test;
        }
        [Key]
        public Guid UserTestId { get; set; }
        [ForeignKey("UsersId")]
        public User User { get; set; }
        [ForeignKey("TestsId")]
        public Test Test { get; set; }
        public virtual ICollection<Result> Results { get; set; } = new List<Result>();
    }
}