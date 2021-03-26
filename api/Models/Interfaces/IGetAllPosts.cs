using System.Collections.Generic;

namespace api.Models.Interfaces
{
    public interface IGetAllPosts
    {
        public List<Post> GetAllPosts();
    }
}