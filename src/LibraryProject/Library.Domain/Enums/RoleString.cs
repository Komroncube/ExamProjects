namespace Library.Domain.Enums;
public static class RoleString
{
    public static string ADMIN = "ADMINISTRATOR";
    public static string STUDENT = "STUDENT";
    public static string LIBRARIAN = "LIBRARIAN";



    public static string STUDENTROLE = STUDENT + ", " + LIBRARIAN + ", " + ADMIN;
    public static string LIBRARIANROLE = LIBRARIAN + ", " + ADMIN;
    public static string ADMINROLE = ADMIN;
}
