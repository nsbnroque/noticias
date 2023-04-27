using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace Auth.Models
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType(){
            Name = "UserInput";
            Field<NonNullGraphType<StringGraphType>>("username");
            Field<NonNullGraphType<StringGraphType>>("password");

        }
    }
}