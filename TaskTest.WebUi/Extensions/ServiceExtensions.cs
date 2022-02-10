using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using TaskTest.BLL.Service;
using TaskTest.DAL.Repository;
using TaskTest.DAL.Repository.Impl;

namespace TaskTest.WebUi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IUnitOfWork, UnitOfWorkImpl>();
        public static void ConfigureTestService(this IServiceCollection service) =>
            service.AddScoped<ITestService, TestServiceImpl>();
    }
}
