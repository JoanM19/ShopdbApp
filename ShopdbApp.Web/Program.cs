using PlatformShop.Application.Contracts;
using PlatformShop.Application.Services;
using PlatformShop.Domain.Repositories;
using PlatformShop.Persistence.Repositories.Base;
using PlatformShop.Persistence.Repositories.Categories;
using PlatformShop.Persistence.Repositories.Customers;
using PlatformShop.Persistence.Repositories.Employees;
using PlatformShop.Persistence.Repositories.Shippers;
using PlatformShop.Persistence.Repositories.Suppliers;


namespace ShopdbApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
