using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AccountWebApi.Model
{
    /// <summary>
    /// This is the db context class for database interactions.
    /// </summary>
    public class AccountDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountTransaction> Transactions { get; set; }
        
        /// <summary>
        /// This method is for configuring the connection to the database.
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=TestDatabase.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        
        /// <summary>
        /// This method is used to map and configure the tables.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<Account>().ToTable("Accounts", "test");
            modelBuilder.Entity<AccountTransaction>().ToTable("Transactions", "test");
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.CustomerId);
                entity.Property(e => e.BalanceDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            modelBuilder.Entity<AccountTransaction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.AccountNumber);
                entity.Property(e => e.ValueDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
