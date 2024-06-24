
using api_superheroe_complete_practice.Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api_superheroe_complete_practice.Services.SuperheroService
{
    public class SuperheroeService : ISuperheroeService
    {

        private readonly DatabaseContext _context;
        public SuperheroeService(DatabaseContext context)
        {
            this._context = context;
        }

        public async Task<List<Superheroe>> GetAll()
        {
            var heroes = await _context.Superheroes.ToListAsync();
            return heroes;
        }

        public async Task<Superheroe>? GetById(int id)
        {
            var hero = await _context.Superheroes.FindAsync(id);
            if(hero is null) 
                return null;
            return hero;
        }
        public async Task<Superheroe> Add(Superheroe superheroe)
        {
            _context.Superheroes.Add(superheroe);
            await _context.SaveChangesAsync();
            
            return superheroe;
        }

        public async Task<Superheroe>? Update(int id, Superheroe request)
        {
            var hero = await _context.Superheroes.FindAsync(id);

            if (hero is null)
                return null;

            hero.Name = request.Name;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();

            return hero;
        }

        public async Task<List<Superheroe>> Delete(int id)
        {
            var hero = await _context.Superheroes.FindAsync(id);
            if (hero is null)
                return null;

            _context.Superheroes.Remove(hero);
            await _context.SaveChangesAsync();

            return await _context.Superheroes.ToListAsync();
        }
    }
}
