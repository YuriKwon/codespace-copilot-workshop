// add a namespace for rewriteoptions
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// 로컬 개발환경일 때 스웨거를 보여줘라. 라는.. 의미
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // add a new rewriteoption that redirects root to /swagger
    var option = new RewriteOptions();
    option.AddRedirect("^$", "swagger"); // root로 들어오면 swagger로 리디렉트 시켜라. 라는 의미
    app.UseRewriter(option);

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
