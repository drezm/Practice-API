using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Contracts.Car;
using Practice.Models;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
            public PracticeContext Context { get; }
            public CarController(PracticeContext context)
            {
                Context = context;
            }
        [HttpGet]
            public IActionResult GetAll()
            {
                List<Car> cars = Context.Cars.ToList();
                return Ok(cars);
            }
            [HttpGet("{id}")]
            public IActionResult GetByld(int id)
            {
                Car? car = Context.Cars.Where(x => x.CarId == id).FirstOrDefault();
                if (car == null)
                {
                    return BadRequest("Данные не найдены");
                }
                return Ok(car);
            }
    
            
            [HttpPost]
            public async Task<IActionResult> Add(CreateCarDto cars)
            {
                var Car = cars.Adapt<Car>();
                Context.Cars.Add(Car);
                Context.SaveChanges();
                return Ok();
            }
        [HttpPut]
        public IActionResult Update(UpdateCarDto car)
        {
            Car newCar = new Car()
            {
                CarId = car.CarId,
                ModelId = car.ModelId,
                CarStatusId = car.CarStatusId,
                UserId = car.UserId,
                ManufacturingYear = car.ManufacturingYear,
                Mileage = car.Mileage,
                Price = car.Price,
                Image = car.Image,
                Description = car.Description,
                Color = car.Color,
            };
            Context.Cars.Update(newCar);
            Context.SaveChanges();
            return Ok(newCar);

        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Car? car = Context.Cars.Where(x => x.CarId == id).FirstOrDefault();
            if (car == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Cars.Remove(car);
            Context.SaveChanges();
            return Ok();
        }

    }
}
