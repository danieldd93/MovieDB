using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDB.DOMAIN.Core.Entities;
using MovieDB.DOMAIN.Core.Interfaces;
using MovieDB.DOMAIN.Infrastructure.Data;

namespace MovieDB.DOMAIN.Infrastructure.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly MovieDbueContext _dbContext;

        public DirectorRepository(MovieDbueContext dbContext)
        {
            _dbContext = dbContext;
        }
        ////Sincrono
        //public IEnumerable<Category> GetAll()
        //{
        //    return _dbContext
        //            .Category
        //            .Where(c => c.IsActive == true)
        //            .ToList();
        //}

        public async Task<IEnumerable<Director>> GetAll()
        {
            return await _dbContext
                    .Director
                    .ToListAsync();
        }

        public async Task<Director> GetById(int id)
        {
            return await _dbContext
                    .Director
                    .Where(c => c.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Director director)
        {
            await _dbContext.Director.AddAsync(director);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Director director)
        {
            _dbContext.Director.Update(director);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var findDirector = await _dbContext
                .Director
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (findDirector == null) return false;

            _dbContext.Director.Remove(findDirector);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> DeleteLogic(int id)
        {
            var findDirector = await _dbContext
                   .Director
                   .Where(x => x.Id == id)
                   .FirstOrDefaultAsync();

            if (findDirector == null) return false;

            int rows = await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
