using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Instrumentation;
using GraphQL.Types;

namespace Auth.Models
{
    public class UserSchema  : Schema
    {
    public UserSchema(IServiceProvider provider)
        : base(provider)
    {
        Query = (UserQuery)provider.GetService(typeof(UserQuery)) ?? throw new InvalidOperationException();
        Mutation = (UserMutation)provider.GetService(typeof(UserMutation)) ?? throw new InvalidOperationException();

        FieldMiddleware.Use(new InstrumentFieldsMiddleware());
    }
    }
}