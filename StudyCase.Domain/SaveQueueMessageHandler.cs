using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StudyCase.Application.Entities;
using StudyCase.Domain.CQ;
using StudyCase.Repository;

namespace StudyCase.Domain
{
    public class SaveQueueMessageHandler : IRequestHandler<SaveQueueMessageCommand, QueueMessage>
    {
        private readonly IRepository<QueueMessage> _queueMessageRepository;

        public SaveQueueMessageHandler(IRepository<QueueMessage> queueMessageRepository)
        {
            _queueMessageRepository = queueMessageRepository;
        }

        public  Task<QueueMessage> Handle(SaveQueueMessageCommand request, CancellationToken cancellationToken)
        {
            var queueMessageEntity= _queueMessageRepository.Insert(new QueueMessage
            {
                Id=request.Id,
                Completed=request.Completed,
                Title=request.Title
            });
            return Task.FromResult(queueMessageEntity);
        }
       
    }
}
