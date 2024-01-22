using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice.Contracts.Owner;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        public PracticeContext Context { get; }
        public OwnerController(PracticeContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll(GetOwnerDto owner)
        {
            List<Owner> owners = Context.Owners.ToList();
            return Ok(owners);
        }
        [HttpPost]
        public IActionResult Add(CreateOwnerDto owner)
        {
            Owner newOwner = new Owner()
            {

                UserId = owner.UserId,
                CarId = owner.CarId,
                TenurePeriodFrom = owner.TenurePeriodFrom,
                TenurePeriodTo = owner.TenurePeriodTo
            };
            Context.Owners.Add(newOwner);
            Context.SaveChanges();
            return Ok(owner);
        }
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {

            Owner? owners = Context.Owners.Where(x => x.OwnnerId == id).FirstOrDefault();
            if (owners == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(owners);
        }
        [HttpPut]
        public IActionResult Update(UpdateOwnerDto owner)
        {
            Owner newOwner = new Owner()
            {

                OwnnerId = owner.UserId,
                UserId = owner.UserId,
                TenurePeriodFrom = owner.TenurePeriodFrom,
                TenurePeriodTo = owner.TenurePeriodTo,
                CarId = owner.CarId
           

        };
            Context.Owners.Update(newOwner);
            Context.SaveChanges();
            return Ok(newOwner);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Owner? owner = Context.Owners.Where(x => x.OwnnerId == id).FirstOrDefault();
            if (owner == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Owners.Remove(owner);
            Context.SaveChanges();
            return Ok();
        }
    }
}
