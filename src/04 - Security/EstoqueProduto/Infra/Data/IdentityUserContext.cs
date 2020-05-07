using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EstoqueProduto.Infra.Data
{
    public class IdentityUserContext : IdentityDbContext<IdentityUser>
    {
        public IdentityUserContext(DbContextOptions options) : base(options) { }    
    }
}