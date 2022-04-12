using photoJournal.Repositories;
using System;

namespace photoJournal.Models
{
    public class JournalPost
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageLocation { get; set; }
        public DateTime CreateDateTime { get; set; }

        public Users User { get; set; }
    }
}
