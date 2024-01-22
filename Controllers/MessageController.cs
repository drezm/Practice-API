using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Contracts.Message;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public PracticeContext Context { get; }
        public MessageController(PracticeContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Message> messages = Context.Messages.ToList();
            return Ok(messages);
        }
        [HttpPost]
        public IActionResult Add(CreateMessageDto message)
        {
            Message newMessage = new Message()
            {

                ChatId = message.ChatId,
                Contents = message.Contents,    
                AddedBy = message.AddedBy,
                AddedTime = message.AddedTime,
                UserId = message.UserId

            };
            Context.Messages.Add(newMessage);
            Context.SaveChanges();
            return Ok(message);
        }
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            Message? messages = Context.Messages.Where(x => x.MessageId == id).FirstOrDefault();
            if (messages == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(messages);
        }
        [HttpPut]
        public IActionResult Update(UpgradeMessageDto message)
        {
            Message newMessage = new Message()
            {
                MessageId = message.MessageId,
                ChatId = message.ChatId,
                Contents = message.Contents,
                EditTime = message.EditTime,
                UserId = message.UserId,
                EditBy = message.EditBy
                

            };
            Context.Messages.Update(newMessage);
            Context.SaveChanges();
            return Ok(newMessage);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
             Message? message = Context.Messages.Where(x => x.MessageId == id).FirstOrDefault();
            if (message == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Messages.Remove(message);
            Context.SaveChanges();
            return Ok();
        }
    }
}
