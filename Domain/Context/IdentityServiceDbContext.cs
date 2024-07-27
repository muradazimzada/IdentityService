using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IdentityService.Domain.Context
{
    public class IdentityServiceDbContext : DbContext
    {
        public IdentityServiceDbContext(DbContextOptions<IdentityServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<App> Apps { get; set; }
        public DbSet<AppApiKey> AppApiKeys { get; set; }
        public DbSet<AppPage> AppPages { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPageAccess> UserPageAccesses { get; set; }
        public DbSet<UserPosition> UserPositions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var body = Expression.Equal(
                        Expression.PropertyOrField(parameter, "RecordStatus"),
                        Expression.Constant(Domain.Enums.RecordStatus.Active));
                    var lambda = Expression.Lambda(body, parameter);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }

            // Configure relationships for App entity
            modelBuilder.Entity<App>()
                .HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<App>()
                .HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<App>()
                .HasOne(e => e.DeletedBy)
                .WithMany()
                .HasForeignKey(e => e.DeletedById)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-One relationship between App and AppApiKey
            modelBuilder.Entity<App>()
              
                
                .HasOne(a => a.AppApiKey)
                
                .WithOne(aak => aak.App)
                .HasForeignKey<AppApiKey>(aak => aak.AppId)
                
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many relationship between App and AppPages
            modelBuilder.Entity<App>()
                .HasMany(a => a.AppPages)
                .WithOne(ap => ap.App)
                .HasForeignKey(ap => ap.AppId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure relationships for Company entity
            modelBuilder.Entity<Company>()
                .HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasOne(e => e.DeletedBy)
                .WithMany()
                .HasForeignKey(e => e.DeletedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Departments)
                .WithOne(d => d.Company)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.UserPositions)
                .WithOne(up => up.Company)
                .HasForeignKey(up => up.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure relationships for Department entity
            modelBuilder.Entity<Department>()
                .HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(e => e.DeletedBy)
                .WithMany()
                .HasForeignKey(e => e.DeletedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Divisions)
                .WithOne(div => div.Department)
                .HasForeignKey(div => div.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.UserPositions)
                .WithOne(up => up.Department)
                .HasForeignKey(up => up.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure relationships for Division entity
            modelBuilder.Entity<Division>()
                .HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Division>()
                .HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Division>()
                .HasOne(e => e.DeletedBy)
                .WithMany()
                .HasForeignKey(e => e.DeletedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Division>()
                .HasMany(div => div.UserPositions)
                .WithOne(up => up.Division)
                .HasForeignKey(up => up.DivisionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure relationships for Position entity
            modelBuilder.Entity<Position>()
                .HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Position>()
                .HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Position>()
                .HasOne(e => e.DeletedBy)
                .WithMany()
                .HasForeignKey(e => e.DeletedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Position>()
                .HasMany(p => p.UserPositions)
                .WithOne(up => up.Position)
                .HasForeignKey(up => up.PositionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure relationships for Role entity
            modelBuilder.Entity<Role>()
                .HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasOne(e => e.DeletedBy)
                .WithMany()
                .HasForeignKey(e => e.DeletedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure relationships for User entity
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserPositions)
                .WithOne(up => up.User)
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserPageAccesses)
                .WithOne(upa => upa.User)
                .HasForeignKey(upa => upa.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppPage>()
                .HasMany(ap => ap.UserPageAccesses)
                .WithOne(upa => upa.AppPage)
                .HasForeignKey(upa => upa.AppPageId)
                .OnDelete(DeleteBehavior.Cascade);

            // Set delete behavior to Restrict to avoid multiple cascade paths issues
            var entityTypes = modelBuilder.Model.GetEntityTypes();
            foreach (var entityType in entityTypes)
            {
                var foreignKeys = entityType.GetForeignKeys();
                foreach (var foreignKey in foreignKeys)
                {
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
        }
    }
}
