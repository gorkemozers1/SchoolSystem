using Microsoft.EntityFrameworkCore;
using SchoolTrackingSystem.BusinessLayer.Abstract;
using SchoolTrackingSystem.EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTrackingSystem.BusinessLayer.Concrete
{
	public class EntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
	{
		private readonly DbContext _context;

		public EntityRepositoryBase(DbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(TEntity entity)
		{
			await _context.Set<TEntity>().AddAsync(entity);
		}

		public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await _context.Set<TEntity>().AnyAsync(predicate);
		}

		public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await _context.Set<TEntity>().CountAsync(predicate);
		}

		public async Task DeleteAsync(TEntity entity)
		{
			await Task.Run(() => {
				_context.Set<TEntity>().Remove(entity);
			});
		}

		public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			IQueryable<TEntity> query = _context.Set<TEntity>(); // surekli yazmamak icin
																 // eger predicateim varsa filtrelere yani adam id ye gore listelme yaptiysa o idye ait olanlari ver
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			// burdada include lar varsa cateogry language falan onlari include ediyorum
			if (includeProperties.Any())
			{
				foreach (var navProperty in includeProperties)
				{
					query = query.Include(navProperty);
				}
			}
			// en son listemi donduruyorum
			return await query.ToListAsync();
		}

		// burda liste yerine tek bi obje ariyorum
		public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			IQueryable<TEntity> query = _context.Set<TEntity>();
			if (predicate != null)
				query = query.Where(predicate);
			foreach (var navProperty in includeProperties)
			{
				query = query.Include(navProperty);
			}
			return await query.SingleOrDefaultAsync();
		}

		public async Task UpdateAsync(TEntity entity)
		{
			await Task.Run(() => {
				_context.Set<TEntity>().Update(entity);
			});
		}
	}
}
