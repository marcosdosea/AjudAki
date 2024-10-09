using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;

namespace AjudAkiWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AjudakiContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("AjudakiDatabase")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IAssinaturaService, AssinaturaService>();
            builder.Services.AddTransient<IClienteService, ClienteService>();
            builder.Services.AddTransient<IProfissionalService, ProfissionalService>();
            builder.Services.AddTransient<IServicoService, ServicoService>();
            builder.Services.AddTransient<IAreaAtuacaoService, AreaAtuacaoService>();
            builder.Services.AddTransient<IAgendaService, AgendaService>();
            builder.Services.AddTransient<IContratacaoService, ContratacaoService>();
            builder.Services.AddTransient<IAvaliarService, AvaliarService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
