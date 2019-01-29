using Framo.Core.Service;
using Framo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Framo.Model.Context;
using Framo.Core.Entity.Enum;
using System.Transactions;
using System.Data.Entity.Infrastructure;

namespace Framo.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private static FramoContext _context;

        public FramoContext Context
        {
            get
            {
                if (_context == null)
                    _context = new FramoContext();

                return _context;
            }
            set
            {
                _context = value;
            }
        }

        public bool Add(T item)
        {
            Context.Set<T>().Add(item);
            return Save() > 0;
        }

        public bool Add(List<T> item)
        {
            Context.Set<T>().AddRange(item);
            return Save() > 0;
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Any(exp);
        }

        public List<T> GetActive()
        {
            return Context.Set<T>().Where(x => x.Status != Status.Deleted).ToList();
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().FirstOrDefault(exp);
        }

        public T GetByID(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Where(exp).ToList();
        }

        public bool Remove(T item)
        {
            item.Status = Status.Deleted;
            return Update(item);
        }

        public bool Remove(Guid id)
        {
            T item = GetByID(id);
            item.Status = Status.Deleted;
            return Update(item);
        }

        public bool RemoveAll(Expression<Func<T, bool>> exp)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    List<T> items = GetDefault(exp);

                    int count = 0;
                    foreach (var item in items)
                    { 
                        item.Status = Status.Deleted;
                        Update(item);
                        count++;
                    }

                    if (count == items.Count)
                    {
                        ts.Complete();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public bool Update(T item)
        {
            T updated = GetByID(item.ID);
            DbEntityEntry entry = Context.Entry(updated);
            entry.CurrentValues.SetValues(item);
            return Save() > 0;
        }

        //Singleton pattern taraflı bir cache sorununu çözer
        public void DetachEntity(T item)
        {
            Context.Entry<T>(item).State = System.Data.Entity.EntityState.Detached;
        }
    }
}
