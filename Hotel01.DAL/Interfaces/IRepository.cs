using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel01.DAL.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория.
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    /// <typeparam name="T2">Тип идентификатора ID или GUID</typeparam>
    public interface IRepository<T,T2> where T : class
    {
        /// <summary>
        /// Метод получения всх сущностей.
        /// </summary>
        /// <returns>Возвращает все сущности из контекста</returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Метод получения сущности по ID.
        /// </summary>
        /// <param name="ID">ID сущности.</param>
        /// <returns>Возвращает Сущность по ID.</returns>
        T Get(T2 ID);
        /// <summary>
        /// Метод получения сущности по предикату.
        /// </summary>
        /// <param name="predicate">предикат для поиска.</param>
        /// <returns></returns>
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        /// <summary>
        /// Добавляет сущность в БД.
        /// </summary>
        /// <param name="item">Объект сущности.</param>
        void Create(T item);
        /// <summary>
        /// Изменяет сущность в БД.
        /// </summary>
        /// <param name="Item">>Объект сущности.</param>
        void Update(T Item);
        /// <summary>
        /// Удаляет сущность из БД
        /// </summary>
        /// <param name="ID">ID сущности.</param>
        void Delete(T2 ID);
    }
}
