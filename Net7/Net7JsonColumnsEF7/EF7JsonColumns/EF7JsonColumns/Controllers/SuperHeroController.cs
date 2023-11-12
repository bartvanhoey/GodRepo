using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF7JsonColumns.Data;
using EF7JsonColumns.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF7JsonColumns.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context) => _context = context;

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHeroes(List<SuperHero> heroes)
        {
            _context.SuperHeros.AddRange(heroes);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeros.ToListAsync());
        }

        [HttpGet("{city}")]
        public async Task<ActionResult<List<SuperHero>>> GetHeroes(string city)
        {
            try
            {
                var heroes = await _context.SuperHeros.Include(h => h.HeroDetail).Where(x => x.HeroDetail != null && x.HeroDetail.City.Contains(city)).ToListAsync();
                return Ok(heroes);
            }
            catch (Exception e)
            {
                throw;
            }

        }

    }
}