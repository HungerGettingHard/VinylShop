using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.DbContext
{
    public interface IVinylShopDbContext
    {
        public DbSet<Genre> Genres { get; set; }
    }
}
