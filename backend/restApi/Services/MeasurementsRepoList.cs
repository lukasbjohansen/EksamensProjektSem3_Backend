namespace restApi.Services
{
    public class MeasurementsRepoList : IMeasurementsRepo
    {
        private List<Measurement> _measurements;
        private int _nextId = 1;
        public int Count { get { return _measurements.Count; } }
        public MeasurementsRepoList()
        {
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


    }
}
