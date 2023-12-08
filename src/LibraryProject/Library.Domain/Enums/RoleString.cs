namespace Library.Domain.Enums;
public static class RoleString
{
    public const string ADMIN = "ADMINISTRATOR";
    public const string STUDENT = "STUDENT";
    public const string LIBRARIAN = "LIBRARIAN";



    public const string STUDENTROLE = STUDENT + ", " + LIBRARIAN + ", " + ADMIN;
    public const string LIBRARIANROLE = LIBRARIAN + ", " + ADMIN;
    public const string ADMINROLE = ADMIN;


}
