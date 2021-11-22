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
    public class GridModel : PageModel
    {
        private readonly IOrdenServices ordenServices;

        public GridModel(IOrdenServices ordenServices)
        {
            this.ordenServices = ordenServices;
        }

        public IEnumerable<OrdenEntity> GridList { get; set; } = new List<OrdenEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await OrdenServices.Get();

               

                return Page();
            }
            catch (Exception ex)
            {

                return new JsonResult(value: new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }


        public async Task<IActionResult> OnDeleteElimianr(int id)
        {
            try
            {
                var result = await OrdenServices.Delete(entity: new() { IdOrden= id});





                return new JsonResult(value: result);
            }
            catch (Exception ex)
            {

                return new JsonResult(value: new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }



    }
}
