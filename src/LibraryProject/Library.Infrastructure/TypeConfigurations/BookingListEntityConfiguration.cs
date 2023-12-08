namespace Library.Infrastructure.TypeConfigurations;
public class BookingListEntityConfiguration : IEntityTypeConfiguration<BookingList>
{
    public void Configure(EntityTypeBuilder<BookingList> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Book)
            .WithMany(x => x.BookingLists)
            .HasForeignKey(x => x.BookId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
