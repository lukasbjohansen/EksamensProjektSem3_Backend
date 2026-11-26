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

    public Measurement? GetMeasurementById(int id)
    {
        return _context.Measurements.FirstOrDefault(m => m.Id == id);
    }
}
