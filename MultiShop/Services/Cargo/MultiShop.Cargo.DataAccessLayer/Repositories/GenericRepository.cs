using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _context;

        public GenericRepository(CargoContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            try
            {
                var values = _context.Set<T>().Find(id);
                if (values != null)
                {
                    _context.Set<T>().Remove(values);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred", ex);
            }

        }

        public List<T> GetAll()
        {
            try
            {
                var values = _context.Set<T>().ToList();
                return values;
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred", ex);
            }
        }

        public T GetByID(int id)
        {
            try
            {
                var value = _context.Set<T>().Find(id);
                return value; // Will return null if value is not found
            }
            catch (Exception ex)
            {
                // Log exception (if logging is implemented)
                // logger.LogError(ex, "Error fetching entity by ID");
                throw new Exception($"An error occurred while fetching the entity with ID {id}.", ex);
            }
        }

        public void Insert(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred", ex);
            }
        }

        public void Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred", ex);
            }
        }
    }
}
