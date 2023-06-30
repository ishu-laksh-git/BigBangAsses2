using BigBangAssesmemtTwo.Interfaces;
using BigBangAssesmemtTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssesmemtTwo.Services
{
    
    public class UserRepo : IRepo<User, int>
    {
        private readonly Context _context;
        public UserRepo(Context context)
        {
            _context = context;
            
        }
        public async Task<User?> Add(User item)
        {
            var user_id = _context.Users.SingleOrDefault(u => u.UserId == item.UserId);
            if (user_id == null)
            {
                try
                {
                    _context.Users.Add(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return null;
        }

        public async Task<User?> Delete(int id)
        {
            try
            {
                var user = await Get(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<User?> Get(int id)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.UserId == id);
                if (user == null)
                {
                    return null;
                }
                return user;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<User>?> GetAll()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                if (users != null)
                {
                    return users;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<User?> Update(User item)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserId == item.UserId);
            if (user != null)
            {
                try
                {
                    user.EmailId = item.EmailId;
                    await _context.SaveChangesAsync();
                    return user;

                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return null;
        }
    }
}
