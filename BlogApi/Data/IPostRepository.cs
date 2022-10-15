using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogApi.Data
{
    public interface IPostRepository
    {
        int AddPostAsync(PostModel postModel);
        List<PostModel> GetAllPost();
        PostModel GetPost(int? id);
        Task RemovePostAsync(int? id);
        Task UpdatePostAsync(PostModel postModel, int id);
    }
}