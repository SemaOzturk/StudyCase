using System;

namespace StudyCase.Contract.RequestModel
{
    public class QueueMessageModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
