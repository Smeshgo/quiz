using System;
using System.Text.Json.Serialization;
using TaskTest.DAL.Entities;

namespace TaskTest.BLL.DTO.Answer
{
    public class AnswerResponse
    {
        public Guid AnswerId { get; set; }
        public string Answers { get; set; }
        public bool Correct { get; set; }
        
    }
}