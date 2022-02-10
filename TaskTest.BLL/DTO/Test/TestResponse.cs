using System;
using System.Collections.Generic;
using TaskTest.DAL.Entities;

namespace TaskTest.BLL.DTO.Test
{
    public class TestResponse
    {
        public Guid TestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}