
using AutoMapper;
using IdentityService.Domain.Context;
using IdentityService.Domain.Contract.Repositories;
using IdentityService.Domain.Contract.Services;
using IdentityService.Mapper;
using IdentityService.Middlewares;
using IdentityService.Repositories;
using IdentityService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Text;

namespace IdentityService
{
    public class Program
    {
        private readonly IConfiguration configuration;
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var allowedOrigins = builder.Configuration["AllowedOrigins"];


            var originsArray = allowedOrigins.Split(',');
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "MyAllowSpecificOrigins",
                    policy =>
                    {
                        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(originsArray);
                    });
            });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { new CultureInfo("az"), new CultureInfo("en-US") };
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("az");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            // Add services to the container.

            builder.Services.AddControllersWithViews();

            // Configure DbContext with SQL Server
            builder.Services.AddDbContext<IdentityServiceDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddScoped<IRepository, EfRepository>();
            builder.Services.AddScoped<IService, SystemService>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

                // Define the security schemes
                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "ApiKey",
                    Type = SecuritySchemeType.ApiKey,
                    Description = "API Key Authentication"
                });

                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    In = ParameterLocation.Header,
                //    Description = "Please insert JWT with Bearer into field",
                //    Name = "Bearer",
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer"
                //});
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http, // Correct type for Bearer token
                    Scheme = "bearer", // Lowercase 'bearer'
                    BearerFormat = "JWT", // Optional, to specify the format
                    In = ParameterLocation.Header,
                    Description = "Please enter 'Bearer' followed by a space and then your token in the text input below.",
                    Name = "Authorization" // Correct header field for HTTP authorization
                });

                // Define the security requirements
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "ApiKey"
                    }
                },
                Array.Empty<string>()
            },
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
            });


            var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Jwt:Key"));


            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidateAudience = false
                };
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = ctx =>
                    {
                        // Log the success of token validation
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = ctx =>
                    {
                        // Log the failure here
                        // ctx.Response.StatusCode = 401;
                        //ctx.Response.ContentType = "text/plain";
                        Console.WriteLine(ctx.Exception.ToString());
                        return ctx.Response.WriteAsync(ctx.Exception.ToString());
                    }
                };


            });


            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfiler());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            ///*if*/ (app.Environment.IsDevelopment())
            {
                app.UseMiddleware<SwaggerBasicAuthMiddleware>();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    //c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity Service API V1");
                });
                //}

                app.UseRequestLocalization();

                app.UseRouting();
                app.UseAuthentication();

                app.UseAuthorization();

                //app.UseMiddleware<ApiKeyMiddleware>();


                //app.UseEndpoints();

                app.MapControllers();
                _ = app.Use(async (context, next) =>
                {
                    var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
                    await Console.Out.WriteLineAsync(($"Received token: {token}"));
                    await next.Invoke();
                });

                app.Run();
            }
        }
    }
}
