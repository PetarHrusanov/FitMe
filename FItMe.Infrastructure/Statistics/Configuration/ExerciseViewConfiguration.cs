namespace FitMe.Infrastructure.Statistics.Configuration
{
    using System;
    using FitMe.Domain.Statistics.Models;
    using FitMe.Infrastructure.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using FitMe.Domain.Exercising.Models.Exercises;

    public class ExerciseViewConfiguration : IEntityTypeConfiguration<ExerciseView>
    {
        public void Configure(EntityTypeBuilder<ExerciseView> builder)
        {
            builder
                .HasKey(cav => cav.Id);

            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Exercise>()
                .WithMany()
                .HasForeignKey(c => c.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        
    }
}