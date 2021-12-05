using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using HogwartsApi.DataAccess.Repositories.IRepositories;

namespace HogwartsApi.DataAccess.Repositories
{
    /// <summary>
    /// Administracion generica del Repositorio
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly ApiDBContext _ApiDBcontext;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ApiDBcontext"></param>
        public GenericRepository(ApiDBContext ApiDBcontext)
        {
            _ApiDBcontext = ApiDBcontext;
        }
        /// <summary>
        /// Agrega un registros
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> Add(TEntity entity)
        {
            await _ApiDBcontext.AddAsync(entity);
            await _ApiDBcontext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        ///  Agrega un rango de registros
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> AddRange(List<TEntity> entity)
        {
            await _ApiDBcontext.AddRangeAsync(entity);
            await _ApiDBcontext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Borra registros
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Delete(TEntity entity)
        {
            var addedEntry = _ApiDBcontext.Remove(entity);
            return await _ApiDBcontext.SaveChangesAsync();
        }

        /// <summary>
        /// Ontiene un registro
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _ApiDBcontext.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        /// <summary>
        /// Ontiene na lista de registros
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return await (filter == null ? _ApiDBcontext.Set<TEntity>().ToListAsync() : _ApiDBcontext.Set<TEntity>().Where(filter).ToListAsync());
        }

        /// <summary>
        /// Actualiza registros
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> Update(TEntity entity)
        {
            var addedEntry = _ApiDBcontext.Update(entity);
            await _ApiDBcontext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Actualiza un rango de registros
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> UpdateRange(List<TEntity> entity)
        {
            _ApiDBcontext.UpdateRange(entity);
            await _ApiDBcontext.SaveChangesAsync();
            return entity;
        }
    }
}
