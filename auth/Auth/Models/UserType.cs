using Auth.Models;
using GraphQL.Types;

namespace Auth.GraphQL.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(u => u.id, type: typeof(IdGraphType)).Description("User ID");
            Field(u => u.username).Description("User name");
            Field(u => u.password).Description("Password");
            Field(u => u.role).Description("User role");
        }
    }
}
