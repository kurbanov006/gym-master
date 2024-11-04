using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddDbContext<AppDbContext>(
    x => x.UseNpgsql(builder.Configuration["ConnectionString"]));


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<RequestMidlleware>();

app.MapControllers();

app.Run();