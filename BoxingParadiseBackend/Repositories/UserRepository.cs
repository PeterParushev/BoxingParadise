using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetById(int id)
        {
            return await new DatabaseContext().Users.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
        }

        public async Task PersistUser(User user)
        {
            DatabaseContext context = new DatabaseContext();
            context.Users.Add(user);
            await context.SaveChangesAsync().ConfigureAwait(false);
            //context.Dispose();
        }

        public async Task DeleteUser(int id)
        {
            DatabaseContext context = new DatabaseContext();
            User user = context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                user.Deleted = true;
            }

            await context.SaveChangesAsync().ConfigureAwait(false);
            //context.Dispose();
        }

        public async Task<IList<User>> GetUsers(int take, int skip)
        {
            return
                await
                    new DatabaseContext().Users.Where(x => !x.Deleted).OrderBy(x => x.Rating)
                        .Take(take)
                        .Skip(skip)
                        .ToListAsync()
                        .ConfigureAwait(false);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await new DatabaseContext().Users.FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}