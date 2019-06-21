using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.UserVieModels
{
    public class UsersViewModel:ApplicationUser
    {
        public List<string> UserRoles { get; set; }
    }
}