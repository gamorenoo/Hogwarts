using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogwartsApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HogwartsApi.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiDBContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Solicitud>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
