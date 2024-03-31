using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nest.Models;

namespace Nest.Contexts
{
    public class NestDbContext : IdentityDbContext<AppUser>
    {
        public NestDbContext(DbContextOptions<NestDbContext> options) : base(options)
        {
        }
    }
}
