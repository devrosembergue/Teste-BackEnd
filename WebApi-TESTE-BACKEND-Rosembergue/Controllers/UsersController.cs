using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApiTESTEBACKENDRosembergue.Common;
using WebApiTESTEBACKENDRosembergue.Model;

namespace WebApi_TESTE_BACKEND_Rosembergue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepositorio<USERS> _repo;
        private readonly IRepositorio<MENUS_USERS> _repoMenus_Users;
        private IConfiguration _config;
        private readonly IUrlHelper _urlHelper;

        public UsersController(IRepositorio<USERS> repositorio, IRepositorio<MENUS_USERS> repositorioMenus_Users, IConfiguration Configuration, IUrlHelper urlHelper)
        {
            _repo = repositorio;
            _repoMenus_Users = repositorioMenus_Users;
            _config = Configuration;
            _urlHelper = urlHelper;
        }

        [HttpPost]
        public IActionResult Login([FromBody]USERS uSERS)
        {
            //bool resultado = ValidarUsuario(uSERS);
            //if (resultado)
            //{
            var tokenString = GerarTokenJWT();
            return Ok(new { token = tokenString });
            //}
            //else
            //{
            //    return Unauthorized();
            //}
        }

        private string GerarTokenJWT()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience,
                                             expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        private void GerarLinks(USERS uSERS)
        {
            uSERS.Links.Add(new HATEOAS(_urlHelper.Link(nameof(Get), new { id = uSERS.ID }), rel: "self", metodo: "GET"));

            uSERS.Links.Add(new HATEOAS(_urlHelper.Link(nameof(Put), new { id = uSERS.ID }), rel: "update-cliente", metodo: "PUT"));

            uSERS.Links.Add(new HATEOAS(_urlHelper.Link(nameof(Delete), new { id = uSERS.ID }), rel: "delete-cliente", metodo: "DELETE"));

        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<USERS>> Get()
        {
            var lista = _repo.Listar();
            return Ok(lista);
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        [Route("Home/Users")]
        [HttpGet("{id?}")]
        public ActionResult<USERS> Get(int id)
        {
            var model = _repo.Selecionar(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] USERS value)
        {
            if (ModelState.IsValid)
            {
                _repo.Incluir(value);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] USERS value)
        {
            if (ModelState.IsValid)
            {
                _repo.Alterar(id, value);
                return Ok(); //200
            }
            return BadRequest();
        }

        // DELETE api/values/5
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

            _repoMenus_Users.Excluir(modelMenus_Users.USER_ID);
            _repo.Excluir(model.ID);

            return NoContent();
        }
    }
}
