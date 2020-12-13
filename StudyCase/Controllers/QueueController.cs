using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudyCase.Contract.RequestModel;
using StudyCase.Domain.CQ;
using System.Threading.Tasks;
using StudyCase.Application.Entities;

namespace StudyCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QueueController(IMediator mediator)
        {
            _mediator = mediator;
        }

     
        [HttpPost]

        public IActionResult GetDataFromQueue(QueueMessageModel queueMessage)
        {
           
           _mediator.Send(new SaveQueueMessageCommand(queueMessage.Id,queueMessage.Title,queueMessage.Completed));
            return Ok();
        }
    }
}