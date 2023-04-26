using Auth.Models;

namespace AuthTests
{
    public class UserTests
    {
        private User _user;

        public UserTests(){
            _user = new User();
        }

        [Fact]
        public void deveCriarUsuario()
        {
            string username = "joao";
            string password = "verysecret";
            User user = new User(username,password);
            Assert.Equal(username, user.username);
        }
    }
}