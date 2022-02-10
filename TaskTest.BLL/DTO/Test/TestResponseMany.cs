using System;
using System.Collections.Generic;
using TaskTest.DAL.Entities;

namespace TaskTest.BLL.DTO.Test
{
    public class TestResponseMany
    {
        public Guid TestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<QuestionResponseMany> Questions { get; set; } = new List<QuestionResponseMany>(){};
    }
}