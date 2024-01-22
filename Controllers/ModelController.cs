using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Contracts.Model;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        public PracticeContext Context { get; }
        public ModelController(PracticeContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Model> model = Context.Models.ToList();
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            Model? model = Context.Models.Where(x => x.ModelId == id).FirstOrDefault();
            if (model == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(model);
        }
        [HttpPost]
        public IActionResult Add(CreateModalDto modal)
        {
            Model newModal = new Model()
            {
                Brand = modal.Brand,
                Model1 = modal.Model1

            };
            Context.Models.Add(newModal);
            Context.SaveChanges();
            return Ok(modal);
        }
        [HttpPut]
        public IActionResult Update(UpdateModalDto model)
        {
            Model newModel = new Model()
            {
                ModelId = model.ModelId,
                Model1= model.Model1,   
                Brand = model.Brand

            };
            Context.Models.Update(newModel);
            Context.SaveChanges();
            return Ok(newModel);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Model? model = Context.Models.Where(x => x.ModelId == id).FirstOrDefault();
            if (model == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Models.Remove(model);
            Context.SaveChanges();
            return Ok();
        }
    }
}
