using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framo.Core.Entity
{
    public interface IEntity<T>
    {
        //Dışarıdan gönderilen tipte bir ID property'si oluşturuyoruz. Interface içerisindeki metotlar sınıfa implament edilmek zorunda olduğundan dolayı ID propertysini bir interface içerisinde tanımlayarak her sınıfın bir ID'si olmasını zorunlu koşuyoruz. Teknik olarak property yapısıda bir metot olduğundan bir sınıf oluşturulduğunda bu metot ID almayı zorlayacaktır.
        T ID { get; set; }
    }
}
