using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestingTask.Model;

namespace TestingTask.Data
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<MinMax> MinMaxes { get; set; }
        public DbSet<SensorInput> SensorInputs { get; set; }
        public DbSet<SensorOutput> SensorOutputs { get; set; }
        public DbSet<VariableData> VariableDatas { get; set; }
        public DbSet<WarioDevice> WarioDevices { get; set; }
        public DbSet<Forecast> Forecasts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=sqlitedb1.db", option =>
            {
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MinMax>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.ToTable("MinMaxes");
            });

            modelBuilder.Entity<SensorInput>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("SensorInputs");
            });


            modelBuilder.Entity<SensorOutput>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.ToTable("SensorOutputs");
            });


            modelBuilder.Entity<VariableData>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.ToTable("VariableDatas");
            });

            modelBuilder.Entity<WarioDevice>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.ToTable("WarioDevices");
            });

            modelBuilder.Entity<Forecast>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.ToTable("Forecasts");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
