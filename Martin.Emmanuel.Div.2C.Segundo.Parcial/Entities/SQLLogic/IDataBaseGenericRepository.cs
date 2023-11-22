namespace Entities.SQLLogic
{
    /// <summary>
    /// CLASE ABSTRACTA DE LA CUAL HEREDAN TODOS LOS REPOSITORIOS DE LA BASE DE DATOS
    /// EN ESTA CLASE SE DEFINEN LOS METODOS GENERICOS QUE SE USARAN EN TODOS LOS REPOSITORIOS
    /// TEMA DE PARCIAL: INTERFACES, TIPO GENERICO Y METODOS ASINCRONOS (ASYNC Y AWAIT) MUTI-HILO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataBaseGenericRepository<T>
    {
        Task<List<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<T> GetById(int id);
    }
}
