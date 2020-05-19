using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace monova.entity
{
  public class MVDContext : IdentityDbContext<MVDUser, IdentityRole<Guid>, Guid>
  {
    public MVDContext(DbContextOptions<MVDContext> options) : base(options)
    {
    }
  }
}
