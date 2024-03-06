namespace Domain.Common;

public static class WhaleApiCatalog
{
    public static class Users
    {
        public static string Register => "users/register";
        public static string Login => "users/login";
        public static string Logout => "users/logout";
    }

    public static class Competitions
    {
        public static string Create => "competitions/create";
        public static string Get => "competitions/get";
    }
}