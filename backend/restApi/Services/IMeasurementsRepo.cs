namespace restApi.Services;

public interface IMeasurementsRepo
{
    int Count { get; }

    Measurement AddMeasurement(Measurement measurement);
    IEnumerable<Measurement> GetAllMeasurements();
    Measurement? GetMeasurementById(int id);
}