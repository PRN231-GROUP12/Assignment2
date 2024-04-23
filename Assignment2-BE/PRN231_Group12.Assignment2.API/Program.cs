using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using PRN231_Group12.Assignment2.API.Middlewares;
using PRN231_Group12.Assignment2.API.Policies;
using PRN231_Group12.Assignment2.Repo;
using PRN231_Group12.Assignment2.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddControllers(opt => opt.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()))).AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRepositoryServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddScoped<ExceptionMiddleware>();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddCors(options =>
{
    options.AddPolicy(CORSPolicy.Development, builder =>
    {
        builder.SetIsOriginAllowed(_ => true);
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization(); 
app.UseCors(CORSPolicy.Development);
app.MapControllers();

app.Run();