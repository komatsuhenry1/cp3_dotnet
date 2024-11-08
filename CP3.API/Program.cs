using Microsoft.EntityFrameworkCore;
using CP3.Data.AppData;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Oracle");

if (string.IsNullOrEmpty(connectionString))
{
    throw new ArgumentNullException("connectionString", "A string de conexão não pode ser nula.");
}

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseOracle(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = string.Empty;
    });
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
