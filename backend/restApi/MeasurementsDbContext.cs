using Microsoft.EntityFrameworkCore;
using restApi.Services;
public class MeasurementsDbContext : DbContext
{
    public MeasurementsDbContext(DbContextOptions<MeasurementsDbContext> options) : base(options)
    {
    }
    public DbSet<Measurement> Measurements { get; set; }
}