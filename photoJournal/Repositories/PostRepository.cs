using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using photoJournal.Repositories;
using photoJournal.Models;
using photoJournal.Utils;

namespace photoJournal.Repositories
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        public PostRepository(IConfiguration configuration) : base(configuration) { }

        public List<JournalPost> GetAllJournalPosts()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                          SELECT jp.Id, jp.UserId, jp.Title, jp.Content, jp.ImageLocation, jp.CreateDateTime, u.FullName
                            FROM JournalPost jp
                            LEFT JOIN Users u on jp.UserId = u.Id
                        ORDER BY jp.CreateDateTime";

                    var reader = cmd.ExecuteReader();

                    var posts = new List<JournalPost>();
                    while (reader.Read())
                    {
                        posts.Add(new JournalPost()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            UserId = DbUtils.GetInt(reader,"UserId"),
                            Title = DbUtils.GetString(reader, "Title"),
                            Content = DbUtils.GetString(reader, "Content"),
                            ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                            CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                            User = new Users()
                            {
                            FullName = DbUtils.GetString(reader, "FullName")
                            }

                        });
                    }

                    reader.Close();

                    return posts;
                }
            }
        }

        //public Post GetById(int id)
        //{
        //    using (var conn = Connection)
        //    {
        //        conn.Open();
        //        using (var cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //                  SELECT Title, Caption, DateCreated, ImageUrl, UserProfileId
        //                    FROM Post
        //                   WHERE Id = @Id";

        //            DbUtils.AddParameter(cmd, "@Id", id);

        //            var reader = cmd.ExecuteReader();

        //            Post post = null;
        //            if (reader.Read())
        //            {
        //                post = new Post()
        //                {
        //                    Id = id,
        //                    Title = DbUtils.GetString(reader, "Title"),
        //                    Caption = DbUtils.GetString(reader, "Caption"),
        //                    DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
        //                    ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
        //                    UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
        //                };
        //            }

        //            reader.Close();

        //            return post;
        //        }
        //    }
        //}

        //public void Add(Post post)
        //{
        //    using (var conn = Connection)
        //    {
        //        conn.Open();
        //        using (var cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //                INSERT INTO Post (Title, Caption, DateCreated, ImageUrl, UserProfileId)
        //                OUTPUT INSERTED.ID
        //                VALUES (@Title, @Caption, @DateCreated, @ImageUrl, @UserProfileId)";

        //            DbUtils.AddParameter(cmd, "@Title", post.Title);
        //            DbUtils.AddParameter(cmd, "@Caption", post.Caption);
        //            DbUtils.AddParameter(cmd, "@DateCreated", post.DateCreated);
        //            DbUtils.AddParameter(cmd, "@ImageUrl", post.ImageUrl);
        //            DbUtils.AddParameter(cmd, "@UserProfileId", post.UserProfileId);

        //            post.Id = (int)cmd.ExecuteScalar();
        //        }
        //    }
        //}

        //public void Update(Post post)
        //{
        //    using (var conn = Connection)
        //    {
        //        conn.Open();
        //        using (var cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //                UPDATE Post
        //                   SET Title = @Title,
        //                       Caption = @Caption,
        //                       DateCreated = @DateCreated,
        //                       ImageUrl = @ImageUrl,
        //                       UserProfileId = @UserProfileId
        //                 WHERE Id = @Id";

        //            DbUtils.AddParameter(cmd, "@Title", post.Title);
        //            DbUtils.AddParameter(cmd, "@Caption", post.Caption);
        //            DbUtils.AddParameter(cmd, "@DateCreated", post.DateCreated);
        //            DbUtils.AddParameter(cmd, "@ImageUrl", post.ImageUrl);
        //            DbUtils.AddParameter(cmd, "@UserProfileId", post.UserProfileId);
        //            DbUtils.AddParameter(cmd, "@Id", post.Id);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public void Delete(int id)
        //{
        //    using (var conn = Connection)
        //    {
        //        conn.Open();
        //        using (var cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = "DELETE FROM Post WHERE Id = @Id";
        //            DbUtils.AddParameter(cmd, "@id", id);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}