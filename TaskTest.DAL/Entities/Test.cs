using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTest.DAL.Entities
{
    public class Test
    {
        [Key]
        public Guid TestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
        public virtual ICollection<UserTest> UserTestS { get; set; } = new List<UserTest>();
    }
}