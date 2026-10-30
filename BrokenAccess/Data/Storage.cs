using BrokenAccess.Models;

namespace BrokenAccess.Data
{
    public static class Storage
    {
        private static List<UserModel> _users;
        private static List<UserModel> _loggedInUsers;
        private static List<BookModel> _books;

        static Storage()
        {
            _users = BuildUserList();
            _books = BuildBookList();
            _loggedInUsers = new List<UserModel>();
        }

        public static bool IsUserLoggedIn(int userId)
        {
            return _loggedInUsers.Any(u => u.Id == userId);
        }


        public static List<UserModel> UserList()
        {
            return _users;
        }

        public static List<BookModel> BookList()
        {
            return _books;
        }

        public static List<UserModel> LoggedIn()
        {
            return _loggedInUsers;
        }

        private static List<UserModel> BuildUserList()
        {
            List<UserModel> users = new List<UserModel>
                {
                    new UserModel { Id = 1, UserName = "admin", PassWord = "1234" },
                    new UserModel { Id = 2, UserName = "donald", PassWord = "duck" },
                    new UserModel { Id = 3, UserName = "john", PassWord = "doe" }
                };

            return users;        }

        private static List<BookModel> BuildBookList()
        {
            List<BookModel> books = new List<BookModel>
                {
                    new BookModel { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Price = 10.99f },
                    new BookModel { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Price = 12.99f },
                    new BookModel { Id = 3, Title = "1984", Author = "George Orwell", Price = 9.99f }
                };
            return books;
        }
    }
}
