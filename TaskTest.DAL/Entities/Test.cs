using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskTest.DAL.Entities
{
    public class Test
    {
        [Key]
        public Guid TestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
        [JsonIgnore]
        public virtual ICollection<User> User { get; set; } = new List<User>();
    }
}