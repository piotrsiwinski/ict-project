using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SmartCardReader.DataAccessLayer.Models
{
    public class Account : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Account> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
        public virtual Lecturer Lecturer { get; set; }
    }

}