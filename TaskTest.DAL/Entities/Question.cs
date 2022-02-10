using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskTest.DAL.Entities
{
    public class Question
    {
        [Key]
        public Guid QuestionId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public Test Tests { get; set; }
        public virtual ICollection<Answer> Answers { get; } = new List<Answer>();
    }
}