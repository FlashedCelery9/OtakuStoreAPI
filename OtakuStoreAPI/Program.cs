using Microsoft.EntityFrameworkCore;
using OtakuStoreAPI.DataBase;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());
});
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(); 

builder.Services.AddAutoMapper(cfg => { }, typeof(Program));
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
var app = builder.Build();
app.UseHttpsRedirection();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //створює маршрут ~address~/swagger/v1/swagger.json
    app.UseSwaggerUI(); //створює саму веб-документацію базуючись на попередньому файлі json. ~address~/swagger/index.html
    app.MapOpenApi();
}
app.UseRouting();

app.UseCors("Frontend");
app.MapControllers();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
