using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlingLeagueController : ControllerBase
    {
        private readonly BowlDbContext _context;

        public BowlingLeagueController(BowlDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetBowlers()
        {
            var bowlers = await _context.Bowlers
                .Include(b => b.Team) // Include the Team relationship
                .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
                .Select(b => new
                {
                    b.BowlerID,
                    Name = $"{b.BowlerFirstName} {(b.BowlerMiddleInit ?? "").Trim()} {b.BowlerLastName}".Trim(),
                    b.BowlerCity,
                    b.BowlerState,
                    b.BowlerZip,
                    b.BowlerPhoneNumber,
                    b.BowlerAddress,
                    TeamName = b.Team.TeamName
                })
                .ToListAsync();

            return Ok(bowlers);
        }

    }
}
