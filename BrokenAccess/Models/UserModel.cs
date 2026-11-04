namespace BrokenAccess.Models
{
    public class UserModel
    {
        public int Id { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
    }

    public class UserResponseModel
    {
        public int Id { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
    }

    public class ProfileRequestModel
    {
        public Guid UserId { get; set; }
    }

    public class LoginModel
    {
        public string UserName { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
        public bool UseExtModel { get; set; } = false;
    }

    public class UserExtModel : UserModel
    {
        private new int Id { get; set; } = 0;
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool MayUpdate { get; set; } = false;
        public bool MayDelete { get; set; } = false;
    }
    public class UserExtResponseModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
        public bool MayUpdate { get; set; } = false;
        public bool MayDelete { get; set; } = false;
    }
}
