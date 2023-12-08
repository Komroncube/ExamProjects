namespace Library.Infrastructure.TypeConfigurations;
public class CheckoutModelEntityConfiguration : IEntityTypeConfiguration<Checkout>
{
    public void Configure(EntityTypeBuilder<Checkout> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.BookCopy)
            .WithMany(x => x.Checkouts)
            .HasForeignKey(x => x.BookCopyId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Checkouts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.Property(x => x.IsReturned)
            .IsRequired();

        builder.Property(x => x.CreatedDate)
            .HasDefaultValue(DateTime.Now)
            .IsRequired();
        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);
    }
}
