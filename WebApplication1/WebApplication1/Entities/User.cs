namespace WebApplication1.Entities;

public class User
{
    public int IDUser { get; set; }
    public string Username { get; set; }
    
    public string Password { get; set; }
    public string RefreshToken { get; set; }
}
