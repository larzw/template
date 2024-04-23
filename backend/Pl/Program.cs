var builder = WebApplication.CreateBuilder(args);

// https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0
// https://stackoverflow.com/questions/59325994/content-type-is-not-allowed-by-access-control-allow-headers-in-preflight-respons
var allowAllOrigins = "AllowAllOrigins";
builder.Services.AddCors(options => options.AddPolicy(name: allowAllOrigins, policy => { _ = policy.AllowAnyOrigin(); _ = policy.AllowAnyHeader(); _ = policy.AllowAnyMethod(); }));


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
app.UseSwaggerUI();
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("swagger/v1/swagger.json", "version 1");
//    c.RoutePrefix = "";
//});
//}

app.UseCors(allowAllOrigins);
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
