using Microsoft.AspNetCore.Mvc;
using WebApiTESTEBACKENDRosembergue.Common;
using WebApiTESTEBACKENDRosembergue.Model;

namespace WebApiTESTEBACKENDRosembergue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Menus_UsersController : ControllerBase
    {
        private readonly IRepositorio<MENUS_USERS> _repo;

        public Menus_UsersController(IRepositorio<MENUS_USERS> repositorio)
        {
            _repo = repositorio;
        }

        // POST: api/Menus_Users
        [HttpPost]
        public void Post([FromBody] MENUS_USERS value)
        {
            if (ModelState.IsValid)
            {
                _repo.Incluir(value);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var model = _repo.Selecionar(id);
            if (model == null)
            {
                return NotFound();
            }
            _repo.Excluir(model.MENU_ID);
            return NoContent();
        }
    }
}
