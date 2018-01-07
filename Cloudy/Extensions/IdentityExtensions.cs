using Cloudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Cloudy.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserFirstName (this IIdentity identity)
        {
            var db = ApplicationDbContext.Create();
            var users = db.Users.FirstOrDefault(u => u.FirstName == identity.Name);

            return users != null ? users.FirstName :String.Empty;
        }

        public static async Task GetUsers (this List<UserViewModel> users)
        {
            var db = ApplicationDbContext.Create();

            users.AddRange(await (from u in db.Users select
                                  new UserViewModel
                                  {
                                      Id = u.Id,
                                      FirstName = u.FirstName,
                                      Email = u.Email
                                      
                                  }).OrderBy(o => o.Email).ToListAsync());



        }
    }
}