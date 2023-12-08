namespace Library.Infrastructure.TypeConfigurations;
internal class BookModelEntityConfiguration : IEntityTypeConfiguration<Book>
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
    }
}
