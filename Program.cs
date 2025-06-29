using cqrs_example.FakeDB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddSingleton<FakeDB>();


var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
// }

app.UseHttpsRedirection();

app.MapControllers();

app.Run();