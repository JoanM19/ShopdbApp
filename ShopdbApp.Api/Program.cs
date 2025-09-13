using PlatformShop.Application.Contracts;
using PlatformShop.Application.Services;
using PlatformShop.Domain.Repositories;
using PlatformShop.Persistence.Repositories.Base;
using PlatformShop.Persistence.Repositories.Categories;
using PlatformShop.Persistence.Repositories.Customers;


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

            //Servicios de aplicacion.
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICustomersService, CustomersService>();

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
