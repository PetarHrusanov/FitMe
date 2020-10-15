namespace FItMe.Infrastructure.Exercise.Configuration
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using FitMe.Domain.Exercising.Models.Exercises;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static FitMe.Domain.Exercising.Models. ModelConstants.Common;
    using static FitMe.Domain.Exercising.Models.ModelConstants.Description;

    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(c => c.Instruction)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);

            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);

            builder
                .Property(c => c.Complexity)
                .IsRequired();

            builder
                .HasOne(c => c.Muscle)
                .WithMany()
                .HasForeignKey("MuscleId")
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
