using System;

namespace photoJournal.Repositories
{
    public class Comments
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
