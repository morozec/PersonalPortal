using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Factories;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DBRepository.Repositories
{
    public class BlogRepository : BaseRepository, IBlogRepository
    {
        public BlogRepository(string connectionString, IRepositoryContextFactory repositoryContextFactory) : base(connectionString, repositoryContextFactory)
        {
            
        }

        public async Task<Page<Post>> GetPosts(int index, int pageSize, string tag = null)
        {
            var result = new Page<Post>() {CurrentPage = index, PageSize = pageSize};
            using (var context = RepositoryContextFactory.CreateDbContext(ConnectionString))
            {
                var query = context.Posts.AsQueryable();
                if (!string.IsNullOrWhiteSpace(tag))
                {
                    query = query.Where(p => p.Tags.Any(t => t.TagName == tag));
                }

                result.TotalPages = await query.CountAsync();
                query = query
                    .Include(p => p.Tags)
                    .Include(p => p.Comments)
                    .OrderByDescending(p => p.CreatedDate)
                    .Skip(index * pageSize).Take(pageSize);

                result.Records = await query.ToListAsync();
            }

            return result;
        }

        public async Task<List<string>> GetAllTagNames()
        {
            using (var context = RepositoryContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Tags.Select(t => t.TagName).Distinct().ToListAsync();
            }
        }

        public async Task<Post> GetPost(int postId)
        {
            using (var context = RepositoryContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Posts.Include(p => p.Tags).Include(p => p.Comments).FirstOrDefaultAsync(p => p.PostId == postId);
            }
        }

        public async Task AddComment(Comment comment)
        {
            using (var context = RepositoryContextFactory.CreateDbContext(ConnectionString))
            {
                context.Comments.Add(comment);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddPost(Post post)
        {
            using (var context = RepositoryContextFactory.CreateDbContext(ConnectionString))
            {
                context.Posts.Add(post);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeletePost(int postId)
        {
            using (var context = RepositoryContextFactory.CreateDbContext(ConnectionString))
            {
                var post = new Post() { PostId = postId };
                context.Posts.Remove(post);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteComment(int commentId)
        {
            using (var context = RepositoryContextFactory.CreateDbContext(ConnectionString))
            {
                var coomment = new Comment() { CommentId = commentId };
                context.Comments.Remove(coomment);
                await context.SaveChangesAsync();
            }
        }
    }
}