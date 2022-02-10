using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TaskTest.DAL.Entities;

namespace TaskTest.BLL.DTO
{
    public class QuestionResponseMany
    {
        public Guid QuestionId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<AnswerResponse> Answers { get; } = new List<AnswerResponse>();
    }
}