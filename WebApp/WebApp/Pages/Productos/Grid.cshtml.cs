using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Productos
{
    public class GridModel : PageModel
    {
        private readonly IProductoServices productoServices;

        public GridModel(IProductoServices productoServices)
        {
            this.productoServices = productoServices;
        }

        public IEnumerable<ProductoEntity> GridList { get; set; } = new List<ProductoEntity>();

        public string Mensaje { get; set; } = "";
        public async Task<ActionResult> OnGet()
        {
            try
            {
                GridList = await ProductoServices.Get();

                

                return Page();
            }
            catch (Exception ex)
            {

                return new JsonResult(value: new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }

        public async Task<ActionResult> OnDeleteEliminar(int id)
        {
            try
            {
                var result = await ProductoServices.Delete(entity: new() { IdProducto = id });



                return new JsonResult(value: result);
            }
            catch (Exception ex)
            {

                return new JsonResult(value: new DBEntity { CodeError= ex.HResult, MsgError = ex.Message});
            }

        }

    }
}
