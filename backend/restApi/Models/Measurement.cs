namespace restApi.Models
{
    public class Measurement
    {
        public int Id { get; private set; }
        public double Temperature { get; private set; }
        public double Humidity { get; private set; }
        public DateTime MeasuredAt { get; private set; }

        private Measurement()
        {
        }

        public Measurement(int id, double temperature, double humidity, DateTime measuredAt)
        {
            Id = id;
            Temperature = temperature;
            Humidity = humidity;
            MeasuredAt = measuredAt;
        }



    }
}
