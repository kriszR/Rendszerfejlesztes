using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Szerver.Models;
using Szerver.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddDbContext<StudentContext>(o => o.UseSqlite("Data source=students.db"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Szerver", Version = "v1" });
});

// CORS policy configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://127.0.0.1:5501")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Szerver v1")
        );
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Apply CORS policy
app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();

