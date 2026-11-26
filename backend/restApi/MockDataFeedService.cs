using restApi.Services;

namespace restApi
{
    public class MockDataFeedService : BackgroundService
    {
        private readonly IMeasurementsRepo _measurementsRepo;
        public MockDataFeedService(IMeasurementsRepo measurementsRepo)
        {
            _measurementsRepo = measurementsRepo;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                // Simulate adding a new measurement every 5 seconds
                var newMeasurement = new Measurement
                {
                    Temperature = -5 + new Random().NextDouble() * 45,
                    Humidity = new Random().NextDouble() * 100,
                    Time = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                };
                // Here you would typically add the new measurement to your repository or database
                Console.WriteLine($"New Measurement Added: Id={newMeasurement.Id}, Temp={newMeasurement.Temperature}, Humidity={newMeasurement.Humidity}, Time={newMeasurement.Time}");
                _measurementsRepo.AddMeasurement(newMeasurement);
                Task.Delay(5000, stoppingToken).Wait();
            }
            return Task.CompletedTask;
        }
    }
}
