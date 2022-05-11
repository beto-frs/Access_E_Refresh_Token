using ApiAuth.Models;

namespace ApiAuth.Repositories
{
    public static class UserRepository
    {
        public static UserModel Get(string username, string password)
        {
            var users = new List<UserModel>
            {
                new () { Id = 1, Username = "admin", Password = "111", Role = "admin"},
                new () { Id = 2, Username = "user", Password = "222", Role = "user"}
            };

            return users.FirstOrDefault(x => 
            x.Username == username 
            && x.Password == password);
        }
    }
}
