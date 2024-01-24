using Company.Api.ServicesConfiguration;
using Company.Api.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;


namespace Company.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.Configure<JsonOptions>(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("local", c =>
                c.AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:4200"));
        });


        builder.Services.AddAppDbContext(builder.Configuration);
        builder.Services.AddRepositories();


        WebApplication app = builder.Build();
        app.ApplyLatestMigration();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAppExceptionMiddleware();

        app.UseCors("local");
        /// app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();


        app.Run();
    }
}
