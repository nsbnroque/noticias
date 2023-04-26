using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.Contexts
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options){

        }

        public DbSet<User> Users {get;set;}
        
    }
}