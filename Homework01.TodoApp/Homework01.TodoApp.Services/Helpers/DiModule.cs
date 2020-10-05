using Homework01.TodoApp.DataAccess;
using Homework01.TodoApp.DataAccess.EntityFramework;
using Homework01.TodoApp.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework01.TodoApp.Services.Helpers
{
    public class DiModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TodoDbContext>(x =>
            x.UseSqlServer(connectionString));

            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Todo>, TodoRepository>();

            return services;
        }
    }
}
