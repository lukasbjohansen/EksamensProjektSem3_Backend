namespace restApi.Services;

public class MeasurementsRepoDbEfCore : IMeasurementsRepo
{
    private readonly MeasurementsDbContext _context;
    public MeasurementsRepoDbEfCore(MeasurementsDbContext context)
    {
        _context = context;
    }
    public int Count { get { return _context.Measurements.Count(); } }

    public Measurement AddMeasurement(Measurement measurement)
    {
        if (measurement == null)
        {
            throw new ArgumentNullException(nameof(measurement));
        }
        _context.Measurements.Add(measurement);
        _context.SaveChanges();
        return measurement;
    }

    public IEnumerable<Measurement> GetAllMeasurements()
    {
        return _context.Measurements.ToList();
    }

	public IEnumerable<Measurement> GetMeasurementsByPeriod(int startTime, int endTime)
	{
		return _context.Measurements
			.Where(m => m.Time >= startTime && m.Time <= endTime)
			.ToList();
	}
	public MeasurementStatistics? GetStatisticsByPeriod(int startTime, int endTime)
	{
		var measurements = GetMeasurementsByPeriod(startTime, endTime).ToList();

		if (!measurements.Any())
		{
			return null;
		}

		return new MeasurementStatistics
		{
			MinTemperature = measurements.Min(m => m.Temperature),
			MaxTemperature = measurements.Max(m => m.Temperature),
			AverageTemperature = measurements.Average(m => m.Temperature),

			MinHumidity = measurements.Min(m => m.Humidity),
			MaxHumidity = measurements.Max(m => m.Humidity),
			AverageHumidity = measurements.Average(m => m.Humidity)
		};
	}
	public Measurement? GetMeasurementById(int id)
    {
        return _context.Measurements.FirstOrDefault(m => m.Id == id);
    }
}
