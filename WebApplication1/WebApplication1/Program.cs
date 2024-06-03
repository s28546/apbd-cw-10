using Microsoft.EntityFrameworkCore;

using WebApplication1.Entities;
// using WebApplication1.Repositories;
// using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
// builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
// builder.Services.AddScoped<IMedicamentRepository, MedicamentRepository>();
// builder.Services.AddScoped<IPatientRepository, PatientRepository>();
// builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();

builder.Services.AddDbContext<HospitalDbContext>(opt =>
{
    string connString = builder.Configuration.GetConnectionString("DbConnString");
    opt.UseSqlServer(connString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();