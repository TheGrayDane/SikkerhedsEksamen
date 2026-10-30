namespace BrokenAccess.Models
{
    public class UserModel
    {
        public int Id { get; set; } = 0;
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }

    public class UserResponseModel
    {
        public int Id { get; set; } = 0;
        public string UserName { get; set; }
    }
}
