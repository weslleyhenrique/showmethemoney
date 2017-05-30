using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootstrapSite2.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BootstrapSite2.Context
{
    public class ApplicationDataContext : IdentityDbContext<AppUser>
    {
        public ApplicationDataContext()
            : base("DefaultConnection")
        { }

        public System.Data.Entity.DbSet<AppUser> AppUsers { get; set; }
    }
}