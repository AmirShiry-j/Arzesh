using Domain.Common;
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
        public string FullName { get; set; }
        //Navs
        public ICollection<Token> Tokens { get; set; }
        //
        public DateTime TimeCreate { get; set; }
    }
}
