using AutoMapper;
using HR_Platform.Data;
using HR_Platform.Helpers;
using HR_Platform.Repository.Abstractions;
using HR_Platform.Repository.Implementations;
using HR_Platform.Services.Abstractions;
using HR_Platform.Services.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IJobCandidateRepository, JobCandidateRepository>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IJobCandidateService, JobCandidateService>();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperConfiguration());
});
var mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dataContext.Database.EnsureCreated();
    Seed.SeedData(dataContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
