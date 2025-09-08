using PlatformShop.Application.Contracts;
using PlatformShop.Application.Services;
using PlatformShop.Domain.Repositories;
using PlatformShop.Persistence.Repositories.Categories;


namespace ShopdbApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //registrar el dbcontext.

            //Repositorios de datos.
            builder.Services.AddScoped<ICategoriesRepository, CategoryRepository>();

            //Servicios de aplicacion.
            builder.Services.AddScoped<ICategoryService, CategoryService>();

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
