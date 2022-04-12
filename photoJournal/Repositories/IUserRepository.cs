using photoJournal.Models;
using System.Collections.Generic;

namespace photoJournal.Repositories
{
    public interface IUserRepository
    {

        Users GetByEmail(string email);
        void Add(Users userProfile);

    }
}
