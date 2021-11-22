using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IProductoServices
    {
        Task<DBEntity> Create(ProductoEntity entity);
        Task<DBEntity> Delete(ProductoEntity entity);
        Task<IEnumerable<ProductoEntity>> Get();
        Task<ProductoEntity> GetById(ProductoEntity entity);
        Task<DBEntity> Update(ProductoEntity entity);
        Task<IEnumerable<OrdenEntity>> GetLista();
    }

    public class ProductoServices : IProductoServices
    {
        private readonly IDataAccess sql;

        public ProductoServices(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCrud

        //Metodo Get
        public async Task<IEnumerable<ProductoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ProductoEntity>(sp: "dbo.ProductoObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo GetById

        public async Task<ProductoEntity> GetById(ProductoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ProductoEntity>(sp: "dbo.ProductoObtener", Param: new { entity.IdProducto });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Create

        public async Task<DBEntity> Create(ProductoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "dbo.ProductoInsertar", Param: new { entity.NombreProducto, entity.PrecioProducto });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Actualizar
        public async Task<DBEntity> Update(ProductoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "dbo.ProductoActualizar", Param: new { entity.IdProducto, entity.NombreProducto, entity.PrecioProducto });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Eliminar
        public async Task<DBEntity> Delete(ProductoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "dbo.ProductoEliminar", Param: new { entity.IdProducto });

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
