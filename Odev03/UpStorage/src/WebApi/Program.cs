using Infrastructure;
using Application;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers(opt => { 
opt.Filters.Add<ValidationFilter>();
});
//Kendili�inden gelen validasyon hata mesajlar�n� ge�ersiz k�ld�k
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);

// Add services to the container.
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
