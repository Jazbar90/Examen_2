using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductoEntity
    {
        public int? IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioProducto { get; set; }

        public static Task<IEnumerable<ProductoEntity>> Get()
        {
            throw new NotImplementedException();
        }

        public static Task Delete(object entity)
        {
            throw new NotImplementedException();
        }
    }
}
