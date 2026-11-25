
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


        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        // --Dependency Injection
        builder.Services.AddSingleton<MeasurementsRepoList>(new MeasurementsRepoList());
        // --StartMockdataFeeder
        builder.Services.AddHostedService<MockDataFeedService>();

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
