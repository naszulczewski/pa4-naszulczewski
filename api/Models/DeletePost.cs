using api.Models.Interfaces;
using System.Data.SQLite;

namespace api.Models
{
    public class DeletePost : IDeletePost
    {
        public void DeleteAPost(int id)
        {
            string cs = @"URI=file:C:\Users\natashaszulczewski\Desktop\UA\MIS321\repos\pa4-naszulczewski\pa4-natashaszulczewski\api\posts.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"DELETE FROM posts WHERE id = " + id;
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}