using MovieDB.DOMAIN.Core.Entities;

namespace MovieDB.DOMAIN.Core.Interfaces
{
    public interface IDirectorRepository
    {
        Task<bool> Delete(int id);
        Task<bool> DeleteLogic(int id);
        Task<IEnumerable<Director>> GetAll();
        Task<Director> GetById(int id);
        Task<bool> Insert(Director director);
        Task<bool> Update(Director director);
    }
}