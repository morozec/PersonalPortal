namespace Models
{
    public class User
    {
        public bool IsAdmin { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
    }
}