using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPicksApi.Models;

namespace SportsPicksApi.Controllers
{
  [Route("api/[controller]")]
  [EnableCors]
  [ApiController]
  public class NewGameController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public NewGameController(DatabaseContext context)
    {
      _context = context;
    }

    // GET: api/NewGame
    [HttpGet("/sport/{filteredSport}")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public async Task<ActionResult<IEnumerable<NewGame>>> GetNewGame(string filteredSport)
    {
      var filter = await _context.NewGame.Where(sport => sport.Sport == filteredSport).ToListAsync();
      return filter;
    }

    [HttpGet("/all")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public async Task<ActionResult<IEnumerable<NewGame>>> GetNewGame()
    {

      return await _context.NewGame.ToListAsync();
    }
    // GET: api/NewGame/5
    [HttpGet("{id}")]
    public async Task<ActionResult<NewGame>> GetNewGame(int id)
    {
      var newGame = await _context.NewGame.FindAsync(id);

      if (newGame == null)
      {
        return NotFound();
      }

      return newGame;
    }

    // PUT: api/NewGame/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public async Task<IActionResult> PutNewGame(int id, NewGame newGame, string adminHash)
    {
      var admin = Environment.GetEnvironmentVariable("ADMIN_HASH");
      if (adminHash == admin)
      {
        if (id != newGame.Id)
        {
          return BadRequest();
        }

        _context.Entry(newGame).State = EntityState.Modified;

        try
        {
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!NewGameExists(id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
      }
      return NoContent();
    }

    // POST: api/NewGame
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    // [Authorize(Roles = )]
    public async Task<ActionResult<NewGame>> PostNewGame(NewGame newGame, string adminHash)
    {
      var admin = Environment.GetEnvironmentVariable("ADMIN_HASH");
      if (adminHash == admin)
      {
        _context.NewGame.Add(newGame);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetNewGame", new { id = newGame.Id }, newGame);
      }
      else
      {
        return NoContent();
      }
    }

    // DELETE: api/NewGame/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<NewGame>> DeleteNewGame(int id, string adminHash)
    {
      var admin = Environment.GetEnvironmentVariable("ADMIN_HASH");

      var newGame = await _context.NewGame.FindAsync(id);
      if (adminHash == admin)
      {
        if (newGame == null)
        {
          return NotFound();
        }

        _context.NewGame.Remove(newGame);
        await _context.SaveChangesAsync();

        return newGame;
      }
      else
      {
        return NoContent();
      }
    }

    private bool NewGameExists(int id)
    {
      return _context.NewGame.Any(e => e.Id == id);
    }
  }
}
