﻿using System.Linq.Expressions;

namespace AccessLeveler.Services;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id); 
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id); 
    Task<bool> ExistsAsync(Guid id); 
    IQueryable<T> Queryable(); 
}