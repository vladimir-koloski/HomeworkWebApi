using CollegeApp.DataAccess;
using CollegeApp.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApp.Services.Helpers
{
    public class DiModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CollegeDbContext>(x =>
            x.UseSqlServer(connectionString));

            services.AddTransient<IRepository<Student>, StudentRepository>();
            services.AddTransient<IStudentService, StudentService>();

            return services;
        }
    }
}
