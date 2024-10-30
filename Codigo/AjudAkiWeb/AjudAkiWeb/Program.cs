using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;
using Core.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using AjudAkiWeb.Helpers;
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
            builder.Services.AddScoped<IAgendaService, AgendaService>();
            builder.Services.AddScoped<IAreaAtuacaoService, AreaAtuacaoService>();
            builder.Services.AddScoped<IAssinaturaService, AssinaturaService>();
            builder.Services.AddScoped<IAvaliarService, AvaliarService>();
            builder.Services.AddScoped<IClienteService, ClienteService>();
            builder.Services.AddScoped<IContratacaoService, ContratacaoService>();
            builder.Services.AddScoped<IPagarAssinaturaService, PagarAssinaturaService>();
            builder.Services.AddScoped<IProfissionalService, ProfissionalService>();
            builder.Services.AddScoped<IServicoService, ServicoService>();
            builder.Services.AddScoped<ISolicitacaoServicoService, SolicitacaoServicoService>();
            builder.Services.AddScoped<ITipoServicoService, TipoServicoService>();

            // Configuração do envio de emails para o usuário
            builder.Services.AddTransient<IEmailSender, EmailSender>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Configuração do banco de dados
            builder.Services.AddDbContext<AjudakiContext>(options =>
                options.UseMySQL(builder.Configuration.GetConnectionString("AjudakiDatabase")));

            builder.Services.AddDbContext<IdentityContext>(options =>
                options.UseMySQL(builder.Configuration.GetConnectionString("IdentityDatabase")));

            // Configuração da identidade
            builder.Services.AddDefaultIdentity<UsuarioIdentity>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false; 
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityContext>();

            // Configuração do cookie de autenticação
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.Cookie.Name = "AjudAkiCookie";
                options.Cookie.HttpOnly = true; // Segurança adicional
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Sempre use cookies seguros
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Identity/Account/Login";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            // Configuração de logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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
