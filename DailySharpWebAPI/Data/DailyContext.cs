using DailySharpWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

public class DailyContext : DbContext
{

    public DbSet<Contributor> Contributors { get; set; }
    public DbSet<Poll> Polls { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Alternative> Alternatives { get; set; }
    public DbSet<Reaction> Reactions { get; set; }
    public DbSet<PollPost> PollPosts { get; set; }


    public DailyContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Contributor>().Property(u=>u.DiscordId).HasMaxLength(500);
        modelBuilder.Entity<Contributor>().Property(u => u.NickName).HasMaxLength(100);

        modelBuilder.Entity<Poll>().Property(p => p.Topic).HasMaxLength(500);
        modelBuilder.Entity<Poll>().Property(p => p.OverallQuestion).HasMaxLength(500);
        modelBuilder.Entity<Poll>().HasOne(p=>p.Contributor).WithMany(c=>c.Poll);
        
        modelBuilder.Entity<Question>().HasMany(q => q.Alternatives).WithOne(a=>a.Question);
        modelBuilder.Entity<Question>().HasOne(q => q.Poll).WithMany(p=>p.Questions);
        modelBuilder.Entity<Question>().Property(q => q.QuestionTxt).HasMaxLength(500);
        modelBuilder.Entity<Question>().Property(q => q.ImageName).HasMaxLength(500);
        
        modelBuilder.Entity<Alternative>().Property(a => a.AltTxt).HasMaxLength(500);

        modelBuilder.Entity<Reaction>().HasOne(r=>r.PollPost).WithMany(pq=>pq.Reactions);
        modelBuilder.Entity<Reaction>().Property(r => r.Name).HasMaxLength(500);

        modelBuilder.Entity<PollPost>().HasOne(pp => pp.Poll).WithMany(p => p.PollPost);



    }

}