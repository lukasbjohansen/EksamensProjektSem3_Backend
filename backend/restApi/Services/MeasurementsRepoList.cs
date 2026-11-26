namespace restApi.Services
{
    public class MeasurementsRepoList : IMeasurementsRepo
    {
        private List<Measurement> _measurements;
        private int _nextId = 1;
        public int Count { get { return _measurements.Count; } }
		public MeasurementsRepoList()
		{
			_measurements = new List<Measurement>();
		}

		public IEnumerable<Measurement> GetAllMeasurements()
        {
            return _measurements.AsReadOnly();
        }

        public Measurement? GetMeasurementById(int id)
        {
            return _measurements.FirstOrDefault(m => m.Id == id);
        }

        public Measurement AddMeasurement(Measurement measurement)
        {
            if (measurement == null)
            {
                throw new ArgumentNullException(nameof(measurement));
            }
            measurement.Id = _nextId++;
            _measurements.Add(measurement);
            return measurement;
        }

		public IEnumerable<Measurement> GetMeasurementsByPeriod(int startTime, int endTime)
		{
			return GetAllMeasurements()
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

	}
}
