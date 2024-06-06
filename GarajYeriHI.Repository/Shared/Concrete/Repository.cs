using GarajYeriHI.Data;
using GarajYeriHI.Models;
using GarajYeriHI.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Repository.Shared.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet=context.Set<T>();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;

         //   _context.Set<T>().Add(entity);
        }

        public T Delete(T entity)
        {
            _dbSet.Remove(entity);
            return entity;
          
        }

        public T DeleteById(int id)
        {
           T entity= _dbSet.Find(id);
            entity.IsDeleted = true;
            entity.DateDeleted= DateTime.Now;
            _dbSet.Update(entity);
            return entity;
          
        }

        public IEnumerable<T> GetAll()
        {
         return  _dbSet.Where(x => !x.IsDeleted).ToList();
            // return _context.Set<T>().Where(x=>.....);
            //Farzedelim ki T bir  Vehicle
            // return _context.Vehicles.Where(x=>!x.isdeleted....);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter);
        }

      

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }



        public void Save()
        {
          _context.SaveChanges();
        }
    }
}
