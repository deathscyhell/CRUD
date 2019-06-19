
namespace BDTienda.Service
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using BDTienda.Models;
    using SQLite;

    public class Service<T> : IService<T> where T: class, new()
    {
        #region Atributos
        SQLiteAsyncConnection _conexion;
        #endregion

        #region Constructor
        public Service()
        {
            Conexion();
        }
        #endregion

        #region metodos

        public void Conexion()
        {
            string FilePath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.Personal), "db_Tienda.db3");

            _conexion = new SQLiteAsyncConnection(FilePath);
            _conexion.CreateTableAsync<Usuarios>().Wait();

        }


        #endregion


        #region CRUD

        public Task<int> Delete(T obj)
        {
            return _conexion.DeleteAsync(obj);
        }

        public Task<List<T>> GetAll()
        {
            return _conexion.Table<T>().ToListAsync();
        }

        public Task<int> Insert(T obj)
        {
            return _conexion.InsertAsync(obj);
        }

        public Task<int> Update(T obj)
        {
            return _conexion.UpdateAsync(obj);
        }
        #endregion
    }
}
