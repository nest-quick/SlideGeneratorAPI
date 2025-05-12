using SlideGeneratorAPI.Interfaces;
using SlideGeneratorAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:5173")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Register controllers and services
builder.Services.AddControllers();
builder.Services.AddHttpClient<ISlideService, SlideService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();
//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
