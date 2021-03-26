using api.Models.Interfaces;
using System.Data.SQLite;

namespace api.Models
{
    public class EditPost : IEditPost
    {
        public void EditAPost(Post value)
        {
            string cs = @"URI=file:C:\Users\natashaszulczewski\Desktop\UA\MIS321\repos\pa4-naszulczewski\pa4-natashaszulczewski\api\posts.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"UPDATE text FROM posts WHERE id = " + value;
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}