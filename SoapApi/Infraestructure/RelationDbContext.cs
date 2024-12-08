using Microsoft.EntityFrameworkCore;
using SoapApi.Infraestructure.Entities;

namespace SoapApi.Infraestructure;

public class RelationDbContect : DbContext
{
    public RelationDbContect(DbContextOptions<RelationalDbContext> options) : base(options)
    {

    }

    public DbSet<UserEntity> Users {get; set;}
}