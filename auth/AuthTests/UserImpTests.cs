using Auth.Models;
using Auth.Services;

namespace AuthTests
{
    public class UserImpTests
    {
        private UserImp _userImp;
        private User _user;

        public UserImpTests(){
            _userImp = new UserImp();
            _user = new User();
        }

        [Fact]
        public void WhenSaveShouldSaveUser()
        {
            User user = new User(username: "username",password: "verysecret");
            User saved = _userImp.save(user);
            Assert.Equal(user,saved);
        }
    }
}
