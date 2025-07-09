using cqrs_example;
using cqrs_example.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
//     .AddJsonOptions(x=>
// {
//     x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
//     x.JsonSerializerOptions.WriteIndented = true;
// });
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
// }

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();