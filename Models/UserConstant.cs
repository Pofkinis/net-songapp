namespace SongsApp.Models;

public class UserConstant
{
    public static List<UserModel> Users = new()
    {
        new UserModel(){ Username="user",Password="user",Role="Admin"}
    };
}