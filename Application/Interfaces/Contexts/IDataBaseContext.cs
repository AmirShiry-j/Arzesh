using Domain.Project;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
        //Users
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Token> Tokens { get; set; }
        //Projects
        public DbSet<Project_Ideh> P_Idehs { get; set; }

        int SaveChanges();
    }
}
