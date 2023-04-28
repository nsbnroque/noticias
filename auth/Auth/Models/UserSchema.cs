using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Contexts;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.Types;

namespace Auth.Models
{
        public class Query
    {
        public List<User> GetUsers([Service]AuthContext service)
        {
            return service.Users.ToList<User>();
        }

        public User GetUserById([Service]AuthContext service,  int Id){
            return service.Users.Find(Id);
        }
    }

    public class Mutation
    {
        public User CreateUser([Service]AuthContext service, CreateUserInput input)
        {
            var user = new User { Name = input.Name, Email = input.Email };
            service.Add(user);
            service.SaveChanges();
            return user;
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class CreateUserInput
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}