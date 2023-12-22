using LogixTask.Common.Configs;
using LogixTask.Services.Implementations;
using LogixTask.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LogixTask.Services
{
    public static class ServicesDependencyInjection
    {
        public static IServiceCollection AddServicesLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenSecret = configuration.GetSection("secret").ToString();

            IConfiguration appSettingConfiguration = configuration.GetSection("AppSetting");
            services.Configure<AppSetting>(appSettingConfiguration);
            services.PostConfigure<AppSetting>(opt =>
            {
                opt.JwtTokenConfig.Secret = tokenSecret;
            });
            var appSetting = appSettingConfiguration.Get<AppSetting>();
            appSetting.JwtTokenConfig.Secret = tokenSecret;

            services.AddSingleton(appSetting.JwtTokenConfig);
            services.AddTransient<IAuthManager, AuthManager>();
            services.AddTransient<ITokenProvider, TokenProvider>();
            services.AddTransient<IUserValidator, UserValidator>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(option =>
                {

                    option.RequireHttpsMetadata = true;
                    option.SaveToken = true;
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = appSetting.JwtTokenConfig.Issuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSetting.JwtTokenConfig.Secret)),
                        ValidAudience = appSetting.JwtTokenConfig.Audience,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(10)
                    };
                });
            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
            services.AddTransient<IRefreshTokenHandler, RefreshTokenHandler>();
            services.AddTransient<IAdminOperations, AdminOperations>();
            services.AddTransient<IWordAbbreviationService, WordAbbreviationService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IPatternReplacementService, PatternReplacementService>();
            services.AddTransient<IRegisterService, RegisterService>();
            services.AddTransient<IClassService, ClassService>();

            return services;
        }
    }
}
