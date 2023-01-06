using Microsoft.EntityFrameworkCore;
using System;

public class DailyContext : DbContext
{

    public DbSet<Contributor> Contributors { get; set; }
    public DbSet<Poll> Polls { get; set; }

    public DailyContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);



    }

}