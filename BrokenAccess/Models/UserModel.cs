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

    public class ProfileRequestModel
    {
        public Guid UserId { get; set; }
    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool UseExtModel { get; set; } = false;
    }

    public class UserExtModel : UserModel
    {
        private int Id { get; set; } = 0;
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool MayUpdate { get; set; } = false;
        public bool MayDelete { get; set; } = false;
    }
    public class UserExtResponseModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool MayUpdate { get; set; } = false;
        public bool MayDelete { get; set; } = false;
    }
}
