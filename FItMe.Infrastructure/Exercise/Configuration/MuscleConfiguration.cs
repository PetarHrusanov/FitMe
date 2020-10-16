namespace FitMe.Infrastructure.Exercise.Configuration
{
    using FitMe.Domain.Exercising.Models.Exercises;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static FitMe.Domain.Exercising.Models.ModelConstants.Common;
    using static FitMe.Domain.Exercising.Models.ModelConstants.Description;

    public class MuscleConfiguration : IEntityTypeConfiguration<Muscle>
    {

        public void Configure(EntityTypeBuilder<Muscle> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);
        }
    }
}
