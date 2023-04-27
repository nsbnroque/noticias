using Auth.GraphQL.Types;
using Auth.Models;
using Auth.Services;
using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;

namespace Auth.Models
{
    public class UserQuery  : ObjectGraphType<object>
{
    private readonly UserImp _userService;

    public UserQuery(UserImp userService)
    {
        _userService = userService;

        Field<ListGraphType<UserType>>("users")
        .Resolve( context => userService.GetAll());

        Field<UserType>("user")
        .Argument<NonNullGraphType<IntGraphType>>("id")
        .Resolve(context => userService.GetById(context.GetArgument<int>("id")));
    }
}

}



