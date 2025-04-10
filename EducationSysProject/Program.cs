using EducationSysProject.Data.Repositories;
using EducationSysProject.Data.UintOfWork;
using EducationSysProject.Data.UnitOfWork;
using EducationSysProject.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace EducationSysProject
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EducationSysProject.Context.EducationSysContext>();
                context.Database.EnsureCreated();
            }

            Application.Run(ServiceProvider.GetRequiredService<MainForm>());
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EducationSysProject.Context.EducationSysContext>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenericCrudService, GenericCrudService>();
            services.AddScoped<DynamicFormService>();
            services.AddScoped<DynamicFormService>(provider =>
                new DynamicFormService(provider.GetRequiredService<IUnitOfWork>()));
            services.AddScoped<MainForm>();
        }
    }
}