namespace api.Models
{
    public class Post
    {
        public int Id{get; set;}
        public string Text{get; set;}
        public string Date{get; set;}

        public override string ToString()
        {
            return Text;
        }
    }
}