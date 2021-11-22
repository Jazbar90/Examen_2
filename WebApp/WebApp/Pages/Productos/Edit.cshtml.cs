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
    public class EditModel : PageModel
    {
        private readonly IProductoServices productoServices;
        private readonly IOrdenServices ordenServices;

        public EditModel(IProductoServices productoServices, IOrdenServices ordenServices)
        {
            this.productoServices = productoServices;
            this.ordenServices = ordenServices;
        }

        [BindProperty]
        [FromBody]
        public ProductoEntity Entity { get; set; } = new ProductoEntity();
        public IEnumerable<ProductoEntity> ProductoLista { get; set; } = new List<ProductoEntity>();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await ProductoServices.GetById(entity: new() { IdProducto = id });
                }
                ProductoLista = await ProductoServices.GetLista();
                return Page();
            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }


        }

        public async Task<IActionResult> OnPosAsync()
        {
            try
            {
                //Metodo Actualizar
                var result = new DBEntity();
                if (Entity.IdProducto.HasValue)
                {
                    result = await ProductoServices.Update(entity: Entity);

                   
                }
                else
                {

                    result = await ProductoServices.Create(entity: Entity);
                }

                return new JsonResult(value: result);
            }
            catch (Exception ex)
            {

                return new JsonResult(value: new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }



    }
}
