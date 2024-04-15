var builder = WebApplication.CreateBuilder(args);

// https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options => options.AddPolicy(name: myAllowSpecificOrigins, policy => policy.WithOrigins("http://localhost:5173", "http://localhost:5284")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("swagger/v1/swagger.json", "version 1");
    c.RoutePrefix = "";
});
//}

app.UseCors(myAllowSpecificOrigins);
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
