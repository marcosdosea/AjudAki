using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;
using AjudAkiWeb.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using BibliotecaWeb.Helpers;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace AjudAkiWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IAgendaService, AgendaService>();
            builder.Services.AddTransient<IAreaAtuacaoService, AreaAtuacaoService>();
            builder.Services.AddTransient<IAssinaturaService, AssinaturaService>();
            builder.Services.AddTransient<IAvaliarService, AvaliarService>();
            builder.Services.AddTransient<IClienteService, ClienteService>();
            builder.Services.AddTransient<IContratacaoService, ContratacaoService>();
            builder.Services.AddTransient<IPagarAssinaturaService, PagarAssinaturaService>();
            builder.Services.AddTransient<IProfissionalService, ProfissionalService>();
            builder.Services.AddTransient<IServicoService, ServicoService>();
            builder.Services.AddTransient<ISolicitacaoServicoService, SolicitacaoServicoService>();
            builder.Services.AddTransient<ITipoServicoService, TipoServicoService>();

            // configuração do envio de emails para o usuário
            builder.Services.AddTransient<IEmailSender, EmailSender>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<AjudakiContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("AjudakiDatabase")));

            builder.Services.AddDbContext<IdentityContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("IdentityDatabase")));

            builder.Services.AddDefaultIdentity<UsuarioIdentity>(
                 options =>
                 {
                     // SignIn settings
                     options.SignIn.RequireConfirmedAccount = true;
                     options.SignIn.RequireConfirmedEmail = true;
                     options.SignIn.RequireConfirmedPhoneNumber = false;

                     // Password settings
                     options.Password.RequireDigit = true;
                     options.Password.RequireLowercase = false;
                     options.Password.RequireNonAlphanumeric = true;
                     options.Password.RequireUppercase = false;
                     options.Password.RequiredLength = 6;

                     // Default User settings.
                     options.User.AllowedUserNameCharacters =
                             "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                     options.User.RequireUniqueEmail = true;

                     // Default Lockout settings
                     options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                     options.Lockout.MaxFailedAccessAttempts = 5;
                     options.Lockout.AllowedForNewUsers = true;
                 }).AddRoles<IdentityRole>()
                 .AddEntityFrameworkStores<IdentityContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                //options.AccessDeniedPath = "/Identity/Autenticar";
                options.Cookie.Name = "YourAppCookieName";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                //options.LoginPath = "/Identity/Autenticar";
                // ReturnUrlParameter requires 
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
