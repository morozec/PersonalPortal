using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DBRepository.Repositories
{
    public interface IBlogRepository
    {
        Task<Page<Post>> GetPosts(int index, int pageSize, string tag = null);
        Task<Post> GetPost(int postId);
        Task AddComment(Comment comment);
        Task<List<string>> GetAllTagNames();
        Task AddPost(Post post);
        Task DeletePost(int postId);
        Task DeleteComment(int commentId);
    }
}