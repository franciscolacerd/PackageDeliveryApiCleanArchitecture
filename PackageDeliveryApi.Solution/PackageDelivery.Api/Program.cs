using Microsoft.Extensions.Options;
using PackageDelivery.Api.Middleware;
using PackageDelivery.Api.Startup;
using PackageDelivery.Application;
using PackageDelivery.Domain;
using PackageDelivery.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureDomainServices();
builder.Services.ConfigureApplicationServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

var tokenProviderSettings = builder.Services.AddJWTAuthentication(
    builder.Configuration,
    builder.Environment.EnvironmentName);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PackageDelivery.Api v1"));
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<TokenProviderMiddleware>(Options.Create(tokenProviderSettings));
app.UseEnableRequestRewind();
app.MapControllers();

app.Run();