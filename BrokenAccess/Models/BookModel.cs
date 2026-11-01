namespace BrokenAccess.Models
{
    public class BookModel
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
    }

    public class BookPostModel
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }

        public int UserId { get; set; }

        //public UserModel User { get; set; }
    }

}
