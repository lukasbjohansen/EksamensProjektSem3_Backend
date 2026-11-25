namespace restApi.Services
{
    public class MeasurementsRepoList
    {
        private List<Measurement> _measurements;
        private int _nextId = 1;
        public MeasurementsRepoList(bool mockData = false)
        {
            _measurements = new List<Measurement>();
            if (mockData)
            {
                _measurements.Add(new Measurement { Id = _nextId++, Temperature = 20.0, Humidity = 50.0, Time = 1234567890 });
                _measurements.Add(new Measurement { Id = _nextId++, Temperature = 25.0, Humidity = 60.0, Time = 1234567891 });
                _measurements.Add(new Measurement { Id = _nextId++, Temperature = 30.0, Humidity = 70.0, Time = 1234567892 });
                _measurements.Add(new Measurement { Id = _nextId++, Temperature = 35.0, Humidity = 80.0, Time = 1234567893 });
                _measurements.Add(new Measurement { Id = _nextId++, Temperature = 40.0, Humidity = 90.0, Time = 1234567894 });
                _measurements.Add(new Measurement { Id = _nextId++, Temperature = 45.0, Humidity = 100.0, Time = 1234567895 });
            }
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
            if(measurement == null)
            {
                throw new ArgumentNullException(nameof(measurement));
            }
            measurement.Id = _nextId++;
            _measurements.Add(measurement);
            return measurement;
        }


    }
}
