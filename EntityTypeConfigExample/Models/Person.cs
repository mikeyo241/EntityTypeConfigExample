using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityTypeConfigExample.Models
{
    public class Person : IEntityTypeConfiguration<Person>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        // https://learn.microsoft.com/en-us/dotnet/api/system.data.entity.modelconfiguration.entitytypeconfiguration-1?view=entity-framework-6.2.0
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // Customize the models table name
            builder.ToTable("PERSON_TABLE");
            // Add a table comment
            builder.ToTable(p => p.HasComment("Information about a person."));
            // Setup the primary key
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            // Setup the required fields
            builder.Property(p => p.FirstName).IsRequired(true);
            builder.Property(p=> p.LastName).IsRequired(true);
            // Set default values for nullable fields
            builder.Property(p => p.Title).HasDefaultValue("");
            builder.Property(p => p.Email).HasDefaultValue("");
        }
    }
}
