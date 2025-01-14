using csharp_ecommerce.Data;
using csharp_ecommerce.Examples;
using csharp_ecommerce.Services.Category;
using csharp_ecommerce.Services.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options => 
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "E-commerce API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Matheus Dalbone",
            Email = "matheusdalbone7@gmail.com",
            Url = new Uri("https://github.com/matheusdalbone")
        }
    });

    c.EnableAnnotations();
    c.ExampleFilters();
   

    //Documentation with XML files.
    //var xmlFile = "csharp-ecommerce.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<UserDTOExample>();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddScoped<ICategoryInterface, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
