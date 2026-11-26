namespace restApi.Services
{
	public class MeasurementStatistics
	{
		public double MinTemperature { get; set; }
		public double MaxTemperature { get; set; }
		public double AverageTemperature { get; set; }

		public double MinHumidity { get; set; }
		public double MaxHumidity { get; set; }
		public double AverageHumidity { get; set; }
	}
}