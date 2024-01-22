using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Contracts.User;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public PracticeContext Context { get; }
        public UsersController(PracticeContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = Context.Users.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            User? user = Context.Users.Where(x =>x.UserId==id).FirstOrDefault();    
            if(user==null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(user);        
        }
  
    
        [HttpPost]
        public IActionResult Add(CreateUserRequest user)
        {
            User newUser = new User()
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                Location = user.Location,
                RoleId = user.RoleId,

            };
            Context.Users.Add(newUser);
            Context.SaveChanges();
            return Ok(user);
        }
        [HttpPut]
        public IActionResult Update(UserUpdateDto user)
        {
            User newUser = new User()
            {
                UserId = user.UserID,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                Location = user.Location,
                RoleId = user.RoleId,

            };
            Context.Users.Update(newUser);
            Context.SaveChanges();
            return Ok(newUser);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            User? user = Context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Данные не найдены");
            }
            
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok();
        }
    }
}
