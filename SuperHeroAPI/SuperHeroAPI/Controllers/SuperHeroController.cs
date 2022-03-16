using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heros = new List<SuperHero>
            {
                new SuperHero{Id=1,Name="Spider Man",FirstName="Peter",LastName="Parker",Place="New York City" },
                new SuperHero{Id=2,Name="IRON Man",FirstName="Toni",LastName="Stark",Place="USA"}
            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {

            return Ok(heros);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddSuperHero(SuperHero hero)
        {
            heros.Add(hero);
            return Ok(heros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var super = heros.Find(h => h.Id == id);
            if(super == null)
            {
                return BadRequest("Hero Not Found");
            }
            else
                return Ok(super);
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> Put(SuperHero hero2)
        {
            var hero = heros.Find(h => h.Id == hero2.Id);
            if (hero == null)
                return BadRequest("Hero Not Found");
           
                hero.FirstName = hero2.FirstName;
                hero.LastName = hero2.LastName;
                hero.Place = hero2.Place;
                hero.Name= hero2.Name;
               // hero.Id= hero2.Id;
                return Ok(heros);
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutById(int id, SuperHero hero)
        {
            var hero2=heros.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero Not Found");
            hero2.FirstName = hero.FirstName;
            hero2.LastName = hero.LastName;
            hero2.Place = hero.Place;
            hero2.Name= hero.Name;
            hero.Id = id;
            return Ok(heros);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeteleById(int id)
        {
            var hero = heros.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero Not Found");
            heros.Remove(hero);
            return Ok("Hero Deleted");

        }
    }
}
