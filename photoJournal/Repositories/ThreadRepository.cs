using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using photoJournal.Repositories;
using photoJournal.Models;
using photoJournal.Utils;


namespace photoJournal.Repositories
{
    public class ThreadRepository : BaseRepository, IThreadRepository
    {
        public ThreadRepository(IConfiguration configuration) : base(configuration) { }

        public List<Threads> GetAllThreads()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                          SELECT t.Id, t.UserId, t.JournalId, t.Title, t.Content, t.CreateDateTime, u.FullName
                            FROM Threads t
                            LEFT JOIN Users u on t.UserId = u.Id
                        ORDER BY t.CreateDateTime";

                    var reader = cmd.ExecuteReader();

                    var threads = new List<Threads>();
                    while (reader.Read())
                    {
                        threads.Add(new Threads()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            UserId = DbUtils.GetInt(reader, "UserId"),
                            JournalId = DbUtils.GetInt(reader, "JournalId"),
                            Title = DbUtils.GetString(reader, "Title"),
                            Content = DbUtils.GetString(reader, "Content"),
                            CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                            user = new Users()
                            {
                                FullName = DbUtils.GetString(reader, "FullName")
                            }

                        });
                    }

                    reader.Close();

                    return threads;
                }
            }
        }

    }
}
