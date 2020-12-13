using System;

namespace StudyCase.DTO
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}