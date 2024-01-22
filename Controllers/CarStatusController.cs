using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Contracts.CarStatus;
using Practice.Contracts.Owner;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarStatusController : ControllerBase
    {
        public PracticeContext Context { get; }
        public CarStatusController(PracticeContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<CarStatus> status = Context.CarStatuses.ToList();
            return Ok(status);


        }
        [HttpPost]
        public IActionResult Add(CreateCarStatusDto CarStatus)
        {
            CarStatus newStatus = new CarStatus()
            {
                StatusName = CarStatus.StatusName
            };
            Context.CarStatuses.Add(newStatus);
            Context.SaveChanges();
            return Ok(CarStatus);
        }
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {

            CarStatus? status = Context.CarStatuses.Where(x => x.CarStatusId == id).FirstOrDefault();
            if (status == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(status);
        }
        [HttpPut]
        public IActionResult Update(UpdateCarStatusDto status)
        {
            CarStatus newStatus = new CarStatus()
            {
                CarStatusId = status.CarStatusId,   
                StatusName = status.StatusName
            };
            Context.CarStatuses.Update(newStatus);
            Context.SaveChanges();
            return Ok(newStatus);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            CarStatus? status = Context.CarStatuses.Where(x => x.CarStatusId == id).FirstOrDefault();
            if (status == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.CarStatuses.Remove(status);
            Context.SaveChanges();
            return Ok();
        }

    }
}
