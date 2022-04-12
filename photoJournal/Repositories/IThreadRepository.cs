using photoJournal.Models;
using System.Collections.Generic;

namespace photoJournal.Repositories
{
    public interface IThreadRepository
    {
        List<Threads> GetAllThreads();
    }
}
