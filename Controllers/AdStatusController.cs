using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Contracts.AdStatus;
using Practice.Contracts.Owner;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdStatusController : ControllerBase
    {

        public PracticeContext Context { get; }
        public AdStatusController(PracticeContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<AdStatus> status = Context.AdStatuses.ToList();
            return Ok(status);
        }
        [HttpPost]
        public IActionResult Add(CreateAdStatusDto AdStatus)
        {
            AdStatus newStatus = new AdStatus()
            {
                StatusName = AdStatus.StatusName
            };
            Context.AdStatuses.Add(newStatus);
            Context.SaveChanges();
            return Ok(AdStatus);
        }
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {

            AdStatus? status = Context.AdStatuses.Where(x => x.AdStatusId == id).FirstOrDefault();
            if (status == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(status);
        }
        [HttpPut]
        public IActionResult Update(UpdateAdStatusDto AdStatus)
        {
           AdStatus newStatus = new AdStatus()
            {
               AdStatusId = AdStatus.AdStatusId,
               StatusName = AdStatus.StatusName
            };
            Context.AdStatuses.Update(newStatus);
            Context.SaveChanges();
            return Ok(newStatus);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            AdStatus? status = Context.AdStatuses.Where(x => x.AdStatusId == id).FirstOrDefault();
            if (status == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.AdStatuses.Remove(status);
            Context.SaveChanges();
            return Ok();
        }
    }
}

