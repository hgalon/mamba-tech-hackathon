using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Service.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace HackathonTotvs.Service
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        protected readonly TotvsContext _context;
        protected readonly IDbConnection _conexao;

        public GenericRepository(TotvsContext context, IDbConnection conexao)
        {
            _context = context;
            _conexao = conexao;
        }

        public virtual async Task<T> Insert(T obj)
        {
            try
            {
                _context.Add(obj);
                await _context.SaveChangesAsync();

                return obj;

            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public virtual async Task Delete(int id)
        {

            try
            {
                var _obj = _context.Find<T>(id);
                _context.Remove(_obj);
                await _context.SaveChangesAsync();

            }
            catch (System.Exception)
            {

                throw;
            }

        }


        public virtual async Task<T> Select(int id)
        {
            try
            {
                var obj = await _context.FindAsync<T>(id);
                _context.Entry(obj).State = EntityState.Detached;
                return obj;

            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public virtual async Task<List<T>> SelectAll()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public virtual async Task Update(T obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }

}
