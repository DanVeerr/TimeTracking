using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TimeTracking.Models;

namespace TimeTracking.Services
{
    /// <summary>
    /// Методы для работы с пользователем.
    /// </summary>
    public class UserService 
    {
        UsersContext db;
        public UserService(UsersContext db)
        {
            if (db == null)
            {
                throw new ArgumentNullException(nameof(db));
            }

            this.db = db;
        }

        /// <summary>
        /// Создание пользователя.
        /// </summary>
        /// <param name="user"> Пользователь</param>
        /// <returns>Созданный пользователь</returns>
        public async Task<User> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();

            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public async Task<bool> Edit(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int? id)
        {
            User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (user != null)
            {
                db.Users.Remove(user);
                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }
        
    }
}
