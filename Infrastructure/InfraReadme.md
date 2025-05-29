### ADD Migration with code base

# Create model
```cs
public class User
{
    [Required]
    [Length(36,36)]
    public string Id { get; set; } 
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    
}
```
# Set model to DbContext
```cs
public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

}
```
# use model to create migration
```bash
dotnet ef migrations add InitialCreate
```
# add migration to database
```bash
dotnet ef database update
```
# Reverse Migrations
```bash
dotnet ef migrations list --project SchoolCheck.Infrastructure
dotnet ef database update <PreviousMigrationName>  --project SchoolCheck.Infrastructure
dotnet ef migrations remove --project SchoolCheck.Infrastructure
```

