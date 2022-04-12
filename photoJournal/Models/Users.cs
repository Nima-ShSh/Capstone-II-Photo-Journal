namespace photoJournal.Repositories
{
    public class Users
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public bool IsAdmin { get; set; }
    }
}