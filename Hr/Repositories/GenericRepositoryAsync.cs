using Hr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Repositories
{
    public class GenericRepositoryAsync<T> : IGenecricRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            try
            {

            
            return await _dbContext.Set<T>().FindAsync(id);
        }catch(Exception e)
            {

            }
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);

                var success = await _dbContext.SaveChangesAsync() > 0;

                if (success)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

            }
            return true;

        }
        public async Task<bool> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);


            var success = await _dbContext.SaveChangesAsync() > 0;

            if (success)
            {
                return true;

            }
            else
            {
                return false;
            }
          
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {


            try
            {
                return await _dbContext
                                  .Set<T>().AsNoTracking()
                                  .ToListAsync();
            }

            catch (Exception e)
            {

            }
            return await _dbContext
                            .Set<T>().AsNoTracking()
                            .ToListAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
    
            _dbContext.Entry(entity).State = EntityState.Modified;

            var success = await _dbContext.SaveChangesAsync() > 0;

          if(success)
            {
                return true;

            }
          else
            {
                return false;
            }
    
            
        }

   
    }
}
