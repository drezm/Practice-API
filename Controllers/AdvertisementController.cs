using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Contracts.AdStatus;
using Practice.Contracts.Advertisement;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        public PracticeContext Context { get; }
        public AdvertisementController(PracticeContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Advertisement> advertisements = Context.Advertisements.ToList();
            return Ok(advertisements);
        }
        [HttpPost]
        public IActionResult Add(CreateAdvertisementDto Advert)
        {
            Advertisement newAdvert = new Advertisement()
            {
                Title = Advert.Title,
                Discription = Advert.Discription,
                UserId = Advert.UserId, 
                CarId = Advert.CarId,   
                AdStatusId = Advert.AdStatusId,
                AddedBy = Advert.AddedBy,
                AddedTime = Advert.AddedTime
            };
            Context.Advertisements.Add(newAdvert);
            Context.SaveChanges();
            return Ok(newAdvert);
        }
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {

            Advertisement? advert = Context.Advertisements.Where(x => x.AdStatusId == id).FirstOrDefault();
            if (advert == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(advert);
        }
        [HttpPut]
        public IActionResult Update(UpdateAdvertisementDto Advert)
        {
            Advertisement newAdvert = new Advertisement()
            {
                AdId = Advert.AdId,
                Title = Advert.Title,
                Discription = Advert.Discription,
                UserId = Advert.UserId,
                CarId = Advert.CarId,
                AdStatusId = Advert.AdStatusId,
                EditBy = Advert.EditBy,
                EditTime = Advert.EditTime
            };
            Context.Advertisements.Update(newAdvert);
            Context.SaveChanges();
            return Ok(newAdvert);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Advertisement? ad = Context.Advertisements.Where(x => x.AdId == id).FirstOrDefault();
            if (ad == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Advertisements.Remove(ad);
            Context.SaveChanges();
            return Ok();
        }
    }
}
