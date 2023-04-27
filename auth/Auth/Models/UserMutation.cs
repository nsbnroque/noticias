using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.GraphQL.Types;
using Auth.Services;
using GraphQL;
using GraphQL.Types;

namespace Auth.Models
{
    public class UserMutation : ObjectGraphType
    {
        private readonly UserImp _userService;
        public UserMutation(UserImp userService)
    {
        _userService = userService;

        Field<UserType>("createHuman")
      .Argument<NonNullGraphType<UserInputType>>("user")
      .Resolve(context =>
      {
        var user = context.GetArgument<User>("user");
        return userService.Save(user);
      });
    }
        
    }
}