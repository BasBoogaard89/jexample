using Infrastructure.Context;
using Infrastructure.Extensions;
using Infrastructure.Installers;

var builder = WebApplication.CreateBuilder(args);

var infrastructureAssembly = typeof(DbContextInstaller).Assembly;

// Register Installers and Services from Infrastructure
builder.Services.InstallServicesFromAssembly(builder.Configuration, infrastructureAssembly);
builder.Services.AddServicesByConvention(infrastructureAssembly);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Seed example data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    ExampleDataSeeder.Seed(dbContext);
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
