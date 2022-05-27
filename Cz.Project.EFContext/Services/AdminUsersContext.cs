using Cz.Project.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Project.EFContext.Services
{
    public class AdminUsersContext
    {
        public DbContext Context { get; }
        private CzProjectDbContext DbContext => Context as CzProjectDbContext;

        public AdminUsersContext()
        {
            Context = new CzProjectDbContext();
        }

        public AdminUsers Add(AdminUsers adminUser)
        {
            try
            {
                var newUser = Context.Set<AdminUsers>().Add(adminUser).Entity;
                DbContext.SaveChanges();
                return newUser;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
