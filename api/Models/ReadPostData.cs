using System.Collections.Generic;
using api.Models.Interfaces;
using System.Data.SQLite;

namespace api.Models
{
    public class ReadPostData : IGetAllPosts, IGetPost
    {
        public List<Post> GetAllPosts()
        {
            string cs = @"URI=file:C:\Users\natashaszulczewski\Desktop\UA\MIS321\repos\pa4-naszulczewski\api\posts.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM posts ORDER BY Date DESC"; //posts in table by descending date order 
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            List<Post> allPosts = new List<Post>();
            while(rdr.Read())
            {
                Post temp = new Post(){Id = rdr.GetInt32(0), Text = rdr.GetString(1), Date = rdr.GetString(2)};
                allPosts.Add(temp);
            }

            return allPosts;
        }

        public Post GetPost(int id)
        {
            string cs = @"URI=file:C:\Users\natashaszulczewski\Desktop\UA\MIS321\repos\pa4-naszulczewski\api\posts.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM posts WHERE id = @id";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Post(){Id = rdr.GetInt32(0), Text = rdr.GetString(1), Date = rdr.GetString(2)};
        }
    }
}