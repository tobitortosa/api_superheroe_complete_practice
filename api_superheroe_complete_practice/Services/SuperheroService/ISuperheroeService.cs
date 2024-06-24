namespace api_superheroe_complete_practice.Services.SuperheroService
{
    public interface ISuperheroeService
    {
        Task<List<Superheroe>> GetAll();
        Task<Superheroe> Add(Superheroe superheroe);
        Task<Superheroe> GetById(int id);
        Task<Superheroe> Update(int id, Superheroe superheroe);
        Task<List<Superheroe>> Delete(int id);
    }
}
