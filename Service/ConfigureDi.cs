using Data;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Factories;
using Microsoft.Extensions.DependencyInjection;
using Service.Departments;
using Service.Employees;
using Service.Positions;

namespace Service
{
    public static class ConfigureDi
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddScoped<RepositoryFactories>();
            services.AddScoped<IRepositoryProvider, RepositoryProvider>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkAsync, UnitOfWork>();
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));


            //scoped
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IPositionService, PositionService>();

        }
    }
}
