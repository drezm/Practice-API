using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Contracts.Role;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public PracticeContext Context { get; }
        public RoleController(PracticeContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Role> roles = Context.Roles.ToList();
            return Ok(roles);
        }
        [HttpPost]
        public IActionResult Add(CreateRoleDto role)
        {
            Role newRole = new Role()
            {
      
                Name = role.Name

            }; 
            Context.Roles.Add(newRole);
            Context.SaveChanges();
            return Ok(role);
        }
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            Role? roles = Context.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            if (roles == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(roles);
        }
        [HttpPut]
        public IActionResult Update(UpdateRoleDto role)
        {
            Role newRole = new Role()
            {
               
                RoleId = role.RoleId,
                Name = role.Name,   

            };
            Context.Roles.Update(newRole);
            Context.SaveChanges();
            return Ok(newRole);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Role? role = Context.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            if (role == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Roles.Remove(role);
            Context.SaveChanges();
            return Ok();
        }
    }
}