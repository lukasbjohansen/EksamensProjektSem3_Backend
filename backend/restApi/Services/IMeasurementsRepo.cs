namespace restApi.Services;

public interface IMeasurementsRepo
{
    int Count { get; }

    Measurement AddMeasurement(Measurement measurement);
    IEnumerable<Measurement> GetAllMeasurements();
	Measurement? GetMeasurementById(int id);

	IEnumerable<Measurement> GetMeasurementsByPeriod(int startTime, int endTime);

	MeasurementStatistics? GetStatisticsByPeriod(int startTime, int endTime);
}