using ExamSystem.Models;
using ExamSystem.Repositories.Implementation;
using ExamSystem.Repositories.Interfaces;
using ExamSystem.Services.Implementation;
using ExamSystem.Services.Interfaces;
using ExamSystem.Services.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;

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

//// Identity services
//builder.Services.AddIdentity<AppUser, IdentityRole>()
//    .AddEntityFrameworkStores<ExamContext>()
//    .AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:55918")
              .AllowAnyMethod()
              .AllowAnyHeader()
        .AllowCredentials();
    });
});




builder.Services.AddAutoMapper(cfg =>
{

    cfg.AddProfile<MappingConfig>();

});

builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IExamRepo, ExamRepo>();
builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateAudience = true,
        ValidAudience = "https://localhost:4200",
        ValidateIssuer = true,
        ValidIssuer = "https://localhost:5026",
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Sara&Rawan7/11/2025ITITanta4MonthsThatIsOurChallange")),



    };

});


var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//    string[] roles = { "Student", "Teacher" }; // Define your roles here

//    foreach (var role in roles)
//    {
//        var exists = await roleManager.RoleExistsAsync(role);
//        if (!exists)
//        {
//            await roleManager.CreateAsync(new IdentityRole(role));
//        }
//    }
//}

app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(option => option.SwaggerEndpoint("/openapi/v1.json", "v1"));

}

app.UseHttpsRedirection();

app.UseCors("AllowAngularApp");
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();