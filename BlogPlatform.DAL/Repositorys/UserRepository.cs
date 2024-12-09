using BlogPlatform.DAL.DTOs;
using BlogPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.DAL.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
             _context.SaveChanges();
            return user;
        }
        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user); 
            await _context.SaveChangesAsync();
            
        }

        public async Task RemoveUser(Guid id)
        {
            var userToDelete = await GetUserById(id);
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();

        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Login == username);
        }
    }
}



