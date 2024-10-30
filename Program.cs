using PruebaBackend_Javier.Repository;
using PruebaBackend_Javier.Service.Interface;
using PruebaBackend_Javier.Service.Interface.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();


//Services
builder.Services.AddScoped<ICustomerInfo, CustomerInfoService>();
builder.Services.AddScoped<ICustomerDataProvider, CustomerDataProvider>();
//Repository
builder.Services.AddTransient<IHttpService, HttpService>();

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
