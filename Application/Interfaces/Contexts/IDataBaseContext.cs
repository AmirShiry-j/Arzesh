using Domain.Projects;
using Domain.ProjectNeeds;
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
        DbSet<Project_Ideh> P_Idehs { get; set; }
        DbSet<Project_Incompleted> P_Incompleteds { get; set; }

        //Faciliti
        DbSet<FacilitiStatus> FacilitiStatuses { get; set; }
        DbSet<FacilitiNature> FacilitiNatures { get; set; }
        DbSet<FacilitiRelProject> FacilitiRelProjects { get; set; }
        //Licence
        DbSet<Licence> Licences { get; set; }
        DbSet<LicenceRelProject> LicenceRelProjects { get; set; }
        //Fund
        DbSet<Fund> Funds { get; set; }
        DbSet<FundRelProject> FundRelProjects { get; set; }
        //Address
        DbSet<Address> Addresses { get; set; }
        public DbSet<United> Uniteds { get; set; }
        public DbSet<City> Cities { get; set; }
        //Industry
        public DbSet<Industry> Industries { get; set; }

        int SaveChanges();
    }
}
