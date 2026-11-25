namespace restApi.Models
{
    public class Measurement
    {
        private int Id { get; set; }
        private double Temperature { get; set; }
        private double Humidity { get; set; }
        private DateTime MeasuredAt { get; set; }

        public Measurement(int id, double temperature, double humidity, DateTime measuredAt)
        {
            Id = id;
            Temperature = temperature;
            Humidity = humidity;
            MeasuredAt = measuredAt;
        }



    }
}
