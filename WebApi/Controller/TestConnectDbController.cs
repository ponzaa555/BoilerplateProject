using InfraStructure.Repository;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers;
[Route("api/[controller]")]
public class TestConnectDbController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    public TestConnectDbController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet("test")]
    public IActionResult TestConnection()
    {
        try
        {
            // Attempt to query the database to check connection
            return Ok("Database connection is successful. Number of users: " );
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Database connection failed: " + ex.Message);
        }
    }
}
