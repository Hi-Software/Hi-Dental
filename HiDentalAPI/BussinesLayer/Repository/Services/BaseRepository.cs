﻿using BussinesLayer.Repository.Contracts;
using DatabaseLayer.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

namespace BussinesLayer.Repository.Services
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>  where TEntity :class
    {
        private readonly ApplicationDbContext _dbContext;
        public BaseRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;
        public async Task<bool> Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return await CommitAsync();
        }

        public async Task<bool> CommitAsync()
        {
            var result = true;
            using var transaction = _dbContext.Database.BeginTransaction();
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    result = false;
                    await transaction.RollbackAsync();
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
            return result;
        }

        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> expression) => _dbContext.Set<TEntity>().Where(expression);

        public async Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> expression) => await Filter(expression).ToListAsync();

        public IQueryable<TEntity> GetAll() => _dbContext.Set<TEntity>().AsQueryable();

        public async Task<TEntity> GetById(Guid id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetList(Expression<Func<TEntity, bool>> expression = null) 
            => expression == null ? await GetAll().ToListAsync() : await FilterAsync(expression);

        public async Task<bool> Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return await CommitAsync();
        }

        public async Task<bool> Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return await CommitAsync();
        }

    }
}
