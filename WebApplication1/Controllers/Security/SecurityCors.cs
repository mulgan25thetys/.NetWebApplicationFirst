using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication1.Controllers.Security
{
    public static class SecurityCors
    {
        public const string DEFAULT_POLICY = "DEFAULT_POLICY";
        public const string DEFAULT_POLICY_2 = "DEFAULT_POLICY_2";
        public static void AddCustomCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DEFAULT_POLICY, policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });

                options.AddPolicy(DEFAULT_POLICY_2, policy =>
                {
                    policy.WithOrigins("http://localhost:3582");
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();

                });
            });
        }
        public static void AddCustomSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCustomCors(configuration);
            services.AddCustomAuthentication(configuration);
        }

        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                string myKey = configuration["Jwt:Key"];
                option.SaveToken = true;
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(myKey)),
                    ValidateActor = false,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                };
            });
        }
        
    }
}
