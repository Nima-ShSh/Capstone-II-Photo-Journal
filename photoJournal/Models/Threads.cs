using System;

namespace photoJournal.Repositories
{
    public class Threads
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int JournalId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDateTime { get; set; }
        public Users user { get; set; }
    }
}