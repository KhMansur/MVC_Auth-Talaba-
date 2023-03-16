using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Text;
using TalabaMVC.DBContext;
using TalabaMVC.Models;

namespace TalabaMVC.Services
{
    public static class Middleware
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthManager, AuthManager>();
        }

        public static void AddConfigurationIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApiUser, Role>(q => q.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }

        public static void AddConfigurationJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");

            var key = jwtSettings.GetSection("Key").Value;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
