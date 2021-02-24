using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Vocabulary.Models;

namespace Vocabulary
{
  public class Context : IdentityDbContext<User, Role, int>
  {
    public DbSet<Word> Words { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      string connection = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
      if (connection == null)
        connection = "Host=localhost;Database=vocabulary;Username=postgres;Password=postgres";
      optionsBuilder.UseNpgsql(connection);
    }
  }
}