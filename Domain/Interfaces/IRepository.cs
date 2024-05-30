using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T>// : IDisposable
        where T : EntityBase
    {
        IEnumerable<T> GetAll(); // получение всех объектов
        Task<T> GetAsync(uint id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void UpdateAsync(T item); // обновление объекта
        void Delete(uint id); // удаление объекта по id
    }
}
