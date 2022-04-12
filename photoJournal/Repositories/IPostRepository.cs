using photoJournal.Models;
using System.Collections.Generic;

namespace photoJournal.Repositories
{
    public interface IPostRepository
    {

        List<JournalPost> GetAllJournalPosts();

        //List<Post> GetAllPosts();
        //Post GetPostById(int id);
        //void UpdatePost(Post post);
        //void Add(Post post);
        //List<Post> GetAllPublishedPosts();
        //Post GetPublishedPostById(int id);
        //List<Post> GetUserPostById(int userProfileId);
        //void Delete(int postId);
        //Post GetPostIdWithComments(int id);

        //public void AddTagToPost(PostTag postTag);

    }
}
