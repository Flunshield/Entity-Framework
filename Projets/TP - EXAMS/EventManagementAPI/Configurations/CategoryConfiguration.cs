using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementAPI.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{

    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category
            {
                Id = 1,
                Name = "Technology",
                Description = "Events related to technology and innovation."
            },
            new Category
            {
                Id = 2,
                Name = "Health",
                Description = "Events focused on health and wellness."
            },
            new Category
            {
                Id = 3,
                Name = "Education",
                Description = "Events related to education and learning."
            }
        );
    }
}
