using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BD;

namespace WBL
{
    public interface IOrdenServices
    {
        Task<DBEntity> Create(OrdenEntity entity);
        Task<DBEntity> Delete(OrdenEntity entity);
        Task<IEnumerable<OrdenEntity>> Get();
        Task<OrdenEntity> GetById(OrdenEntity entity);
        Task<DBEntity> Update(OrdenEntity entity);
        Task<IEnumerable<OrdenEntity>> GetLista();
    }

    public class OrdenServices : IOrdenServices
    {
        private readonly IDataAccess sql;

        public OrdenServices(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region Metodos Crud

        //Metodo Get
        public async Task<IEnumerable<OrdenEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<OrdenEntity>(sp: "dbo.OrdenObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo GetById
        public async Task<OrdenEntity> GetById(OrdenEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<OrdenEntity>(sp: "dbo.OrdenObtener", Param: new { entity.IdOrden });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Create
        public async Task<DBEntity> Create(OrdenEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "dbo.OrdenInsertar", Param: new { entity.CantidadProducto, entity.Estado });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo Actualizar
        public async Task<DBEntity> Update(OrdenEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "dbo.OrdenActualizar", Param: new { entity.IdOrden, entity.CantidadProducto, entity.Estado });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Eliminar
        public async Task<DBEntity> Delete(OrdenEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "dbo.OrdenEliminar", Param: new { entity.IdOrden });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Lista
        public async Task<IEnumerable<OrdenEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<OrdenEntity>(sp: "dbo.OrdenLista");

                return await result;
            }
            catch (Exception ex) 
            {

                throw;
            }

        }


        #endregion

    }
}
