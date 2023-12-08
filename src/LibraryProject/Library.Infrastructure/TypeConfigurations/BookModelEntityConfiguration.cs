namespace Library.Infrastructure.TypeConfigurations;
public class BookModelEntityConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x => x.Description)
            .HasMaxLength(300)
            .IsRequired(false);
        builder.Property(x => x.Category)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x => x.CoverImage)
            .HasMaxLength(50)
            .IsRequired(false);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValue(DateTime.Now)
            .IsRequired();
        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);
        builder.HasData(
            new Book(
                1,
                "The Great Gatsby",
                "A novel set in the Roaring Twenties, exploring themes of wealth, class, and the American Dream.",
                "F. Scott Fitzgerald",
                "Classic"
            ),
            new Book(
                2,
                "To Kill a Mockingbird",
                "A story of racial injustice and the destruction of innocence, set in the Deep South.",
                "Harper Lee",
                "Classic"
            ),
            new Book(
                3,
                "1984",
                "A dystopian novel about a future totalitarian regime and the rebellion of one man against it.",
                "George Orwell",
                "Science Fiction"
            )
        );

    }
}
