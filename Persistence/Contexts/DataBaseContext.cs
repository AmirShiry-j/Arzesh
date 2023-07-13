using Application.Interfaces.Contexts;
using Domain.Project;
using Domain.ProjectNeeds;
using Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.ProjectNeeds;
using Persistence.Configurations.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class DataBaseContext : IdentityDbContext<User, Role, string>, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        //Users
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Token> Tokens { get; set; }
        //Projects
        public DbSet<Project_Ideh> P_Idehs { get; set; }
        public DbSet<Project_Incompleted> P_Incompleteds { get; set; }

        //Faciliti
        public DbSet<FacilitiStatus> FacilitiStatuses { get; set; }
        public DbSet<FacilitiNature> FacilitiNatures { get; set; }
        public DbSet<FacilitiRelProject> FacilitiRelProjects { get; set; }
        //Licence
        public DbSet<Licence> Licences { get; set; }
        public DbSet<LicenceRelProject> LicenceRelProjects { get; set; }
        //Fund
        public DbSet<Fund> Funds { get; set; }
        public DbSet<FundRelProject> FundRelProjects { get; set; }
        //Address
        public DbSet<Address> Addresses { get; set; }
        public DbSet<United> Uniteds { get; set; }
        public DbSet<City> Cities { get; set; }
        //Industry
        public DbSet<Industry> Industries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ////Relations
            //Users
            builder.Entity<Token>()
                .HasOne(p => p.User)
                .WithMany(p => p.Tokens)
                .HasForeignKey(p => p.UserId)
                .IsRequired(true);

            builder.Entity<Token>()
                .HasOne(p => p.User)
                .WithMany(p => p.Tokens)
                .HasForeignKey(p => p.UserId)
                .IsRequired(true);
            //

            builder.Entity<LicenceRelProject>()
                .HasOne(p => p.Project_Incompleted)
                .WithMany(p => p.Licences)
                .HasForeignKey(p => p.ProjectId)
                .IsRequired(true);

            builder.Entity<FacilitiRelProject>()
    .HasOne(p => p.Project_Incompleted)
    .WithMany(p => p.Facilitis)
    .HasForeignKey(p => p.ProjectId)
    .IsRequired(true);

            builder.Entity<FundRelProject>()
.HasOne(p => p.Project_Incompleted)
.WithMany(p => p.Funds)
.HasForeignKey(p => p.ProjectId)
.IsRequired(true);

            //For Address
            builder.Entity<Address>()
                .HasOne(p => p.City)
                .WithMany();

            SetConfigurations(builder);

            base.OnModelCreating(builder);
        }

        private void SetConfigurations(ModelBuilder builder)
        {
            //Users
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new RoleConfig());
            builder.ApplyConfiguration(new TokenConfig());
            //Address
            builder.ApplyConfiguration(new UnitedConfig());


            base.OnModelCreating(builder);
        }
    }
}
