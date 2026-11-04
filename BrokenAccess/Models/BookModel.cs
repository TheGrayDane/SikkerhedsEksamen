namespace BrokenAccess.Models
{
    public class BookModel
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public float Price { get; set; }
    }

    public class BookPostModel
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public float Price { get; set; }

        public int UserId { get; set; }

        public bool UseGuid { get; set; } = false;
        public Guid UserGuid { get; set; }

        //public UserModel User { get; set; }
    }

}
