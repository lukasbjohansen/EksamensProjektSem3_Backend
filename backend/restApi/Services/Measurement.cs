using System.ComponentModel.DataAnnotations.Schema;

namespace restApi.Services
{
    [Table("Measurements")]
    public class Measurement
    {
        public  int Id { get; set; }

        public double Temperature { get; set; }
        public double Humidity { get; set; }
        [Column("MeasurementTime")]
        public int Time { get; set; }

    }
}
