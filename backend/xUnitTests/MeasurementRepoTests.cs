using Microsoft.EntityFrameworkCore;
using restApi.Services;

namespace xUnitTests;

public class MeasurementRepoTests
{
    private IMeasurementsRepo _measurementsRepo;

    public MeasurementRepoTests()
    {
        var optionsBuilder = new DbContextOptionsBuilder<MeasurementsDbContext>();
        // https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets
        optionsBuilder.UseSqlServer(Secret.ConnectionString);
        // connection string structure
        //   "Data Source=mssql7.unoeuro.com;Initial Catalog=FROM simply.com;Persist Security Info=True;User ID=FROM simply.com;Password=DB PASSWORD FROM simply.com;TrustServerCertificate=True"
        MeasurementsDbContext _dbContext = new(optionsBuilder.Options);
        // clean database table: remove all rows
        _dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Measurements");
        _measurementsRepo = new MeasurementsRepoDbEfCore(_dbContext);
    }


    [Fact]
    public void AddMeasurement()
    {
        ////Arrange
        //Measurement measurement = new Measurement
        //{
        //    Humidity = 50.0f,
        //    Temperature = 20.0f,
        //    Time = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        //};
        ////Act
        //var result = _measurementsRepo.AddMeasurement(measurement);

        ////Assert
        //Assert.NotNull(result);
        //Assert.NotEmpty(_measurementsRepo.GetAllMeasurements());
        //Assert.Equal(measurement.Humidity, result.Humidity);
        //Assert.Equal(measurement.Temperature, result.Temperature);
        //Assert.Equal(measurement.Time, result.Time);
        //Assert.Equal(1, result.Id);
        //Assert.Equal(1, _measurementsRepo.Count);
    }
}
