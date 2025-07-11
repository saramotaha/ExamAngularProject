using ExamSystem.Models;
using ExamSystem.Repositories.Implementation;
using ExamSystem.Repositories.Interfaces;
//using ExamSystem.Services.Implementation;
using ExamSystem.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ExamContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole<int>>()
    .AddEntityFrameworkStores<ExamContext>()
    .AddDefaultTokenProviders();













//builder.Services.AddScoped<IQuestionService, QuestionService>();
//builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(option => option.SwaggerEndpoint("/openapi/v1.json", "v1"));

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();