using MediatR;
using StudyCase.Application.Entities;
using System;

namespace StudyCase.Domain.CQ
{
    public class SaveQueueMessageCommand:IRequest<QueueMessage>
    {
      
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        public SaveQueueMessageCommand(Guid id, string title, bool completed)
        {
            Id = id;
            Title = title;
            Completed = completed;
        }

    }
}
