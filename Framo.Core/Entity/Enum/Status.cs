using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framo.Core.Entity.Enum
{
    //Kayıdın durumunu status adındaki bu enum içerisinde tutuyoruz. Enum değeri aşağıdakilerden biriyse bu ifadelerin karşılığı olarak saklanacaktır.
    public enum Status
    {
        None = 0,
        Active = 1,
        Deleted = 3,
        Updated = 5
    }
}
