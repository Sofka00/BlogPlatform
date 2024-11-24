using BlogPlatform.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.DAL.Repositorys
{
    public class UserRepository
    {
        private Context _context;

        public UserRepository()
        {
            _context = new Context();
        }

        public async Task <User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
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

        public async Task<User> UpdateUser(User user)
        {
            var userToUpdate = await GetUserById(user.Id);

            userToUpdate.Username = user.Username;
            userToUpdate.Password = user.Password;
            userToUpdate.Email = user.Email;
            userToUpdate.FullName = user.FullName;

            await _context.SaveChangesAsync();

            return userToUpdate; //(oshibka)
        }

        public async Task <User> RemoveUser (Guid id)
        {
            var userToDelete = await GetUserById(id);
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();

            return userToDelete;
        }
        








    }
}



