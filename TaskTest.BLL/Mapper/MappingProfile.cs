using System.Linq;
using AutoMapper;
using TaskTest.BLL.DTO.Test;
using TaskTest.DAL.Entities;

namespace TaskTest.BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Test, TestResponse>();
            CreateMap<TestResponse, Test>();

            CreateMap<Test, TestResponseMany>();
            CreateMap<TestResponseMany, Test>();

        }
    }
}