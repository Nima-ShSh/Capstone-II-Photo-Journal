using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using photoJournal.Utils;
using System.Collections.Generic;
using photoJournal.Models;
using photoJournal.Utils;

namespace photoJournal.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public Users GetByEmail(string email)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, FullName, Email, ProfileImage, IsAdmin
                          FROM Users
                         WHERE Email = @email";

                    DbUtils.AddParameter(cmd, "@email", email);

                    Users user = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = NewUserFromReader(reader);
                    }
                    reader.Close();

                    return user;
                }
            }
        }



        public void Add(Users userProfile)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Users (FullName, Email, 
                                                                 ProfileImage, IsAdmin)
                                        OUTPUT INSERTED.ID
                                        VALUES (@FullName, @Email, @ProfileImage, @IsAdmin)";
                    DbUtils.AddParameter(cmd, "@FullName", userProfile.FullName);
                    DbUtils.AddParameter(cmd, "@Email", userProfile.Email);
                    DbUtils.AddParameter(cmd, "@ProfileImage", userProfile.ProfileImage);
                    DbUtils.AddParameter(cmd, "@IsAdmin", 0);

                    userProfile.Id = (int)cmd.ExecuteScalar();
                }
            }
        }


        private Users NewUserFromReader(SqlDataReader reader)
        {
            return new Users()
            {

                Id = DbUtils.GetInt(reader, "Id"),
                FullName = DbUtils.GetString(reader, "FullName"),
                Email = DbUtils.GetString(reader, "Email"),
                ProfileImage = DbUtils.GetString(reader, "ProfileImage"),
                IsAdmin = reader.GetBoolean(reader.GetOrdinal("IsAdmin"))

            };
        }


    }

}

