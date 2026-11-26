
using Microsoft.EntityFrameworkCore;
using restApi.Services;

namespace restApi;

public class Program
{
    private const string Policy = "AllowAll";

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // --CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: Policy,
                                      policy =>
                                      {
                                          policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                                      });
        });

        // --Database connection string and dependency injection for the MeasurementsRepoDbEfCore
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' blev ikke fundet.");
        builder.Services.AddDbContext<MeasurementsDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddScoped<IMeasurementsRepo, MeasurementsRepoDbEfCore>();

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        // --StartMockdataFeeder
        //builder.Services.AddHostedService<MockDataFeedService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        // --CORS part 2
        app.UseCors(Policy);

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
