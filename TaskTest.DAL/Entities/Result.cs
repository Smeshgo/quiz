using System;
using System.ComponentModel.DataAnnotations;

namespace TaskTest.DAL.Entities
{
    public class Result
    {
        [Key]
        public Guid ResultId { get; set; }

        public decimal Score { get; set; }
        public UserTest UserTest { get; set; }
    }
}