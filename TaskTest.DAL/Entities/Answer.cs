using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskTest.DAL.Entities
{
    public class Answer
    {
        
        [Key]
        public Guid AnswerId { get; set; }
        public string Answers { get; set; }
        public bool Correct { get; set; }
        [JsonIgnore]
        public Question Question { get; set; }
    }
}