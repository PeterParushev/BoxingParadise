﻿using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public async Task<Login> Login(string username, string password)
        {
            DatabaseContext context = new DatabaseContext();

            if (context.Users.Any(x => x.Username == username && x.Password == password && !x.Deleted))
            {
                await context.Logins.Where(x => x.IsExpired).ForEachAsync(x => x.IsExpired = true).ConfigureAwait(false);
                context.Logins.Add(new Login() { ExpiryDate = DateTime.Now + new TimeSpan(1, 0, 0), IsExpired = false });
                await context.SaveChangesAsync().ConfigureAwait(false);
            }

            return await context.Logins.FirstOrDefaultAsync(x => x.ExpiryDate < DateTime.Now).ConfigureAwait(false);
        }
    }
}