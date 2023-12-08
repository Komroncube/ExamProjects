using Library.Domain.Enums;

namespace Library.Infrastructure.TypeConfigurations;
public class UserModelEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);


        builder.Property(x => x.UserName)
            .HasMaxLength(20)
            .IsRequired();
        builder.Property(x => x.Email)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.Password)
            .IsRequired();
        builder.Property(x => x.Phone)
            .HasMaxLength(12)
            .IsRequired();
        builder.Property(x => x.Role)
            .HasDefaultValue(Role.Student)
            .IsRequired();

        builder.Property(x => x.CreatedDate)
            .HasDefaultValue(DateTime.Now)
            .IsRequired();
        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);

        builder.HasData(
            new User(
                "Komil",
                "Qodirov",
                "komilqodir@gmail.com",
                "admin1",
                "admin123",
                "998998829988",
                Role.Admin
                ),
            new User(
                "Asqar",
                "Hikmatov",
                "asqarhikmat@gmail.com",
                "library1",
                "library123",
                "848884744728",
                Role.Librarian
                ),
            new User(
                "Temur",
                "Torayev",
                "temurtorayev@gmail.com",
                "student1",
                "student123",
                "39399292019",
                Role.Student
                ));

    }
}
