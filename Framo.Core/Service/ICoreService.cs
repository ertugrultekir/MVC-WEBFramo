using Framo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Framo.Core.Service
{
    public interface ICoreService<T> where T : CoreEntity
    {
        //Tüm sınıflarımız içerisinde kullanılacak olan metotlarımız bir interface içerisinde generic type yöntemiyle tanımlandı.
        bool Add(T item);
        bool Add(List<T> item);
        bool Update(T item);
        bool Remove(T item);
        bool Remove(Guid id);
        bool RemoveAll(Expression<Func<T, bool>> exp); //Metoda parametre olarak lambda gönderebilmek için
        T GetByID(Guid id);
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetActive();
        List<T> GetAll();
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        int Save();
    }
}
