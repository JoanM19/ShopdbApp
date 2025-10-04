using PlatformShop.Application.Contracts;
using PlatformShop.Application.Services;
using PlatformShop.Domain.Repositories;
using PlatformShop.Persistence.Repositories.Base;
using PlatformShop.Persistence.Repositories.Categories;
using PlatformShop.Persistence.Repositories.Customers;
using PlatformShop.Persistence.Repositories.Employees;
using PlatformShop.Persistence.Repositories.Shippers;
using PlatformShop.Persistence.Repositories.Suppliers;


namespace ShopdbApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //registrar el dbcontext.
            // Infraestructura/base de datos
            builder.Services.AddScoped<IStoredProcedureExecutor, StoredProcedureExecutor>();

            //Repositorios de datos.
            builder.Services.AddScoped<ICategoriesRepository, CategoryRepository>();
            builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
            builder.Services.AddScoped<ISuppliersRepository, SuppliersRepository>();
            builder.Services.AddScoped<IShippersRepository, ShippersRepository>();
            builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();


            //Servicios de aplicacion.
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICustomersService, CustomersService>();
            builder.Services.AddScoped<ISupplierService, SupplierService>();
            builder.Services.AddScoped<IShippersService, ShippersService>();
            builder.Services.AddScoped<IEmployeesService, EmployeesService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
