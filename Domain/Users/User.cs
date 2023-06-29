using Domain.Common;
using Domain.Project;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class User : IdentityUser, BaseProps
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public UserType UserType { get; set; }
        //Navs
        public ICollection<Token> Tokens { get; set; }
        public ICollection<Project_Ideh> P_Idehs { get; set; }
        //
        public DateTime TimeCreate { get; set; }
    }
    public enum UserType
    {
        Haghighi = 1,
        Hoghooghi = 2
    }
}
