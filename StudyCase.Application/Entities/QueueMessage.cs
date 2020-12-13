using System;

namespace StudyCase.Application.Entities
{
    public class QueueMessage
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
