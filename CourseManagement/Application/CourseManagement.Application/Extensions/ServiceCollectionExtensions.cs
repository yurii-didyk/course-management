using AutoMapper;
using CourseManagement.Application.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CourseManagement.Application.Extensions
{
    public static class ServiceCollectionExtensions
    { 
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<CourseProfile>();
            });
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

    }
}
