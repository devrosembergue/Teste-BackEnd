using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiTESTEBACKENDRosembergue.Common;
using WebApiTESTEBACKENDRosembergue.Model;

namespace WebApiTESTEBACKENDRosembergue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IRepositorio<MENUS> _repo;
        private readonly IRepositorio<MENUS_USERS> _repoMenus_Users;

        public MenuController(IRepositorio<MENUS> repositorio, IRepositorio<MENUS_USERS> repositorioMenus_Users)
        {
            _repo = repositorio;
            _repoMenus_Users = repositorioMenus_Users;
        }

        // GET: api/Menu
        [HttpGet]
        public ActionResult<IEnumerable<MENUS>> Get()
        {
            var lista = _repo.Listar();
            return Ok(lista);
        }

        // GET: api/Menu/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<USERS> Get(int id)
        {
            var model = _repo.Selecionar(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        // POST: api/Menu
        [HttpPost]
        public void Post([FromBody] MENUS value)
        {
            if (ModelState.IsValid)
            {
                _repo.Incluir(value);
            }
        }

        // PUT: api/Menu/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MENUS value)
        {
            if (ModelState.IsValid)
            {
                _repo.Alterar(id, value);
                return Ok(); //200
            }
            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var modelMenus_Users = _repoMenus_Users.Selecionar(id);
            var model = _repo.Selecionar(id);

            if (modelMenus_Users == null)
            {
                return NotFound();
            }

            if (model == null)
            {
                return NotFound();
            }

            _repoMenus_Users.Excluir(modelMenus_Users.MENU_ID);
            _repo.Excluir(model.ID);

            return NoContent();
        }
    }
}
