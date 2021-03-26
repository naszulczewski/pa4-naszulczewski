using api.Models.Interfaces;
using System.Data.SQLite;

namespace api.Models
{
    public class SavePost : IInsertPost
    {
        public void InsertPost(Post value)
        {
            string cs = @"URI=file:C:\Users\natashaszulczewski\Desktop\UA\MIS321\repos\pa4-naszulczewski\pa4-natashaszulczewski\api\posts.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO posts(text, date) VALUES(@text, @date)";
            cmd.Parameters.AddWithValue("@text", value.Text);
            cmd.Parameters.AddWithValue("@date", value.Date);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}