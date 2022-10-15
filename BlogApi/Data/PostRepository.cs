using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Data
{

    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        //Get all the post Without no Filter
        public List<PostModel> GetAllPost()
        {
           var post = _dbContext.Posts.ToList();
           return _mapper.Map<List<PostModel>>(post);
        }


        public PostModel GetPost(int? id)
        {

            var post = _dbContext.Posts.FirstOrDefault(c => c.Id == id);
            return _mapper.Map<PostModel>(post);

        }


        public int AddPostAsync(PostModel postModel)
        {
            var post = new Post()
            {
                Title = postModel.Title,
                Author = postModel.Author,
                Body = postModel.Body,
                Description = postModel.Description,
                DateCreated = postModel.DateCreated

            };
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
            var a = 1 + 1;
            return post.Id;
        }



        public async Task UpdatePostAsync(PostModel postModel, int id)
        {
            //var post = await _dbContext.Posts.FindAsync(id);
            //if (post != null)
            //{
            //    if (postModel.Title != null)
            //    {
            //        post.Title = postModel.Title;
            //    }
            //    else if (postModel.Body != null)
            //    {
            //        post.Body = postModel.Body;
            //    }
            //    else if (postModel.Author != null)
            //    {
            //        post.Author = postModel.Author;
            //    }
            //    else if (postModel.Description != null)
            //    {
            //        post.Description = postModel.Description;
            //    }

            //    await _dbContext.SaveChangesAsync();

            //}


            var post = new PostModel()
            {
                Id = postModel.Id,
                Title = postModel.Title,
                Description = postModel.Description
            };

            //return (post.Id);
        }


        public async Task RemovePostAsync(int? id)
        {
            var post = await _dbContext.Posts.FindAsync(id);
            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();
        }
    }
}

