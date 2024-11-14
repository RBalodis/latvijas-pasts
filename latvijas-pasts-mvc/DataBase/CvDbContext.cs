using latvijas_pasts_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace latvijas_pasts_mvc.DataBase;

public class CvDbContext(DbContextOptions<CvDbContext> options) : DbContext(options)
{
    public DbSet<BaseData> BaseData { get; set; }
}