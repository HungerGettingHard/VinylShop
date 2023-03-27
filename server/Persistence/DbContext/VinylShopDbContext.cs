using Application.Common.DbContext;
using Domain.Entities;
using Persistence.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;
using Persistence.Configurations;

namespace Persistence.DbContext
{
    public class VinylShopDbContext : Microsoft.EntityFrameworkCore.DbContext, IVinylShopDbContext
    {
        private readonly PostgresOptions _postgresOptions;

        public VinylShopDbContext(IOptions<PostgresOptions> postgresOptions, DbContextOptions options)
            : base(options)
        {
            _postgresOptions = postgresOptions.Value;
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = new NpgsqlConnectionStringBuilder
            {
                Host = _postgresOptions.PostgresHost,
                Port = _postgresOptions.PostgresPort,
                Username = _postgresOptions.PostgresUser,
                Password = _postgresOptions.PostgresPassword,
                Database = _postgresOptions.PostgresDataBase,
                IncludeErrorDetail = true
            }.ConnectionString;
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new GenreConfiguration().Configure(modelBuilder.Entity<Genre>());
            new PersonConfiguration().Configure(modelBuilder.Entity<Person>());
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            new ShoppingCartConfiguration().Configure(modelBuilder.Entity<ShoppingCart>());
        }
    }
}
