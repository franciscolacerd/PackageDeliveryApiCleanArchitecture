using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PackageDelivery.Api.Middleware;
using PackageDelivery.Api.Provider;
using PackageDelivery.Application;
using PackageDelivery.Domain;
using PackageDelivery.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var tokenProviderOptions = JWTServicesRegistration.ConfigureJWTServices(builder.Services, builder.Configuration, builder.Environment.EnvironmentName);

builder.Services.ConfigurePersistenceServices(builder.Configuration);

builder.Services.ConfigureDomainServices();

builder.Services.ConfigureApplicationServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "PackageDelivery Api",
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PackageDelivery.Api v1"));
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<TokenProviderMiddleware>(Options.Create(tokenProviderOptions));
app.UseEnableRequestRewind();
app.MapControllers();

app.Run();