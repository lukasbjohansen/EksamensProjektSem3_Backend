using restApi.Services;

public class MockDataFeedService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public MockDataFeedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var newMeasurement = new Measurement
            {
                Temperature = -5 + new Random().NextDouble() * 45,
                Humidity = new Random().NextDouble() * 100,
                Time = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };

            // Create a scope for the scoped service
            using (var scope = _serviceProvider.CreateScope())
            {
                var measurementsRepo = scope.ServiceProvider.GetRequiredService<IMeasurementsRepo>();
                Console.WriteLine($"New Measurement Added: Id={newMeasurement.Id}, Temp={newMeasurement.Temperature}, Humidity={newMeasurement.Humidity}, Time={newMeasurement.Time}");
                measurementsRepo.AddMeasurement(newMeasurement);
            }

            Task.Delay(5000, stoppingToken).Wait();
        }
        return Task.CompletedTask;
    }
}