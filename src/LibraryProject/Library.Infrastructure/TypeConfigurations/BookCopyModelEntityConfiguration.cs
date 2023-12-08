namespace Library.Infrastructure.TypeConfigurations;
public class BookCopyModelEntityConfiguration : IEntityTypeConfiguration<BookCopy>
{
    public void Configure(EntityTypeBuilder<BookCopy> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Book)
            .WithMany(x => x.BookCopies)
            .HasForeignKey(x => x.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.PublishedYear)
            .IsRequired();

        builder.Property(x => x.CreatedDate)
            .HasDefaultValue(DateTime.Now)
            .IsRequired();
        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);

        
    }
}
