namespace FItMe.Infrastructure.Exercise.Configuration
{
    using FitMe.Domain.Exercising.Models.Instructors;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static FitMe.Domain.Exercising.Models.ModelConstants.Common;
    using static FitMe.Domain.Exercising.Models.ModelConstants.Description;

    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
       
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);

            builder
                .OwnsOne(
                    d => d.PhoneNumber,
                    p =>
                    {
                        p.WithOwner();

                        p.Property(pn => pn.Number);
                    });

            builder
                .HasMany(d => d.Exercises)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("exercises");
        }
    }
}
