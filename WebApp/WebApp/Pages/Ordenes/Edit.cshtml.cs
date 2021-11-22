using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Ordenes
{
    public class EditModel : PageModel
    {
        private readonly IOrdenServices ordenServices;
        private readonly IProductoServices productoServices;

        public EditModel(IOrdenServices ordenServices, IProductoServices productoServices)
        {
            this.ordenServices = ordenServices;
            this.productoServices = productoServices;
        }

        [BindProperty]
        [FromBody]
        public OrdenEntity Entity { get; set; } = new OrdenEntity();

        public IEnumerable<OrdenEntity> OrdenLista { get; set; } = new List<OrdenEntity>();

        [BindProperty(SupportsGet = true)]

        public int? id { get; set; }

        public async Task<IActionResult> OnGet() {
            try
            {
                if (id.HasValue) {
                    Entity = await OrdenServices.GetById(entity: new() { IdOrden = id });
                }
                OrdenLista = await OrdenServices.GetLista();
                return Page();
            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }
            
        
        }

        public async Task<IActionResult> OnPosAsync() {
            try
            {
                //Metodo Actualizar
                var result = new DBEntity();
                if (Entity.IdOrden.HasValue)
                {
                    result = await OrdenServices.Update(entity: Entity);

                    
                }
                else {

                    result = await OrdenServices.Create(entity: Entity);
                }

                return new JsonResult(value: result);

            }
            catch (Exception ex)

            {

                return new JsonResult(value: new DBEntity { CodeError= ex.HResult, MsgError = ex.Message});
            }
        
        }



    }
}
