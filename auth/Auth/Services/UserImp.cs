using System;
using Auth.Contexts;
using Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.Services
{
    public class UserImp
    {
              private readonly AuthContext _context;

        public UserImp(AuthContext context){
            _context = context;
        }

        public UserImp()
        {
        }

        public User Save(User user)
        {
            Console.WriteLine("Chegou aqui" + user);
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public async Task<List<User>> GetAllAsync(){
            return await _context.Users.ToListAsync();
        }

        public User Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

       public async Task<User> GetByIdAsync(int id)
        {
        return await _context.Users.FindAsync(id);
        }

        internal void Save(CreateUserInput input)
        {
            throw new NotImplementedException();
        }
    }
}